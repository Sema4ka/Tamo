using System;
using UnityEngine;


public class Pet : Entity
{
    [SerializeField]
    protected int jumpForce = 10;
    public void Catch(Transform target)
    {
        MyRigitbody.AddForce((transform.position - target.position)*-jumpForce, ForceMode2D.Impulse);
    }
}
