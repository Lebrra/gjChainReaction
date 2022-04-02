using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<CartItem> purchasedIngredients;
    public List<Recipe> menuList;

    [Header("Day Menu Systems")]
    public ShoppingCart shoppingSystem;
    public MenuSelector menuSystem;

    private void Awake()
    {
        if (instance) Destroy(gameObject);
        else instance = this;
    }

    public void StartNewDay()
    {
        shoppingSystem.gameObject.SetActive(true);
        shoppingSystem.SetUpShop();
    }

    public void SendPurchases(float cost, List<CartItem> cart)
    {
        // money stuff

        purchasedIngredients = new List<CartItem>();
        foreach (var item in cart) purchasedIngredients.Add(item);

        ToMenuSelection();
    }

    public void ToMenuSelection()
    {
        shoppingSystem.gameObject.SetActive(false);
        menuSystem.gameObject.SetActive(true);
        menuSystem.GetIngredientList(purchasedIngredients);
    }
}
