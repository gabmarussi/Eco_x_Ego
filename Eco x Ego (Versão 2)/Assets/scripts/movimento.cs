using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimento : MonoBehaviour


{

    private CharacterController character;
    private Animator animator;
    private Vector3 inputs;
private float velocidade =5f;
    public float sensibilidade = 10f; 


    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        inputs.Set(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        character.Move(inputs * Time.deltaTime * velocidade);

        transform.Rotate(new Vector3(0, (Input.GetAxis("Mouse X") * sensibilidade )* Time.deltaTime, 0)); 

        if (inputs != Vector3.zero)
        {
            animator.SetBool("andando", true);
        }
            else
        {
            animator.SetBool("andando", false);
        }

        

    }
}
