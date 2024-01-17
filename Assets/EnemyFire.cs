
using System.Collections;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    [SerializeField]
    private GameObject ball;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float ballForce = 4f;

    private SpriteRenderer spriteRenderer;
    private CircleCollider2D circleCollider2D;
    private Coroutine fireCoroutine;

    void Start()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();    
        this.circleCollider2D = this.GetComponent<CircleCollider2D>();
    }

    IEnumerator Fire()
    {
        do
        {
            /*
             * Desactivamos esta funcionalidad para evitar que el rayo choque contra el propio objeto
             * */
            Physics2D.queriesStartInColliders = false;

            /*
             * Obtenemos la dirección desde el centinela al player
             * */
            var directionRayCast = player.transform.position - gameObject.transform.position;

            /*
             * Activamos la funcionalidad nuevamente (Esto no tiene porqué ser necesario)
             * */
            Physics2D.queriesStartInColliders = true;

            /*
             * Lanzamos un rayo con la misma longitud que el collider
             * */
            RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, directionRayCast.normalized, circleCollider2D.radius);
            if (hit.collider != null && hit.collider.gameObject.CompareTag("Player"))
            {
                /* 
                 * Si el rayo choca contra el player significa que tiene visión directa y lanzamos
                 * la bola
                 * */
                var ball = Instantiate(this.ball, this.transform.position, this.transform.rotation);
                var rbBall = ball.GetComponent<Rigidbody2D>();

                /*
                 * Aplicamos una fuerza a la bola en dirección al Player
                 * */
                rbBall.AddForce(directionRayCast.normalized * this.ballForce, ForceMode2D.Impulse);

                /*
                 * Destruiremos la bola en 3 segundos
                 * */
                Destroy(ball, 3f);
            }            
            yield return new WaitForSeconds(1);

        } while (true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            /*
             * Al detectar la presencia cambiamos el color del centinela
             * */
            this.spriteRenderer.color = Color.red;

            /*
             * Lanzamos la corrutina para disparar al player
             * */
            this.fireCoroutine = StartCoroutine(Fire());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            /*
             * Si el player sale del alcance del centinela, volvemos al color por defecto
             * */
            this.spriteRenderer.color = Color.white;

            /*
             * Si está a corrutina lanzada, la paramos para que deje de disparar bolas
             * */
            if (this.fireCoroutine != null)
                StopCoroutine(this.fireCoroutine);                       
        }
    }
}
