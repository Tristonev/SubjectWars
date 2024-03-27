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

    //gain currency
    public void gain(int val)
    {
        currency += val;
        UpdateUI();
    }

    //use currency
    public bool use(int val) 
    {
        if(enoughCurrency(val))
        {
            currency -= val;
            UpdateUI();
            return true;
        }
        else
            return false;
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

    public void useUnitOne()
    {
        use(2);
    }
    public void useUnitTwo()
    {
        use(4);
    }
    public void useUnitThree()
    {
        use(5);
    }

}
