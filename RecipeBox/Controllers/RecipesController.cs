using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using RecipeBox.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace RecipeBox.Controllers
{
  [Authorize]
  public class RecipesController : Controller
  {
    private readonly RecipeBoxContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public RecipesController(UserManager<ApplicationUser> userManager, RecipeBoxContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public async Task<ActionResult> Index()
    {
      string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
      List<Recipe> userRecipes = _db.Recipes
                          .Where(entry => entry.User.Id == currentUser.Id)
                          .Include(recipe => recipe.IngredientRecipeJoinEntities)
                          .ToList();
      return View(userRecipes);
    }

    public ActionResult Create()  
    {
      ViewBag.IngredientId = new SelectList(_db.Ingredients, "IngredientId", "IngredientName");
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Recipe recipe, int IngredientId)
    {
      if (!ModelState.IsValid)
      {
        return View();
      }
      else
      {
        string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
        recipe.User = currentUser;
        _db.Recipes.Add(recipe);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }

    public ActionResult Details(int id)  
    {
      Recipe thisRecipe = _db.Recipes
          .Include(recipe => recipe.IngredientRecipeJoinEntities)
          .ThenInclude(join => join.Ingredient)
          .Include(recipe => recipe.RecipeTagJoinEntities)
          .ThenInclude(join => join.Tag)
          .FirstOrDefault(recipe => recipe.RecipeId == id);
      return View(thisRecipe);
    }

    public ActionResult Edit(int id) 
    {
      Recipe thisRecipe = _db.Recipes.FirstOrDefault(recipe => recipe.RecipeId == id);
      return View(thisRecipe);
    }

    [HttpPost]
    public ActionResult Edit(Recipe recipe)
    {
      _db.Recipes.Update(recipe);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Recipe thisRecipe = _db.Recipes.FirstOrDefault(recipe => recipe.RecipeId == id);
      return View(thisRecipe);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Recipe thisRecipe = _db.Recipes.FirstOrDefault(recipe => recipe.RecipeId == id);
      _db.Recipes.Remove(thisRecipe);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddTag(int id)
    {
      Recipe thisRecipe = _db.Recipes.FirstOrDefault(recipes => recipes.RecipeId == id);
      ViewBag.TagId = new SelectList(_db.Tags, "TagId", "TagName");
      return View(thisRecipe);
    }

    [HttpPost]
    public ActionResult AddTag(Recipe recipe, int tagId)
    {
      #nullable enable
      RecipeTag? joinEntity = _db.RecipeTags.FirstOrDefault(join => (join.TagId == tagId && join.RecipeId == recipe.RecipeId));
      #nullable disable
      if (joinEntity == null && tagId != 0)
      {
        _db.RecipeTags.Add(new RecipeTag() { TagId = tagId, RecipeId = recipe.RecipeId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = recipe.RecipeId });
    }   

    public ActionResult AddIngredient(int id)
    {
      Recipe thisRecipe = _db.Recipes.FirstOrDefault(recipes => recipes.RecipeId == id);
      ViewBag.IngredientId = new SelectList(_db.Ingredients, "IngredientId", "IngredientName");
      return View(thisRecipe);
    }

    [HttpPost]
    public ActionResult AddIngredient(Recipe recipe, int ingredientId)
    {
      #nullable enable
      IngredientRecipe? joinEntity = _db.IngredientRecipes.FirstOrDefault(join => (join.IngredientId == ingredientId && join.RecipeId == recipe.RecipeId));
      #nullable disable
      if (joinEntity == null && ingredientId != 0)
      {
        _db.IngredientRecipes.Add(new IngredientRecipe() { IngredientId = ingredientId, RecipeId = recipe.RecipeId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = recipe.RecipeId });
    }   

    [HttpPost]
    public ActionResult DeleteJoin(int joinId) //Deletes Tag
    {
      RecipeTag joinEntry = _db.RecipeTags.FirstOrDefault(entry => entry.RecipeTagId == joinId);
      _db.RecipeTags.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    } 
  }
}