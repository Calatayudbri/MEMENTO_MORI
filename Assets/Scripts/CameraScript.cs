using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform playerTr_;
    public Transform activeRoom;
    public float dampSpeed = 3;

    public static CameraScript instance;
    [Range(-5, 25)]
    public float minModX, maxModX, minModY, maxModY;

    private void Awake() 
    {
        if(instance == null){
            instance = this;
        }   
    }

  
    void Start()
    {
        
    }

    void Update()
    {
        var minPosY = activeRoom.GetComponent<BoxCollider2D>().bounds.min.y + minModY;
        var maxPosY = activeRoom.GetComponent<BoxCollider2D>().bounds.max.y + maxModY;
        var minPosX = activeRoom.GetComponent<BoxCollider2D>().bounds.min.x + minModX;
        var maxPosX = activeRoom.GetComponent<BoxCollider2D>().bounds.max.x + maxModX;

        Vector3 clampedPos = new Vector3(
            Mathf.Clamp(playerTr_.position.x, minPosX, maxPosX),
            Mathf.Clamp(playerTr_.position.y, minPosY, maxPosY),
            Mathf.Clamp(playerTr_.position.z, -10.0f, -10.0f));

        Vector3 smoothPos = Vector3.Lerp(transform.position, clampedPos, dampSpeed * Time.deltaTime);
        transform.position = smoothPos;

    }
}
