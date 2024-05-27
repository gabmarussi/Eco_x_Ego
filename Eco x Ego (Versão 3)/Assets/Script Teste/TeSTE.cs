using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeSTE : MonoBehaviour
{
    private CharacterController character;
    private Animator animator;
    private Camera mainCamera;
    private Vector3 inputs;
    private float velocidade = 2f;
    private float sensibilidade = 150f;
    private float forcaPulo = 150f; // Ajuste a força do pulo conforme necessário
    private bool estaNoChao; // Flag para verificar se o personagem está no chão

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

        // Rotação da câmera (vertical)
        // float mouseY = -Input.GetAxis("Mouse Y") * sensibilidade * Time.deltaTime;
        // mainCamera.transform.Rotate(new Vector3(mouseY, 0, 0));

        // Verifica se o personagem está se movendo para definir a animação corretamente
        if (inputs != Vector3.zero)
        {
            animator.SetBool("andando", true);
        }
        else
        {
            animator.SetBool("andando", false);
        }

        // Verifica se a barra de espaço foi pressionada e o personagem está no chão
        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao)
        {
            // Aplica uma força vertical para fazer o personagem pular
            inputs.y = forcaPulo;
        }

        // Aplica a gravidade manualmente
        inputs.y += Physics.gravity.y * Time.deltaTime;

        // Move o personagem conforme a gravidade
        character.Move(inputs * Time.deltaTime);
    }

}
    




