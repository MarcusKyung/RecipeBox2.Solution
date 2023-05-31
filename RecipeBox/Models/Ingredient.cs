
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace RecipeBox.Models
{
  public class Ingredient
  {
    public int IngredientId { get; set; }
    [Required(ErrorMessage = "The ingredient name can't be empty!")]
    public string IngredientName { get; set; }
    public List<IngredientRecipe> IngredientRecipeJoinEntities { get;}
  }
}