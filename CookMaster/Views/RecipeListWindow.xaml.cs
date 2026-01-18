using CookMaster.Managers;
using CookMaster.Models;
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
    /// Interaction logic for RecipeListWindow.xaml
    /// </summary>
    public partial class RecipeListWindow : Window
    {
        public RecipeListWindow()
        {
            InitializeComponent();
            RefreshList();
            txtWelcome.Text = $"Welcome {UserManager.LoggedInUser.Username}!";
        }

        private void RefreshList()
        {
            lstRecipes.ItemsSource = null;
            lstRecipes.ItemsSource = RecipeManager.GetRecipes();
        }

        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            new AddRecipeWindow().ShowDialog();
            RefreshList();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (lstRecipes.SelectedItem is Recipe selectedRecipe)
            {
                RecipeManager.RemoveRecipe(selectedRecipe);
                RefreshList();
            }
            else
            {
                MessageBox.Show("Please select a recipe first.");
            }
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            UserDetailsWindow profileWindow = new UserDetailsWindow();
            profileWindow.ShowDialog();
            txtWelcome.Text = $"Welcome, {UserManager.LoggedInUser.Username}";
        }

        private void Details_Click(object sender, RoutedEventArgs e)
        {
            if (lstRecipes.SelectedItem is Recipe selectedRecipe)
            {
                new RecipeDetailWindow(selectedRecipe).ShowDialog();
                RefreshList();
            }
            else
            {
                MessageBox.Show("Please select a recipe first.");
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            UserManager.Logout();
            new MainWindow().Show();
            this.Close();
        }
    }
}
