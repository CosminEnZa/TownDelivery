using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTime : MonoBehaviour
{
    public void Time0()
    {
        Time.timeScale = 0;
    }

    public void Time1()
    {
        Time.timeScale = 1;
    }
}
