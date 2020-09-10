using System.Collections.Generic;
using System.Linq;
using CookBook.Core;

namespace CookBook.Data
{
    public class InMemoryRecipeData : IRecipeData
    {

        readonly List<Recipe> recipes;

        public InMemoryRecipeData()
        {
            recipes = new List<Recipe>(){
                 new Recipe() {Id = 1, Name = "Wegeburgery z orientalnym sosem śliwkowym",
                 Description = "Znudziły Ci się klasyczne burgery? Pora na odrobinę szaleństwa na talerzu i to w roślinnej wersji!",
                 Cuisine= CuisineType.NorthAmerica},
                 new Recipe() {Id = 2, Name = "Frytki z halloumi z sosem tzatziki", Description = "Wspaniały smak sera halloumi zamknięty w pysznych i prostych frytkach zachwyci każdego miłośnika greckiej kuchni! Wykorzystaj przepis Kingi i podaj je z sosem tzatziki.",
                 Cuisine = CuisineType.Greek
                 },
                 new Recipe() {Id = 3, Name = "Szare Kluski", Description = "Tradycyjny przepis w nowej odsłonie, czyli szare kluski z miodową kapustą i wegańską okrasą! To danie obowiązkowe dla miłośników regionalnej kuchni. Spróbujesz?", Cuisine = CuisineType.Polish},
                  new Recipe() {Id = 4, Name = "Pad Thai", Description = "Tradycyjny przepis w nowej odsłonie, czyli szare kluski z miodową kapustą i wegańską okrasą! To danie obowiązkowe dla miłośników regionalnej kuchni. Spróbujesz?",
                  Cuisine = CuisineType.Thai, ImagePath= "/images/padthai.jpeg",
                  Ingredients = new List<Ingredient>(){new Ingredient(){Name = "Makaron 100 g"}},LevelOfDifficulty = LevelOfDifficulty.Average,
                  NumberOfServings = 2,PreparationTime =40,
                  PreparationSteps = new List<PreparationStep>(){
                      new PreparationStep(){
                          Name = "Przygotuj", Description = "wok, piekarnik rozgrzany do 180°C"
                      },
                        new PreparationStep(){
                          Name = "Krok 1. Gotujemy makaron", Description = "Makaron ryżowy przygotowujemy według wskazań na opakowaniu."
                      } ,

                     new PreparationStep(){
                          Name = "Krok 1: Marynujemy tofu",
                        Description = @"Tofu osączamy z zalewy, kroimy w plasterki i dobrze osuszamy. Czosnek i imbir obieramy, czosnek przeciskamy przez praskę,
                         imbir drobno ścieramy na tarce. Oba składniki mieszamy z 4-5 łyżkami oleju, 4 łyżkami sosu sojowego, 
                         miodem i odrobiną pieprzu cayenne. Obtaczamy w tym tofu i marynujemy przez co najmniej 1 godzinę w lodówce."
                         },
                          new PreparationStep(){
                          Name = "Krok 2: Gotujemy makaron",
 Description = @"Marchew obieramy i kroimy w plasterki. Cebulę obieramy i kroimy w krążki. Makaron gotujemy zgodnie z instrukcją podaną na opakowaniu. Odcedzamy, przelewamy zimną wodą i osączamy."
                          },

 new PreparationStep(){
                          Name ="Krok 3: Smażymy warzywa",
 Description ="Tofu osączamy, marynatę pozostawiamy. Tofu smażymy w woku lub na dużej patelni na 1 łyżce gorącego oleju przez 2-3 minuty z każdej strony. Wyjmujemy. Marchew i cebulę podsmażamy w woku na pozostałym oleju przez 3 minuty, mieszając. Dodajemy makaron, doprawiamy pozostałym sosem sojowym i podsmażamy przez kolejne 3 minuty."
 },

new PreparationStep(){
                          Name ="Krok 4: Dodajemy jajka do makaronu",
Description ="Jajka roztrzepujemy z marynatą z tofu. Dodajemy do makaronu i mieszamy przez 2-3 minuty, aż się zetną. Dodajemy tofu, krótko podgrzewamy po bokach w woku. Pad thai podajemy z sosem sojowym."
                  }},
                  Secification =@"
                  
                  PRZYGOTUJ
wok
piekarnik rozgrzany do 180°C
KROK 1. GOTUJEMY MAKARON
Makaron ryżowy przygotowujemy według wskazań na opakowaniu.

KROK 2. PRZYGOTOWUJEMY MARYNATĘ
Pad thai z warzywami i łososiem - Przygotowujemy marynatę

Posiekane orzeszki ziemne ucieramy w moździerzu. Dodajemy pół posiekanej papryczki chili, olej sezamowy, 2 łyżki sosu sojowego i odrobinę skórki otartej z limonki. Ucieramy na jednolitą masę.

 

KROK 3. MARYNUJEMY ŁOSOSIA
Pad thai z warzywami i łososiem - Marynujemy łososia

Łososia kroimy w grubą kostkę (ok. 2 x 2 cm). Na kawałku papieru do pieczenia rozsmarowujemy marynatę i obtaczamy w niej łososia. Całość wkładamy do naczynia żaroodpornego i odstawiamy na kilka minut. Piekarnik rozgrzewamy do temperatury 180°C. Łososia pieczemy ok. 10 minut.

KROK 4. PODSMAŻAMY W WOKU WARZYWA Z JAJKIEM
Pad thai z warzywami i łososiem - Podsmażamy w woku warzywa z jajkiem

Por i dymki kroimy w grubą kostkę. Ząbki czosnku kroimy w plastry. Szczypiorek, chili siekamy. W woku rozgrzewamy delikatnie olej. Smażymy cebulę i czosnek aż do zeszklenia. Wbijamy 1 jajko, rozprowadzamy. Dolewamy 2 łyżki sosu sojowego i mieszamy. Dodajemy makaron, por, chili, skórkę otartą z limonki.

KROK 5. DOPRAWIAMY DANIE
Danie doprawiamy sosem rybnym oraz kilkoma kroplami oleju sezamowego. Dodajemy ocet ryżowy (możemy go zastąpić sokiem z limonki) oraz kiełki. Podsmażamy, mieszając. Świeżą kolendrę siekamy i dodajemy do makaronu na samym końcu. Mieszamy. Doprawiamy cukrem.

KROK 6. PODAJEMY PAD THAI
Do miski przekładamy makaron z warzywami, posypujemy szczypiorkiem, skrapiamy sokiem z limonki. Upieczonego łososia układamy na wierzchu dania. Całość posypujemy kolendrą i posiekanym chili.
                  
                  " },

            };

        }

        public Recipe Add(Recipe newRecipe)
        {
            var newId = recipes.Max(recipe => recipe.Id) + 1;
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
            var recipe = recipes.FirstOrDefault(r => r.Id == id);
            if (recipe != null)
            {
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
            if (entity != null)
            {
                var index = recipes.IndexOf(entity);
                recipes[index] = updatedRecipe;
            }
            return updatedRecipe;
        }
    }
}