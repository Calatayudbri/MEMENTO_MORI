using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Behaviour : MonoBehaviour
{
  public int healthPoints;
  public float speed;
  public float knockBackForceX;
  public float knockBackForceY;
  public float leftBound = -5f; 
  public float rightBound = 5f;

    void Start()
    {
        
    }
    void Update()
    {

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (transform.position.x >= rightBound)
        {
            transform.position = new Vector2(rightBound, transform.position.y);
            speed = -speed;
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
        if (transform.position.x <= leftBound)
        {
            transform.position = new Vector2(leftBound, transform.position.y);
            speed = -speed;
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);

        }
        
    }
}
