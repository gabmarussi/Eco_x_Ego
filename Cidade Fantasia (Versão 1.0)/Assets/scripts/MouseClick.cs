using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed = 5f; // Velocidade de rota��o
    private bool isRotating; // Flag para indicar se estamos girando a c�mera
    private Vector3 lastMousePosition; // �ltima posi��o do mouse

    void Update()
    {
        // Verifica se o bot�o do mouse foi pressionado
        if (Input.GetMouseButtonDown(0))
        {
            isRotating = true;
            lastMousePosition = Input.mousePosition;
        }
        // Verifica se o bot�o do mouse foi solto
        else if (Input.GetMouseButtonUp(0))
        {
            isRotating = false;
        }

        // Se estamos girando a c�mera
        if (isRotating)
        {
            // Calcula a diferen�a entre a posi��o atual do mouse e a �ltima posi��o do mouse
            Vector3 deltaMouse = Input.mousePosition - lastMousePosition;

            // Calcula a rota��o da c�mera com base no movimento do mouse
            float rotationY = deltaMouse.x * rotationSpeed * Time.deltaTime;

            // Rotaciona a c�mera ao redor do eixo vertical (eixo Y)
            transform.Rotate(Vector3.up, rotationY);

            // Atualiza a �ltima posi��o do mouse
            lastMousePosition = Input.mousePosition;
        }
    }
}