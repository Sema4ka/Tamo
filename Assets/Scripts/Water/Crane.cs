using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane : MonoBehaviour
{
    [SerializeField] private GameObject waterShape;
    [SerializeField] static float _maxHeight = -6;
    [SerializeField] static float _minHeight = -13;
    [SerializeField] private bool isActive;
    [SerializeField] private int _index=1;


    private void OnMouseDown()
    {
        isActive = !isActive;
    }

    private void Update()
    {

        if (isActive)
        {
            waterShape.transform.Translate(Vector2.up * 0.01f * _index);
        }

        if (waterShape.transform.position.y > _maxHeight)
        {
            waterShape.transform.position = new Vector2(waterShape.transform.position.x, _maxHeight);
            isActive = !isActive;
        }

        if (waterShape.transform.position.y < _minHeight)
        {
            waterShape.transform.position = new Vector2(waterShape.transform.position.x, _minHeight);
            isActive = !isActive;
        }
    }
}
