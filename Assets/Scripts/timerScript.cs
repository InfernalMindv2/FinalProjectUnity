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

public class timerScript : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public int Score;
    public float timeRemaining = 60f;
    public bool timerIsRunning = true;
    public GameObject settingsPanel, settingsPanel2;
    public GameObject chGameObject;
    public SceneController oriScore;
    public Animator ani;
    public characterDatabase cd;
    public string name1;
    void Start()
    {
        settingsPanel.SetActive(false);
        settingsPanel2.SetActive(false);
    }
    void Update()
    {
        //Debug.Log(oriScore._score);
        Score = oriScore._score;
        if (!timerIsRunning)
            return;
        if(Score==4)
        {
            timerIsRunning = false;
            ApplyAnimation();
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
        }
    }
    void ApplyAnimationFalse()
    {
        gameCharacterMemory x = FindAnyObjectByType<gameCharacterMemory>();
        chGameObject = x.chGameObject;
        Animator ani2 = chGameObject.GetComponent<Animator>();
        ani = ani2;
        oriScore = FindAnyObjectByType<SceneController>();
        name = cd.GetCharacterByName(PlayerPrefs.GetString("SelectedCharacter")).characterSprite.name;

        if (name == "clown_export-walk_19")
        {
            ani.SetTrigger("attack");
            Debug.Log("tmam2");
            StartCoroutine(WaitForAnimationDie(4));
        }
        else if (name == "Complete")
        {
            ani.SetTrigger("Die");
            Debug.Log("tmam");
            StartCoroutine(WaitForAnimationDie(4));
        }
        else
        {
            ani.SetTrigger("Diiee");
            Debug.Log("tmam");
            StartCoroutine(WaitForAnimationDie(4));
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

        gameCharacterMemory x = FindAnyObjectByType<gameCharacterMemory>();
        chGameObject = x.chGameObject;
        Animator ani2 = chGameObject.GetComponent<Animator>();
        ani = ani2;
        oriScore = FindAnyObjectByType<SceneController>();
        name = cd.GetCharacterByName(PlayerPrefs.GetString("SelectedCharacter")).characterSprite.name;

        







        name = cd.GetCharacterByName(PlayerPrefs.GetString("SelectedCharacter")).characterSprite.name;
        if (name == "clown_export-walk_19")
        {
            ani.SetTrigger("Rogue_run_01");
            Debug.Log("tmam");
            StartCoroutine(WaitForAnimation(4));
        }
        else if (name == "Complete")
        {
            ani.SetTrigger("Jump");
            Debug.Log("tmam");
            StartCoroutine(WaitForAnimation(4));
        }
        else
        {
            ani.SetTrigger("Run");
            Debug.Log("tmam");
            StartCoroutine(WaitForAnimation(4));
        }
    }
    private IEnumerator WaitForAnimation(float duration)
    {
        yield return new WaitForSeconds(duration);
        settingsPanel2.SetActive(true);
    }
    private IEnumerator WaitForAnimationDie(float duration)
    {
        yield return new WaitForSeconds(duration);
        settingsPanel.SetActive(true);
    }

}
