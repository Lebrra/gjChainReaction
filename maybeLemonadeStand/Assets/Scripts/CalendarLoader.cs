using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CalendarLoader : MonoBehaviour
{
    int lastLoadedDay = -7;

    public TextMeshProUGUI weekdayTxt;
    public TextMeshProUGUI dateTxt;
    public TextMeshProUGUI tempTxt;
    public TextMeshProUGUI seasonTxt;
    public Image weatherImg;

    public Sprite[] weatherSprites;

    private void OnEnable()
    {
        if (GameManager.instance)
        {
            if (lastLoadedDay != GameManager.instance.dayCounter)
            {
                lastLoadedDay = GameManager.instance.dayCounter;
                LoadUI(lastLoadedDay);
            }
        }
    }

    public void LoadUI(int day)
    {
        Date date = Calendar.GetDate(day);

        weekdayTxt.text = date.weekday.ToString();
        dateTxt.text = date.month.ToString() + " " + date.day.ToString() + " ~ Year " + date.year.ToString();
        seasonTxt.text = date.season.ToString();

        // get temp and weather from WeatherMan
    }

    Sprite WeatherToSprite(Weather weather)
    {
        return null;
    }
}
