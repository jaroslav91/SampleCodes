using System;
using System.ComponentModel.DataAnnotations;

namespace KitchenBook.Core
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required, StringLength(255)]
        public string Name { get; set; }

        [Required, StringLength(500)]
        public string Description { get; set; }
        public CuisineType Cuisine { get; set; }
        public int PreparationTime { get; set; }
        public LevelOfDifficulty LevelOfDifficulty { get; set; }
        public int NumberOfServings { get; set; }
        public string Secification { get; set; }
    }
}
