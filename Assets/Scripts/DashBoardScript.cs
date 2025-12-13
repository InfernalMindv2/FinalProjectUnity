using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.SceneManagement;
public class DashBoardScript : MonoBehaviour
{
    public Button logOut;
    public TextMeshProUGUI textMeshPro;
    public Image im;
    public characterDatabase cd;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textMeshPro.text = "Welcome : " + PlayerPrefs.GetString("Email")+'\n'
            + PlayerPrefs.GetString("Nickname");
        im.sprite = cd.GetCharacterByName(PlayerPrefs.GetString("SelectedCharacter")).characterSprite;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickLogOut()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("SampleScene");
    }
    public void OnClickGo()
    {
        SceneManager.LoadScene("gameScene");
    }
}
