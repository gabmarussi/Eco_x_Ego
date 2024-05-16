using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController character;
    private Animator animator;
    private Camera mainCamera;
    private Vector3 inputs;
    private float velocidade = 2f;
    private float velocidadeCorrendo = 7f;
    private float sensibilidade = 180f;
    private float forcaPulo = 6f;
    private bool estaNoChao;

    // Variáveis de controle de stamina
    public float staminaMax = 100f;
    public float staminaAtual;
    public float taxaConsumoStamina = 10f;
    public float taxaRecuperacaoStamina = 5f;

    void Start()
    {
        character = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        mainCamera = Camera.main;
        staminaAtual = staminaMax; // Começa com a stamina máxima
    }

    void Update()
    {
        estaNoChao = character.isGrounded;

        // Consumo de stamina ao correr
        if (Input.GetKey(KeyCode.LeftShift) && staminaAtual > 0)
        {
            staminaAtual -= taxaConsumoStamina * Time.deltaTime;
            if (staminaAtual < 0)
            {
                staminaAtual = 0;
            }
        }

        // Recuperação de stamina quando não estiver correndo
        if (!Input.GetKey(KeyCode.LeftShift) && staminaAtual < staminaMax)
        {
            staminaAtual += taxaRecuperacaoStamina * Time.deltaTime;
            if (staminaAtual > staminaMax)
            {
                staminaAtual = staminaMax;
            }
        }

        // Verifica se o jogador está pressionando Shift para correr e se ele tem stamina suficiente para correr
        bool correndo = Input.GetKey(KeyCode.LeftShift) && staminaAtual > 0;
        float velocidadeAtual = correndo ? velocidadeCorrendo : velocidade;

        // Verifica se o jogador está pressionando as teclas de movimento
        bool movendo = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);

        // Define a velocidade atual do personagem com base na stamina e nas teclas de movimento
        if (movendo)
        {
            velocidadeAtual = correndo ? velocidadeCorrendo : velocidade;
        }
        else
        {
            velocidadeAtual = velocidade;
        }

        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= velocidadeAtual * Time.deltaTime;

        character.Move(moveDirection);

        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * sensibilidade * Time.deltaTime, 0));

        inputs.y += Physics.gravity.y * Time.deltaTime;
        character.Move(inputs * Time.deltaTime);

        // Animações

        // animação para esquerda
        animator.SetBool("Esquerda", Input.GetKey(KeyCode.A));

        // animação para direita 
        animator.SetBool("Direita", Input.GetKey(KeyCode.D));

        // animação para frente 
        animator.SetBool("frente", Input.GetKey(KeyCode.W));

        // animação para trás 
        animator.SetBool("tras", Input.GetKey(KeyCode.S));

        // animação correndo para frente
        animator.SetBool("correndoFrente", correndo && Input.GetKey(KeyCode.W));

        // animação pulando e correndo 
        animator.SetBool("puloShift", Input.GetKeyDown(KeyCode.Space) && correndo);

        // Lógica de pulo
        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao)
        {
            inputs.y = forcaPulo;
            animator.SetBool("pulando", true);
        }

        if (estaNoChao && !Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("pulando", false);
        }
    }
}