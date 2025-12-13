using UnityEngine;
using UnityEngine.SceneManagement;

public class selectImage_GameScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickMessi()
    {
        PlayerPrefs.SetString("Photo","Messi") ;
        SceneManager.LoadScene("SampleScene1");
    }
    public void OnClickRonaldo()
    {
        PlayerPrefs.SetString("Photo", "Ronaldo");
        SceneManager.LoadScene("SampleScene1");
    }
    public void OnClickTrain()
    {
        PlayerPrefs.SetString("Photo", "Train");
        SceneManager.LoadScene("SampleScene1");
    }
}
