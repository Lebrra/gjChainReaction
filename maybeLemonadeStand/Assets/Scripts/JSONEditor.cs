using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class JSONEditor
{
    /// <summary>
    /// If JSON save data exists, pull and load it. Else make new save data
    /// </summary>
    public static T JSONToData<T>(string fileName)
    {
        if (File.Exists(Application.persistentDataPath + "/" + fileName + ".json"))
        {
            // get from file
            var file = File.ReadAllText(Application.persistentDataPath + "/" + fileName + ".json");
            T data = JsonUtility.FromJson<T>(file);
            return data;
        }
        else
        {
            // form default data
            return default(T);
        }
    }

    /// <summary>
    /// Convert SaveData to JSON and save to persistentDataPath
    /// </summary>
    public static string DataToJSON<T>(T data, string fileName)
    {
        var json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/" + fileName + ".json", json);

        return json;
    }

    public static void DeleteData(string fileName)
    {
        if (File.Exists(Application.persistentDataPath + "/" + fileName + ".json"))
        {
            // get from file
            File.Delete(Application.persistentDataPath + "/" + fileName + ".json");
        }
    }
}

[System.Serializable]
public class SaveData
{
    public float bank = 7F;
    public int dayCounter = 1;
    public string truckName = "Seven";

    public SaveData()
    {
        // nothing
    }

    public SaveData(float money, int day, string truck)
    {
        bank = money;
        dayCounter = day;
        truckName = truck;
    }
}

[System.Serializable]
public class RecipeDataList
{
    public List<Recipe> allRecipes;

    public RecipeDataList(List<Recipe> recipes)
    {
        allRecipes = new List<Recipe>();
        foreach (var recipe in recipes) allRecipes.Add(recipe);
    }
}

[System.Serializable]
public class IngredientDataList
{
    public List<Ingredient> allRecipes;

    public IngredientDataList(List<Ingredient> ingredients)
    {
        allRecipes = new List<Ingredient>();
        foreach (var ingredient in ingredients) allRecipes.Add(ingredient);
    }
}