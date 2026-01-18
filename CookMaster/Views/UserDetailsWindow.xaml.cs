using CookMaster.Managers;
using CookMaster.Models;
using System.Windows;
using System.Windows.Controls;


namespace CookMaster.Views
{
    /// <summary>
    /// Interaction logic for UserDetailsWindow.xaml
    /// </summary>
    public partial class UserDetailsWindow : Window
    {
        private User _currentUser;
        public UserDetailsWindow()
        {
            InitializeComponent();
            LoadUserData();
        }

        private void LoadUserData()
        {
            _currentUser = UserManager.LoggedInUser;

            if (_currentUser != null)
            {
                txtUsername.Text = _currentUser.Username;
                cmbCountry.Text = _currentUser.Country;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string newUsername = txtUsername.Text.Trim();
            string newCountry = (cmbCountry.SelectedItem as ComboBoxItem)?.Content.ToString() ?? _currentUser.Country;

            // Validate
            if (newUsername.Length <= 3)
            {
                MessageBox.Show("Username must be longer than 3 characters.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string currentPassword = _currentUser.Password;
            string inputOldPass = txtOldPass.Password;
            string inputNewPass = txtNewPass.Password;
            string inputConfirmPass = txtConfirmPass.Password;

            string finalPasswordToSave = currentPassword;

            bool isChangingPassword = !string.IsNullOrEmpty(inputOldPass) ||
                                      !string.IsNullOrEmpty(inputNewPass) ||
                                      !string.IsNullOrEmpty(inputConfirmPass);

            if (isChangingPassword)
            {
                if (inputOldPass != currentPassword)
                {
                    MessageBox.Show("Old password is incorrect.", "Security Check", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (inputNewPass.Length < 5)
                {
                    MessageBox.Show("Password must be longer than 5 characters.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (inputNewPass != inputConfirmPass)
                {
                    MessageBox.Show("New passwords do not match.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(inputNewPass))
                {
                    MessageBox.Show("New password cannot be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                finalPasswordToSave = inputNewPass;
            }

            _currentUser.Username = newUsername;
            _currentUser.Country = newCountry;
            _currentUser.Password = finalPasswordToSave;

            MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
