using System;
using System.Collections.Generic;
using CookBook.Core;

namespace CookBook.Data
{
    public interface IRecipeData
    {
        IEnumerable<Recipe> GetRecipeByName(string name);
        IEnumerable<Recipe> GetAll();
        Recipe GetById(int id);
        Recipe Update(Recipe updatedRecipe);
        Recipe Add(Recipe newRecipe);
        Recipe Delete(int id);
        int GetCountOfRecipe();
        int Commit();
    }
}
