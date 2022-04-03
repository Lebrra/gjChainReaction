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

    public void LoadEndDay(List<Recipe> menu, Weather forecast, float moneySpent) {
        titleTxt.text = "End of Day " + GameManager.instance.dayCounter.ToString();

        var moneys = MoneyLogic.GetDailyEarnings(menu, forecast);
        float total = 0F;

        for(int iterator = 0; iterator < menu.Count; iterator++)
        {
            itemTxts[iterator].text = menu[iterator].name;
            moneyTxts[iterator].text = "$" + moneys[iterator].ToString();
            total += moneys[iterator];
        }

        totalTxt.text = "$" + total.ToString();
        GameManager.instance?.AddToBank(total);
        bankTxt.text = "$" + GameManager.instance.bank.ToString();

        // trigger animation
    }

    public void NextDay()
    {
        GameManager.instance.SaveThisDay();
    }
}
