using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject opening;
    public void StartButton()
    {
        opening.SetActive(true);
        
        SceneManager.LoadSceneAsync("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
