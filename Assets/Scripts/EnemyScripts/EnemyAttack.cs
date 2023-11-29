using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject fireballPrefab;  // Prefab de la bola de fuego
    public float fireballSpeed = 8f;   // Velocidad de la bola de fuego
    public float attackInterval = 2f;  // Intervalo entre ataques en segundos
    float destroyBullet = 2.0f;
    float currentTime = 0.0f;
    float shootTime = 5.0f;
    public float speedShoot = 50.0f;
    public Transform initShootPoint;

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= shootTime)
        {
            Attack();
            currentTime = 0.0f;
        }

    }

    void Attack()
    {
        GameObject fireball = Instantiate(fireballPrefab, initShootPoint.position, Quaternion.Euler(0, 0, 0));
        Rigidbody rb = fireball.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speedShoot;
        Destroy(fireball, destroyBullet);
    }
}

