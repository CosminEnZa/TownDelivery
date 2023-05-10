using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightManager : MonoBehaviour
{
    public GameObject PeopleRed;
    public GameObject PeopleYellow;
    public GameObject PeopleGreen;

    public GameObject CarRed;
    public GameObject CarYellow;
    public GameObject CarGreen;

    public GameObject CarCollider;
    public GameObject PeopleCollider;
    

    // Start is called before the first frame update
    void Start()
    {
        
        CarCollider = this.transform.Find("CarCol").gameObject;
        PeopleCollider = this.transform.Find("PeopleCol").gameObject;
        

        ShowCarGreen();
    }

    private void Update()
    {
        
    }

    void ShowCarGreen()
    {
        PeopleGreen.SetActive(false);
        CarRed.SetActive(false);
        CarYellow.SetActive(false);
        PeopleYellow.SetActive(false);
        CarCollider.transform.localPosition = new Vector3(0f, -2f, 0f);
        PeopleCollider.transform.localPosition = new Vector3(-0.56f, 0.35f, -1.52f);
        CarGreen.SetActive(true);
        PeopleRed.SetActive(true);

        Invoke("ShowYellowToRed", 20);
    }

    void ShowYellowToRed()
    {
        CarYellow.SetActive(true);
        PeopleYellow.SetActive(true);

        Invoke("ShowCarRed", 3);
    }

    void ShowCarRed()
    {
        CarYellow.SetActive(false);
        PeopleYellow.SetActive(false);
        CarCollider.transform.localPosition = new Vector3(1.91f, 0.35f, 1.23f);
        PeopleCollider.transform.localPosition = new Vector3(0f, -2f, 0f);
        CarGreen.SetActive(false);
        PeopleRed.SetActive(false);
        PeopleGreen.SetActive(true);
        CarRed.SetActive(true);

        Invoke("ShowYellowToGreen", 10);
    }

    void ShowYellowToGreen()
    {
        CarYellow.SetActive(true);
        PeopleYellow.SetActive(true);

        Invoke("ShowCarGreen", 3);
    }
}
