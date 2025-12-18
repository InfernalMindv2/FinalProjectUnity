using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;



public class TimerGirl : MonoBehaviour
{
    public GameObject settingsPanel, settingsPanel2;
    public GameObject chGameObject;
    public Animator ani;
    public characterDatabase cd;
    bool winHandled = false;
    public GameController test;
    void Start()
    {
        GameController x = FindAnyObjectByType<GameController>();
         test = x.GetComponent<GameController>();
        settingsPanel.SetActive(false);
        settingsPanel2.SetActive(false);
        //StartCoroutine(WaitShuffle(1f));
    }
    void Update()
    {
        winHandled = test.gameOver;
        if (winHandled)
        {
            ApplyAnimation();
            StartCoroutine(WaitShuffle(3));
            settingsPanel2.SetActive(true);
            return;
        }
    }
    private IEnumerator WaitShuffle(float duration)
    {
        yield return new WaitForSeconds(duration);
        
    }
    
    
    void ApplyAnimation()
    {

        gameCharacterScript x = FindAnyObjectByType<gameCharacterScript>();
        chGameObject = x.chGameObject;
        Animator ani2 = chGameObject.GetComponent<Animator>();
        ani = ani2;
        //oriScore = FindAnyObjectByType<SceneController>();
        name = cd.GetCharacterByName(PlayerPrefs.GetString("SelectedCharacter")).characterSprite.name;

        SortingGroup group = chGameObject.GetComponent<SortingGroup>();
        if (group == null)
        {
            group = chGameObject.AddComponent<SortingGroup>();
        }
        group.sortingOrder = 13;







        ani.ResetTrigger("Run");
        ani.ResetTrigger("Attack");
        ani.ResetTrigger("Die");
        ani.ResetTrigger("Jump");
        name = cd.GetCharacterByName(PlayerPrefs.GetString("SelectedCharacter")).characterSprite.name;
        if (name == "clown_export-walk_19")
        {
            //ani.SetTrigger("Rogue_run_01");
            Debug.Log("tmam");
            StartCoroutine(WaitForAnimation(4, "Rogue_run_01"));
        }
        else if (name == "Complete")
        {
            //ani.SetTrigger("Jump");
            Debug.Log("tmam");
            StartCoroutine(WaitForAnimation(4, "Jump"));
        }
        else
        {
            //ani.SetTrigger("Run");
            Debug.Log("tmam");
            StartCoroutine(WaitForAnimation(4, "Run"));
        }
    }
    private IEnumerator WaitForAnimation(float duration, string x)
    {
        ani.SetTrigger(x);
        yield return new WaitForSeconds(duration);
    }
    

}


