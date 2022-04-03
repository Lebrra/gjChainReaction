using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject closeButton;

    public GameObject recipePanel;
    public GameObject truckPanel;
    public GameObject calandarPanel;
    public GameObject settingsPanel;

    public TMPro.TextMeshProUGUI bankText;

    private void Start()
    {
        CloseAll();
        if (GameManager.instance)
        {
            GameManager.instance.OnBankChanged.AddListener(UpdateBankUI);
            UpdateBankUI();
        }
    }

        public void OpenRecipePanel()
    {
        CloseAll();
        closeButton.SetActive(true);
        recipePanel.SetActive(true);
    }

    public void OpenTruckPanel()
    {
        CloseAll();
        closeButton.SetActive(true);
        truckPanel.SetActive(true);
    }

    public void OpenCalandarPanel()
    {
        CloseAll();
        closeButton.SetActive(true);
        calandarPanel.SetActive(true);
    }

    public void OpenSettingsPanel()
    {
        CloseAll();
        closeButton.SetActive(true);
        settingsPanel.SetActive(true);
    }

    public void CloseAll()
    {
        recipePanel.SetActive(false);
        truckPanel.SetActive(false);
        calandarPanel.SetActive(false);
        settingsPanel.SetActive(false);

        closeButton.SetActive(false);
    }

    public void UpdateBankUI()
    {
        bankText.text = "$" + GameManager.instance.bank.ToString();
    }
}
