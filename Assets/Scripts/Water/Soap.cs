using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Soap : MonoBehaviour
{

    public List<Collider2D> ignoreColliders;
    void Start()
    {
        foreach(Collider2D col in ignoreColliders)
        {
            Physics2D.IgnoreCollision(col, GetComponent<Collider2D>(), true);
        }
        GetComponent<Rigidbody2D>().centerOfMass = new Vector2(0, -1);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(GetComponent<Rigidbody2D>().worldCenterOfMass, 0.1f);
    }
}
