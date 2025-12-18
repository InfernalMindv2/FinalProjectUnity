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

public class timerPuzzle : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public bool Score;
    public float timeRemaining = 60f;
    public bool timerIsRunning = true;
    public GameObject settingsPanel, settingsPanel2;
    public GameObject chGameObject;
    public Animator ani;
    public characterDatabase cd;
    public string name1;
    public List<Transform> piecesNow;
    bool starting = false;
    bool winHandled = false;

    void Start()
    {
        GameManager test = GetComponent<GameManager>();
        piecesNow = test.pieces;
        settingsPanel.SetActive(false);
        settingsPanel2.SetActive(false);
        StartCoroutine(WaitShuffle(1f));
    }
    void Update()
    {

        GameManager test = GetComponent<GameManager>();
        Score = test.CheckCompletion();
        if (!timerIsRunning)
            return;
        if (Score && starting && !winHandled)
        {
            winHandled = true;
            timerIsRunning = false;
            ApplyAnimation();
            return;
        }
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
        else
        {
            timerIsRunning = false;
            timeRemaining = 0;
            ApplyAnimationFalse();
            DisplayTime(0);
            Debug.Log("Timer finished!");
            return;
        }
    }
    private IEnumerator WaitShuffle(float duration)
    {
        yield return new WaitForSeconds(1);
        starting = true;
    }
    void ApplyAnimationFalse()
    {
        

        gameCharacterScript x = FindAnyObjectByType<gameCharacterScript>();
        chGameObject = x.chGameObject;
        Animator ani2 = chGameObject.GetComponent<Animator>();
        ani = ani2;
        //oriScore = FindAnyObjectByType<SceneController>();
        name = cd.GetCharacterByName(PlayerPrefs.GetString("SelectedCharacter")).characterSprite.name;

        if (name == "clown_export-walk_19")
        {
            //ani.SetTrigger("attack");
            Debug.Log("tmam2");
            StartCoroutine(WaitForAnimationDie(4, "attack"));
        }
        else if (name == "Complete")
        {
            //ani.SetTrigger("Die");
            Debug.Log("tmam");
            StartCoroutine(WaitForAnimationDie(4, "Die"));
        }
        else
        {
            //ani.SetTrigger("Diiee");
            Debug.Log("tmam");
            StartCoroutine(WaitForAnimationDie(4, "Diiee"));
        }

    }
    void DisplayTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        timerText.text = $"Time Elapsed : {minutes:00}:{seconds:00}";
    }
    void ApplyAnimation()
    {
        
            gameCharacterScript x = FindAnyObjectByType<gameCharacterScript>();
        chGameObject = x.chGameObject;
        Animator ani2 = chGameObject.GetComponent<Animator>();
        ani = ani2;
        //oriScore = FindAnyObjectByType<SceneController>();
        name = cd.GetCharacterByName(PlayerPrefs.GetString("SelectedCharacter")).characterSprite.name;








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
    private IEnumerator WaitForAnimation(float duration,string x)
    {
        ani.SetTrigger(x);
        yield return new WaitForSeconds(duration);
        for (int row = 0; row < 9; row++)
        {

            Vector3 pos = piecesNow[row].localPosition;
            pos.z = -2.07f; // set your desired Z
            piecesNow[row].localPosition = pos;
        }
        settingsPanel2.SetActive(true);
    }
    private IEnumerator WaitForAnimationDie(float duration , string x)
    {
        ani.SetTrigger(x);
        yield return new WaitForSeconds(duration);
        for (int row = 0; row < 9; row++)
        {

            Vector3 pos = piecesNow[row].localPosition;
            pos.z = -2.07f; // set your desired Z
            piecesNow[row].localPosition = pos;
        }
        settingsPanel.SetActive(true);
    }

}
