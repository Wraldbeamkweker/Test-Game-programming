using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Clicker : MonoBehaviour
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
    public int BuildNeedF1;
    public int BuildNeedF2;
    public int BuildNeedF3;
    public Button buttonF1;
    public Button buttonF2;
    public Button buttonF3;
    Color ActualColorF1;
    Color ActualColorF2;
    Color ActualColorF3;
    int ActualBuildF1;
    int ActualBuildF2;
    int ActualBuildF3;
    float RedTimer;
    float OrangeTimer;
    int cibleOrange;
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
        ActualBuildF1 = 0;
        ActualBuildF2 = 0;
        ActualBuildF3 = 0;
        RedTimer = 2000;
        OrangeTimer = 400;
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
        int NewAssaut = Random.Range(1,3);
        if (NewAssaut == 1 && rewardF1)
        {
            NewAssaut = 2;
        }
        if (NewAssaut == 2 && rewardF2)
        {
            NewAssaut = 3;
        }
        if (NewAssaut == 3 && rewardF3)
        {
            NewAssaut = 1;
        }
        return NewAssaut;
    }
    // Start is called before the first frame update
    void Start()
    {
        buttonF1.onClick.AddListener(() => OnClick(1));
        buttonF2.onClick.AddListener(() => OnClick(2));
        buttonF3.onClick.AddListener(() => OnClick(3));
        cibleOrange = NewAttack();
    }

    // Update is called once per frame
    void Update()
    {
        if (rewardF1 && rewardF2 && rewardF3 && !reward)
        {
            currency.GetComponent<Currency>().addCurrency(400);
            reward = true;
            app.GetComponent<SwitchGameShop>().setIngame(false);
            app.GetComponent<SwitchGameShop>().setInresult(true);
            result.GetComponent<Result>().setResult(true);
            gamelaunch = false;
        }
        if (gamelaunch)
        {
            RedTimer--;
            OrangeTimer--;
            int RedMin = (int)(RedTimer/6000);
            int RedSec = (int)((RedTimer%6000)/100);
            timerRed.text = RedMin+":"+RedSec;
            int OrangeMin = (int)(OrangeTimer/6000);
            int OrangeSec = (int)((OrangeTimer%6000)/100);
            timerOrange.text = OrangeMin+":"+OrangeSec+" On floor "+cibleOrange;
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
            if (RedTimer <= 0)
            {
                app.GetComponent<SwitchGameShop>().setIngame(false);
                app.GetComponent<SwitchGameShop>().setInresult(true);
                result.GetComponent<Result>().setResult(false);
                RedTimer = 2000;
                gamelaunch = false;
            }
            if (OrangeTimer <= 0)
            {
                if (cibleOrange == 1 && !rewardF1)
                {
                    app.GetComponent<SwitchGameShop>().setIngame(false);
                    app.GetComponent<SwitchGameShop>().setInresult(true);
                    result.GetComponent<Result>().setResult(false);
                    gamelaunch = false;
                }
                if (cibleOrange == 2 && !rewardF2)
                {
                    app.GetComponent<SwitchGameShop>().setIngame(false);
                    app.GetComponent<SwitchGameShop>().setInresult(true);
                    result.GetComponent<Result>().setResult(false);
                    gamelaunch = false;
                }
                if (cibleOrange == 3 && !rewardF3)
                {
                    app.GetComponent<SwitchGameShop>().setIngame(false);
                    app.GetComponent<SwitchGameShop>().setInresult(true);
                    result.GetComponent<Result>().setResult(false);
                    gamelaunch = false;
                }
                OrangeTimer = 400;
            }
        }
    }
    void OnClick(int number)
    {
        if (number == 1)
        {
            if (ActualBuildF1<BuildNeedF1)
            {
               ActualBuildF1++;
               int AlphaLevel = 100/BuildNeedF1;
               ActualColorF1.a = AlphaLevel*ActualBuildF1;
               buttonF1.GetComponent<Image>().color = ActualColorF1;
               textF1.text = ActualBuildF1+"/"+BuildNeedF1;
            }
            if (ActualBuildF1 == BuildNeedF1 && !rewardF1)
            {
                currency.GetComponent<Currency>().addCurrency(200);
                rewardF1 = true;
                if (cibleOrange == 1)
                {
                    cibleOrange = NewAttack();
                    OrangeTimer = 400;
                }
            }
        }
        if (number == 2)
        {
            if (ActualBuildF2<BuildNeedF2)
            {
                ActualBuildF2++;
                int AlphaLevel = 100/BuildNeedF2;
                ActualColorF2.a = AlphaLevel*ActualBuildF2;
                buttonF2.GetComponent<Image>().color = ActualColorF2;
                textF2.text = ActualBuildF2+"/"+BuildNeedF2;
            }
            if (ActualBuildF2 == BuildNeedF2 && !rewardF2)
            {
                currency.GetComponent<Currency>().addCurrency(200);
                rewardF2 = true;
                if (cibleOrange == 2)
                {
                    cibleOrange = NewAttack();
                    OrangeTimer = 400;
                }
            }
        }
        if (number == 3)
        {
            if (ActualBuildF3<BuildNeedF3)
            {
                ActualBuildF3++;
                int AlphaLevel = 100/BuildNeedF3;
                ActualColorF3.a = AlphaLevel*ActualBuildF3;
                buttonF3.GetComponent<Image>().color = ActualColorF3;
                textF3.text = ActualBuildF3+"/"+BuildNeedF3;
            }
            if (ActualBuildF3 == BuildNeedF3 && !rewardF3)
            {
                currency.GetComponent<Currency>().addCurrency(200);
                rewardF3 = true;
                if (cibleOrange == 3)
                {
                    cibleOrange = NewAttack();
                    OrangeTimer = 400;
                }
            }
        }
    }
}
