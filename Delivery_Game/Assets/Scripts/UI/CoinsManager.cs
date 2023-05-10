using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    public RankingManager rank;
    public static int Coins;
    public List <TMPro.TextMeshProUGUI> coinText;
    public TMPro.TextMeshProUGUI rewardText;

    // Start is called before the first frame update
    void Start()
    {
        Coins = PlayerPrefs.GetInt("Coins");
        Coins = 36500;
        for (int i = 0; i < coinText.Count; i++)
        {
            coinText[i].text = Coins + "$";
        }

        UpdateCoins();
    }

    public void UpdateCoins()
    {
        if(Coins <= 0)
        {
            Coins = 0;
        }
        if(Coins >= 9999999)
        {
            Coins = 9999999;
        }
        for (int i = 0; i < coinText.Count; i++)
        {
            coinText[i].text = Coins + "$";
        }
        PlayerPrefs.SetInt("Coins", Coins);
    }


}
