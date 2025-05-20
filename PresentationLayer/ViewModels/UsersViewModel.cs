using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using LogicLayer;

namespace PresentationLayer.ViewModels
{
    public class UsersViewModel : INotifyPropertyChanged
    {
        private readonly ILogicService _logicService;
        private ObservableCollection<UserModel> _users;
        private int _selectedUserId;
        private string _selectedUserType;
        private int _newUserId;
        private string _newUserType;

        public UsersViewModel(ILogicService logicService)
        {
            _logicService = logicService;
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
            _logicService.AddUser(NewUserId, NewUserType);
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
            var users = _logicService.GetAllUsers();
            foreach (var user in users)
            {
                Users.Add(new UserModel { id = user.Key, type = user.Value });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
} 