using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public FuelManager fuelmanager;
    public CoinsManager coinsman;
    public GameObject CarTowTransform;

    private float horizontalInput;
    private float verticalInput;
    private float steerAngle;
    public static bool isBreaking;

    public Material normal;
    public Material bright;

    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider rearLeftWheelCollider;
    public WheelCollider rearRightWheelCollider;
    public Transform frontLeftWheelTransform;
    public Transform frontRightWheelTransform;
    public Transform rearLeftWheelTransform;
    public Transform rearRightWheelTransform;

    public float maxSteeringAngle = 30f;
    public float motorForce = 50f;
    public float brakeForce = 0f;

    private bool breaking;
    private bool left;
    private bool right;

    public static float speed = 0.0f;
    public Rigidbody _rb;
    public GameObject Right_Stop;
    public GameObject Left_Stop;
    public GameObject Top_Stop;

    public GameObject[] tow;
    

    public static bool isMoving;
    public static bool noFuel;

    int LayerNotColide;
    int player;


    private void Start()
    {
        breaking = false;
        ReseachComponents();

        isBreaking = false;
        speed = 0;

        int LayerNotColide = LayerMask.NameToLayer("NotColideWithCars");
        int player = LayerMask.NameToLayer("NotColideWithCars");
    }

    public void ReseachComponents()
    {
        frontLeftWheelCollider = GameObject.Find("Front Left Collider").GetComponent<WheelCollider>();
        frontRightWheelCollider = GameObject.Find("Front Right Collider").GetComponent<WheelCollider>();
        rearLeftWheelCollider = GameObject.Find("Rear Left Collider").GetComponent<WheelCollider>();
        rearRightWheelCollider = GameObject.Find("Rear Right Collider").GetComponent<WheelCollider>();

        frontLeftWheelTransform = GameObject.Find("Front Left Wheel").transform;
        frontRightWheelTransform = GameObject.Find("Front Right Wheel").transform;
        rearLeftWheelTransform = GameObject.Find("Rear Left Wheel").transform;
        rearRightWheelTransform = GameObject.Find("Rear Right Wheel").transform;

        Right_Stop = GameObject.Find("Right_Stop");
        Left_Stop = GameObject.Find("Left_Stop");
        Top_Stop = GameObject.Find("Top_Stop");
    }
    

   public void PayTow()
    {
            noFuel = false;
            CoinsManager.Coins -= 350;
            this.transform.position = CarTowTransform.transform.position;
            coinsman.UpdateCoins();
            fuelmanager.currentFuel = 0;
            this.gameObject.transform.eulerAngles = new Vector3(0, -90, 0);
            tow[0].SetActive(false);
            tow[1].SetActive(false);
    }

    public void GetA100Tow()
    {
        CoinsManager.Coins -= 100;
        WorkDayOver.tow += 100;
        this.transform.position = CarTowTransform.transform.position;
        coinsman.UpdateCoins();
        this.gameObject.transform.eulerAngles = new Vector3(0, -90, 0);
        tow[0].SetActive(false);
        tow[1].SetActive(false);

        MissionsManager.TowValue += 1;
        GameObject.Find("CoinsManager & CANVAS").GetComponent<MissionsManager>().UpdateMission();
    }

        private void FixedUpdate()
        {

        

        speed = transform.InverseTransformDirection(_rb.velocity).z * 3.6f;

       // breaking = Input.GetKey(KeyCode.Space);

        

        
        GetInput();
       
        HandleMotor();
        
        HandleSteering();
        UpdateWheels();

        if(_rb.velocity.magnitude > 0.01f)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    
        if(CarSwitch.isOn == true)
        {
            this.gameObject.layer = LayerNotColide;
        }
        else if (CarSwitch.isOn == false)
        {
            this.gameObject.layer = player;
        }

    }

    private void GetInput()
    {
        if (CarSwitch.isOn)
        {
            if (noFuel == false)
            {
               // horizontalInput = Input.GetAxis("Horizontal");
               // verticalInput = Input.GetAxis("Vertical");
            }
            isBreaking = breaking;
        }
    }

    private void HandleSteering()
    {
        steerAngle = maxSteeringAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = steerAngle;
        frontRightWheelCollider.steerAngle = steerAngle;
    }

    private void HandleMotor()
    {
            frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
            frontRightWheelCollider.motorTorque = verticalInput * motorForce;

        brakeForce = isBreaking ? 3000f : 0f;
        if (isBreaking)
        {
            Top_Stop.GetComponent<MeshRenderer>().material = bright;
            Right_Stop.GetComponent<MeshRenderer>().material = bright;
            Left_Stop.GetComponent<MeshRenderer>().material = bright;
        }
        else
        {
            Top_Stop.GetComponent<MeshRenderer>().material = normal;
            Right_Stop.GetComponent<MeshRenderer>().material = normal;
            Left_Stop.GetComponent<MeshRenderer>().material = normal;
        }

        frontLeftWheelCollider.brakeTorque = brakeForce;
        frontRightWheelCollider.brakeTorque = brakeForce;
        rearLeftWheelCollider.brakeTorque = brakeForce;
        rearRightWheelCollider.brakeTorque = brakeForce;
    }

    private void UpdateWheels()
    {
        UpdateWheelPos(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateWheelPos(frontRightWheelCollider, frontRightWheelTransform);
        UpdateWheelPos(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateWheelPos(rearRightWheelCollider, rearRightWheelTransform);
    }

    private void UpdateWheelPos(WheelCollider wheelCollider, Transform trans)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        trans.rotation = rot;
        trans.position = pos;
    }

    public void SpeedUp()
    {
        if (fuelmanager.currentFuel < 180)
        {
            verticalInput = 1;
        }
    }

    public void SpeedDown()
    {
        verticalInput = 0;
    }

    public void ReverseUp()
    {
        if (fuelmanager.currentFuel < 180)
        {
            verticalInput = -1;
        }
    }

    public void ReverseDown()
    {
        verticalInput = 0;
    }

    public void RightUp()
    {      
       horizontalInput = 0;
    }
     
    public void RightDown()
    {
        horizontalInput = 1;
    }

    public void LeftUp()
    {
       horizontalInput = 0;
    }

    public void LeftDown()
    { 
            horizontalInput = -1;
    }

    public void BreakUp()
    {
        breaking = true;
    }

    public void BreakDown()
    {
        breaking = false;
    }
    

}