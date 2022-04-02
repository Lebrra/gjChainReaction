using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookbookLoader : MonoBehaviour
{
    bool hasLoaded = false;

    public GameObject recipePrefUI;
    public Transform container;

    private void OnEnable()
    {
        if (hasLoaded) return;
        else LoadRecipeUI();
    }

    void LoadRecipeUI()
    {
        // use RecipeLogic to load all recipes

        foreach(var recipe in RecipeLogic.GetRecipeList())
        {
            GameObject recipeUI = Instantiate(recipePrefUI, container);
            recipeUI.GetComponent<RecipeUILoader>().LoadUI(recipe);
            //when ui is ready fill it
        }

        hasLoaded = true;
    }
}
