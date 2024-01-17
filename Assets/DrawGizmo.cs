using UnityEngine;

public class DrawGizmo : MonoBehaviour
{
    /*
     * Atributo para establecer el objetivo del rayo
     * */
    [SerializeField]
    private Transform target;

    /*
     * Atributo para establecer la longitud del rayo
     * */
    [SerializeField]
    private float rayLength;

    private void OnDrawGizmos()
    {     
        /*
         * Obtenemos la dirección entre el objeto y el objetivo
         * */
        Vector3 direction = target.position - transform.position;

        /*
         * Establecemos el color del gizmo a pintar
         * */
        Gizmos.color = Color.red;

        /*
         * Dibujamos un rayo dirección el objetivo con una longitud de rayLength
         * */
        Gizmos.DrawRay(transform.position, direction.normalized * this.rayLength);
    }

}
