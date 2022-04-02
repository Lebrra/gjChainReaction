using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShoppingCart : MonoBehaviour
{
    //UI Stuff
    public Image chosenProductImage;
    public TextMeshProUGUI chosenProductPriceText;
    public TextMeshProUGUI chosenProductAmountText;

    //Keep track of selected amount
    public int chosenProductAmount = 7;

    //List of selected items and amount
    public List<CartItem> cart = new List<CartItem>();

    public Ingredient chosenProduct;

    private void Start()
    {
        chosenProductAmount = 0;
    }

    private void Update()
    {
        chosenProductAmountText.text = ("Amount: " + chosenProductAmount);
    }

    public void DisplayItem(Ingredient ingredient)
    {
        chosenProduct = ingredient;
        chosenProductImage.sprite = ingredient.sprite;
        //chosenProductPrice = ingredient.buyPrice;
        chosenProductPriceText.text = ("Price: " + ingredient.buyPrice.ToString());
    }

    public void AddOneToCart()
    {
        chosenProductAmount++;
    }

    public void RemoveOneFromCart()
    {
        if(chosenProductAmount > 0)
            chosenProductAmount--;
    }

    public void AddItem()
    {
        if (chosenProductAmount > 0 && chosenProduct != null)
        {
            CartItem temp = new CartItem();
            temp.ingredient = chosenProduct;
            temp.amount = chosenProductAmount;

           // bool exists = false;

            foreach (CartItem item in cart)
            {
                if (item.ingredient.name == temp.ingredient.name)
                {
                    //item.amount += chosenProductAmount;
                    chosenProductAmount += item.amount;
                    cart.Remove(item);
                    temp.amount = chosenProductAmount;
                    //exists = true;
                    break;
                }
            }

            cart.Add(temp);

            chosenProductAmount = 0;

            ResetDisplay();
        }
    }

    public void ResetDisplay()
    {
        chosenProduct = null;
        chosenProductImage.sprite = null;
        chosenProductPriceText.text = ("Price: ");
    }
}

[System.Serializable]
public struct CartItem
{
    public Ingredient ingredient;
    public int amount;
}
