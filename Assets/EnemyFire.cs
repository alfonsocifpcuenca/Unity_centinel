using System.Collections;
using System.Linq;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public GameObject ball;
    public GameObject player;

    private Coroutine fireCoroutine;

    void Start()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();    
    }

    IEnumerator Fire()
    {
        do
        {
            var ball = Instantiate(this.ball, this.transform.position, this.transform.rotation);
            
            var rbBall = ball.GetComponent<Rigidbody2D>();

            Vector3 direction = player.transform.position - this.transform.position;
            direction.Normalize();

            rbBall.AddForce(direction * 10, ForceMode2D.Impulse);
            Destroy(ball, 3f);
            yield return new WaitForSeconds(1);

        } while (true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.spriteRenderer.color = Color.red;
            this.fireCoroutine = StartCoroutine(Fire());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.spriteRenderer.color = Color.white;
            StopCoroutine(this.fireCoroutine);            

            var balls = GameObject.FindGameObjectsWithTag("Ball");
            foreach (var ball in balls)
                Destroy(ball);            
        }
    }
}
