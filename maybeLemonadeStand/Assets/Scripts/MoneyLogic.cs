using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MoneyLogic
{
    /// <summary>
    /// Generates total income from each menu item with weather modifiers
    /// </summary>
   public static float GetDailyEarnings(List<Recipe> menu, Weather forcast)
    {
        float totalEarnings = 0F;
        
        foreach(var item in menu)
        {
            totalEarnings += (item.sellPrice * item.GetWeatherPercent(forcast));
        }

        return totalEarnings;
    }
}
