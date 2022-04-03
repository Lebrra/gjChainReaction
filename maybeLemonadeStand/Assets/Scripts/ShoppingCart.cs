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
    public TextMeshProUGUI receiptTotalAmountText;
    public GameObject receiptObject;
    public GameObject shopObject;

    //Receipt stuff
    public GameObject productPrefab;
    public Transform content;

    //Shop Stuff
    public GameObject shopProductPrefab;
    public Transform shopContent;

    //Keep track of selected amount
    public int chosenProductAmount = 7;

    //List of selected items and amount
    public List<CartItem> cart = new List<CartItem>();
    List<GameObject> uiCardItems = new List<GameObject>();

    public Ingredient chosenProduct;

    private float activeProductPrice;

    private float currentBank;

    public float totalAmount = 7;

    bool setup = false;

    private void Update()
    {
        chosenProductAmountText.text = ("Amount: " + chosenProductAmount);

        receiptTotalAmountText.text = ("Total: $" + totalAmount);
    }

    public void DisplayItem(Ingredient ingredient)
    {
        activeProductPrice = ingredient.buyPrice;

        if (currentBank >= ingredient.buyPrice) {
            chosenProduct = ingredient;
            chosenProductImage.gameObject.SetActive(true);
            chosenProductImage.sprite = ingredient.sprite;
            chosenProductPriceText.text = ("Price: $" + ingredient.buyPrice.ToString() + " ea.");
            chosenProductAmount = 1;
        }
    }

    public void AddOneToCart()
    {
        if(currentBank >= activeProductPrice * (chosenProductAmount + 1))
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

            currentBank -= (chosenProduct.buyPrice * (float)chosenProductAmount);

            chosenProductAmount = 0;

            ResetDisplay();
        }
    }

    public void ResetDisplay()
    {
        chosenProduct = null;
        chosenProductImage.sprite = null;
        chosenProductImage.gameObject.SetActive(false);
        chosenProductPriceText.text = ("Price: ");
    }

    public void GetReceipt()
    {
        shopObject.SetActive(false);
        receiptObject.SetActive(true);

        BuildReceipt();
        GetTotal();
    }

    public void GetTotal()
    {
        foreach (CartItem item in cart)
        {
            totalAmount += (item.ingredient.buyPrice * item.amount);
        }
    }

    public void BuildReceipt()
    {
        foreach (CartItem item in cart)
        {
            GameObject prefab = Instantiate(productPrefab, content);
            prefab.GetComponent<ProductLoader>().LoadUI(item);

            uiCardItems.Add(prefab);
        }
    }

    public void NotTheBestWayToDoThis()
    {
        currentBank = GameManager.instance.bank;
        receiptObject.SetActive(false);
        shopObject.SetActive(true);

        foreach (GameObject item in uiCardItems)
        {
            Destroy(item);
        }

        uiCardItems.Clear();
        cart.Clear();
        totalAmount = 0;
    }

    public void FinalizePurchase()
    {
        GameManager.instance.SendPurchases(totalAmount, cart);
    }

    public void SetUpShop()
    {
        chosenProductAmount = 0;
        totalAmount = 0;

        currentBank = GameManager.instance.bank;

        if (setup) return;

        List<Ingredient> temp = IngredientLogic.GetIngredientList();

        foreach (Ingredient item in temp)
        {
            GameObject prefab = Instantiate(shopProductPrefab, shopContent);
            prefab.GetComponent<ProductLoader>().LoadUI(item, this);

            //uiCardItems.Add(prefab);
        }
        setup = true;
    }
}

[System.Serializable]
public struct CartItem
{
    public Ingredient ingredient;
    public int amount;
}
