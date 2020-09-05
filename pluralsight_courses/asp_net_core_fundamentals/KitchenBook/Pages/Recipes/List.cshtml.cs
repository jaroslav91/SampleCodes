using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitchenBook.Core;
using KitchenBook.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KitchenBook.Pages.Recipes
{
    public class ListModel : PageModel
    {

        private readonly IRecipeData recipeData;

        public IEnumerable<Recipe> Recipes {get; set;}

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public ListModel(IRecipeData recipeData)
        {            
            this.recipeData = recipeData;
        }

        public void OnGet()
        {
            Recipes = recipeData.GetRecipeByName(SearchTerm);
        }
    }
}
