using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public GameObject screen;

    private void Start()
    {
        Cursor.visible = true;
    }

    public void StartLevel()
    {
        screen.SetActive(true);
        PlayerPrefs.SetInt("Intro", 1);
        
        SceneManager.LoadSceneAsync("SampleScene");
    }


}
