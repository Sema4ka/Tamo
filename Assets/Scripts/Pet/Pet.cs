using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class Pet : Entity
{
    [SerializeField] public int jumpForce = 10;
    
    [SerializeField] public int saturation;
    [SerializeField] readonly int _maxSaturation = 100;
    [SerializeField] private float hungerTime = 300;

    [HideInInspector]public List<Toy> toys;
    public Toy activeToy;
    private float _actTime;
    private float _minDistance=100f;

    private Pet instance;

    protected virtual void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    protected override void Start()
    {
        base.Start();
        StartCoroutine(GetHungryCorutine());
        StartCoroutine(ToyAwake());
        DontDestroyOnLoad(this);
    }

    public void Update()
    {
        ChechToys();
    }

    protected void ChechToys()
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
        if(saturation + 5 <= _maxSaturation)
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

    protected void SetActive(Toy toy)
    {
        activeToy = toy;
        _actTime = toy.actInSeconds;
    }

    public bool isFull()
    {
        return saturation == _maxSaturation;
    }
    

}
