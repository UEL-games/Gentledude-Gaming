﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{

    //Should we look at the camera?
    public bool BL_LookAtCam = false;
    public bool BL_LookAtPC = false;

    private GameObject player;
    private Quaternion originalRot;

    float playerfollowSmoothSpeed = 2f;
    Vector3 lookPos;
    Quaternion rotation;

    //Direction in front of the player
    public Transform Forward;

    // Use this for initialization
    private void Start()
    {
        player = FindObjectOfType<PC_Controller>().gameObject;
        originalRot = transform.rotation;
    }

    // Update is called once per frame
    virtual public void Update()
    {
        if(TargetHandler.instance.heroCount > 0)
        {
            BL_LookAtPC = false;
        }

        if(Vector3.Distance(gameObject.transform.position, player.transform.position) < 10)
        {
            originalRot = transform.rotation;
            lookPos = transform.position - Camera.main.transform.position;
            lookPos.y = 0;
            rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, playerfollowSmoothSpeed * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRot, playerfollowSmoothSpeed * Time.deltaTime);
        }

        /*if(BL_LookAtPC)
        {            
            if (Vector3.Distance(gameObject.transform.position, player.transform.position) < 10)
            {
                lookPos = transform.position - player.transform.position;
                lookPos.y = 0;
                rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, playerfollowSmoothSpeed * Time.deltaTime);
            }  
            else
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, originalRot, playerfollowSmoothSpeed * Time.deltaTime);
            }
        }
        else if (BL_LookAtCam)
        {
            lookPos = transform.position - Camera.main.transform.position;
            lookPos.y = 0;
            rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, playerfollowSmoothSpeed * Time.deltaTime);
        }
        else
        {
            lookPos = transform.position - Forward.position;
            lookPos.y = 0;
            rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, playerfollowSmoothSpeed * Time.deltaTime);
        }*/
    }
}