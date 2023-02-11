using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Entity : MonoBehaviour
{
    private bool _isSelected = false;
    [SerializeField]
    protected int force = 50;
    [HideInInspector]public Rigidbody2D myRigitbody;
    [HideInInspector]public Transform myTransform;
    
     protected virtual void Start() {
        myRigitbody =  GetComponent<Rigidbody2D>();
        myTransform = GetComponent<Transform>();
     }
    private void OnMouseDown()
    {
        if (Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)) == GetComponent<Collider2D>())
            _isSelected = true;
    }

    private void OnMouseUp()
    {
        _isSelected = false;
    }
    
    private void OnMouseDrag()
    {
        if(_isSelected)
        {
            Vector2 v2 = new Vector2(
                Input.GetAxis("Mouse X"),
                Input.GetAxis("Mouse Y"));
            myRigitbody.AddForce(v2 * force);
        }
    }
}
