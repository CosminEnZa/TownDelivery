using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipBoxPanel : MonoBehaviour
{

    public static int skip_value = 1;
    public DiamondManager diamonds;
    public GameObject skip_button;

    // Start is called before the first frame update
    void Start()
    {
        skip_value = 1;
    }

    public void Free_Skip()
    {
        skip_value = 100;
    }

    public void Diamond_Skip()
    {
        if(DiamondManager.Diamonds >= 3)
        {
            skip_value = 100;
            DiamondManager.Diamonds -= 3;
            diamonds.UpdateDiamonds();
        }
    }
}
