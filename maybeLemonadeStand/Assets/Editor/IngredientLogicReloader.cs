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
        string runningList = "Ingredients: ";

        List<Ingredient> ingredients = new List<Ingredient>();

        foreach (var ingredient in Resources.LoadAll("Ingredients", typeof(Ingredient)))
        {
            ingredients.Add(ingredient as Ingredient);
            runningList += (ingredient.name + ", ");
        }

        Debug.Log(runningList);

        IngredientDataList newDatalist = new IngredientDataList(ingredients);
        JSONEditor.DataToJSON(newDatalist, "IngredientDatalist");

        Debug.Log("All ingredients reloaded.");
    }
}
