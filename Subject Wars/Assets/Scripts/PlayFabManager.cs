using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayFabManager : MonoBehaviour
{
    [Header("UI")]
    public Text messageText; //text for feedback
    public InputField emailInput; //email input
    public InputField passwordInput; //password input
    // Start is called before the first frame update
    void Start()
    {
        Login();
    }

    void Login() ///Method login will create a login request and send this request to the PlayFab API
    {
        var request = new LoginWithCustomIDRequest { CustomId = SystemInfo.deviceUniqueIdentifier, CreateAccount = true };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }

    void OnSuccess(LoginResult result) //OnSuccess method to show a successful login on the console
    {
        Debug.Log("Successful login/account create!");
    }

    void OnLoginSuccess(LoginResult result) //OnLoginSuccess method to show a successful login on the console and display successful login text to user
    {
        messageText.text = "Logged in!";
        Debug.Log("Successful login");
        StateDataController.email = StateDataController.tempEmail;
    }

    void OnError(PlayFabError error) //OnError method needed for PlayFab API calls
    {
        //This function is a work in progress. The function must exist for the API call. 
    }

    public void RegisterButton() //RegisterButton Method checks for required password length. Then creates a request using the inputed data and register the user with PlayFab API
    {
        if (passwordInput.text.Length < 6)
        {
            messageText.text = "Password too short!";
            return;
        }
        var request = new RegisterPlayFabUserRequest {
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        StateDataController.tempEmail = emailInput.text;
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result) //Method to display a successful register
    {
        messageText.text = "Register and logged in!";
        StateDataController.email = StateDataController.tempEmail;
    }

    public void LoginButton() //LoginButton method to create a login request with user entered data and send the login request to PlayFab API
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text
        };
        StateDataController.tempEmail = emailInput.text;
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }

    public void ResetPasswordButton() //ResetPasswordButton method to send a password reset email to user. Currently the PlayFab API account recovery emails do not work.
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = emailInput.text,
            TitleId = "6D7A6"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }

    void OnPasswordReset(SendAccountRecoveryEmailResult result) //Display text to user that recovery email was sent
    {
        messageText.text = "Password reset mail sent!";
    }
}
