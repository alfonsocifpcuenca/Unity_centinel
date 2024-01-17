using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMove : MonoBehaviour
{
    public float speed = 5;

    private Rigidbody2D rb2D;



    void Start()
    {
        this.rb2D = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        var moveX = Input.GetAxisRaw("Horizontal");
        var moveY = Input.GetAxisRaw("Vertical");
        
        var newVelocity = new Vector2(moveX * speed, moveY * speed);
        this.rb2D.velocity = newVelocity;
    }
}
