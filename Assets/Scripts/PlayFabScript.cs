using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayFabScript : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public InputField emailInput;
    public InputField passwordInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(PlayerPrefs.GetInt("LoggedIn")==1 
            && PlayerPrefs.HasKey("SelectedCharacter")
            && PlayerPrefs.HasKey("Nickname"))
        {
            LoginButtonWithData();
            //SceneManager.LoadScene("DashBoardScene");
        }
        else if(PlayerPrefs.GetInt("LoggedIn") == 1)
        {
            LoginButtonWithData();
            //SceneManager.LoadScene("CharacterSelection");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        return System.Text.RegularExpressions.Regex.IsMatch(email, pattern);
    }

    public void RegisterButton()
    {
        if (passwordInput.text.Length < 6)
        {
            messageText.text = "Password is too short :D";
            return;
        }
        if(!IsValidEmail(emailInput.text))
        {
            messageText.text = "Not valid Email !";
            return;
        }
        var request = new RegisterPlayFabUserRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request
   ,OnRegisterSucess,OnError);
    }

    
    public void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSucess, OnError);
    }
    public void LoginButtonWithData()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = PlayerPrefs.GetString("Email"),
            Password = PlayerPrefs.GetString("Password")
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSucessLoggedIn, OnError);
    }

    public void GetUserAttributes()
    {
        var request = new GetUserDataRequest
        {
            PlayFabId = PlayFabClientAPI.IsClientLoggedIn() ? null : "", // optional if current player
            Keys = null // null = retrieve all keys
        };

        PlayFabClientAPI.GetUserData(request, OnGetDataSuccess, OnGetDataError);
    }

    public void ResetPasswordButton()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = emailInput.text,
            TitleId = "1E519D"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }




    public void OnRegisterSucess(RegisterPlayFabUserResult result)
    {
        messageText.text = "Registered and loggin in <3";
    }
    public void OnError(PlayFabError result)
    {
        messageText.text = result.ErrorMessage;
        Debug.Log(result.GenerateErrorReport());
    }
    
    public void OnLoginSucess(LoginResult result)
    {
        messageText.text = "Logged In!";
        Debug.Log("Successful login!");
        PlayerPrefs.SetInt("LoggedIn",1);
        PlayerPrefs.SetString("Email", emailInput.text);
        PlayerPrefs.SetString("Password", passwordInput.text);
        GetUserAttributes();
        PlayerPrefs.Save();
    }
    public void OnLoginSucessLoggedIn(LoginResult result)
    {
        messageText.text = "Logged In!";
        
        Debug.Log("Successful login!");
        GetUserAttributes();
        
        
    }
    public void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        messageText.text = "Password reset mail sent!";
    }
    private void OnGetDataSuccess(GetUserDataResult result)
    {
        Debug.Log("User data retrieved!");

        
            foreach (var kvp in result.Data)
            {
                string key = kvp.Key; // Attribute name
                string value = kvp.Value.Value; // Attribute value
                PlayerPrefs.SetString(key, value);
                Debug.Log($"Attribute: {key} = {value}");
            }
            if (PlayerPrefs.GetInt("LoggedIn") == 1
            && PlayerPrefs.HasKey("SelectedCharacter")
            && PlayerPrefs.HasKey("Nickname"))
                SceneManager.LoadScene("DashBoardScene");
            else if (PlayerPrefs.GetInt("LoggedIn") == 1)
                SceneManager.LoadScene("CharacterSelection");
        

    }

    private void OnGetDataError(PlayFabError error)
    {
        Debug.LogError("Error retrieving user data: " + error.GenerateErrorReport());
    }
}
