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

    public void LoadUI(CartItem item)
    {
        productImage.sprite = item.ingredient.sprite;
        productName.text = item.ingredient.name;
        productPrice.text = ("Price: $" + item.ingredient.buyPrice.ToString());
        productAmount.text = ("Amount: " + item.amount.ToString());
    }
}
