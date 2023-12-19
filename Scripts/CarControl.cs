
using Cinemachine;
using JetBrains.Annotations;
using SimpleInputNamespace;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class CarControl : MonoBehaviour, IGameEventListener
{
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider backLeft;

    public float acceleration = 500f;
    public float brakingForce = 3000f;
    public float maxTurnAngle = 15f;

    public float currentAcceleration = 0f;
    public float currentBrakeForce = 0f;
    public float currentTurnAngle = 0f;

    public bool levelWonFreeze = false;
    public bool levelFailedFreeze = false;

    public Rigidbody rb;

    public ParticleSystem leftTyreSmokeEffect;
    public ParticleSystem rightTyreSmokeEffect;

    public GameManager gameManager;

    public bool gameBegins = false;

    //button functions
    
    [HideInInspector]
    public float accInput;
   
    [HideInInspector]
    public bool brakeInput;

    [HideInInspector]
    public bool toggleCam = false;


    public bool KeyboardControl;
    public GameObject uiMobileControl;

    //top angle vcam
    public GameObject vCamTopAngle;
    //car control cam
    public GameObject vCamCarControl;

    [SerializeField] GameEventSubject gameEventSubject;

    //headlamps
    /*public GameObject headLampLeft;
    public GameObject headLampRight;*/
    
    public void OnGameEvent(string eventName)
    {
        if(eventName == "GameBegins")
        {
            gameBegins = true;

        }
    }
    private void FixedUpdate()
    {
       

        if (KeyboardControl)
        {
            GetKeyboardInput();
        }
        else
        {
            GetInput();
        }


        MoveCar();
        SteerWheel();
        if (toggleCam)
        {
            vCamTopAngle.SetActive(true);
        }
        else
        {
            vCamTopAngle.SetActive(false);
        }

      

        //smoke effect
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && Input.GetKeyUp(KeyCode.Space))
        {

            StartCoroutine(PlayEffect());

        }
        if (currentTurnAngle != 0 && accInput>1)
        {
            StartCoroutine(PlayEffect());
        }
        IEnumerator PlayEffect()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || currentTurnAngle<0)
            {
                leftTyreSmokeEffect.Play();
            }
            else
            {
                rightTyreSmokeEffect.Play();
            }
            yield return new WaitForSeconds(0.25f);

            leftTyreSmokeEffect.Stop();
            rightTyreSmokeEffect.Stop();
        }
    }
    private void Update()
    {
        

       
        if (levelWonFreeze)
        {

            FreezeAll();


            Invoke("LoadLevel", 3f);

        }
     
        if (levelFailedFreeze)
        {
            FreezeAll();
        }
       
        

    }

     
    public void LoadLevel()
    {
        gameManager.LoadNextLevel();
    }

    private void FreezeAll()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
   
    public void GetInput()
    {
        
        currentAcceleration = accInput * acceleration;
      
        currentTurnAngle = maxTurnAngle * SimpleInput.GetAxis("Horizontal") ;

        if (brakeInput)
        {
            currentBrakeForce = brakingForce;
            Brake();

        }
        else
        {
            currentBrakeForce = 0f;
            Brake();

        }



    }
    public void GetKeyboardInput()
    {
        if (gameBegins)
        {
            uiMobileControl.SetActive(false);


            currentAcceleration = acceleration * Input.GetAxis("Vertical");


            currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");

            if (Input.GetKey(KeyCode.Space))
            {
                currentBrakeForce = brakingForce;
                Brake();

            }
            else
            {
                currentBrakeForce = 0f;
                Brake();

            }
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                if (!toggleCam)
                    toggleCam = true;
                else
                    toggleCam = false;
            }

        }
        
    /*    if(Input.GetKeyDown(KeyCode.LeftAlt))
        {
            HeadLampsOn();
        }
        if(Input.GetKeyUp(KeyCode.LeftAlt))
        {
            HeadLampsOff();
        }*/


    }
    public void MoveCar()
    {
        //apply acceleration to front wheels
        frontRight.motorTorque = currentAcceleration;
        frontLeft.motorTorque = currentAcceleration;
    }
    public void SteerWheel()
    {
        frontRight.steerAngle = currentTurnAngle;
        frontLeft.steerAngle = currentTurnAngle;
    }
    public void Brake()
    {
        frontRight.brakeTorque = currentBrakeForce;
        frontLeft.brakeTorque = currentBrakeForce;
        backRight.brakeTorque = currentBrakeForce;
        backLeft.brakeTorque = currentBrakeForce;
    }

    
    

    public void AccPressed()
    {
        accInput = 1f;
    }
    public void AccReleased()
    {
        accInput = 0;
    }

    public void RevPressed()
    {
        accInput = -1f;
       
    }
    public void RevReleased()
    {
        accInput = 0;
        
    }

    public void BrakePressed()
    {
        brakeInput = true;
    }
    public void BrakeReleased()
    {
        brakeInput = false;
    }
    public void ToggleCamPressed()
    {
        if (!toggleCam)
            toggleCam = true;
        else
            toggleCam = false;
    }
   
   /* public void HeadLampsOn()
    {
        headLampLeft.SetActive(true);
        headLampRight.SetActive(true);  
    }
    public void HeadLampsOff()
    {
        headLampLeft.SetActive(false);
        headLampRight.SetActive(false);
    }*/

}
