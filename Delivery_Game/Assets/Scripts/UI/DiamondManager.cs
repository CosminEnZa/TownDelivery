using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondManager : MonoBehaviour
{
    public static int Diamonds;
    public List<TMPro.TextMeshProUGUI> coinText;

    // Start is called before the first frame update
    void Start()
    {
        Diamonds = PlayerPrefs.GetInt("Diamonds");
        Diamonds = 6500;
        for (int i = 0; i < coinText.Count; i++)
        {
            coinText[i].text = Diamonds.ToString();
        }

        UpdateDiamonds();
    }

    public void UpdateDiamonds()
    {
        if (Diamonds <= 0)
        {
            Diamonds = 0;
        }
        if (Diamonds >= 9999999)
        {
            Diamonds = 9999999;
        }
        for (int i = 0; i < coinText.Count; i++)
        {
            coinText[i].text = Diamonds.ToString();
        }
        PlayerPrefs.SetInt("Diamonds", Diamonds);
    }


}
