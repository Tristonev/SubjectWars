using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinCountText : MonoBehaviour, IDataPersistence
{
    private int winCount = 0;

    private TextMeshProUGUI winCountText;

    private void Awake()
    {
        winCountText = this.GetComponent<TextMeshProUGUI>();
        
    }

    public void LoadData(GameData data)
    {
        this.winCount = data.winCount;
        if (StateDataController.wins == -1)
        {
            StateDataController.wins = this.winCount;
            Debug.Log("Set State");
        }

        else if (this.winCount < StateDataController.wins)
        {
            this.winCount++;
            StateDataController.wins = this.winCount;
            Debug.Log("Win Count Updated");
        }
        Debug.Log(winCount);
        Debug.Log(StateDataController.wins);
    }

    public void SaveData(ref GameData data)
    {
        data.winCount = this.winCount;
    }

    public void OnPlayerWin()
    {
        winCount++;
    }

    // Update is called once per frame
    private void Update()
    {
        winCountText.text = "" + winCount;
    }
}
