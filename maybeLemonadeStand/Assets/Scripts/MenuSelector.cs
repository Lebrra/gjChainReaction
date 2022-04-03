using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSelector : MonoBehaviour
{
    public List<Toggle> allToggles;
    List<Recipe> menuList;
    List<CartItem> ingredientListInst;

    bool hasLoaded = false;

    public GameObject recipePrefUI;
    public Transform container;

    public Button bigGoButton;

    private void OnEnable()
    {
        if (hasLoaded) return;
        else LoadRecipeUI();
        menuList = new List<Recipe>();
        bigGoButton.interactable = false;
    }

    public void GetIngredientList(List<CartItem> items)
    {
        ingredientListInst = new List<CartItem>();
        foreach (var item in items) ingredientListInst.Add(item);
        UpdateMenuLogic();
    }

    void LoadRecipeUI()
    {
        allToggles = new List<Toggle>();

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
        List<Ingredient> tempIngredients = new List<Ingredient>();
        foreach (var item in ingredientListInst)
        {
            if (item.amount > 0) tempIngredients.Add(item.ingredient);
        }

        foreach (var recipe in allToggles)
        {
            if (recipe.isOn) continue;

            bool recipeValid = true;
            foreach (var ingredient in recipe.GetComponent<RecipeUILoader>().myRecipe.ingredients)
            {
                if (!tempIngredients.Contains(ingredient))
                {
                    recipeValid = false;
                    break;
                }
            }

            if (recipeValid)
            {
                recipe.interactable = true;
            }
            else
            {
                recipe.interactable = false;
                recipe.transform.SetAsLastSibling();
            }
        }
    }

    public bool UpdateMenu(bool updatedState, Recipe recipe)
    {
        bool state = updatedState;
        if (!updatedState)
        {
            if (menuList.Contains(recipe)) AddPurchasedIngredients(recipe);
        }
        else
        {
            state = menuList.Count < 3;
            if (state && !menuList.Contains(recipe)) RemovePurchasedIngredients(recipe);
        }
        UpdateMenuLogic();
        return state;
    }

    void RemovePurchasedIngredients(Recipe recipe)
    {
        foreach (var ingredient in recipe.ingredients)
        {
            // find ingredient in cart & remove
            foreach (var cartItem in ingredientListInst)
            {
                if (cartItem.ingredient == ingredient)
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
        menuList.Add(recipe);
        bigGoButton.interactable = true;
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
        menuList.Remove(recipe);
        if (menuList.Count == 0) bigGoButton.interactable = false;
    }

    public void FinalizeMenu()
    {
        if (menuList.Count > 0)
        {
            GameManager.instance?.SendMenu(menuList);
            menuList = new List<Recipe>();
        }
    }
}