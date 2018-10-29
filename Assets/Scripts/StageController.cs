using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;


public class StageController : MonoBehaviour
{

    public float MainSpeed = 0.1f;
    public float StageSpeed = 0;
    public int PlayerSpeed = 0;
    public bool C_Spawn = true;



    public GameObject SpawnStage;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckUserInput();

        CheckMoveSpeed();

        Moveforward();

        CheckSpawnStage();

    }

    public void CheckUserInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Moveforward();
        }

        ////////////////////////////////////////// TEST PLAYER SPEED ////// START

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            SpeedPlus();
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            SpeedDown();
        }

        ////////////////////////////////////////// TEST PLAYER SPEED ////// END

    }


    ////////////////////////////////////////// TEST PLAYER SPEED ////// START
    public void SpeedPlus()
    {
        PlayerSpeed += 1;
    }

    public void SpeedDown()
    {
        PlayerSpeed -= 1;
    }
    ////////////////////////////////////////// TEST PLAYER SPEED ////// END




    public void Moveforward()
    {
        transform.position -= new Vector3(0, 0, StageSpeed);
    }

    public void CheckMoveSpeed()
    {
        StageSpeed = MainSpeed * PlayerSpeed;
    }

    /*   GET VALUE FROM AVATAR TO MAKE DIFFERENT SPEED
    public void CheckMainSpeed()
    {
        MainSpeed = int GetFromAvatar;
    }

    */

    public void CheckSpawnStage()
    {
        if (this.transform.position.z <= 0)
        {
            if (C_Spawn == true)
            { 
                Instantiate(SpawnStage, new Vector3(0, 0, 170), Quaternion.identity);
                C_Spawn = false;
                return;
            }
        }
        if (this.transform.position.z <= -120)
        {
            if (C_Spawn == false)
            {
                
                Destroy(this.gameObject);
                C_Spawn = true;
            }
        }
    }




    //////////SPEED SECTOR///////////

    public void UpdateSpeedC0()
    {
        PlayerSpeed = 0;
    }
    public void UpdateSpeedC1()
    {
        PlayerSpeed = 1;
    }
    public void UpdateSpeedC2()
    {
        PlayerSpeed = 2;
    }
    public void UpdateSpeedC3()
    {
        PlayerSpeed = 3;
    }
    public void UpdateSpeedC4()
    {
        PlayerSpeed = 4;
    }
    public void UpdateSpeedC5()
    {
        PlayerSpeed = 5;
    }
    public void UpdateSpeedC6()
    {
        PlayerSpeed = 6;
    }
    public void UpdateSpeedC7()
    {
        PlayerSpeed = 7;
    }
    public void UpdateSpeedC8()
    {
        PlayerSpeed = 8;
    }
    //////////SPEED SECTOR///////////
}

