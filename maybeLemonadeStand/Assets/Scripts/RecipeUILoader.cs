using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecipeUILoader : MonoBehaviour
{
    public Image recipeSprite;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI ingredientText;

    Recipe myRecipe;

    public void LoadUI(Recipe recipe)
    {
        if (recipe.sprite) recipeSprite.sprite = recipe.sprite;
        titleText.text = recipe.name;

        string ingredients = "";
        foreach (var ingred in recipe.ingredients)
        {
            ingredients += "- " + ingred.name + "\n";
        }
        ingredientText.text = ingredients;
    }
}
