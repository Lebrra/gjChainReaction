using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Day Data")]
    public Weather todaysForecast;
    public List<CartItem> purchasedIngredients;
    public List<Recipe> menuList;
    float moneySpent = 7f;

    [Header("Day Menu Systems")]
    public GameObject mainMenuPanel;
    public ShoppingCart shoppingSystem;
    public MenuSelector menuSystem;
    public GameObject truck;
    public ParticleHandler weatherFx;
    public EndDayReport endDayPanel;

    [HideInInspector]
    public UnityEvent OnBankChanged;

    [Header("Player Data")]
    public float bank = 7F;
    public int dayCounter = 7;
    public string truckName = "Seven";
    //public List<Upgrade> unlockedUpgrades;

    private void Awake()
    {
        if (instance) Destroy(gameObject);
        else instance = this;

        StartNewDay();
    }

    public void StartNewDay()
    {
        endDayPanel.gameObject.SetActive(false);
        todaysForecast = WeatherMan.GetForcast(Calendar.GetSeason(dayCounter));
        mainMenuPanel.SetActive(true);

        shoppingSystem.gameObject.SetActive(true);
        shoppingSystem.SetUpShop();
    }

    public void SendPurchases(float cost, List<CartItem> cart)
    {
        // money stuff
        moneySpent = cost;
        bank -= cost;
        OnBankChanged.Invoke();

        purchasedIngredients = new List<CartItem>();
        foreach (var item in cart) purchasedIngredients.Add(item);

        ToMenuSelection();
    }

    public void ToMenuSelection()
    {
        shoppingSystem.gameObject.SetActive(false);
        menuSystem.gameObject.SetActive(true);
        menuSystem.GetIngredientList(purchasedIngredients);
    }

    public void SendMenu(List<Recipe> menu)
    {
        menuList = new List<Recipe>();
        foreach (var recipe in menu) menuList.Add(recipe);

        StartDay();
    }

    public void StartDay()
    {
        if (ScreenFader.instance)
        {
            ScreenFader.instance.ScreenFade(ToTruckTransition, EnableTruck);
        }
        else ToTruckTransition();
        // start animation here
        // send earnings to endofday ui
    }

    void ToTruckTransition()
    {
        weatherFx.TurnOnWeatherFx(todaysForecast);
        menuSystem.gameObject.SetActive(false);
        mainMenuPanel.SetActive(false);
    }

    void EnableTruck()
    {
        truck.SetActive(true);
    }

    public void EndDay()
    {
        truck.SetActive(false);
        weatherFx.ResetAllWeather();
        endDayPanel.gameObject.SetActive(true);
        endDayPanel.LoadEndDay(menuList, todaysForecast, moneySpent);
    }

    public void AddToBank(float amount)
    {
        bank += amount;
        OnBankChanged.Invoke();
    }

    public void SaveThisDay()
    {
        // save
        dayCounter++;
        ScreenFader.instance.ScreenFade(StartNewDay);
    }
}
