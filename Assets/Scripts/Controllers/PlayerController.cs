using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public float moveForce = 10f;  // Fuerza de movimiento
    public Transform cameraTransform;  // Cámara para orientar el movimiento
    private Rigidbody rb;  // Componente Rigidbody de la esfera

    public GameObject projectilePrefab;  // Prefab del proyectil
    public Transform enemy;  // Referencia al enemigo

    private GameObject activeProjectile;  // Referencia al proyectil activo

    private Animator animatorPlayer;  // Animator del jugador

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearDamping = 5f;  // Ajuste del drag para reducir el deslizamiento
        animatorPlayer = GetComponent<Animator>();
    }

    void update()
    {
        
       
    }

    void FixedUpdate()
    {
        // Movimiento de la esfera con velocidad en lugar de AddForce
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = (forward * moveZ + right * moveX).normalized;
        
        // Aplicar velocidad directamente en el eje X y Z
        rb.linearVelocity = new Vector3(moveDirection.x * moveForce, rb.linearVelocity.y, moveDirection.z * moveForce);


         // Animación de movimiento
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            animatorPlayer.SetBool("walk", true);
        }
        else
        {
            animatorPlayer.SetBool("walk", false);
        }
    }
}