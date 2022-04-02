using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RecipeLogicReloader : Editor
{
    [MenuItem("Custom Editor/Reload Recipe List")]
    public static void ReloadRecipes()
    {
        Debug.Log("Reloading Recipes...");

        RecipeLogic.allRecipes = new List<Recipe>();
        foreach(var recipe in Resources.LoadAll("Recipes", typeof(Recipe)))
        {
            RecipeLogic.allRecipes.Add(recipe as Recipe);
            Debug.Log(recipe);
        }

        Debug.Log("All recipes reloaded.");
    }
}
