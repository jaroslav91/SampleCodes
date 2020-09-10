namespace CookBook.Core
{
    public class PreparationStep
    {
        public int Id {get;set;}
        public int RecipeId {get; set;}
        public int Order {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
    }
}