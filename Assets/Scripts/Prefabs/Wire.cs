using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Wire : MonoBehaviour
{
    [SerializeField] private GameObject _mainWire;
    [SerializeField, Range(1,100)] private int _amount;

    void Update()
    {
        if (transform.childCount < _amount)
        {
            for (int i = transform.childCount-1; i < _amount; i++)
            {
                GameObject nextWire = Instantiate(transform.GetChild(i).gameObject, transform);
                nextWire.transform.position -= new Vector3(0, transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.y-0.01f, 0);
                nextWire.GetComponent<HingeJoint2D>().connectedBody = transform.GetChild(i).gameObject.GetComponent<Rigidbody2D>();
            }
        }
        else if (transform.childCount > _amount)
        {
            for (int i = transform.childCount - 1; i >= _amount; i--)
            {
                DestroyImmediate(transform.GetChild(i).gameObject);
            }
        }

    }
  
}
