﻿using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class MainCharacterController : MonoBehaviour
{
    //MOVEMENT
    float speed = 1f;
    float rot = 0f;
    float rotSpeed = 80f;
    float gravity = 8f;

    //POWER UPS
    [SerializeField]
    public bool strength = false;
    public float strengthVal = 0f;
    public bool shape = false;
    public bool jumpBoost = false;
    public float jumpYVal = 5f;
    public float jumpXVal = 5f;
    public bool jumpFix = false;

    Vector3 moveDir = Vector3.zero;
    CharacterController controller;
    Animator animate;
    Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>(); //referncing character controller on player in Unity
        //animate = GetComponent<Animator>(); //referencing animator on player in Unity
        trans = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf == true)//if the character is touching the ground
        {
            //----------WALKING MOVEMENT AND ANIMATION (CONDITION 01)----------
            if (Input.GetKey(KeyCode.W))//If the 'w' key is being pressed
            {
                //animate.SetInteger("Condition", 1);
                moveDir = new Vector3(1, 0, 0);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);//sets transform from local space to world space

            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                //animate.SetInteger("Condition", 0);
                moveDir = new Vector3(0, 0, 0);
            }


            //----------SPRINTING MOVEMENT AND ANIMATION (CONDITION 02)----------
            if (Input.GetKey(KeyCode.LeftShift))//If the 'left shift' key is being pressed
            {
                //animate.SetInteger("Condition", 2);
                moveDir = new Vector3(2, 0, 0);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);//sets transform from local space to world space

            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                //animate.SetInteger("Condition", 0);
                moveDir = new Vector3(0, 0, 0);
            }


            //----------RUNNING BACKWARDS MOVEMENT AND ANIMATION (CONDITION 03)----------
            if (Input.GetKey(KeyCode.S))//If the 's' key is being pressed
            {
                //animate.SetInteger("Condition", 3);
                moveDir = new Vector3(-2, 0, 0);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);//sets transform from local space to world space

            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                //animate.SetInteger("Condition", 0);
                moveDir = new Vector3(0, 0, 0);
            }


            //----------JUMPING MOVEMENT AND ANIMATION (CONDITION 05)----------
            if (Input.GetKey(KeyCode.Space))//If the 'space' key is being pressed
            {
                if(jumpFix == false)
                {
                    moveDir = new Vector3(jumpXVal, jumpYVal, 0);
                    moveDir *= speed;
                    moveDir = transform.TransformDirection(moveDir);//sets transform from local space to world space
                    //animate.SetInteger("Condition", 5);             

                    jumpFix = true;
                }
               
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                //animate.SetInteger("Condition", 0);
                moveDir = new Vector3(0, 0, 0);
                jumpFix = false;
            }





            //----------POWER UP 01 - STRENGTH----------



            //----------POWER UP 02 - SHAPE-------------

            if (shape == true)
            {

            }

            //----------POWER UP 03 - JUMP BOOST--------
            //Rotate left and right with the 'a' and 'd' keys
            rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, rot, 0);

            moveDir.y -= gravity * Time.deltaTime; //every frame, move our player on the y axis by gravity value. Essentially, lowering the character to the ground
            controller.Move(moveDir * Time.deltaTime);
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Roll"))
        {
            shape = true;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Strength"))
        {
            strength = true;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Jump"))
        {
            Debug.Log("Here");
            jumpBoost = true;
            jumpYVal += 20f;
            jumpXVal += 7.5f;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Cube"))
        {
            other.SendMessage("Finish");
            //Destroy(other.gameObject);
        }
    }
}