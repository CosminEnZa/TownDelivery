using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankEntity : MonoBehaviour
{
    public bool isPlayer = false;
    public int poz = 0;
    public int score;
    [SerializeField]
    private int ID;
    public string name;

    public TMPro.TextMeshProUGUI multiplierText;
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI pozText;

    public RankingManager rankMan;

    private void Start()
    {
        if(!PlayerPrefs.HasKey("RankDay"))
        {
            PlayerPrefs.SetInt("RankDay", 1);
        }

        score = PlayerPrefs.GetInt("RankID" + ID);

        if(!isPlayer)
        {
            score += Random.Range(1, 2);
            scoreText.text = "Score: " + score.ToString();
        }
        else
        {
            score = PlayerPrefs.GetInt("Deliveries");
            scoreText.text = "Score: " + score.ToString();
           
        }
        if (PlayerPrefs.GetInt("RankDay") == PlayerPrefs.GetInt("Day"))
        {
            PlayerPrefs.SetInt("RankID" + ID, score);
        }

    }

   public void AfterSort()
    {
        switch(poz)
        {
            case 0:
                poz = 4;
                this.transform.SetSiblingIndex(poz-1);
                pozText.text = " " + poz.ToString() + ". " + name;
                multiplierText.text = "x0.8";

                if(isPlayer)
                {
                    rankMan.Playermultiplier = 0.6f;
                }
                break;

            case 1:
                poz = 3;
                this.transform.SetSiblingIndex(poz-1);
                pozText.text = " " + poz.ToString() + ". " + name;
                multiplierText.text = "x1";
                if (isPlayer)
                {
                    rankMan.Playermultiplier = 1;
                }
                break;
            case 2:
                poz = 2;
                this.transform.SetSiblingIndex(poz-1);
                pozText.text = " " + poz.ToString() + ". " + name;
                multiplierText.text = "x1.5";
                if (isPlayer)
                {
                    rankMan.Playermultiplier = 1.5f;
                }
                break;
            case 3:
                poz = 1;
                this.transform.SetSiblingIndex(poz-1);
                pozText.text = " " + poz.ToString() + ". " + name;
                multiplierText.text = "x2";
                if (isPlayer)
                {
                    rankMan.Playermultiplier = 2f;
                }
                break;

        }
    }
}
