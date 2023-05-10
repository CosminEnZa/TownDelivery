using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipboardButton : MonoBehaviour
{

    public static bool tablet_opened = false;
    public GameObject canvas;
    bool isOpen = false;
    public GameObject moveObjectScript;

    private void Start()
    {
        Cursor.visible = true;
    }

    public void OpenCloseClipboard()
    {
        if (isOpen)
        {
            canvas.SetActive(false);
            moveObjectScript.GetComponent<FirstPersonControllerTouch>().enabled = true;
            isOpen = false;
            //HoldAlt.stop = false;
            //Cursor.visible = false;
            Tutorial.check_list_pressed = false;
        }
        else if (isOpen == false)
        {
            moveObjectScript.GetComponent<FirstPersonControllerTouch>().enabled = false;
            canvas.SetActive(true);
            //HoldAlt.stop = true;
            //Cursor.visible = true;
            isOpen = true;
        }
    }
}
