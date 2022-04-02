using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ingredient", menuName = "ScriptableObjects/Recipe", order = 2)]
public class Recipe : ScriptableObject
{
    public float sellPrice;
    public Sprite sprite;
    public List<Ingredient> ingredients;

    public Upgrade requiredAppliance;

    public float sunRate;
    public float rainRate;
    public float windRate;
    public float snowRate;

    public float GetWeatherPercent(Weather weather)
    {
        switch (weather)
        {
            case Weather.Sun: return sunRate;
            case Weather.Rain: return rainRate;
            case Weather.Wind: return windRate;
            case Weather.Snow: return snowRate;
        }

        return 7F;
    }
}