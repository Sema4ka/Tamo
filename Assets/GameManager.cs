using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private string _currentState = "";
    public GameObject toy;
    private Camera _myCamera;
    public void SetState(string state)
    {
        if (_currentState == state)
        {
            _currentState = "";
            return;
        }
        _currentState = state;
    }

    void Start()
    {
        _myCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_currentState == "Ball")
            {
                Vector3 pos = _myCamera.ScreenToWorldPoint(Input.mousePosition);
                pos.z = 0;
                Instantiate(toy, pos, Quaternion.identity);
            }
        }
    }
}
