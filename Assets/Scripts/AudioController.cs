using UnityEngine;
using UnityEngine.UI;

public class AudioButton : MonoBehaviour
{
    public Sprite audioOnIcon;
    public Sprite audioOffIcon;
    public Slider volumeSlider;
    private bool isSoundOn = true;

    private Image buttonImage;
    private Button button;
    private AudioSource audioSource;
    private float liveValue = 1f;
    private float prevValue = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonImage = GetComponent<Image>();
        button = GetComponent<Button>();
        audioSource = GetComponent<AudioSource>();
        button.onClick.AddListener(OnButtonClick);
        volumeSlider.onValueChanged.AddListener(OnVolumeChanges);
    }

    void VolumeController(float value = 0)
    {
        volumeSlider.value = value;
        audioSource.volume = value;

        if(value == 0)
        {
            isSoundOn = false;
            buttonImage.sprite = audioOffIcon;
        }
        else
        {
            isSoundOn = true;
            buttonImage.sprite = audioOnIcon;
        }
    }

    void OnButtonClick()
    {
        if (isSoundOn)
        {
            VolumeController(0);
        }
        else
        {
            VolumeController(prevValue);
        }
        
    }

    void OnVolumeChanges(float value)
    {
        liveValue = value;
        VolumeController(value);
    }
    
    public void OnSliderRelease()
    {
        prevValue = liveValue == 0 ? prevValue : liveValue;
        // Unfocus the slider
        // EventSystem.current.SetSelectedGameObject(null);
    }

}
