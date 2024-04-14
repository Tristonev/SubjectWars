using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LossCountText : MonoBehaviour, IDataPersistence
{
    private int lossCount = 0;

    private TextMeshProUGUI lossCountText;

    private void Awake()
    {
        lossCountText = this.GetComponent<TextMeshProUGUI>();
        
    }

    public void LoadData(UserData data)
    {
        this.lossCount = data.lossCount;

        if (StateDataController.losses == -1)
        {
            StateDataController.losses = this.lossCount;
        }

        if (this.lossCount != StateDataController.losses)
        {
            this.lossCount++;
            StateDataController.losses = this.lossCount;
        }
    }

    public void SaveData(ref UserData data)
    {
        data.lossCount = this.lossCount;
    }


    public void OnPlayerLoss()
    {
        lossCount++;
    }

    // Update is called once per frame
    private void Update()
    {
        lossCountText.text = "" + lossCount;
    }
}
