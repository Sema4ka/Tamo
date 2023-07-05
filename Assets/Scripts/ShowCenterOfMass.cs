using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ShowCenterOfMass : MonoBehaviour
{
    public Vector3 centerOfmass;
    public bool show;
    private void Update()
    {
        GetComponent<Rigidbody2D>().centerOfMass = centerOfmass;
    }
    private void OnDrawGizmos()
    {
        if (show)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(GetComponent<Rigidbody2D>().worldCenterOfMass, 0.1f);
        }
    }
}
