using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSelector : MonoBehaviour
{
    public List<UnityEngine.UI.Toggle> allToggles;
    List<Recipe> menuList;
    List<CartItem> ingredientListInst;

    bool hasLoaded = false;

    public GameObject recipePrefUI;
    public Transform container;

    private void OnEnable()
    {
        if (hasLoaded) return;
        else LoadRecipeUI();
        menuList = new List<Recipe>();
    }

    public void GetIngredientList(List<CartItem> items)
    {
        ingredientListInst = new List<CartItem>();
        foreach (var item in items) ingredientListInst.Add(item);
        UpdateMenuLogic();
    }

    void LoadRecipeUI()
    {
        allToggles = new List<UnityEngine.UI.Toggle>();

        foreach (var recipe in RecipeLogic.GetRecipeList())
        {
            GameObject recipeUI = Instantiate(recipePrefUI, container);
            recipeUI.GetComponent<RecipeUILoader>().LoadUI(recipe, this);

            allToggles.Add(recipeUI.GetComponent<UnityEngine.UI.Toggle>());
        }

        hasLoaded = true;
    }

    void UpdateMenuLogic()
    {
        foreach (var recipe in allToggles)
        {

        }
    }

    public bool UpdateMenu(bool updatedState, Recipe recipe)
    {
        bool state = updatedState;
        if (!updatedState)
        {
            if (menuList.Contains(recipe)) RemovePurchasedIngredients(recipe);
        }
        else
        {
            state = menuList.Count < 3;
            if (state && !menuList.Contains(recipe)) AddPurchasedIngredients(recipe);
        }
        UpdateMenuLogic();
        return state;
    }

    void RemovePurchasedIngredients(Recipe recipe)
    {
        foreach(var ingredient in recipe.ingredients)
        {
            // find ingredient in cart & remove
            foreach(var cartItem in ingredientListInst)
            {
                if(cartItem.ingredient == ingredient)
                {
                    int count = cartItem.amount - 1;
                    ingredientListInst.Remove(cartItem);
                    CartItem newItem = new CartItem();
                    newItem.ingredient = ingredient;
                    newItem.amount = count;
                    ingredientListInst.Add(newItem);
                    break;
                }
            }
        }
        menuList.Remove(recipe);
    }

    void AddPurchasedIngredients(Recipe recipe)
    {
        foreach (var ingredient in recipe.ingredients)
        {
            // find ingredient in cart & remove
            foreach (var cartItem in ingredientListInst)
            {
                if (cartItem.ingredient == ingredient)
                {
                    int count = cartItem.amount + 1;
                    ingredientListInst.Remove(cartItem);
                    CartItem newItem = new CartItem();
                    newItem.ingredient = ingredient;
                    newItem.amount = count;
                    ingredientListInst.Add(newItem);
                    break;
                }
            }
        }
        menuList.Add(recipe);
    }
}
