using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb2D;

    void Start()
    {
        this.rb2D = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        var moveX = Input.GetAxisRaw("Horizontal");
        var moveY = Input.GetAxisRaw("Vertical");
        
        var newVelocity = new Vector2(moveX * speed, moveY * speed);
        this.rb2D.velocity = newVelocity;
    }
}
