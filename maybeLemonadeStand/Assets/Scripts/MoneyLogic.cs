using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MoneyLogic
{
    /// <summary>
    /// Generates total income from each menu item with weather modifiers
    /// </summary>
   public static List<float> GetDailyEarnings(List<Recipe> menu, Weather forcast)
    {
        List<float> totalEarnings = new List<float>();
        
        foreach(var item in menu)
        {
            totalEarnings.Add(item.sellPrice * item.GetWeatherPercent(forcast));
        }

        return totalEarnings;
    }
}
