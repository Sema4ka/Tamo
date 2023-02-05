using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Toy : Entity
{
    private Pet _pet;
    protected override void Start()
    {   
        base.Start();
        _pet = FindObjectOfType<Pet>();
        StartCoroutine(CallPet());
    }
    IEnumerator CallPet()
    {
        while(true)
        {
            yield return new WaitForSeconds(2f);
            _pet.Catch(MyTransform);
        }
    }
}
