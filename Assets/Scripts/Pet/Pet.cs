using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class Pet : Entity
{
    [SerializeField] public int jumpForce = 10;
    
    [SerializeField] private int saturation;
    [SerializeField] private int maxSaturation = 100;
    [SerializeField] private float hungerTime = 300;

    [HideInInspector]public List<Toy> toys;
    public Toy activeToy;
    
    private float _actTime;
    private float _minDistance=100f;


    protected override void Start()
    {
        base.Start();
        StartCoroutine(GetHungryCorutine());
        StartCoroutine(ToyAwake());
    }

    public void Update()
    {
            foreach (var toy in toys)
            {
                if (Vector2.Distance(transform.position, toy.myTransform.position) < _minDistance && toy != activeToy)
                {
                    SetActive(toy);
                }
                _minDistance = Vector2.Distance(transform.position, activeToy.myTransform.position);
            }
    }

    public void Eat()
    {
        if(saturation + 5 <= maxSaturation)
        {
            saturation += 5;
            transform.localScale += new Vector3(0.05f, 0.05f, 0);
        }        
    }
    
    private void GetHungry()
    {
        if(saturation - 5 >= 0)
        {
            saturation -= 5;
            transform.localScale -= new Vector3(0.05f, 0.05f, 0);
        }        
    }

    IEnumerator GetHungryCorutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(hungerTime);
            GetHungry();
        }
    }

    IEnumerator ToyAwake()
    {
        while (true)
        {
            yield return new WaitForSeconds(_actTime);
            activeToy?.m_Action();
        }
    }

    private void SetActive(Toy toy)
    {
        activeToy = toy;
        _actTime = toy.actInSeconds;
        print(_actTime);
    }


}
