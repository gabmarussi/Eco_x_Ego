using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DireitaTeste : MonoBehaviour
{
    private CharacterController character;
    private Animator animator;
    private Camera mainCamera;
    private Vector3 inputs;
    private float velocidade = 5f;
    private float sensibilidade = 100f;
    private float forcaPulo = 8f;
    private bool estaNoChao;

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
        // Verifica se o personagem está no chão
        estaNoChao = character.isGrounded;

        // Obtém a entrada do teclado
        inputs.Set(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // Transforma a direção da entrada local para o espaço mundial
        inputs = transform.TransformDirection(inputs);

        // Move o personagem
        character.Move(inputs * Time.deltaTime * velocidade);

        // Rotação da câmera (horizontal)
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * sensibilidade * Time.deltaTime, 0));

        // Aplica a gravidade manualmente
        inputs.y += Physics.gravity.y * Time.deltaTime;

        // Move o personagem conforme a gravidade
        character.Move(inputs * Time.deltaTime);

        // camera e movimentação EM CIMA 


        // ESQUERDA 


        // Verifica se o personagem está se movendo para definir a animação corretamente
        if (Input.GetKey(KeyCode.A))
        {
            // Define a bool "Esquerda" como verdadeira
            animator.SetBool("Esquerda", true);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            // Define a bool "Esquerda" como falsa quando a tecla é solta
            animator.SetBool("Esquerda", false);
        }

        // DIREITA

        // Verifica se o personagem está se movendo para a direita
        if (Input.GetKeyDown(KeyCode.D))
        {
            // Define a bool "Direita" como verdadeira
            animator.SetBool("Direita", true);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            // Define a bool "Direita" como falsa quando a tecla é solta
            animator.SetBool("Direita", false);
        }


        // ANDANDO


        // Verifica se o personagem está se movendo para definir a animação corretamente
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            animator.SetBool("andando", true);
        }
        else
        {
            animator.SetBool("andando", false);
        }


        // PULANDO

        // Verifica se a barra de espaço foi pressionada e o personagem está no chão
        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao)
        {
            // Aplica uma força vertical para fazer o personagem pular
            inputs.y = forcaPulo;

            // Define a bool "pulando" como verdadeira para acionar a animação de pulo
            animator.SetBool("pulando", true);
        }


        // Verifica se o jogador parou de pressionar a barra de espaço e o personagem está no chão
        if (Input.GetKeyUp(KeyCode.Space) && estaNoChao)
        {
            // Define a bool "pulando" como falsa quando o personagem para de pular
            animator.SetBool("pulando", false);
        }
    }

}


