using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController character;
    private Animator animator;
    private Camera mainCamera;
    private Vector3 inputs;
    private bool estaNoChao;
    private float movimentoHorizontal;
    private float movimentoVertical;
    private bool movendo;
    private float corrida;
    private float pulo;
    private float velocidadeAtual;

    private bool canMove = true;

    // Variáveis de controle de stamina
    public float staminaMax = 100f;
    public float staminaAtual;
    public float taxaConsumoStamina = 5f;
    public float taxaRecuperacaoStamina = 10f;

    // Variáveis de controle de pulo
    public float alturaPulo = 3f;
    public float forcaGravidade = -9.81f;
    private float velocidade = 4f;
    private float velocidadeCorrendo = 7f;
    private float sensibilidade = 180f;

    // Referência ao ConversationManager
    private ConversationManager conversationManager;

    void Start()
    {
        character = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        mainCamera = Camera.main;
        staminaAtual = staminaMax; // Começa com a stamina máxima

        // Encontra o ConversationManager na cena
        conversationManager = ConversationManager.Instance;
    }

    void Update()
    {
        // Se um diálogo está ativo ou o movimento está desabilitado, não permite movimento ou rotação
        if ((conversationManager != null && conversationManager.IsConversationActive) || !canMove)
        {
            ResetAnimations();
            return;
        }

        estaNoChao = character.isGrounded;

        // Consumo de stamina ao correr
        corrida = Input.GetAxis("Run");
        if (corrida > 0 && staminaAtual > 0)
        {
            staminaAtual -= taxaConsumoStamina * Time.deltaTime;
            if (staminaAtual < 0)
            {
                staminaAtual = 0;
            }
        }

        // Recuperação de stamina quando não estiver correndo
        if (corrida == 0 && staminaAtual < staminaMax)
        {
            staminaAtual += taxaRecuperacaoStamina * Time.deltaTime;
            if (staminaAtual > staminaMax)
            {
                staminaAtual = staminaMax;
            }
        }

        // Verifica se o jogador está pressionando as teclas de movimento
        movimentoHorizontal = Input.GetAxis("Horizontal");
        movimentoVertical = Input.GetAxis("Vertical");
        movendo = Mathf.Abs(movimentoHorizontal) > 0 || Mathf.Abs(movimentoVertical) > 0;

        // Define a velocidade atual do personagem com base na stamina e nas teclas de movimento
        velocidadeAtual = movendo ? (corrida > 0 && staminaAtual > 0 ? velocidadeCorrendo : velocidade) : 0f;

        Vector3 moveDirection = new Vector3(movimentoHorizontal, 0, movimentoVertical);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= velocidadeAtual * Time.deltaTime;

        character.Move(moveDirection);

        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * sensibilidade * Time.deltaTime, 0));

        inputs.y += forcaGravidade * Time.deltaTime;
        character.Move(inputs * Time.deltaTime);

        // Lógica de pulo
        pulo = Input.GetAxis("Jump");
        if (pulo > 0 && estaNoChao)
        {
            inputs.y = Mathf.Sqrt(alturaPulo * -2f * forcaGravidade);
            animator.SetBool("Pulando", true);
        }
        else
        {
            animator.SetBool("Pulando", false);
        }

        // Atualizações das animações
        animator.SetBool("Esquerda", movimentoHorizontal < 0);
        animator.SetBool("Direita", movimentoHorizontal > 0);
        animator.SetBool("frente", movimentoVertical > 0);
        animator.SetBool("tras", movimentoVertical < 0);
        animator.SetBool("diagonalE", movimentoHorizontal < 0 && movimentoVertical > 0);
        animator.SetBool("diagonalTE", movimentoHorizontal < 0 && movimentoVertical < 0);
        animator.SetBool("diagonalD", movimentoHorizontal > 0 && movimentoVertical > 0);
        animator.SetBool("diagonalTD", movimentoHorizontal > 0 && movimentoVertical < 0);
        animator.SetBool("correndoFrente", movimentoVertical > 0 && corrida > 0 && staminaAtual > 0);
        animator.SetBool("correndoT", movimentoVertical < 0 && corrida > 0 && staminaAtual > 0);
    }

    public void DisableMovement()
    {
        canMove = false;
        ResetAnimations();
    }

    public void EnableMovement()
    {
        canMove = true;
    }

    private void ResetAnimations()
    {
        animator.SetBool("Esquerda", false);
        animator.SetBool("Direita", false);
        animator.SetBool("frente", false);
        animator.SetBool("tras", false);
        animator.SetBool("diagonalE", false);
        animator.SetBool("diagonalTE", false);
        animator.SetBool("diagonalD", false);
        animator.SetBool("diagonalTD", false);
        animator.SetBool("correndoFrente", false);
        animator.SetBool("correndoT", false);
        animator.SetBool("Pulando", false);
    }
}