using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    private Animator anim;

    public float speed;
    public float gravity; 

    private Vector3 rot;
    private Vector3 moveDirection;



    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        Move();

    }


    void Move()
    {
         
            if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                moveDirection = Vector3.forward * speed; 
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                moveDirection = Vector3.zero;
            }






        }
            moveDirection.y -= gravity * Time.deltaTime;

        controller.Move(moveDirection * Time.deltaTime);


    }
}
