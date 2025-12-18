using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenuMemory : MonoBehaviour
{
    public Toggle volumeToggle;
    void Start()
    {
        CloseSettings();
        // Load saved volume setting
        int volumeOn = PlayerPrefs.GetInt("VolumeOn", 1);
        volumeToggle.isOn = volumeOn == 1;
        AudioListener.volume = volumeToggle.isOn ? 1f : 0f;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            OpenSettings();
            
        }

    }

    public void ToggleVolume(bool isOn)
    {
        AudioListener.volume = isOn ? 1f : 0f;
        PlayerPrefs.SetInt("VolumeOn", isOn ? 1 : 0);
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
    public GameObject settingsPanel;

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }
}
