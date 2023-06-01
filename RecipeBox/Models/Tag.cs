using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeBox.Models
{
  public class Tag
    {
        public int TagId { get; set; }
        [Required(ErrorMessage = "The tag name can't be empty")]
        public string TagName { get; set; }
        public List<RecipeTag> RecipeTagJoinEntities { get;}
    }
}