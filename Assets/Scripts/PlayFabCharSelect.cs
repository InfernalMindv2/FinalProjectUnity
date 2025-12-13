using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PlayFabCharSelect : MonoBehaviour
{
    public Image selectedCharacter;
    public TMP_InputField Input;
     void Start()
    {
        bool checkSelected = PlayerPrefs.HasKey("SelectedCharacter")
            ,Nickname = PlayerPrefs.HasKey("Nickname");
        if(checkSelected && Nickname)
            SceneManager.LoadScene("DashBoardScene");
    }
    public void SelectCharacter(Image characterImg)
    {
        Debug.Log(characterImg.sprite.name);
        selectedCharacter = characterImg; // store the selected character
    }
    public void CompleteRegister()
    {
        if (!ValidateNickname(Input.text))
            return;
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                { "SelectedCharacter", selectedCharacter.sprite.name },
                { "Nickname", Input.text }
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnSaveSuccess, OnSaveError);
    }
    private void OnSaveSuccess(UpdateUserDataResult result)
    {
        Debug.Log("Player data saved successfully.");
        PlayerPrefs.SetString("SelectedCharacter", selectedCharacter.sprite.name);
        PlayerPrefs.SetString("Nickname", Input.text);
        PlayerPrefs.Save();
        SceneManager.LoadScene("DashBoardScene");
    }

    private void OnSaveError(PlayFabError error)
    {
        Debug.LogError("Failed to save data: " + error.ErrorMessage);
    }

    public bool ValidateNickname(string nickname)
    {
        // 1. Check empty or whitespace
        if (string.IsNullOrWhiteSpace(nickname))
            return false;

        // 2. Length check
        if (nickname.Length < 3 || nickname.Length > 16)
            return false;

        return true; // nickname is valid
    }
    public void OnClickLogOut()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("SampleScene");
    }
}
