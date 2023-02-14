using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Toy : Entity
{
    public float actInSeconds;

    private Pet _pet;

    protected override void Start()
    {
        base.Start();
        _pet = FindObjectOfType<Pet>();
        _pet.toys.Add(this);
    }
    

    public virtual void m_Action()
    {
        _pet.myRigitbody.AddForce((_pet.myTransform.position - myTransform.position)*-_pet.jumpForce, ForceMode2D.Impulse);
    }

    private void OnDestroy()
    {
        _pet.toys.Remove(this);
    }
}
