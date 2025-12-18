using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenuGirl : MonoBehaviour
{
    
    void Start()
    {
        CloseSettings();
        
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            OpenSettings();

        }

    }

    

    public void ResetProgress()
    {
        SceneManager.LoadScene("selectImage");
        Debug.Log("Progress Reset");
    }
    public void ResetProgressMemory()
    {
        SceneManager.LoadScene("MemoryScene");
        Debug.Log("Progress Reset");
    }
    public void ResetProgressGirl()
    {
        SceneManager.LoadScene("girlFlyScene");
        Debug.Log("Progress Reset");
    }
    public GameObject settingsPanel;

    public void OpenSettings()
    {
        GameController.instance.isPaused = true;
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        GameController.instance.isPaused = false;
        settingsPanel.SetActive(false);
    }
}
