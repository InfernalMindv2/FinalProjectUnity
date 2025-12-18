using UnityEngine;

public class MusicAttempt : MonoBehaviour
{
    public AudioSource musicSource;

    void Start()
    {
        ApplyMenuSettings();
    }

    public void ApplyMenuSettings()
    {
        // MUSIC ON / OFF
        string music = PlayerPrefs.GetString("Music", "On");

        if (music == "On")
        {
            if (!musicSource.isPlaying)
                musicSource.Play();
        }
        else
        {
            musicSource.Stop();
        }

        // VOLUME
        string volumeStr = PlayerPrefs.GetString("Volume", "100");
        float volume = float.Parse(volumeStr) / 100f;

        musicSource.volume = volume;
    }
}
