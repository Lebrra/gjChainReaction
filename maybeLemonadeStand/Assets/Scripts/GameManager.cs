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
    float earnings = 7F;

    [Header("Day Menu Systems")]
    public GameObject mainMenuPanel;
    public ShoppingCart shoppingSystem;
    public MenuSelector menuSystem;

    [HideInInspector]
    public UnityEvent OnBankChanged;

    [Header("Player Data")]
    public float bank = 7F;
    public int dayCounter = 7;
    public string truckName = "Seven";
    public List<Upgrade> unlockedUpgrades;

    private void Awake()
    {
        if (instance) Destroy(gameObject);
        else instance = this;

        StartNewDay();

        Debug.Log(Calendar.DateToString(Calendar.GetDate(1700)));
        Debug.Log(Calendar.DateToString(Calendar.GetDate(45)));
        Debug.Log(Calendar.DateToString(Calendar.GetDate(4)));
    }

    public void StartNewDay()
    {
        todaysForecast = WeatherMan.GetForcast(Calendar.GetSeason(dayCounter));
        mainMenuPanel.SetActive(true);

        shoppingSystem.gameObject.SetActive(true);
        shoppingSystem.SetUpShop();
    }

    public void SendPurchases(float cost, List<CartItem> cart)
    {
        // money stuff
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
            ScreenFader.instance.ScreenFade(ToTruckTransition);
        }
        else ToTruckTransition();
        // start animation here
        // send earnings to endofday ui
    }

    void ToTruckTransition()
    {
        menuSystem.gameObject.SetActive(false);
        earnings = MoneyLogic.GetDailyEarnings(menuList, todaysForecast);
        bank += earnings;
        Debug.Log("MAKING BANK: " + bank);
        OnBankChanged.Invoke();
        mainMenuPanel.SetActive(false);
    }
}
