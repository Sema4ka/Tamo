using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
    public bool isFull { get { return saturation == _maxSaturation; } }


    protected override void Start()
    {
        base.Start();
        StartCoroutine(GetHungryCorutine());
        StartCoroutine(ToyAwake());
        DontDestroyOnLoad(this);
    }

    protected void Update()
    {
        CatchToy();
    }


    
    #region ToyLogic
    
    protected void CatchToy()
    {
        foreach (var toy in toys)
        {
            if (Vector2.Distance(transform.position, toy.myTransform.position) < _minDistance && toy != activeToy)
            {
                SetActiveToy(toy);
            }
            _minDistance = Vector2.Distance(transform.position, activeToy.myTransform.position);
        }
    }

    
    protected void SetActiveToy(Toy toy)
    {
        activeToy = toy;
        _actTime = toy.actInSeconds;
    }
    
    
    protected IEnumerator ToyAwake()
    {
        while (true)
        {
            yield return new WaitForSeconds(_actTime);
            activeToy?.m_Action();
        }
    }
    #endregion

    #region HungerLogic

    public void Eat()
    {
        if(saturation + 5 <= _maxSaturation)
        {
            saturation += 5;
            transform.localScale += new Vector3(0.05f, 0.05f, 0);
        }        
    }
    
    protected void GetHungry()
    {
        if(saturation - 5 >= 0)
        {
            saturation -= 5;
            transform.localScale -= new Vector3(0.05f, 0.05f, 0);
        }        
    }

    protected IEnumerator GetHungryCorutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(hungerTime);
            GetHungry();
        }
    }

    #endregion

}
