using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{

    private Rigidbody2D rb_;
    private PlayerManager player_;

    private float dash_duration_ = 0.5f;
    private float dash_force_ = 10.0f;
    private float dash_cd_ = 1.0f;

    private bool is_dashing = false;
    private bool can_dash = true;
    // Start is called before the first frame update
    void Start()
    {
        rb_ = GetComponent<Rigidbody2D>();
        player_ = GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
