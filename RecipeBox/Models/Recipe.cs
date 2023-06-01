using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeBox.Models
{
  public class Recipe
  {
    public int RecipeId { get; set; }
    [Required(ErrorMessage = "The recipe name can't be empty")]
    public string RecipeName { get; set; }
    [Required(ErrorMessage = "The recipe instructions can't be empty")]
    public string RecipeInstructions { get; set; }
    [Range(1, 5, ErrorMessage = "Your rating must be between 1 and 5")]
    public int RecipeRating { get; set; }
    public List<IngredientRecipe> IngredientRecipeJoinEntities { get;}
    public List<RecipeTag> RecipeTagJoinEntities { get;}
    public ApplicationUser User { get; set; }
  }
}