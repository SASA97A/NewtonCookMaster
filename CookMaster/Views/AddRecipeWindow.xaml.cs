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
    /// Interaction logic for AddRecipeWindow.xaml
    /// </summary>
    public partial class AddRecipeWindow : Window
    {
        public AddRecipeWindow()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
                string.IsNullOrWhiteSpace(txtIngredients.Text) ||
                string.IsNullOrWhiteSpace(txtInstructions.Text) ||
                cmbCategory.SelectedItem == null ||
                datePicker.SelectedDate == null)
            {
                MessageBox.Show("All fields are mandatory.");
                return;
            }

            var newRecipe = new Recipe
            {
                Title = txtTitle.Text,
                Ingredients = txtIngredients.Text,
                Instructions = txtInstructions.Text,
                Category = (cmbCategory.SelectedItem as ComboBoxItem).Content.ToString(),
                DateAdded = datePicker.SelectedDate ?? DateTime.Now,
                CreatedBy = UserManager.LoggedInUser
            };

            RecipeManager.AddRecipe(newRecipe);
            this.Close();
        }
    }
}
