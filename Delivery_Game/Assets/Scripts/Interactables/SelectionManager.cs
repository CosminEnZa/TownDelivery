using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SelectionManager : MonoBehaviour
{
    public Camera cam;
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private string DropTag = "Drop";

    public TMPro.TextMeshProUGUI Info_Text;
    public TMPro.TextMeshProUGUI bonus_text;

    public GameObject drop_box_text;

    public GameObject happy;
    public GameObject sad;
    public GameObject normal;

    public TMPro.TextMeshProUGUI Text;

    public GameObject DropButton;
    public GameObject PickButton;

    private Transform _selection;

    
    public GameObject BoxPlace;
    public GameObject DropPlace;

   public GameObject CurrentBoxPos;

    public GameObject PlayerBoxPos;
    public GameObject PlayerObjectPos;

    public static bool hasBox = false;
    public bool hasBoxTest;

    public float interactionDistance;

    public GameObject[] SpawnList;
    public GameObject DeliverPoint;
    public GameObject boxList;

    public GameObject deliverWaypoint;
    public GameObject DropButtonRandom;

    public TMPro.TextMeshProUGUI test_hasbox_text;

    public UnityEvent CurrentTask;
    public TMPro.TextMeshProUGUI CurrentTaskText;

    GameObject currentBox;

    bool pressed = false;

    private void Start()
    {
        Text.text = "";
        hasBox = false;
        SpawnList = new GameObject[boxList.transform.childCount];
        int i = 0;
        foreach (Transform child in boxList.transform)
        {
            SpawnList[i] = child.gameObject;
            i++;
        }
    }

    private void Update()
    {
        hasBoxTest = hasBox;
        if(_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.GetComponent<Outline>().enabled = false;
            Text.text = "";
            DropButton.SetActive(false);
            PickButton.SetActive(false);
            _selection = null;
        }

        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;   

        if (Physics.Raycast(ray, out hit, 3.5f))
        {
             var selection = hit.transform;

            CurrentBoxPos = selection.gameObject;

            if (selection.CompareTag(selectableTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.GetComponent<Outline>().enabled = true;
                    
                }
                _selection = selection;
            }


            if (selection.CompareTag(DropTag) || selection.CompareTag("SortDrop") || selection.CompareTag("DeliverBox"))
            {
                DropPlace = CurrentBoxPos;
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    
                    if (hasBox == true && currentBox.tag != "Object")
                    {
                        selectionRenderer.GetComponent<Outline>().enabled = true;
                        DropButton.SetActive(true);
                        DropPlace = CurrentBoxPos;
                        Text.text = "<color=green>Press</color> to place the package.";
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            BoxPlace.GetComponent<PickBox>().ObjectPosition = DropPlace;
                            hasBox = false;
                            ////drop_box_text.SetActive(false);
                            DropButtonRandom.SetActive(false);

                            // DropPlace.SetActive(false);
                        }

                    }
                      
                        
                    }

                    
                
                _selection = selection;
            }
          

            if (selection.CompareTag("Box") || selection.CompareTag("PackedBox"))
            {
                
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selection != null)
                {
                    
                    selectionRenderer.GetComponent<Outline>().enabled = true;
                    CurrentTask.Invoke();
                    
                    float minutes = Mathf.FloorToInt(selectionRenderer.GetComponent<BoxManager>().timeRemaining / 60);
                    float seconds = Mathf.FloorToInt(selectionRenderer.GetComponent<BoxManager>().timeRemaining % 60);
                    CurrentTaskText.text = "Time left: " + string.Format("{0:00}:{1:00}", minutes, seconds) + "\n" + "From: " + selectionRenderer.GetComponent<BoxManager>().from + "\n" + "To: " + selectionRenderer.GetComponent<BoxManager>().peopleName + "\n" + "Delivery Reward: " + selectionRenderer.GetComponent<BoxManager>().price;
                    if (hasBox == false)
                    {
                        PickButton.SetActive(true);
                        BoxPlace = CurrentBoxPos;

                    
                        Text.text = "<color=green>Press</color> to pick the package.";
                        if(Input.GetKeyDown(KeyCode.E) || pressed == true)
                        {
                            currentBox = selection.gameObject;
                            BoxPlace.GetComponent<PickBox>().ObjectPosition = PlayerBoxPos;
                            BoxPlace.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                            BoxPlace.GetComponent<Rigidbody>().isKinematic = true;
                            BoxPlace.GetComponent<Rigidbody>().useGravity = false;
                            BoxPlace.GetComponent<BoxCollider>().isTrigger = true;
                            BoxPlace.GetComponent<BoxManager>().remainPicked = true;
                            BoxPlace.transform.eulerAngles = new Vector3(0,0,0);
                            hasBox = true;
                            Tutorial.has_picked_a_box = true;
                            DropButtonRandom.SetActive(true);
                            deliverWaypoint.SetActive(false);
                            // DropPlace.SetActive(true);
                            if (selection.CompareTag("PackedBox"))
                            {
                                Info_Text.text = " Name: " + selection.GetComponent<BoxManager>().peopleName;

                                DeliverPoint.SetActive(true);
                                if(selection.GetComponent<BoxManager>().hasLocation == false)
                                {
                                    DeliverPoint.transform.position = SpawnList[Random.Range(0, SpawnList.Length)].transform.position;
                                    selection.GetComponent<BoxManager>().hasLocation = true;
                                    selection.GetComponent<BoxManager>().pointLocation = new Vector3(DeliverPoint.transform.position.x, DeliverPoint.transform.position.y, DeliverPoint.transform.position.z);
                                    deliverWaypoint.SetActive(true);
                                    
                                }
                                else if(selection.GetComponent<BoxManager>().hasLocation == true)
                                {
                                    DeliverPoint.transform.position = selection.GetComponent<BoxManager>().pointLocation;
                                    deliverWaypoint.SetActive(true);
                                }
                            }        
                        }
                    }
                    if (hasBox == true)
                    {
                        Text.text = "You can't carry 2 packages.";
                    }

                }
                _selection = selection;
            }

            if (selection.CompareTag("Object"))
            {

                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selection != null)
                {
                    selectionRenderer.GetComponent<Outline>().enabled = true;
                    if (hasBox == false)
                    {
                        PickButton.SetActive(true);
                        BoxPlace = CurrentBoxPos;


                        Text.text = "<color=green>Press</color> to pick the object.";
                        if (Input.GetKeyDown(KeyCode.E) || pressed == true)
                        {
                            currentBox = selection.gameObject;
                            BoxPlace.GetComponent<PickBox>().ObjectPosition = PlayerObjectPos;
                            BoxPlace.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                            BoxPlace.GetComponent<Rigidbody>().isKinematic = true;
                            BoxPlace.GetComponent<Rigidbody>().useGravity = false;
                            BoxPlace.GetComponent<BoxCollider>().isTrigger = true;       
                            BoxPlace.transform.eulerAngles = new Vector3(0, 0, 0);
                            hasBox = true;
                            DropButtonRandom.SetActive(true);
                            deliverWaypoint.SetActive(false);
                            // DropPlace.SetActive(true);
                           
                        }
                    }
                    if (hasBox == true && currentBox.tag == "Object")
                    {
                        ////Text.text = "<color=green>Press</color> to place the object.";
                        /////
                        if (Input.GetKeyDown(KeyCode.F) || pressed == true)
                        {
                            BoxPlace.GetComponent<PickBox>().Reset();
                            hasBox = false;

                            BoxPlace.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                            BoxPlace.GetComponent<Rigidbody>().isKinematic = false;
                            BoxPlace.GetComponent<Rigidbody>().useGravity = true;
                            BoxPlace.GetComponent<BoxCollider>().isTrigger = false;

                        }
                        ////
                    }

                }
                _selection = selection;
            }

        }

        /////
        if (hasBox == true && (BoxPlace.CompareTag("Box") || BoxPlace.CompareTag("PackedBox")))
        {
            ////drop_box_text.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                BoxPlace.GetComponent<PickBox>().Reset();
                hasBox = false;
               //// drop_box_text.SetActive(false);
                BoxPlace.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                BoxPlace.GetComponent<Rigidbody>().isKinematic = false;
                BoxPlace.GetComponent<Rigidbody>().useGravity = true;
                BoxPlace.GetComponent<BoxCollider>().isTrigger = false;
            }
        }
        //////

        test_hasbox_text.text = hasBox.ToString();
        if (currentBox != null && currentBox.tag != "Object")
        {
            if (currentBox.GetComponent<BoxManager>().ID == "happy")
            {
                bonus_text.text = "Delivery bonus: +" + currentBox.GetComponent<BoxManager>().price * 0.2f + "$ tips";
                sad.SetActive(false);
                normal.SetActive(false);
                happy.SetActive(true);
               
            }
            else if (currentBox.GetComponent<BoxManager>().ID == "normal")
            {
                bonus_text.text = "Delivery bonus: no bonus";
                sad.SetActive(false);
                normal.SetActive(true);
                happy.SetActive(false);
            
            }
            else if (currentBox.GetComponent<BoxManager>().ID == "sad")
            {
                bonus_text.text = "Too late. " + currentBox.GetComponent<BoxManager>().price * 0.2f + "$ less";
                sad.SetActive(true);
                normal.SetActive(false);
                happy.SetActive(false);
         
            }
        }
    }

    public void Pick_Box()
    {
        pressed = true;
       
    }

    public void Drop_Box()
    {
        pressed = false;
        if (hasBox)
        {
            BoxPlace.GetComponent<PickBox>().ObjectPosition = DropPlace;
            hasBox = false;
            DropButtonRandom.SetActive(false);
        }
    }

    public void Drop_Box_With_Buton()
    {
        pressed = false;
        BoxPlace.GetComponent<PickBox>().Reset();
        hasBox = false;

        BoxPlace.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        BoxPlace.GetComponent<Rigidbody>().isKinematic = false;
        BoxPlace.GetComponent<Rigidbody>().useGravity = true;
        BoxPlace.GetComponent<BoxCollider>().isTrigger = false;

        DropButtonRandom.SetActive(false);
        
    }

}
