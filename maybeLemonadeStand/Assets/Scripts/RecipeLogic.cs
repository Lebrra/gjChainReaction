using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RecipeLogic
{
    public static List<Recipe> GetRecipeList()
    {
        var datalist = JSONEditor.JSONToData<RecipeDataList>("RecipeDatalist");
        if (datalist == null)
        {
            datalist = new RecipeDataList(GenerateDatalistJSON());
        }

        return datalist.allRecipes;
    }

    public static List<Recipe> GetMenuOptions(List<Ingredient> ingredients)
    {
        List<Recipe> allRecipes = GetRecipeList();
        List<Recipe> menuOptions = new List<Recipe>();

        foreach(var recipe in allRecipes)
        {
            bool hasAllIngredients = true;
            foreach(var recIngred in recipe.ingredients)
            {
                if (!ingredients.Contains(recIngred))
                {
                    hasAllIngredients = false;
                    break;
                }
            }

            if (hasAllIngredients) menuOptions.Add(recipe);
        }

        return menuOptions;
    }


    static List<Recipe> GenerateDatalistJSON()
    {
        Debug.Log("Reloading Recipes...");

        List<Recipe> recipes = new List<Recipe>();

        //RecipeLogic.allRecipes = new List<Recipe>();
        foreach (var recipe in Resources.LoadAll("Recipes", typeof(Recipe)))
        {
            //RecipeLogic.allRecipes.Add(recipe as Recipe);
            recipes.Add(recipe as Recipe);
            Debug.Log(recipe);
        }

        RecipeDataList newDatalist = new RecipeDataList(recipes);
        JSONEditor.DataToJSON(newDatalist, "RecipeDatalist");

        Debug.Log("All recipes reloaded.");
        return recipes;
    }
}
