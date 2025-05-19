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
        private UserModel _selectedUser;
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

        public UserModel SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
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
            // Generate new ID based on existing users
            int newId = Users.Count > 0 ? Users.Max(u => u.id) + 1 : 1;
            _events.Add2Users(newId, NewUserType);
            RefreshUsers();
            NewUserType = string.Empty;
        }

        private bool CanAddUser()
        {
            return !string.IsNullOrWhiteSpace(NewUserType);
        }

        private void RefreshUsers()
        {
            Users.Clear();
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