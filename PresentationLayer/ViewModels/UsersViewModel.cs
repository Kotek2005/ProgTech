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
            // This is a placeholder - in a real implementation, you would get the users from the database
            Users.Clear();
            // Add some sample users for now
            Users.Add(new UserModel { id = 1, type = "Supplier" });
            Users.Add(new UserModel { id = 2, type = "Customer" });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
} 