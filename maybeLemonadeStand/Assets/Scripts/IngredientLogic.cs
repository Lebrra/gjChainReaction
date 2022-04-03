using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IngredientLogic 
{
    public static List<Ingredient> GetIngredientList()
    {
        var datalist = JSONEditor.JSONToData<IngredientDataList>("IngredientDatalist");
        if (datalist == null)
        {
            datalist = new IngredientDataList(GenerateDatalistJSON());
        }

        return datalist.allRecipes;
    }

    public static List<Ingredient> GenerateDatalistJSON()
    {
        Debug.Log("Reloading Ingredients...");

        List<Ingredient> ingredients = new List<Ingredient>();

        //RecipeLogic.allRecipes = new List<Recipe>();
        foreach (var ingredient in Resources.LoadAll("Ingredients", typeof(Ingredient)))
        {
            //RecipeLogic.allRecipes.Add(recipe as Recipe);
            ingredients.Add(ingredient as Ingredient);
            Debug.Log(ingredient);
        }

        IngredientDataList newDatalist = new IngredientDataList(ingredients);
        JSONEditor.DataToJSON(newDatalist, "IngredientDatalist");

        Debug.Log("All ingredients reloaded.");
        return ingredients;
    }
}
