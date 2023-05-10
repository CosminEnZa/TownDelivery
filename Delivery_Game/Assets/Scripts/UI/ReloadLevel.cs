using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadLevel : MonoBehaviour
{
    public void ReloadScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
