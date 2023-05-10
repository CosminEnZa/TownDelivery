using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public GameObject canvas;
    public GameObject moveObjectScript;

    public void Pause()
    {
        canvas.SetActive(true);
        moveObjectScript.GetComponent<FirstPersonControllerTouch>().enabled = false;
        Time.timeScale = 0;
        HoldAlt.stop = true;
        Cursor.visible = true;
    }

    public void Resume()
    {
        canvas.SetActive(false);
        Time.timeScale = 1;
        HoldAlt.stop = false;
        Cursor.visible = false;
        moveObjectScript.GetComponent<FirstPersonControllerTouch>().enabled = true;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void TabletPressed()
    {
        HoldAlt.stop = true;
        Cursor.visible = true;
    }

    public void TabletClosed()
    {
        HoldAlt.stop = false;
        Cursor.visible = false;
    }
}
