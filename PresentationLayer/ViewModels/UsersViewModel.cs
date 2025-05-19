using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using DataLayer;

namespace PresentationLayer.ViewModels
{
    public class UsersViewModel : INotifyPropertyChanged
    {
        private readonly IEvents _events;
        private ObservableCollection<UserModel> _users;
        private int _selectedUserId;
        private string _selectedUserType;
        private int _newUserId;
        private string _newUserType;

        public UsersViewModel(IEvents events)
        {
            _events = events;
            Users = new ObservableCollection<UserModel>();
            AddUserCommand = new RelayCommand(AddUser, CanAddUser);
            RefreshUsers();
        }

        public ObservableCollection<UserModel> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        public int NewUserId
        {
            get => _newUserId;
            set
            {
                _newUserId = value;
                OnPropertyChanged(nameof(NewUserId));
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public string NewUserType
        {
            get => _newUserType;
            set
            {
                _newUserType = value;
                OnPropertyChanged(nameof(NewUserType));
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public ICommand AddUserCommand { get; }

        private void AddUser()
        {
            _events.Add2Users(NewUserId, NewUserType);
            RefreshUsers();
            NewUserId = 0;
            NewUserType = string.Empty;
        }

        private bool CanAddUser()
        {
            return NewUserId > 0 && !string.IsNullOrWhiteSpace(NewUserType);
        }

        private void RefreshUsers()
        {
            Users.Clear();
            // Get users from Events_class
            var users = _events.GetAllUsers();
            foreach (var user in users)
            {
                Users.Add(new UserModel { id = (int)user.Key, type = user.Value });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
} 