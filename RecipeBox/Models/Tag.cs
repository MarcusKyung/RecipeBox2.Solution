using System.Collections.Generic;

namespace RecipeBox.Models
{
  public class Tag
    {
        public int TagId { get; set; }
        public string TagName { get; set; }
        public List<RecipeTag> RecipeTagJoinEntities { get;}
    }
}