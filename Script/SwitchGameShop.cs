using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SwitchGameShop : MonoBehaviour
{
    public Canvas game;
    public Canvas shop;
    public Canvas result;
    public Canvas currency;
    public Button StartBut;
    bool ingame = false;
    bool inresult = false;
    Color ActualBuilding = Color.blue;
    public void setIngame(bool value)
    {
        ingame = value;
    }
    public void setInresult(bool value)
    {
        inresult = value;
    }
    public void setBuildingColor(Color color)
    {
        ActualBuilding = color;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartBut.onClick.AddListener(() => OnClick());
    }

    // Update is called once per frame
    void Update()
    {
        if (ingame)
        {
            game.enabled = true;
            shop.enabled = false;
            result.enabled = false;
        }
        else if (inresult)
        {
            game.enabled = false;
            shop.enabled = false;
            result.enabled = true;
        }
        else
        {
            game.enabled = false;
            shop.enabled = true;
            result.enabled = false;
        }
    }
    void OnClick()
    {
        ingame = true;
        game.GetComponent<Clicker>().restart(ActualBuilding);
        currency.GetComponent<Currency>().restartIncome();
    }
}
