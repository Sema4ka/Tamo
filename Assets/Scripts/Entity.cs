using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private bool _isSelected = false;
    [SerializeField]
    protected int force = 50;
    protected Rigidbody2D MyRigitbody;
    protected Transform MyTransform;
    
     protected virtual void Start() {
        MyRigitbody =  GetComponent<Rigidbody2D>();
        MyTransform = GetComponent<Transform>();
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
            MyRigitbody.AddForce(v2 * force);
        }
    }
}
