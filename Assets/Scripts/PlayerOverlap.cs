using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOverlap : MonoBehaviour
{
    public class OverlapCapsuleExample : MonoBehaviour
    {
        public LayerMask Ground = LayerMask.GetMask("Ground");
        public float capsuleRadius = 10.0f;
        public float capsuleHeight = 7.0f;

        public PlayerManager player_;
        void Update()
        {
            // Supongamos que quieres realizar la detección en el eje X.
            Vector2 capsuleCenter = new Vector2(player_.transform.position.x, player_.transform.position.y);

            // Realizar la detección de cápsula
            Collider2D overlap = Physics2D.OverlapCapsule(capsuleCenter, new Vector2(capsuleRadius, capsuleHeight), CapsuleDirection2D.Horizontal, 0f, Ground);

            // Verificar si hubo una colisión
            if (overlap != null)
            {
           
            }else
            {
            
            }
        }
    }
}