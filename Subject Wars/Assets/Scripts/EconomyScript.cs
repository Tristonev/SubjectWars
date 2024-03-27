using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.Economy;
using Unity.Services.Economy.Model;

public class EconomyScript : MonoBehaviour
{
    public async void Start()
    {
        await UnityServices.InitializeAsync();
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }
        // Replace with currency

    // Start is called before the first frame update
    //void Start()
    //{    
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
