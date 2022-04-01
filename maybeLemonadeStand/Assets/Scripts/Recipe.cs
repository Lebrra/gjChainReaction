using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ingredient", menuName = "ScriptableObjects/Recipe", order = 2)]
public class Recipe : ScriptableObject
{
    public float sellPrice;
    public Sprite sprite;
    public List<Ingredient> ingredients;

    [Tooltip("How long will this product last?")]
    public float quanity;
}