using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProductLoader : MonoBehaviour
{
    public Image productImage;
    public TextMeshProUGUI productName;
    public TextMeshProUGUI productPrice;
    public TextMeshProUGUI productAmount;

    public bool useAmount = false;

    public void LoadUI(CartItem item)
    {
        productImage.sprite = item.ingredient.sprite;
        productName.text = item.ingredient.name;
        productPrice.text = ("Price: $" + item.ingredient.buyPrice.ToString());
        if(useAmount)
            productAmount.text = ("Amount: " + item.amount.ToString());
    }

    public void LoadUI(Ingredient ingredient, ShoppingCart shoppingCart)
    {
        productImage.sprite = ingredient.sprite;
        productName.text = ingredient.name;
        productPrice.text = ("Price: $" + ingredient.buyPrice.ToString());
        GetComponent<Button>().onClick.AddListener(() => shoppingCart.DisplayItem(ingredient));
    }
}
