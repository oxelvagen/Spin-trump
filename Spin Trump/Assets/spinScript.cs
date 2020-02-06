using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spinScript : MonoBehaviour
{

    //initiera lite variabler

    public Rigidbody2D player;

    public float torque = 1f;

    public int spins = 0; //Totala antalet snurr

    public float currentSpeed = 0; //Akutell hastighet

    public Image help; //Pratbubbla hjälp

    private Image rend; //vindögd bild vid 100RPM

    public Sprite trumpSprite, trumpvinogdSprite;//väljer mellan de olika

    public float highestSpeed = 0;

    float deltaRotation = 0;

    float currentRotation = 0;

    float WindupRotation = 0;

    

    public object Images { get; private set; }
    

    //------------------------------------------------------------------------------------------------

    void Start()
    {
       

        gameObject.GetComponent<Image>().sprite = trumpSprite;
        

        help.enabled = false; //Sätter bilden gömd till hastihet har uppnåtts
        highestSpeed = PlayerPrefs.GetFloat("highestSpeed", highestSpeed);

    }
    public void onClick()
    {
        player.AddTorque(torque, ForceMode2D.Impulse);

    }
    void Update()
    {
        //Räkna ut hur många snurr som gjorts
        deltaRotation = (currentRotation - transform.eulerAngles.z);
        currentRotation = transform.eulerAngles.z;
        if (deltaRotation >= 300)
            deltaRotation -= 360;
        if (deltaRotation <= -300)
            deltaRotation += 360;
        WindupRotation -= (deltaRotation);

        spins = (int)(WindupRotation / 360);


        //Sätt aktuell hastighet på spelaren--------------------------------------------------------------

        currentSpeed = (player.angularVelocity * ((2 * Mathf.PI) / 60));

        if (currentSpeed > highestSpeed)
        {
            highestSpeed = currentSpeed;
            PlayerPrefs.SetFloat("highestSpeed", highestSpeed);
        }

        //------------------------------------------------------------------------------------------------------
        //Om hastigheten är tillräckligt hög så ska pratbubbla Help komma upp-----------------------------------

        if (currentSpeed >= 50)
        {
            help.enabled = true;
        }
        else
            help.enabled = false;

        //om hastighet över 100 byt sprite

        if (currentSpeed >= 100)
        {
            gameObject.GetComponent<Image>().sprite = trumpvinogdSprite;
        }
        else
            gameObject.GetComponent<Image>().sprite = trumpSprite;
        
        //-----------------------------------------------------------------------------------------------------------
    }
}

