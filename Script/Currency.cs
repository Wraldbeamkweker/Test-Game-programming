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
    // Start is called before the first frame update
    void Start()
    {
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
            if (currency >= 1000)
            {
                Actualbackground = ChangeColorBack.GetComponent<Image>().color;
                currency -= 1000;
            }
        }
        if (type == 2)
        {
            if (currency >= 1000)
            {
                App.GetComponent<SwitchGameShop>().setBuildingColor(ChangeColorBuild.GetComponent<Image>().color);
                currency -= 1000;
            }
        }
    }
}
