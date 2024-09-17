using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Options_Script : MonoBehaviour
{
    public AudioMixer musicMixer;
    public AudioMixer sfxMixer;
    public Slider Mslider;
    public Slider Sslider;
    public Toggle Stoggle;
    public LVLController LC;

    public void Start()
    {

        if (PlayerPrefs.HasKey("SMV"))
                Mslider.value = PlayerPrefs.GetFloat("SMV");
        else
        {
            Mslider.value = -0.5f;
        }

        if (PlayerPrefs.HasKey("SSV"))
            Sslider.value = PlayerPrefs.GetFloat("SSV");
        else
        {
            Sslider.value = -0.5f;
        }
    }

    public void SetMVolume(float Mvolume)
    {
        musicMixer.SetFloat("Mvolume", Mathf.Log10(- Mvolume) * 20);
        PlayerPrefs.SetFloat("SMV", Mvolume);
        PlayerPrefs.Save();
    }

    public void SetSVolume(float Svolume)
    {
        sfxMixer.SetFloat("Svolume", Mathf.Log10(-Svolume) * 20);
        PlayerPrefs.SetFloat("SSV", Svolume);
        PlayerPrefs.Save();
    }

    public void MSound()
    {
        AudioListener.pause = !AudioListener.pause;
    }

    public void lvlClear()
    {
        PlayerPrefs.DeleteKey("levels");
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
