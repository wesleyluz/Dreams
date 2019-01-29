using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class icon : MonoBehaviour
{
    private Vector2 moveVelocity;
    public float speed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        iconMove();
        
    }
    void iconMove()
    {
        Vector2 MoveInput = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        moveVelocity = MoveInput.normalized * speed;
    }
    void FixedUpdate(){
        rb.MovePosition(rb.position + moveVelocity*Time.fixedDeltaTime);
    }

}
