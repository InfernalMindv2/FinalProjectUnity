using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using System.Collections.Generic;

public class gameCharacterScript : MonoBehaviour
{
    
    public Button logOut;
    public TextMeshProUGUI textMeshPro;
    public characterDatabase cd;
    public GameObject chGameObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chGameObject = GetComponent<GameObject>();
        textMeshPro.text =  PlayerPrefs.GetString("Nickname");
        Debug.Log(PlayerPrefs.GetString("SelectedCharacter"));
        string name = cd.GetCharacterByName(PlayerPrefs.GetString("SelectedCharacter")).characterSprite.name;
        //chGameObject = Resources.Load<GameObject>("UsedCharacter/" + name);
        //rb.bodyType = RigidbodyType2D.Kinematic;
        Debug.Log(name);
        if(name == "clown_export-walk_19")
        {
            chGameObject = Instantiate(Resources.Load<GameObject>("UsedCharacter/" + name));
            Rigidbody2D rb = chGameObject.GetComponent<Rigidbody2D>();
            chGameObject.transform.position = new Vector3(-10.44f, 2.84f, 0f);
            chGameObject.transform.localScale = new Vector3(0.25f, 0.25f, 0f);
        }
        else if(name == "Complete")
        {
            chGameObject = Instantiate(Resources.Load<GameObject>("UsedCharacter/" + name)
                , new Vector3(-10.44f, 3.13f, 0f)
            , Quaternion.identity);
            Rigidbody2D rb = chGameObject.GetComponent<Rigidbody2D>();

            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
            Animator anim = chGameObject.GetComponent<Animator>();
            if (anim != null)
            {
                anim.applyRootMotion = false;
            }
            //chGameObject.transform.localScale = new Vector3(1.75f, 1.75f, 0f);
        }
        else
        {
            chGameObject = Instantiate(Resources.Load<GameObject>("UsedCharacter/" + name)
                , new Vector3(-10.44f, 2.27f, 0f)
            , Quaternion.identity);
            Rigidbody2D rb = chGameObject.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Kinematic;
            chGameObject.transform.position = new Vector3(-10.44f, 2.27f, 0f);
            chGameObject.transform.localScale = new Vector3(2f, 2f, 0f);
        }
        SortingGroup group = chGameObject.GetComponent<SortingGroup>();
        if (group == null)
        {
            group = chGameObject.AddComponent<SortingGroup>();
        }

        group.sortingOrder = -1;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.sortingLayerName = "GameBoard";
            sr.sortingOrder = -1;
        }

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
    public void OnClickBack()
    {
        SceneManager.LoadScene("DashBoardScene");
    }
    public void OnClickGameScene()
    {
        SceneManager.LoadScene("gameScene");
    }
    public void OnClickPuzzle()
    {
        SceneManager.LoadScene("selectImage");
    }
    public void OnClickMemory()
    {
        SceneManager.LoadScene("MemoryScene");
    }
    public void OnClicGirl()
    {
        SceneManager.LoadScene("girlFlyScene");
    }
}
