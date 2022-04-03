using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WeatherMan
{

    public static Weather GetForcast(Season s)
    {
        Weather currentWeather;

        float rand = Random.Range(0f, 1f);

        switch (s)
        {
            //SPRING
            case Season.Spring:
                if (rand <= 0.67)
                    currentWeather = Weather.Sun;
                else if (rand > .67 && rand <= .85)
                    currentWeather = Weather.Rain;
                else if (rand > .85 && rand <= .98)
                    currentWeather = Weather.Wind;
                else
                    currentWeather = Weather.Snow;
                break;
            //SUMMER
            case Season.Summer:
                if (rand <= 0.7)
                    currentWeather = Weather.Sun;
                else if (rand > .7 && rand <= .8)
                    currentWeather = Weather.Rain;
                else if (rand > .8 && rand <= 1)
                    currentWeather = Weather.Wind;
                else
                    currentWeather = Weather.Snow;
                break;
            //FALL
            case Season.Fall:
                if (rand <= 0.67)
                    currentWeather = Weather.Sun;
                else if (rand > .67 && rand <= .8)
                    currentWeather = Weather.Rain;
                else if (rand > .8 && rand <= .98)
                    currentWeather = Weather.Wind;
                else
                    currentWeather = Weather.Snow;
                break;
            //WINTER
            case Season.Winter:
                if (rand <= .2)
                    currentWeather = Weather.Sun;
                else if (rand > .2 && rand <= .23)
                    currentWeather = Weather.Rain;
                else if (rand > .23 && rand <= .33)
                    currentWeather = Weather.Wind;
                else
                    currentWeather = Weather.Snow;
                break;

            default:
                currentWeather = Weather.Snow;
                break;
        }

        return currentWeather;
    }

    public static int GetTemperature(Season s)
    {
        int currTemp = 7;

        return currTemp;
    }
}

public enum Weather
{
    Sun,
    Rain,
    Wind,
    Snow
}