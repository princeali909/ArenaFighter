using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Arena.Helper;
using Arena.General;

namespace Arena.Player
{

    public class PlayerMovement : MonoBehaviour
    {
        private CharacterAnimation playerAnimation;
        private Rigidbody myBody;
        
    
        public float walkSpeed = 2f;
        public float zSpeed = 1.5f;
    
        private float rotationY = -90f;
        private float rotationSpeed = 15f;

        private void Awake()
        {
            playerAnimation = GetComponentInChildren<CharacterAnimation>();
            myBody = GetComponent<Rigidbody>();
            
        }


        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            RotatePlayer();
            MovePlayer();
        }

        void FixedUpdate()
        {
            DetectMoveMent();
        }


        void DetectMoveMent()
        {
            float XSpeed = Input.GetAxisRaw(TagManager.HORIZONTAL_AXIS) * (-walkSpeed);
            float YSpeed = myBody.velocity.y;
            float ZSpeed = Input.GetAxisRaw(TagManager.VERTICAL_AXIS) * (-zSpeed);
            myBody.velocity = new Vector3(XSpeed, YSpeed, ZSpeed);
        }

        void RotatePlayer()
        {
            if (Input.GetAxisRaw(TagManager.HORIZONTAL_AXIS) > 0)
            {
                transform.GetChild(0).rotation = Quaternion.Euler(0f, rotationY, 0f);
                
            } else if (Input.GetAxisRaw(TagManager.HORIZONTAL_AXIS) < 0)
            {
                transform.GetChild(0).rotation = Quaternion.Euler(0f, Mathf.Abs(rotationY), 0f);
            }
        }

        void MovePlayer()
        {
            if (Input.GetAxisRaw(TagManager.HORIZONTAL_AXIS) != 0 || Input.GetAxisRaw(TagManager.VERTICAL_AXIS) != 0)
            {
                playerAnimation.Walk(true);
            }
            else
            {
                playerAnimation.Walk(false);
            }
        }
    }
}
