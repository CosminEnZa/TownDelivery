using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldAlt : MonoBehaviour
{

    public OpenShopButton shopman;
    public PauseButton pause;
    public static bool stop = false;

    private void Awake()
    {
        Cursor.visible = false;
    }

    private void Start()
    {
        stop = false;
        Cursor.visible = false;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftAlt))
        {
            stop = true;
            Cursor.visible = true;
        }
       
        else if(Input.GetKeyUp(KeyCode.LeftAlt))
        {
            stop = false;
            Cursor.visible = false;
        }
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            shopman.OpenShopMenu();
            pause.Pause();
            stop = true;
            Cursor.visible = true;
        }

    }
}
