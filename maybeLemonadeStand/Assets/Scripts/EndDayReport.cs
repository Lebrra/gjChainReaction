using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndDayReport : MonoBehaviour
{
    public TextMeshProUGUI titleTxt;
    public List<TextMeshProUGUI> itemTxts;
    public List<TextMeshProUGUI> moneyTxts;

    public TextMeshProUGUI totalTxt;
    public TextMeshProUGUI bankTxt;

    public List<GameObject> weatherIcons;

    public void LoadEndDay(List<Recipe> menu, Weather forecast, float moneySpent) {
        titleTxt.text = "End of Day " + GameManager.instance.dayCounter.ToString();
        SetWeatherIcon(forecast);

        var moneys = MoneyLogic.GetDailyEarnings(menu, forecast);
        float total = 0F;

        for(int iterator = 0; iterator < 3; iterator++)
        {
            if (iterator < menu.Count)
            {
                itemTxts[iterator].text = menu[iterator].name;
                moneyTxts[iterator].text = "$" + moneys[iterator].ToString();
                total += moneys[iterator];
            }
            else
            {
                itemTxts[iterator].text = "---";
                moneyTxts[iterator].text = "$0";
            }
        }

        totalTxt.text = "$" + total.ToString();
        GameManager.instance?.AddToBank(total);
        bankTxt.text = "$" + GameManager.instance.bank.ToString();

        // trigger animation
    }

    void SetWeatherIcon(Weather weather)
    {
        foreach (var img in weatherIcons) img.SetActive(false);
        switch (weather)
        {
            case Weather.Sun:
                weatherIcons[0].SetActive(true);
                break;
            case Weather.Rain:
                weatherIcons[1].SetActive(true);
                break;
            case Weather.Wind:
                weatherIcons[2].SetActive(true);
                break;
            case Weather.Snow:
                weatherIcons[3].SetActive(true);
                break;
        }
    }

    public void NextDay()
    {
        GameManager.instance.SaveThisDay();
    }
}
