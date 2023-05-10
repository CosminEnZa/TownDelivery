using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public GameObject[] logos;
    public GameObject Canvas;
    public GameObject BarStopTouch;
    public GameObject PlayerCapsule;
    public GameObject TutorialCanvas;
    public GameObject PickOrder;
    public GameObject[] check_list_hide;
    public GameObject check_list_end;
    public GameObject pick_object_3;

    public GameObject left_stop_touch;
    public GameObject right_stop_touch;

    public GameObject head_to_car;

    public GameObject Free_skip_button;
    public static bool check_list_pressed = false;

    bool carEnter = false;
    bool pickBox = false;
    bool placed = false;
    bool sorted = false;

    public TMPro.TextMeshProUGUI text;
    public Animator _anim;

    public static bool has_picked_a_box = false;
    public static bool has_placed_a_box = false;
    public static bool box_sorted = false;

    public GameObject reward;
    public GameObject choose_logo;
    public GameObject end_tutorial;
    bool tolist8 = false;
    public GameObject ArrowSkip;
    public CoinsManager coinsman;
    public static bool endtutorial = false;
    private void Start()
    {
        endtutorial = false;
        check_list_pressed = false;
        has_placed_a_box = false;
        has_picked_a_box = false;
        box_sorted = false;

        if (PlayerPrefs.GetInt("Intro") == 0)
        {

            SceneManager.LoadScene("Intro");
        }

        if (PlayerPrefs.GetInt("Tutorial") == 0)
        {
            TutorialStart();
            Free_skip_button.SetActive(true);
        }
    }

    private void Update()
    {
        if(check_list_pressed == true)
        {
            foreach (GameObject obj in check_list_hide)
            {
                obj.SetActive(false);
            }

            check_list_end.SetActive(true);
            pick_object_3.SetActive(false);
            left_stop_touch.SetActive(true);
            right_stop_touch.SetActive(false);
            
        }
        if (check_list_pressed == false)
        {
            check_list_end.SetActive(false);
        }

        if (CarSwitch.isOn && carEnter == false)
        {
            text.text = "You took your driving license with you, right? Good. Now let's get that package already. \n <b>Press the <i>interaction button</i> once the pointer is on the package.</b>";
            _anim.SetTrigger("Open");
            carEnter = true;
        }
        
        if(has_picked_a_box == true && pickBox == false)
        {
            text.text = "Place it carefully on the passager seat inside your car. Ah, don't worry about me... I'll stay on the back seat. \n Let's get back to the <b>warehouse</b> after that and place the package on the <color=blue>blue</color> shelf.";
            _anim.SetTrigger("Open");
            pickBox = true;
        }

        if (has_placed_a_box == true && placed == false)
        {
            text.text = "Yup, that's it. I think you already met our assistant, <b>Charlotte</b>. After you bring a package to the warehouse, you'll have to wait for <b>Charlotte</b> to pack them, but let's just call for more help for now.";
            _anim.SetTrigger("Open");
            ArrowSkip.SetActive(true);
            placed = true;
            Time.timeScale = 0;
        }

        if (box_sorted == true && sorted == false)
        {
            text.text = "The package is ready for delivery. Take it to the <color=green>green</color> indicator. Hurry up, the customer is waiting!";
            _anim.SetTrigger("Open");          
            sorted = true;
        }

        if (tolist8 && endtutorial)
        {
            reward.SetActive(true);
            tolist8 = false;
        }

    }
    public void ToList8()
    {
        tolist8 = true;
    }
    public void Time1()
    {
        Time.timeScale = 1;
    }

    public void ChooseLogo()
    {
        reward.SetActive(false);
        choose_logo.SetActive(true);

        CoinsManager.Coins += 1000;
        coinsman.UpdateCoins();
    }

    public void ChooseLogo1()
    {
        PlayerPrefs.SetInt("Logo1", 1);
        logos[0].SetActive(true);

        choose_logo.SetActive(false);
        end_tutorial.SetActive(true);
    }

    public void ChooseLogo2()
    {
        PlayerPrefs.SetInt("Logo2", 1);
        logos[1].SetActive(true);

        choose_logo.SetActive(false);
        end_tutorial.SetActive(true);
    }

    public void ChooseLogo3()
    {
        PlayerPrefs.SetInt("Logo3", 1);
        logos[2].SetActive(true);

        choose_logo.SetActive(false);
        end_tutorial.SetActive(true);
    }

    void TutorialStart()
    { 
        TutorialCanvas.SetActive(true);   
    }

    public void LastPanel()
    {
        EndTutorialWith8();
        TutorialDone();
    }

    void EndTutorialWith8()
    {

        PlayerPrefs.SetInt("Tutorial", 1);
    }

    public void TutorialDone()
    {
        Canvas.SetActive(false);
    }

    public void AfterMovement()
    {
        Invoke("StartCheckList", 3);
    }

    void StartCheckList()
    {
        PlayerCapsule.GetComponent<FirstPersonControllerTouch>().enabled = false;
        BarStopTouch.SetActive(false);
        PickOrder.SetActive(true);
    }

    public void GoToCar()
    {
        head_to_car.SetActive(true);

    }
}
