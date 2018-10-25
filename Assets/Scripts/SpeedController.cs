using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpeedController : MonoBehaviour {

    //Declare for using other script variable
    private LeftControllerVelocity left; 
    private RightControllerVelocity right;

    //GameObject Insert
    [Tooltip("Insert Left Contoller (GameObj)")]
    public GameObject leftDevice;
    [Tooltip("Insert Right Contoller (GameObj)")]
    public GameObject rightDevice;

    

    //Adjustable Parameters
    [Range(0,10)]
    [Tooltip("Player's Speed")]
    public int speed = 0;
    [Range(1,3)]
    [Tooltip("Increase Step(s)")]
    public int steps = 1;
    [Range(1,3)]
    [Tooltip("Decrease Step(s)")]
    public int decrease = 1;

    [Tooltip("Minimum Threshold before speed decrease")]
    public int minT = 30;

    [Tooltip("Threshold before speed increase")]
    public int maxT = 80;

    [Tooltip("Delta Time (Delay time)")]
    public int Delta = 80;


    //Private Vairable
    private float VelL;
    private float VelR;
    private int currentDelta = 0;
    
    void FixedUpdate() {

        left = leftDevice.GetComponent<LeftControllerVelocity>();
        right = rightDevice.GetComponent<RightControllerVelocity>();

        VelL = left.AvgVelL;
        VelR = right.AvgVelR;

        print(VelL + " " + VelR); //Print Current AVGSpeed //For Debuging

        if (currentDelta == Delta)
        {
            if (VelL > maxT && VelR > maxT) //Check Increase
            {
                if (speed < 10)
                {
                    //increase speed
                    speed = speed + steps;

                    if (speed > 10)
                    {
                        //Check Speed not more than 10
                        speed = 10;
                    }
                }
            }
            else if (VelL < maxT && VelL > minT || VelR < maxT && VelR > minT) //Check Maintain
            {
                if(speed == 0)
                {
                    //When Fully Stopped
                    speed++;
                }
                //maintain speed
            }
            else if (VelL < minT && VelR < minT) //Check Decrease
            {
                if (speed != 0)
                {
                    if(speed < 0)
                    {
                        //Check Speed not less than 0
                        speed = 0;
                    }
                    //decrease speed
                    speed = speed - decrease;
                }
            }
            currentDelta = 0; //Reset Delta
        }
        else
        {
            currentDelta++; //Increase Current Delta
        }
        print(speed);
        /*To get speed parameter using GetComponet<> from this scrpit by referencing CameraRig Object*/
	}
}
