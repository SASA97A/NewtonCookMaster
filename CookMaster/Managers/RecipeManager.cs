using CookMaster.Models;

namespace CookMaster.Managers
{
    public static class RecipeManager
    {
        private static List<Recipe> _recipes = new List<Recipe>();

        public static void AddRecipe(Recipe recipe)
        {
            _recipes.Add(recipe);
        }

        public static void RemoveRecipe(Recipe recipe)
        {
            _recipes.Remove(recipe);
        }

        public static List<Recipe> GetRecipes()
        {
            var user = UserManager.LoggedInUser;
            if (user == null) return new List<Recipe>();

            if (user.IsAdmin)
            {
                return _recipes.ToList();
            }
            else
            {
                return _recipes.Where(r => r.CreatedBy == user).ToList();
            }
        }
    }
}
