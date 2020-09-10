using System.ComponentModel.DataAnnotations;

namespace CookBook.Core
{
    public enum CuisineType
    {
        None,
        [Display(Name = "Kuchnia Polska")]
        Polish,
        Thai,
        Greek,
        Spanish,
        Italian,
        NorthAmerica
    }
}