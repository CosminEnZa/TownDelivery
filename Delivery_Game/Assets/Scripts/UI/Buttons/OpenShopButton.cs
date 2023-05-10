using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShopButton : MonoBehaviour
{
    
    public TabGroup tabGroup;

    public void OpenShopMenu()
    {
        tabGroup.OnTabSelected(tabGroup.tabButtons[0]);
    }
}
