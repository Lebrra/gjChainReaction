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

    public GameObject toggleImg;

    public Recipe myRecipe;
    bool isRunningLogic = false;

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
        myRecipe = recipe;
    }

    public void LoadUI(Recipe recipe, MenuSelector menu)
    {
        LoadUI(recipe);

        var toggle = GetComponent<Toggle>();
        toggle.enabled = true;
        toggle.onValueChanged.AddListener((state) => {
            if (isRunningLogic) return;
            isRunningLogic = true;
            Debug.Log("HERE");
            state = menu.UpdateMenu(state, recipe);
            toggle.isOn = state;
            toggleImg?.SetActive(state);

            isRunningLogic = false;
            });

    }
}
