using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RankingManager : MonoBehaviour
{
    public GameObject Panel;
    public float Playermultiplier = 0;
    public List<GameObject> entities;
    private void Start()
    {
        Invoker.InvokeDelayed(Sort, 0.5f);
    }
    public void Sort()
    {
        entities = entities.OrderBy (obj => obj.GetComponent<RankEntity>().score).ToList();

        foreach (GameObject character in entities)
        {
            character.GetComponent<RankEntity>().poz = entities.IndexOf(character);
            character.GetComponent<RankEntity>().AfterSort();   
        }

        Panel.SetActive(false);
  }

  
}
