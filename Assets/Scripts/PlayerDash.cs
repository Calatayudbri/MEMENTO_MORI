using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{

    private float dashDistance = 1.5f;
    public float dashDuration = 0.5f;
    private bool isDashing = false;
    private float startTime;
    Vector2 dashDirection = new Vector3();
    public PlayerManager player_;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isDashing)
        {
            player_.anim_.SetBool("dash", true);
            StartDash();
        }
        if (isDashing)
        {
            PerformDash();
        }
        
    }

    void StartDash()
    {
        isDashing = true;
        startTime = Time.time;

        // Desactiva la capacidad de recibir daño durante el dash
        // (puedes tener tu propia lógica aquí, dependiendo de cómo gestionas el daño)
    }

    void PerformDash()
    {
       
        float dashSpeed = dashDistance / dashDuration;
       
        // Obtén la dirección hacia la que mira el jugador
        if (player_.rb.velocity.x > 0)
        {
            dashDirection = new Vector2(1, 0); ;
            }

        if (player_.rb.velocity.x < 0)
        {
            dashDirection = new Vector2(-0.5f,0);
            }

        if (player_.rb.velocity.x == 0)
        {
            player_.anim_.SetBool("dash", false);
            dashDirection = new Vector2(0, 0);
        }
        // Mueve al jugador en la dirección del dash
        transform.Translate(dashDirection * dashSpeed * Time.deltaTime, Space.World);

        if (Time.time >= startTime + dashDuration)
        {
            // Reactiva la capacidad de recibir daño después del dash
            // (puedes tener tu propia lógica aquí)

            isDashing = false;
            player_.anim_.SetBool("dash", false);
        }
    }
}
