using System.Linq;
using System.Windows;
using System.Windows.Input;
using netproject2.Commands;
using netproject2.Data;
using netproject2.Models;
using netproject2.Views;

namespace netproject2.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _email;
        private string _password;
        private readonly AppDbContext _dbContext;

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            _dbContext = new AppDbContext(); // Assuming AppDbContext is properly configured
            LoginCommand = new RelayCommand(Login);
        }

        private void Login()
        {
            // Check the database for the user credentials
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == Email && u.Password == Password);

            if (user != null)
            {
                // If user is found, pass the user object to SubjectsView
                var subjectsView = new SubjectsView(user);
                subjectsView.Show();

                // Close the login window
                Application.Current.Windows[0].Close();
            }
            else
            {
                // Display an error message
                MessageBox.Show("Invalid email or password. Please try again.", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
