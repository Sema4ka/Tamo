using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyManager : MonoBehaviour
{
    [HideInInspector] public List<Toy> toys;

    protected float _minDistance = 100f;
    public Toy activeToy;
    protected float _actTime;


    private void Start()
    {
        StartCoroutine(ToyAwake());
    }
    private void Update()
    {
        foreach (var toy in toys)
        {
            if (Vector2.Distance(transform.position, toy.myTransform.position) < _minDistance && toy != activeToy)
            {
                SetActiveToy(toy);
                _minDistance = Vector2.Distance(transform.position, activeToy.myTransform.position);
            }
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
}
