using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MissionsManager : MonoBehaviour
{
    public CoinsManager coinsman;
    public GameObject[] Missions;

    public GameObject redDot;

    int randomNumber = 0;

    [Header("Airport")]
    public int AirportReward;
    public TMPro.TextMeshProUGUI AirportText;
    public Button AirportButton;
    public static int AirportValue;
    public GameObject AirportClaimed;

    [Space]
    [Header("Bank")]
    public int BankReward;
    public TMPro.TextMeshProUGUI BankText;
    public Button BankButton;
    public static int BankValue;
    public GameObject BankClaimed;

    [Space]
    [Header("Burger")]
    public int BurgerReward;
    public TMPro.TextMeshProUGUI BurgerText;
    public Button BurgerButton;
    public static int BurgerValue;
    public GameObject BurgerClaimed;

    [Space]
    [Header("Coffee")]
    public int CoffeeReward;
    public TMPro.TextMeshProUGUI CoffeeText;
    public Button CoffeeButton;
    public static int CoffeeValue;
    public GameObject CoffeeClaimed;

    [Space]
    [Header("Office")]
    public int OfficeReward;
    public TMPro.TextMeshProUGUI OfficeText;
    public Button OfficeButton;
    public static int OfficeValue;
    public GameObject OfficeClaimed;

    [Space]
    [Header("Pet")]
    public int PetReward;
    public TMPro.TextMeshProUGUI PetText;
    public Button PetButton;
    public static int PetValue;
    public GameObject PetClaimed;

    [Space]
    [Header("Pizza")]
    public int PizzaReward;
    public TMPro.TextMeshProUGUI PizzaText;
    public Button PizzaButton;
    public static int PizzaValue;
    public GameObject PizzaClaimed;

    [Space]
    [Header("Supermarket")]
    public int SuperReward;
    public TMPro.TextMeshProUGUI SuperText;
    public Button SuperButton;
    public static int SuperValue;
    public GameObject SuperClaimed;

    [Space]
    [Header("Train Station")]
    public int TrainReward;
    public TMPro.TextMeshProUGUI TrainText;
    public Button TrainButton;
    public static int TrainValue;
    public GameObject TrainClaimed;

    [Space]
    [Header("Fuel")]
    public int FuelReward;
    public TMPro.TextMeshProUGUI FuelText;
    public Button FuelButton;
    public static int FuelValue;
    public GameObject FuelClaimed;

    [Space]
    [Header("Invest")]
    public int InvestReward;
    public TMPro.TextMeshProUGUI InvestText;
    public Button InvestButton;
    public static int InvestValue;
    public GameObject InvestClaimed;

    [Space]
    [Header("Tips")]
    public int TipsReward;
    public TMPro.TextMeshProUGUI TipsText;
    public Button TipsButton;
    public static int TipsValue;
    public GameObject TipsClaimed;

    [Space]
    [Header("Towing")]
    public int TowReward;
    public TMPro.TextMeshProUGUI TowText;
    public Button TowButton;
    public static int TowValue;
    public GameObject TowClaimed;

    [Space]
    [Header("OnTime")]
    public int OnTimeReward;
    public TMPro.TextMeshProUGUI OnTimeText;
    public Button OnTimeButton;
    public static int OnTimeValue;
    public GameObject OnTimeClaimed;


    // Start is called before the first frame update
    void Start()
    {
        AirportValue = PlayerPrefs.GetInt("AirportMission", 0);
        BankValue = PlayerPrefs.GetInt("BankMission", 0);
        BurgerValue = PlayerPrefs.GetInt("BurgerMission", 0);
        CoffeeValue = PlayerPrefs.GetInt("CoffeeMission", 0);
        OfficeValue = PlayerPrefs.GetInt("OfficeMission", 0);
        PetValue = PlayerPrefs.GetInt("PetMission", 0);
        PizzaValue = PlayerPrefs.GetInt("PizzaMission", 0);
        SuperValue = PlayerPrefs.GetInt("SuperMission", 0);
        TrainValue = PlayerPrefs.GetInt("TrainMission", 0);
        FuelValue = PlayerPrefs.GetInt("FuelMission", 0);
        InvestValue = PlayerPrefs.GetInt("InvestMission", 0);
        TipsValue = PlayerPrefs.GetInt("TipsMission", 0);
        TowValue = PlayerPrefs.GetInt("TowMission", 0);
        OnTimeValue = PlayerPrefs.GetInt("OnTimeMission", 0);

        if(!PlayerPrefs.HasKey("Dailyi" + 0))
        {
            ResetValues();
        }

        for (int i = 0; i <= 3; i++)
        {
            randomNumber = PlayerPrefs.GetInt("Dailyi" + i);
            Missions[randomNumber].SetActive(true);          
        }

            UpdateMission();
    }

    public void UpdateMission()
    {
        
        PlayerPrefs.SetInt("AirportMission", AirportValue);
        PlayerPrefs.SetInt("BankMission", BankValue);
        PlayerPrefs.SetInt("BurgerMission", BurgerValue);
        PlayerPrefs.SetInt("CoffeeMission", CoffeeValue);
        PlayerPrefs.SetInt("OfficeMission", OfficeValue);
        PlayerPrefs.SetInt("PetMission", PetValue);
        PlayerPrefs.SetInt("PizzaMission", PizzaValue);
        PlayerPrefs.SetInt("SuperMission", SuperValue);
        PlayerPrefs.SetInt("TrainMission", TrainValue);
        PlayerPrefs.SetInt("FuelMission", FuelValue);
        PlayerPrefs.SetInt("InvestMission", InvestValue);
        PlayerPrefs.SetInt("TipsMission", TipsValue);
        PlayerPrefs.SetInt("TowMission", TowValue);
        PlayerPrefs.SetInt("OnTimeMission", OnTimeValue);


        AirportText.text = AirportValue.ToString() + "/3";
        BankText.text = BankValue.ToString() + "/3";
        BurgerText.text = BurgerValue.ToString() + "/4";
        CoffeeText.text = CoffeeValue.ToString() + "/4";
        OfficeText.text = OfficeValue.ToString() + "/3";
        PetText.text = PetValue.ToString() + "/3";
        PizzaText.text = PizzaValue.ToString() + "/4";
        SuperText.text = SuperValue.ToString() + "/3";
        TrainText.text = TrainValue.ToString() + "/3";
        FuelText.text = FuelValue.ToString() + "/2";
        InvestText.text = InvestValue.ToString() + "/1000";
        TipsText.text = TipsValue.ToString() + "/5";
        TowText.text = TowValue.ToString() + "/2";
        OnTimeText.text = OnTimeValue.ToString() + "/6";



        if (PlayerPrefs.GetInt("AirportClaimed") == 1)
        {
            AirportClaimed.SetActive(true);
        }

        if (PlayerPrefs.GetInt("BankClaimed") == 1)
        {
            BankClaimed.SetActive(true);
        }

        if (PlayerPrefs.GetInt("BurgerClaimed") == 1)
        {
            BurgerClaimed.SetActive(true);
        }

        if (PlayerPrefs.GetInt("CoffeeClaimed") == 1)
        {
            CoffeeClaimed.SetActive(true);
        }

        if (PlayerPrefs.GetInt("OfficeClaimed") == 1)
        {
            OfficeClaimed.SetActive(true);
        }

        if (PlayerPrefs.GetInt("PetClaimed") == 1)
        {
            PetClaimed.SetActive(true);
        }

        if (PlayerPrefs.GetInt("PizzaClaimed") == 1)
        {
            PizzaClaimed.SetActive(true);
        }

        if (PlayerPrefs.GetInt("SuperClaimed") == 1)
        {
            SuperClaimed.SetActive(true);
        }

        if (PlayerPrefs.GetInt("TrainClaimed") == 1)
        {
            TrainClaimed.SetActive(true);
        }

        if (PlayerPrefs.GetInt("FuelClaimed") == 1)
        {
            FuelClaimed.SetActive(true);
        }

        if (PlayerPrefs.GetInt("InvestClaimed") == 1)
        {
            InvestClaimed.SetActive(true);
        }

        if (PlayerPrefs.GetInt("TipsClaimed") == 1)
        {
            TipsClaimed.SetActive(true);
        }

        if (PlayerPrefs.GetInt("TowClaimed") == 1)
        {
            TowClaimed.SetActive(true);
        }

        if (PlayerPrefs.GetInt("OnTimeClaimed") == 1)
        {
            OnTimeClaimed.SetActive(true);
        }



        if (AirportValue >= 3)
        {
            AirportButton.gameObject.SetActive(true);
            if(PlayerPrefs.GetInt("AirportClaimed") != 1)
            {
                redDot.SetActive(true);
            }
        }
        if (BankValue >= 3)
        {
            BankButton.gameObject.SetActive(true);
            if (PlayerPrefs.GetInt("BankClaimed") != 1)
            {
                redDot.SetActive(true);
            }

        }
        if (BurgerValue >= 4)
        {
            BurgerButton.gameObject.SetActive(true);
            if (PlayerPrefs.GetInt("BurgerClaimed") != 1)
            {
                redDot.SetActive(true);
            }
        }
        if (CoffeeValue >= 4)
        {
            CoffeeButton.gameObject.SetActive(true);
            if (PlayerPrefs.GetInt("CoffeeClaimed") != 1)
            {
                redDot.SetActive(true);
            }
        }
        if (OfficeValue >= 3)
        {
            OfficeButton.gameObject.SetActive(true);
            if (PlayerPrefs.GetInt("OfficeClaimed") != 1)
            {
                redDot.SetActive(true);
            }
        }
        if (PetValue >= 3)
        {
            PetButton.gameObject.SetActive(true);
            if (PlayerPrefs.GetInt("PetClaimed") != 1)
            {
                redDot.SetActive(true);
            }
        }
        if (PizzaValue >= 4)
        {
            PizzaButton.gameObject.SetActive(true);
            if (PlayerPrefs.GetInt("PizzaClaimed") != 1)
            {
                redDot.SetActive(true);
            }
        }
        if (SuperValue >= 3)
        {
            SuperButton.gameObject.SetActive(true);
            if (PlayerPrefs.GetInt("SuperClaimed") != 1)
            {
                redDot.SetActive(true);
            }
        }
        if (TrainValue >= 3)
        {
            TrainButton.gameObject.SetActive(true);
            if (PlayerPrefs.GetInt("TrainClaimed") != 1)
            {
                redDot.SetActive(true);
            }
        }
        if (FuelValue >= 2)
        {
            FuelButton.gameObject.SetActive(true);
            if (PlayerPrefs.GetInt("FuelClaimed") != 1)
            {
                redDot.SetActive(true);
            }
        }
        if (InvestValue >= 1000)
        {
            InvestButton.gameObject.SetActive(true);
            if (PlayerPrefs.GetInt("InvestClaimed") != 1)
            {
                redDot.SetActive(true);
            }
        }

        if (TipsValue >= 5)
        {
            TipsButton.gameObject.SetActive(true);
            if (PlayerPrefs.GetInt("TipsClaimed") != 1)
            {
                redDot.SetActive(true);
            }
        }

        if (TowValue >= 2)
        {
            TowButton.gameObject.SetActive(true);
            if (PlayerPrefs.GetInt("TowClaimed") != 1)
            {
                redDot.SetActive(true);
            }
        }

        if (OnTimeValue >= 6)
        {
            OnTimeButton.gameObject.SetActive(true);
            if (PlayerPrefs.GetInt("OnTimeClaimed") != 1)
            {
                redDot.SetActive(true);
            }
        }

        AirportButton.onClick.AddListener(() => {
            CoinsManager.Coins += AirportReward;
            coinsman.UpdateCoins();
            AirportButton.gameObject.SetActive(false);
            AirportClaimed.SetActive(true);
            PlayerPrefs.SetInt("AirportClaimed", 1);
        });

        BankButton.onClick.AddListener(() => {
            CoinsManager.Coins += BankReward;
            coinsman.UpdateCoins();
            BankButton.gameObject.SetActive(false);
            BankClaimed.SetActive(true);
            PlayerPrefs.SetInt("BankClaimed", 1);
        });

        BurgerButton.onClick.AddListener(() => {
            CoinsManager.Coins += BurgerReward;
            coinsman.UpdateCoins();
            BurgerButton.gameObject.SetActive(false);
            BurgerClaimed.SetActive(true);
            PlayerPrefs.SetInt("BurgerClaimed", 1);
        });

        CoffeeButton.onClick.AddListener(() => {
            CoinsManager.Coins += CoffeeReward;
            coinsman.UpdateCoins();
            CoffeeButton.gameObject.SetActive(false);
            CoffeeClaimed.SetActive(true);
            PlayerPrefs.SetInt("CoffeeClaimed", 1);
        });

        OfficeButton.onClick.AddListener(() => {
            CoinsManager.Coins += OfficeReward;
            coinsman.UpdateCoins();
            OfficeButton.gameObject.SetActive(false);
            OfficeClaimed.SetActive(true);
            PlayerPrefs.SetInt("OfficeClaimed", 1);
        });

        PetButton.onClick.AddListener(() => {
            CoinsManager.Coins += PetReward;
            coinsman.UpdateCoins();
            PetButton.gameObject.SetActive(false);
            PetClaimed.SetActive(true);
            PlayerPrefs.SetInt("PetClaimed", 1);
        });

        PizzaButton.onClick.AddListener(() => {
            CoinsManager.Coins += PizzaReward;
            coinsman.UpdateCoins();
            PizzaButton.gameObject.SetActive(false);
            PizzaClaimed.SetActive(true);
            PlayerPrefs.SetInt("PizzaClaimed", 1);
        });

        SuperButton.onClick.AddListener(() => {
            CoinsManager.Coins += SuperReward;
            coinsman.UpdateCoins();
            SuperButton.gameObject.SetActive(false);
            SuperClaimed.SetActive(true);
            PlayerPrefs.SetInt("SuperClaimed", 1);
        });

        TrainButton.onClick.AddListener(() => {
            CoinsManager.Coins += TrainReward;
            coinsman.UpdateCoins();
            TrainButton.gameObject.SetActive(false);
            TrainClaimed.SetActive(true);
            PlayerPrefs.SetInt("TrainClaimed", 1);
        });

        FuelButton.onClick.AddListener(() => {
            CoinsManager.Coins += FuelReward;
            coinsman.UpdateCoins();
            FuelButton.gameObject.SetActive(false);
            FuelClaimed.SetActive(true);
            PlayerPrefs.SetInt("FuelClaimed", 1);
        });

        InvestButton.onClick.AddListener(() => {
            CoinsManager.Coins += InvestReward;
            coinsman.UpdateCoins();
            InvestButton.gameObject.SetActive(false);
            InvestClaimed.SetActive(true);
            PlayerPrefs.SetInt("InvestClaimed", 1);
        });

        TipsButton.onClick.AddListener(() => {
            CoinsManager.Coins += TipsReward;
            coinsman.UpdateCoins();
            TipsButton.gameObject.SetActive(false);
            TipsClaimed.SetActive(true);
            PlayerPrefs.SetInt("TipsClaimed", 1);
        });

        TowButton.onClick.AddListener(() => {
            CoinsManager.Coins += TowReward;
            coinsman.UpdateCoins();
            TowButton.gameObject.SetActive(false);
            TowClaimed.SetActive(true);
            PlayerPrefs.SetInt("TowClaimed", 1);
        });

        OnTimeButton.onClick.AddListener(() => {
            CoinsManager.Coins += OnTimeReward;
            coinsman.UpdateCoins();
            OnTimeButton.gameObject.SetActive(false);
            OnTimeClaimed.SetActive(true);
            PlayerPrefs.SetInt("OnTimeClaimed", 1);
        });
    }

    public void ResetValues()
    {
        PlayerPrefs.SetInt("AirportMission", 0);
        PlayerPrefs.SetInt("BankMission", 0);
        PlayerPrefs.SetInt("BurgerMission", 0);
        PlayerPrefs.SetInt("CoffeeMission", 0);
        PlayerPrefs.SetInt("OfficeMission", 0);
        PlayerPrefs.SetInt("PetMission", 0);
        PlayerPrefs.SetInt("PizzaMission", 0);
        PlayerPrefs.SetInt("SuperMission", 0);
        PlayerPrefs.SetInt("TrainMission", 0);
        PlayerPrefs.SetInt("FuelMission", 0);
        PlayerPrefs.SetInt("InvestMission", 0);
        PlayerPrefs.SetInt("TipsMission", 0);
        PlayerPrefs.SetInt("TowMission", 0);
        PlayerPrefs.SetInt("OnTImeMission", 0);


        AirportValue = 0;
        BankValue = 0;
        BurgerValue = 0;
        CoffeeValue = 0;
        OfficeValue = 0;
        PetValue = 0;
        PizzaValue = 0;
        SuperValue = 0;
        TrainValue = 0;
        FuelValue = 0;
        InvestValue = 0;
        TipsValue = 0;
        TowValue = 0;
        OnTimeValue = 0;


        AirportButton.gameObject.SetActive(false);
        AirportClaimed.SetActive(false);

        BankButton.gameObject.SetActive(false);
        BankClaimed.SetActive(false);

        BurgerButton.gameObject.SetActive(false);
        BurgerClaimed.SetActive(false);

        CoffeeButton.gameObject.SetActive(false);
        CoffeeClaimed.SetActive(false);

        OfficeButton.gameObject.SetActive(false);
        OfficeClaimed.SetActive(false);

        PetButton.gameObject.SetActive(false);
        PetClaimed.SetActive(false);

        PizzaButton.gameObject.SetActive(false);
        PizzaClaimed.SetActive(false);

        SuperButton.gameObject.SetActive(false);
        SuperClaimed.SetActive(false);

        TrainButton.gameObject.SetActive(false);
        TrainClaimed.SetActive(false);

        FuelButton.gameObject.SetActive(false);
        FuelClaimed.SetActive(false);

        InvestButton.gameObject.SetActive(false);
        InvestClaimed.SetActive(false);

        TipsButton.gameObject.SetActive(false);
        TipsClaimed.SetActive(false);

        TowButton.gameObject.SetActive(false);
        TowClaimed.SetActive(false);

        OnTimeButton.gameObject.SetActive(false);
        OnTimeClaimed.SetActive(false);


        foreach (GameObject mission in Missions)
        {
            mission.SetActive(false);
        }

        for (int i = 0; i <= 3; i++)
        {
            randomNumber = Random.Range(0, 13);
            
            if (Missions[randomNumber].activeSelf == false)
            {
                Missions[randomNumber].SetActive(true);
                PlayerPrefs.SetInt("Dailyi" + i, randomNumber);
            }
            else i--;
        }
       
    }

    
    
    
}
