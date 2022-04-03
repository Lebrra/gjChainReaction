using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHandler : MonoBehaviour
{
    public GameObject rain;
    public GameObject wind;
    public GameObject snow;

    public void TurnOnWeatherFx(Weather w)
    {
        switch (w)
        {
            case Weather.Rain:
                rain.SetActive(true);
                break;
            case Weather.Wind:
                wind.SetActive(true);
                break;
            case Weather.Snow:
                snow.SetActive(true);
                break;

            default:
                break;
        }
    }

    public void ResetAllWeather()
    {
        rain.SetActive(false);
        wind.SetActive(false);
        snow.SetActive(false);
    }
}
