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
    /// Interaction logic for RecipeDetailWindow.xaml
    /// </summary>
    public partial class RecipeDetailWindow : Window
    {
        public RecipeDetailWindow()
        {
            InitializeComponent();
        }

        private Recipe _recipe;

        public RecipeDetailWindow(Recipe recipe)
        {
            InitializeComponent();
            _recipe = recipe;

            // POPULATE ALL FIELDS
            txtTitle.Text = _recipe.Title;
            txtCategory.Text = _recipe.Category;
            txtDate.Text = _recipe.DateAdded.ToShortDateString();
            txtIngredients.Text = _recipe.Ingredients;
            txtInstructions.Text = _recipe.Instructions;

            SetEditable(false);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // Check if user is owner or admin before allowing edit
            if (UserManager.LoggedInUser.IsAdmin || _recipe.CreatedBy == UserManager.LoggedInUser)
            {
                SetEditable(true);
            }
            else
            {
                MessageBox.Show("You can only edit your own recipes.");
            }
        }

        private void SetEditable(bool canEdit)
        {
            // Standard TextBoxes
            txtTitle.IsReadOnly = !canEdit;
            txtIngredients.IsReadOnly = !canEdit;
            txtInstructions.IsReadOnly = !canEdit;

            // Toggle Category Visibility
            if (canEdit)
            {
                txtCategory.Visibility = Visibility.Collapsed;
                cmbCategoryEdit.Visibility = Visibility.Visible;

                // Pre-select the current category in the dropdown
                foreach (ComboBoxItem item in cmbCategoryEdit.Items)
                {
                    if (item.Content.ToString() == _recipe.Category)
                    {
                        cmbCategoryEdit.SelectedItem = item;
                        break;
                    }
                }
            }
            else
            {
                txtCategory.Visibility = Visibility.Visible;
                cmbCategoryEdit.Visibility = Visibility.Collapsed;
            }

            btnSave.IsEnabled = canEdit;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Update
            _recipe.Title = txtTitle.Text;
            _recipe.Ingredients = txtIngredients.Text;
            _recipe.Instructions = txtInstructions.Text;

            if (cmbCategoryEdit.SelectedItem is ComboBoxItem selectedItem)
            {
                _recipe.Category = selectedItem.Content.ToString();
            }

            txtCategory.Text = _recipe.Category;
            txtDate.Text = _recipe.DateAdded.ToShortDateString();

            MessageBox.Show("Recipe Updated!");
            SetEditable(false);
        }
    }
}
