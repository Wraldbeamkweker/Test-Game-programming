using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public GameObject currency;
    public GameObject app;
    public Canvas result;
    public Image ennemy;
    public Image boss;
    public Text timerRed;
    public Text timerOrange;
    public Text textF1;
    public Text textF2;
    public Text textF3;
    public Button buttonF1;
    public Button buttonF2;
    public Button buttonF3;
    Color ActualColorF1;
    Color ActualColorF2;
    Color ActualColorF3;
    int BuildNeedF1;
    int BuildNeedF2;
    int BuildNeedF3;
    int ActualBuildF1;
    int ActualBuildF2;
    int ActualBuildF3;
    int cibleOrange;
    float RedTimer;
    float OrangeTimer;
    bool rewardF1 = false;
    bool rewardF2 = false;
    bool rewardF3 = false;
    bool reward = false;
    bool gamelaunch;
    public void restart(Color building)
    {
        ActualColorF1 = building;
        ActualColorF1.a = 0.1f;
        ActualColorF2 = building;
        ActualColorF2.a = 0.1f;
        ActualColorF3 = building;
        ActualColorF3.a = 0.1f;
        BuildNeedF1 = 3;
        BuildNeedF2 = 4;
        BuildNeedF3 = 5;
        ActualBuildF1 = 0;
        ActualBuildF2 = 0;
        ActualBuildF3 = 0;
        RedTimer = 2000;
        rewardF1 = false;
        rewardF2 = false;
        rewardF3 = false;
        reward = false;
        buttonF1.GetComponent<Image>().color = ActualColorF1;
        textF1.text = ActualBuildF1+"/"+BuildNeedF1;
        buttonF2.GetComponent<Image>().color = ActualColorF2;
        textF2.text = ActualBuildF2+"/"+BuildNeedF2;
        buttonF3.GetComponent<Image>().color = ActualColorF3;
        textF3.text = ActualBuildF3+"/"+BuildNeedF3;
        gamelaunch = true;
        cibleOrange = NewAttack();
    }
    int NewAttack()
    {
        OrangeTimer = 400;
        int NewAssaut = Random.Range(1,3);
        while (((NewAssaut == 1 && rewardF1) || (NewAssaut == 2 && rewardF2) || (NewAssaut == 3 && rewardF3))&&!reward)
        {
            NewAssaut = Random.Range(1,3);
        }
        return NewAssaut;
    }
    void GameOver()
    {
        app.GetComponent<GestionnaireCanvas>().setIngame(false);
        app.GetComponent<GestionnaireCanvas>().setInresult(true);
        result.GetComponent<Result>().setResult(false);
        gamelaunch = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        buttonF1.onClick.AddListener(() => Build(1));
        buttonF2.onClick.AddListener(() => Build(2));
        buttonF3.onClick.AddListener(() => Build(3));
    }

    // Update is called once per frame
    void Update()
    {
        if (rewardF1 && rewardF2 && rewardF3 && !reward)
        {
            currency.GetComponent<CurrencyShop>().addCurrency(400);
            reward = true;
            app.GetComponent<GestionnaireCanvas>().setIngame(false);
            app.GetComponent<GestionnaireCanvas>().setInresult(true);
            result.GetComponent<Result>().setResult(true);
            gamelaunch = false;
        }
        if (gamelaunch)
        {
            RedTimer--;
            OrangeTimer--;
            timerRed.text = (int)(RedTimer/6000)+":"+(int)((RedTimer%6000)/100);
            timerOrange.text = (int)(OrangeTimer/6000)+":"+(int)((OrangeTimer%6000)/100)+" On floor "+cibleOrange;
            /*if (cibleOrange ==  1)
            {
                ennemy.transform.position = new Vector3(buttonF1.transform.position.x-(timerOrange/100),ennemy.transform.position.y,ennemy.transform.position.z);
            }
            if (cibleOrange == 2)
            {
                ennemy.transform.position = new Vector3(buttonF2.transform.position.x-(timerOrange/100),ennemy.transform.position.y,ennemy.transform.position.z);
            }
            if (cibleOrange == 3)
            {
                ennemy.transform.position = new Vector3(buttonF3.transform.position.x-(timerOrange/100),ennemy.transform.position.y,ennemy.transform.position.z);
            }*/
            if (RedTimer <= 0 || (OrangeTimer <= 0 && cibleOrange == 1 && !rewardF1) || (OrangeTimer <= 0 && cibleOrange == 2 && !rewardF2) || (OrangeTimer <= 0 && cibleOrange == 3 && !rewardF3))
            {
                GameOver();
            }
        }
    }
    void Build(int number)
    {
        if (number == 1 && ActualBuildF1<BuildNeedF1)
        {
               ActualBuildF1++;
               ActualColorF1.a = (100/BuildNeedF1)*0.01f*ActualBuildF1;
               buttonF1.GetComponent<Image>().color = ActualColorF1;
               textF1.text = ActualBuildF1+"/"+BuildNeedF1;
        }
        else if (number == 1 && !rewardF1)
        {
            currency.GetComponent<CurrencyShop>().addCurrency(200);
            rewardF1 = true;
            if (cibleOrange == 1)
            {
                cibleOrange = NewAttack();
            }
        }
        if (number == 2 && ActualBuildF2<BuildNeedF2)
        {
            ActualBuildF2++;
            ActualColorF2.a = (100/BuildNeedF2)*0.01f*ActualBuildF2;
            buttonF2.GetComponent<Image>().color = ActualColorF2;
            textF2.text = ActualBuildF2+"/"+BuildNeedF2;
        }
        else if (number == 2 && !rewardF2)
        {
            currency.GetComponent<CurrencyShop>().addCurrency(200);
            rewardF2 = true;
            if (cibleOrange == 2)
            {
                cibleOrange = NewAttack();
            }
        }
        if (number == 3 && ActualBuildF3<BuildNeedF3)
        {
            ActualBuildF3++;
            ActualColorF3.a = (100/BuildNeedF3)*0.01f*ActualBuildF3;
            buttonF3.GetComponent<Image>().color = ActualColorF3;
            textF3.text = ActualBuildF3+"/"+BuildNeedF3;
        }
        else if (number == 3 && !rewardF3)
        {
            currency.GetComponent<CurrencyShop>().addCurrency(200);
            rewardF3 = true;
            if (cibleOrange == 3)
            {
                cibleOrange = NewAttack();
            }
        }
    }
}
