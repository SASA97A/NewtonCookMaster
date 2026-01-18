using CookMaster.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CookMaster.Views
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }


        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            string user = txtUser.Text;
            string pass = txtPass.Password;
            string confirm = txtConfirm.Password;
            string country = cmbCountry.Text;

            if (pass != confirm) { MessageBox.Show("Passwords do not match"); return; }

            bool success = UserManager.Register(user, pass, country);
            if (success)
            {
                MessageBox.Show("Registered! Please Log in.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Username already taken.");
            }
        }
    }
}
