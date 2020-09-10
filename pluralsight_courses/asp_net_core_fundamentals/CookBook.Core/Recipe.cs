using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CookBook.Core
{
    public class Recipe
    {
        public Recipe(){
            Ingredients = new List<Ingredient>();
        }

        public int Id { get; set; }

        [Required, StringLength(255), ]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Required, StringLength(500)]
        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Display(Name = "Rodzaj kuchni")]
        public CuisineType Cuisine { get; set; }

        [Display(Name = "Czas Przygotowania")]
        public int PreparationTime { get; set; }

        [Display(Name = "Poziom trudności")]
        public LevelOfDifficulty LevelOfDifficulty { get; set; }

        [Display(Name = "Liczba porcji")]
        public int NumberOfServings { get; set; }

        [Display(Name = "Opis przygotowania")]
        public string Secification { get; set; }

        public string ImagePath { get; set; }

        [Display(Name = "Składniki")]
        public IEnumerable<Ingredient> Ingredients {get; set;}

        public IEnumerable<PreparationStep> PreparationSteps {get; set;}
    }
}
