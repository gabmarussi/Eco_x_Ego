using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed = 5f; // Velocidade de rotação
    private bool isRotating; // Flag para indicar se estamos girando a câmera
    private Vector3 lastMousePosition; // Última posição do mouse

    void Update()
    {
        // Verifica se o botão do mouse foi pressionado
        if (Input.GetMouseButtonDown(0))
        {
            isRotating = true;
            lastMousePosition = Input.mousePosition;
        }
        // Verifica se o botão do mouse foi solto
        else if (Input.GetMouseButtonUp(0))
        {
            isRotating = false;
        }

        // Se estamos girando a câmera
        if (isRotating)
        {
            // Calcula a diferença entre a posição atual do mouse e a última posição do mouse
            Vector3 deltaMouse = Input.mousePosition - lastMousePosition;

            // Calcula a rotação da câmera com base no movimento do mouse
            float rotationY = deltaMouse.x * rotationSpeed * Time.deltaTime;

            // Rotaciona a câmera ao redor do eixo vertical (eixo Y)
            transform.Rotate(Vector3.up, rotationY);

            // Atualiza a última posição do mouse
            lastMousePosition = Input.mousePosition;
        }
    }
}