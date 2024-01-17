using UnityEngine;

public class DrawGizmo : MonoBehaviour
{
    public Transform target;

    private void OnDrawGizmos()
    {     
        Vector3 direction = target.position - transform.position;
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, direction.normalized * 4f);
    }

}
