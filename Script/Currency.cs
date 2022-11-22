using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{
    public GameObject App;
    public Camera background;
    public Text CurrencyText;
    public Text IncomeText;
    public Button ChangeColorBack;
    public Button ChangeColorBuild;
    public Toggle KeepBack;
    public Toggle KeepBuild;
    int currency = 0;
    int incomePart = 0;
    Color Actualbackground = Color.white;
    public void addCurrency(int income)
    {
        currency += income;
        incomePart += income;
    }
    public void restartIncome()
    {
        incomePart = 0;
    }
    public void NewColor()
    {
        if (!KeepBack.isOn)
        {
            ChangeColorBack.GetComponent<Image>().color = new Color(Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f));
        }
        if (!KeepBuild.isOn)
        {
            ChangeColorBuild.GetComponent<Image>().color = new Color(Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f));
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        KeepBack.isOn = false;
        KeepBuild.isOn = false;
        ChangeColorBack.onClick.AddListener(() => OnClick(1));
        ChangeColorBuild.onClick.AddListener(() => OnClick(2));
    }

    // Update is called once per frame
    void Update()
    {
        CurrencyText.text = ""+currency;
        background.backgroundColor = Actualbackground;
        IncomeText.text = ""+incomePart;
    }
    void OnClick(int type)
    {
        if (type == 1)
        {
            if (currency >= 5000)
            {
                Actualbackground = ChangeColorBack.GetComponent<Image>().color;
                ChangeColorBack.GetComponent<Image>().color = new Color(Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f));
                currency -= 5000;
                KeepBack.isOn = false;
            }
        }
        if (type == 2)
        {
            if (currency >= 5000)
            {
                App.GetComponent<SwitchGameShop>().setBuildingColor(ChangeColorBuild.GetComponent<Image>().color);
                ChangeColorBuild.GetComponent<Image>().color = new Color(Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f));
                currency -= 5000;
                KeepBuild.isOn = false;
            }
        }
    }
}
