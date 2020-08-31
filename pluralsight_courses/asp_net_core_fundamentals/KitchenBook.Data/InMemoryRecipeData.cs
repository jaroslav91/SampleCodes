using System.Collections.Generic;
using System.Linq;
using KitchenBook.Core;

namespace KitchenBook.Data
{
    public class InMemoryRecipeData : IRecipeData
    {
        
        readonly List<Recipe> recipes;

        public InMemoryRecipeData()
        {
            recipes = new List<Recipe>(){
                 new Recipe() {Id = 1, Name = "WEGEBURGERY Z ORIENTALNYM SOSEM ŚLIWKOWYM", 
                 Description = "Znudziły Ci się klasyczne burgery? Pora na odrobinę szaleństwa na talerzu i to w roślinnej wersji!", 
                 Cuisine= CuisineType.NorthAmerica},
                 new Recipe() {Id = 2, Name = "FRYTKI Z HALLOUMI Z SOSEM TZATZIKI", Description = "Wspaniały smak sera halloumi zamknięty w pysznych i prostych frytkach zachwyci każdego miłośnika greckiej kuchni! Wykorzystaj przepis Kingi i podaj je z sosem tzatziki.",
                 Cuisine = CuisineType.Greek
                 },
                 new Recipe() {Id = 3, Name = "SZARE KLUSKI", Description = "Tradycyjny przepis w nowej odsłonie, czyli szare kluski z miodową kapustą i wegańską okrasą! To danie obowiązkowe dla miłośników regionalnej kuchni. Spróbujesz?", Cuisine = CuisineType.Polish},
            };
            
        }

        public Recipe Add(Recipe newRecipe)
        {
            var newId = recipes.Max(recipe =>recipe.Id) +1 ;
            newRecipe.Id = newId;
            recipes.Add(newRecipe);
            return newRecipe;
        }

        public int Commit()
        {
            return 0;
        }

        public Recipe Delete(int id)
        {
            var recipe = recipes.FirstOrDefault(r=>r.Id == id);
            if(recipe != null){
                recipes.Remove(recipe);
            }
            return recipe;
        }

        public IEnumerable<Recipe> GetAll()
        {
            return recipes.OrderBy(r => r.Name);
        }

        public Recipe GetById(int id)
        {
            return recipes.Find(r => r.Id == id);
        }

        public int GetCountOfRecipe()
        {
            return recipes.Count();
        }

        public IEnumerable<Recipe> GetRecipeByName(string name = null)
        {
            return recipes.Where(r => string.IsNullOrEmpty(name) || r.Name.ToLower().StartsWith(name.ToLower()));
        }

        public Recipe Update(Recipe updatedRecipe)
        {
            var entity = recipes.Find(r => r.Id == updatedRecipe.Id);
            if(entity != null)
            {                
                entity = updatedRecipe;
            }
            return updatedRecipe;
        }
    }
}