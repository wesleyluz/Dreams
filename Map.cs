using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public Transform playerpos;
    public Transform offscreenPos;
    public float speed;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.M))
        {
            transform.position = Vector2.MoveTowards(transform.position,playerpos.position,speed*Time.deltaTime);
        }else
        {
            transform.position =  Vector2.MoveTowards(transform.position,offscreenPos.position,speed*Time.deltaTime);
        }
    }
}
