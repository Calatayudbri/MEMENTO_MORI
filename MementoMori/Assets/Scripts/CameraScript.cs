using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    /* public Transform tr_player;
    public Transform activeRoom;

    public static CameraScript instance;
    
    [Range(-5,5)]
    public float minModX, maxModX, minModY, maxModY; */
    /* private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    } */
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* var minPosY = activeRoom.GetComponent<BoxCollider2D>().bounds.min.y + minModY;
        var maxPosY = activeRoom.GetComponent<BoxCollider2D>().bounds.max.y + maxModY;
        var minPosX = activeRoom.GetComponent<BoxCollider2D>().bounds.min.x + minModX;
        var maxPosX = activeRoom.GetComponent<BoxCollider2D>().bounds.max.x + maxModX; */

        /* Vector3 clampedPos = new Vector3(
            Mathf.Clamp(tr_player.position.x, minPosX, maxPosX),
            Mathf.Clamp(tr_player.position.y, minPosY, maxPosY),
            tr_player.position.z);

        transform.position = new Vector3(clampedPos.x, clampedPos.y, clampedPos.z); */
    }
}
