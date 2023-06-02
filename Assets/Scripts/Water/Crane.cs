using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane : MonoBehaviour
{
    [SerializeField] private GameObject waterShape;
    [SerializeField] private float _maxHeight;
    [SerializeField] private bool isActive;

    private void Start()
    {
        _maxHeight = transform.position.y - waterShape.transform.localScale.y;
    }
    private void OnMouseDown()
    {
        isActive = !isActive;
    }

    private void Update()
    {
        if (isActive && waterShape.transform.position.y <= _maxHeight)
        {
            waterShape.transform.Translate(Vector2.up*0.01f);
        }
    }
}
