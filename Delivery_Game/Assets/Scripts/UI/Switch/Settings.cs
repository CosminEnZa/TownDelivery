using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public Light lightSet;
    public GameObject postPro;
    public AudioSource music;

    AudioSource[] audios;
    void Start()
    {
        audios = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];

        if(PlayerPrefs.GetInt("Shadow", 1) == 1)
        {
            lightSet.shadows = LightShadows.Hard;
        }
        else if (PlayerPrefs.GetInt("Shadow", 1) == 0)
        {
            lightSet.shadows = LightShadows.None;
        }

        if(PlayerPrefs.GetInt("FPS", 1) == 0)
        {
            Application.targetFrameRate = 30;
        }
        else if (PlayerPrefs.GetInt("FPS", 1) == 1)
        {
            Application.targetFrameRate = 60;
        }

        if(PlayerPrefs.GetInt("Music", 1) == 1)
        {
            music.Play();
            music.volume = 1;
        }
        else if (PlayerPrefs.GetInt("Music", 1) == 0)
        {
            music.Pause();
            music.volume = 0;
        }

        if (PlayerPrefs.GetInt("Effects", 1) == 1)
        {
            foreach(AudioSource aud in audios)
            {
                aud.volume = 1;
            }
            if (PlayerPrefs.GetInt("Music", 1) == 1)
            {
                music.Play();
                music.volume = 1;
            }
            else if (PlayerPrefs.GetInt("Music", 1) == 0)
            {
                music.Pause();
                music.volume = 0;
            }
        }

        else if (PlayerPrefs.GetInt("Effects", 1) == 0)
        {
            foreach (AudioSource aud in audios)
            {
                aud.volume = 0;
            }
            if (PlayerPrefs.GetInt("Music", 1) == 1)
            {
                music.Play();
                music.volume = 1;
            }
            else if (PlayerPrefs.GetInt("Music", 1) == 0)
            {
                music.Pause();
                music.volume = 0;
            }
        }
    }

    public void ShadowsON()
    {
        PlayerPrefs.SetInt("Shadow", 1);
        lightSet.shadows = LightShadows.Hard;
    }

    public void ShadowsOFF()
    {
        PlayerPrefs.SetInt("Shadow", 0);
        lightSet.shadows = LightShadows.None;
    }


    public void LOCK30()
    {
        PlayerPrefs.SetInt("FPS", 0);
        Application.targetFrameRate = 30;
    }

    public void LOCK60()
    {
        PlayerPrefs.SetInt("FPS", 1);
        Application.targetFrameRate = 60;
    }

    public void EffectsOFF()
    {

        PlayerPrefs.SetInt("Effects", 0);
        
        foreach (AudioSource aud in audios)
        {
            aud.volume = 0;
        }
        if (PlayerPrefs.GetInt("Music", 1) == 1)
        {
            music.Play();
            music.volume = 1;
        }
        else if (PlayerPrefs.GetInt("Music", 1) == 0)
        {
            music.Pause();
            music.volume = 0;
        }

    }

    public void EffectsON()
    {
        PlayerPrefs.SetInt("Effects", 1);
        foreach (AudioSource aud in audios)
        {
            aud.volume = 1;
        }
        if (PlayerPrefs.GetInt("Music", 1) == 1)
        {
            music.volume = 1;
            music.Play();
        }
        else if (PlayerPrefs.GetInt("Music", 1) == 0)
        {
            music.Pause();
            music.volume = 0;
        }

    }

    public void MusicOFF()
    {
        PlayerPrefs.SetInt("Music", 0);
        music.Pause();
        music.volume = 0;

    }

    public void MusicON()
    {
        PlayerPrefs.SetInt("Music", 1);
        music.Play();
        music.volume = 1;

    }

}
