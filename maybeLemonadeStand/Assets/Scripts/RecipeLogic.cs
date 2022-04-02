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
