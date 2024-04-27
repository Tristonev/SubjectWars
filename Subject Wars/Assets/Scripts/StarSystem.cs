using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarSystem : MonoBehaviour
{
    public Text StarTextNumber; //currency text UI
    public int defaultCurrency; //default currency value
    public int currency; //current currency value

    //intialization
    public void Init()
    {
        currency = defaultCurrency;
        UpdateUI();
    }

    void Start()
    {
        AddStars();
    }

    //gain currency
    public void gain(int val)
    {
        if(currency < defaultCurrency)
        {
            currency += val;
            UpdateUI();
        }
    }

    //use currency
    public void use(int val) 
    {
        currency -= val;
        UpdateUI();
    }

    //check for enough currency
    bool enoughCurrency(int val)
    {
        if(val <= currency)
        {
            return true;
        }
        else 
        { 
            return false; 
        }
    }

    //update the text ui
    void UpdateUI()
    {
        StarTextNumber.text = currency.ToString();
    }

    public void AddStars()
    {
        StartCoroutine(AddStarRoutine());
        IEnumerator AddStarRoutine()
        {
            WaitForSeconds waitTime = new WaitForSeconds(1f);
            while(true)
            {
                gain(1);
                UpdateUI();
                yield return waitTime;
            }
        }
    }
    public void useUnitOne()
    {
        if(enoughCurrency(2) == false)
        {
            return;
        }
        else
        {
            use(2);
        }
    }
    public void useUnitTwo()
    {
        if(enoughCurrency(4) == false)
        {
            return;
        }
        else
        {
            use(4);
        }
    }
    public void useUnitThree()
    {
        if(enoughCurrency(5) == false)
        {
            return;
        }
        else
        {
            use(5);
        }
    }

}
