using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private CharacterController character;
    private Animator animator;
    private Camera mainCamera;
    private Vector3 inputs;
    private float velocidade = 5f;
    private float sensibilidade = 100f;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Obt�m a entrada do teclado
        inputs.Set(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // Transforma a dire��o da entrada local para o espa�o mundial
        inputs = transform.TransformDirection(inputs);

        // Move o personagem
        character.Move(inputs * Time.deltaTime * velocidade);

        // Rota��o da c�mera (horizontal)
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * sensibilidade * Time.deltaTime, 0));

        // Rota��o da c�mera (vertical)
        // float mouseY = -Input.GetAxis("Mouse Y") * sensibilidade * Time.deltaTime;
        // mainCamera.transform.Rotate(new Vector3(mouseY, 0, 0));

        // Verifica se o personagem est� se movendo para definir a anima��o corretamente
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
