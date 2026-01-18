
namespace CookMaster.Models
{
    public class Recipe
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Title { get; set; }
        public string? Ingredients { get; set; }
        public string? Instructions { get; set; }
        public required string Category { get; set; }
        public required DateTime DateAdded { get; set; }
        public required User CreatedBy { get; set; }

        public override string ToString() => $"{Title} (Created by {CreatedBy.Username})";
    }
}
