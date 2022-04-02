using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class IngredientLogicReloader : Editor
{
    [MenuItem("Custom Editor/Reload Ingredient List")]
    public static void ReloadIngredients()
    {
        Debug.Log("Reloading Ingredients...");

        List<Ingredient> ingredients = new List<Ingredient>();

        foreach (var ingredient in Resources.LoadAll("Ingredients", typeof(Ingredient)))
        {
            ingredients.Add(ingredient as Ingredient);
            Debug.Log(ingredient);
        }

        IngredientDataList newDatalist = new IngredientDataList(ingredients);
        JSONEditor.DataToJSON(newDatalist, "IngredientDatalist");

        Debug.Log("All ingredients reloaded.");
    }
}
