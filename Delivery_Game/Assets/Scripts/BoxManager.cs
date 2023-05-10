using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxManager : MonoBehaviour
{
    
    public string from;

    public string peopleName;
    [SerializeField]
    private string status;

    public float price;


    public string ID = "happy";
    public string originID;


    public GameObject prefab;
    [SerializeField]
    GameObject Panel;

     CoinsManager coinsman;

    
    public int timeRemaining = 10;

    private bool timerIsRunning = false;
    public int timeLeft;

    TMPro.TextMeshProUGUI price_text;
    private TMPro.TextMeshProUGUI from_text;
    private TMPro.TextMeshProUGUI to_text;
    private TMPro.TextMeshProUGUI status_text;
    private TMPro.TextMeshProUGUI time_text;
    public TMPro.TextMeshProUGUI sort_time_text;

    [SerializeField]
    private GameObject parent;

     GameObject carcam;
    GameObject playerCamera;

    private AudioSource _audio;

    private bool AwatingDelivery = false;

    private string[] firstnames = new string[] { "Johan", "Sullivan", "Makena", "Jameson", "Porter", "Clinton", "Arianna", "Shaun", "Reid", "Maxwell", "Trevin", "Christopher", "Myla", "Brennan", "Kenna", "Azul", "Brianna", "Braelyn", "Nickolas", "Neil", "Stephanie", "Athena", "Matias", "Jaqueline", "Jordyn", "Abby", "Francis", "Carlos", "Gage", "Amelia", "Jeremy", "Celeste", "Ruben", "Ignacio", "Kamari", "Paloma", "Kolby", "Zackary", "Valeria", "Rodney", "Joaquin", "Trent", "Franklin", "Melvin", "Zion", "Lola", "Keyon", "Ashlynn", "Braiden", "Jared" };
    private string[] names = new string[] { "Holloway", "Banks", "Chapman", "Larson", "Cain", "Church", "Estrada", "Barr", "Simon", "Juarez", "Mercado", "Odonnell", "Ballard", "Pham", "Sparks", "Orr", "Haas", "Pennington", "Lynn", "Shepard", "Rocha", "Phelps", "Padilla", "Oneill", "Travis", "Chavez", "Richards", "Fischer", "Chase", "Garza", "Faulkner", "Garrison", "Garner", "Tanner", "Mills", "Malone", "Mccarthy", "Mccall", "Thomas", "Leblanc", "Guzman", "Marks", "Becker", "Beltran", "Wells", "Arroyo", "Shields", "Rice", "Reynolds", "Arellano" };

    [SerializeField]
    private GameObject startAspect;
    [SerializeField]
    private GameObject finalAspect;

    public GameObject sortPoint;
    [SerializeField]
    private Image radialBar;

    public static float sortMultiplier = 1;

    private bool inSorting = false;

    private bool doneRad = false;

    public GameObject Canvas;

    public bool hasLocation = false;

    public Vector3 pointLocation;
    GameObject notification;

    [SerializeField]
    private bool isPicked;
    public bool remainPicked = false;

    float dist;
    GameObject player;
    

    GameObject waypoint;
    GameObject skip_button;

    private WaitForSeconds waitTime = new WaitForSeconds(1);

    TMPro.TextMeshProUGUI rewardText;
    private Transform afterLocation;
    GameObject deliverPoint;
    float sortTime = 60;

    private bool del = false;
    private void Start()
    {
        ID = "happy";
        carcam = GameObject.Find("SpawnManager").GetComponent<SpawnBoxes>().cameraCar;
        playerCamera = GameObject.Find("SpawnManager").GetComponent<SpawnBoxes>().playerCamera;
        parent = GameObject.Find("SpawnManager").GetComponent<SpawnBoxes>().BoxPanelParent;
        notification = GameObject.Find("CheckList").transform.GetChild(0).gameObject;
        afterLocation = GameObject.Find("AfterDeliveryLocation").transform;
        deliverPoint = GameObject.Find("FX_Direction_Arrows_01");
        player = GameObject.Find("PlayerCapsule");
        skip_button = GameObject.Find("CoinsManager & CANVAS").GetComponent<SkipBoxPanel>().skip_button;

        sortTime = 60;
        _audio = GetComponent<AudioSource>();

        coinsman = GameObject.Find("CoinsManager & CANVAS").GetComponent<CoinsManager>();
        rewardText = GameObject.Find("CoinsManager & CANVAS").GetComponent<CoinsManager>().rewardText;

        sortPoint = GameObject.Find("SortPointSpawn");
        radialBar.fillAmount = 0;
        Panel = GameObject.Instantiate(prefab);


        Panel.transform.SetParent(parent.transform);
        Panel.transform.localScale = new Vector3(1, 1, 1);

        waypoint = carcam.GetComponent<BoxWaypoint>().img.gameObject;

        timeRemaining = Random.Range(180, 450);
        timerIsRunning = true;
        price_text = Panel.transform.Find("Price_Text (TMP)").GetComponent<TMPro.TextMeshProUGUI>();
        from_text = Panel.transform.Find("From_Text (TMP)").GetComponent<TMPro.TextMeshProUGUI>();
        to_text = Panel.transform.Find("To_Text (TMP)").GetComponent<TMPro.TextMeshProUGUI>();
        status_text = Panel.transform.Find("Status_Text (TMP)").GetComponent<TMPro.TextMeshProUGUI>();
        time_text = Panel.transform.Find("Time_Text (TMP)").GetComponent<TMPro.TextMeshProUGUI>();

        peopleName = firstnames[Random.Range(0, firstnames.Length)] + " " + names[Random.Range(0, names.Length)];
        price = Random.Range(65, 110) * GameObject.Find("CoinsManager & CANVAS").GetComponent<CoinsManager>().rank.Playermultiplier;
        price += (price * AdvertisingShop.newsMulti) + (price * AdvertisingShop.radioMulti) + (price * AdvertisingShop.TVMulti) + (price * AdvertisingShop.AdsMulti);
        
        notification.SetActive(true);
        Panel.transform.Find("Button").GetComponent<Button>().onClick.AddListener(() => { 
            //Button[] btns = GameObject.Find("BoxPanels").GetComponentsInChildren<Button>();
            //foreach (Button btn in btns)
            // {
            //    btn.gameObject.SetActive(true);
            //}

            Mask[] accs = GameObject.Find("BoxPanels").GetComponentsInChildren<Mask>();
            foreach (Mask acc in accs)
            {
                acc.gameObject.SetActive(false);
            }

            Panel.transform.Find("Accepted").gameObject.SetActive(true);
           
            waypoint.SetActive(true);
            carcam.GetComponent<BoxWaypoint>().target = this.transform;
            playerCamera.GetComponent<BoxWaypoint>().target = this.transform;
            Tutorial.check_list_pressed = true;



        });

        price_text.text = (int)price + "$";
        from_text.text = "From: " + from;
        to_text.text = "To: " + peopleName;
        status_text.text = " Status: " + status;

        StartCoroutine(StartTimer());
    }



    private void Update()
    {
        
        if (del == false)
        {
            if (player == null)
            {
                player = GameObject.Find("PlayerCapsule");
            }
            

            if (player != null && player.activeSelf == true && remainPicked == true)
            {
                dist = Vector3.Distance(player.transform.position, transform.position);

                if (dist <= 13)
                {
                    waypoint.SetActive(false);

                }
                else
                {
                    waypoint.SetActive(true);
                }

            }

            if (inSorting == true && radialBar.fillAmount <= 1)
            {
                radialBar.fillAmount += (Time.deltaTime / 60) * SkipBoxPanel.skip_value;
                float minutes = Mathf.FloorToInt((int)sortTime / 60);
                float seconds = Mathf.FloorToInt((int)sortTime % 60);
                sortTime -= Time.deltaTime * SkipBoxPanel.skip_value;
                
                sort_time_text.text = string.Format("{0:00}m {1:00}s", minutes, seconds);
                skip_button.SetActive(true);
                if (radialBar.fillAmount == 1 && doneRad == false)
                {
                    sortArea();
                }
            }


        }
    }

    IEnumerator StartTimer()
    {
        while (true)
        {
            if (PlayerPrefs.GetInt("Tutorial") == 1)
            {
                if (TimeManager.timeRunning == false)
                {
                    if (!doneRad && inSorting == false && isPicked == false && remainPicked == false)
                    {
                        Destroy(Panel);
                        Destroy(this.gameObject);

                    }
                }
            }

            price_text.text = (int)price + "$";
            from_text.text = "From: " + from;
            to_text.text = "To: " + peopleName;
            status_text.text = " Status: " + status;

            if (timerIsRunning)
            {
                
                if (timeRemaining >= 0)
                {
                    timeRemaining -= 1;
                    DisplayTime(timeRemaining);
                }
                else
                {

                    timeRemaining = 0;
                    timerIsRunning = false;

                    if (!AwatingDelivery)
                    {
                        NoTimeAndStop();
                    }
                }
            }   
            if (timeRemaining <= 60 && timeRemaining > 0)
            {
                ID = "normal";
            }
            yield return waitTime;

        }
    }

    void NoTimeAndStop()
    {
        //NoBonus.
        if (!doneRad && inSorting == false && isPicked == false && remainPicked == false)
        {
            Destroy(Panel);
            Destroy(this.gameObject);
            SpawnBoxes.totalObjects--;

        }
        else
        {
            ID = "sad";
        }
    }
    void Delivered()
    {

        del = true;
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        this.GetComponent<Rigidbody>().isKinematic = false;
        this.GetComponent<Rigidbody>().useGravity = true;
        this.GetComponent<BoxCollider>().isTrigger = false;
        SpawnBoxes.totalObjects--;
        Destroy(Panel);
        this.tag = "delivered";
        GameObject.Find("PlayerMainCamera").GetComponent<SelectionManager>().deliverWaypoint.SetActive(false);

        Tutorial.endtutorial = true;

        rewardText.gameObject.SetActive(false);
        if (ID == "happy")
        {
            AchievementsTotalDeliveries.TotalDeliveriesValue += 1;
            GameObject.Find("CoinsManager & CANVAS").GetComponent<AchievementsTotalDeliveries>().UpdateAchievement();

            MissionsManager.TipsValue += 1;
            GameObject.Find("CoinsManager & CANVAS").GetComponent<MissionsManager>().UpdateMission();

            MissionsManager.OnTimeValue += 1;
            GameObject.Find("CoinsManager & CANVAS").GetComponent<MissionsManager>().UpdateMission();

            CoinsManager.Coins += (int)(price + price * 0.2f);
            coinsman.UpdateCoins();
            WorkDayOver.deliveries += (int)price;
            WorkDayOver.tips += (int)(price * 0.2f);

            PlayerPrefs.SetInt("Deliveries", PlayerPrefs.GetInt("Deliveries") + 1);
            rewardText.gameObject.SetActive(true);
            rewardText.text = "+" + (price + price * 0.2f).ToString() + "$";
        }
        else if (ID == "normal")
        {
            MissionsManager.OnTimeValue += 1;
            GameObject.Find("CoinsManager & CANVAS").GetComponent<MissionsManager>().UpdateMission();

            AchievementsTotalDeliveries.TotalDeliveriesValue += 1;
            GameObject.Find("CoinsManager & CANVAS").GetComponent<AchievementsTotalDeliveries>().UpdateAchievement();

            CoinsManager.Coins += (int) price;
            coinsman.UpdateCoins();
            WorkDayOver.deliveries += (int)price;

            PlayerPrefs.SetInt("Deliveries", PlayerPrefs.GetInt("Deliveries") + 1);
            rewardText.gameObject.SetActive(true);
            rewardText.text = "+" + price.ToString() + "$";
        }
        else if (ID == "sad")
        {
            AchievementsTotalDeliveries.TotalDeliveriesValue += 1;
            GameObject.Find("CoinsManager & CANVAS").GetComponent<AchievementsTotalDeliveries>().UpdateAchievement();

            CoinsManager.Coins += (int)(price - price * 0.2f);
            coinsman.UpdateCoins();

            WorkDayOver.deliveries += (int)price;
            PlayerPrefs.SetInt("Deliveries", PlayerPrefs.GetInt("Deliveries") + 1);
            rewardText.gameObject.SetActive(true);
            rewardText.text = "+" + (price - price * 0.2f).ToString() + "$";
        }

        deliverPoint.transform.position = afterLocation.position;


        if (originID == "airport")
        {
            MissionsManager.AirportValue += 1;
            GameObject.Find("CoinsManager & CANVAS").GetComponent<MissionsManager>().UpdateMission();
        }

        if (originID == "bank")
        {
            MissionsManager.BankValue += 1;          
            GameObject.Find("CoinsManager & CANVAS").GetComponent<MissionsManager>().UpdateMission();
        }

        if (originID == "burger")
        {
            MissionsManager.BurgerValue += 1;
            GameObject.Find("CoinsManager & CANVAS").GetComponent<MissionsManager>().UpdateMission();
        }

        if (originID == "caffe")
        {
            MissionsManager.CoffeeValue += 1;
            GameObject.Find("CoinsManager & CANVAS").GetComponent<MissionsManager>().UpdateMission();
        }

        if (originID == "office")
        {
            MissionsManager.OfficeValue += 1;
            GameObject.Find("CoinsManager & CANVAS").GetComponent<MissionsManager>().UpdateMission();
        }

        if (originID == "pet")
        {
            MissionsManager.PetValue += 1;
            GameObject.Find("CoinsManager & CANVAS").GetComponent<MissionsManager>().UpdateMission();
        }

        if (originID == "pizza")
        {
            MissionsManager.PizzaValue += 1;
            GameObject.Find("CoinsManager & CANVAS").GetComponent<MissionsManager>().UpdateMission();
        }

        if (originID == "market")
        {
            MissionsManager.SuperValue += 1;
            GameObject.Find("CoinsManager & CANVAS").GetComponent<MissionsManager>().UpdateMission();
        }

        if (originID == "train")
        {
            MissionsManager.TrainValue += 1;
            GameObject.Find("CoinsManager & CANVAS").GetComponent<MissionsManager>().UpdateMission();
        }

        StartCoroutine(coroutineA());
    }

    IEnumerator coroutineA()
    {
        // wait for 1 second
       
        yield return new WaitForSeconds(2.0f);

        rewardText.gameObject.SetActive(false);
        yield return new WaitForSeconds(15.0f);
        Destroy(this.gameObject);  
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        if (!doneRad && inSorting == false && remainPicked == false)
        {
            time_text.text = "Expires in " + string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else if (inSorting == true || remainPicked == true || doneRad)
        {
            time_text.text = "Expected in " + string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
    
    void waitSort()
    {
        SelectionManager.hasBox = false;
        inSorting = true;
        status = "Sorting";
        Canvas.SetActive(true);
        this.tag = "NoBox";
        this.transform.rotation = Quaternion.identity;
        skip_button.SetActive(true);
        Tutorial.has_placed_a_box = true;
        this.gameObject.GetComponent<PickBox>().Reset();
    }

    void sortArea()
    {
        this.tag = "PackedBox";
        this.gameObject.GetComponent<PickBox>().enabled = true;
        Tutorial.box_sorted = true;
        doneRad = true;
        inSorting = false;
        Canvas.SetActive(false);
        this.GetComponent<BoxCollider>().isTrigger = false;
        this.GetComponent<Rigidbody>().useGravity = true;
        this.GetComponent<Rigidbody>().isKinematic = false;
        status = "To be delivered";
 

        skip_button.SetActive(false);
        this.gameObject.transform.position = sortPoint.transform.position;
        startAspect.SetActive(false);
        finalAspect.SetActive(true);


        timeRemaining += 120;
        timerIsRunning = true;
    }

    private void OnTriggerEnter(Collider other)
    {

          if (other.gameObject.tag == "SortDrop")
         {
            if (!doneRad && !SelectionManager.hasBox)
            {
                //this.gameObject.GetComponent<PickBox>().Reset();
                Invoke("waitSort", 1);
            }
         }

         if(other.gameObject.tag == "PlayerBox")
        {
            isPicked = true;
        }

         if (other.gameObject.tag == "DeliverBox")
        {
            this.gameObject.GetComponent<PickBox>().Reset();
            _audio.Play();
            Delivered();
        }
    }


 

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PlayerBox")
        {
            isPicked = false;   
        }
    }
}
