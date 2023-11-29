using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
  public Enemy1Behaviour enemy;

  public bool isDamage;
  SpriteRenderer sp;
  EnemyBlink blink;
  Rigidbody2D rb;
  private void Start()
  {
    sp = GetComponent<SpriteRenderer>();
    rb = GetComponent<Rigidbody2D>();
    blink = GetComponent<EnemyBlink>();
    enemy = GetComponent<Enemy1Behaviour>();
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.CompareTag("Player_weapon") )
    {
      enemy.healthPoints -= 1;
      if(collision.transform.position.x < transform.position.x)
      {
        rb.AddForce(new Vector2 (enemy.knockBackForceX, enemy.knockBackForceY), ForceMode2D.Force);
      }else{
        rb.AddForce(new Vector2 (-enemy.knockBackForceX, enemy.knockBackForceY), ForceMode2D.Force);

      }
      StartCoroutine(Damager());
    }
    if(enemy.healthPoints <= 0)
    {
      Destroy(gameObject);
    }
  }

  IEnumerator Damager()
  {
    isDamage = true;
    sp.material = blink.blink;

    yield return new WaitForSeconds(0.5f);
    isDamage = false;

    sp.material = blink.original;



  }
}
