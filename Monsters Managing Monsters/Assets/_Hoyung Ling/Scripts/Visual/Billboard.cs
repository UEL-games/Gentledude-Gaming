﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{

    //Should we look at the camera?
    public bool BL_LookAtPC = false;
    public bool BL_LookAtCam = false;

    private GameObject player;
    private Quaternion originalRot;

    float playerfollowSmoothSpeed = 5f;
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
        if (BL_LookAtPC)
        {
            if (Vector3.Distance(gameObject.transform.position, player.transform.position) < 15f)
            {
                //originalRot = transform.rotation;
                lookPos = transform.position - player.transform.position;
                lookPos.y = 0;
                rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, playerfollowSmoothSpeed * Time.deltaTime);
            }
            else
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, originalRot, playerfollowSmoothSpeed * Time.deltaTime);
            }
        }else if (BL_LookAtCam)
        {
            //originalRot = transform.rotation;
            lookPos = transform.position - Camera.main.transform.position;
            rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, playerfollowSmoothSpeed * Time.deltaTime);
        }
    }
}
