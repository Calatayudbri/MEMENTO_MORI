using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject fireballPrefab;  
    public float fireballSpeed = 8f;  
    public float attackInterval = 2f; 
    float destroyBullet = 2.0f;
    float currentTime = 0.0f;
    float shootTime = 5.0f;
    public float speedShoot = 50.0f;
    public Transform initShootPoint;
    public PlayerManager player_manager;
    Vector2 bullet_dir;

  
    void Update()
    {
        bullet_dir = new Vector2(player_manager.transform.position.x - transform.position.x, transform.position.y);

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
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        rb.velocity = bullet_dir * speedShoot;
        
        Destroy(fireball, destroyBullet);
    }
}

