using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject toy;
    
    private string _currentState = "";
    private Camera _myCamera;
    public Pet pet;

    private GameManager instance;
    public void SetState(string state)
    {
        if (_currentState == state)
        {
            _currentState = "";
            return;
        }
        _currentState = state;
    }

    private void Awake()
    {
        Pet pet1 = PetSaverSystem.PetLoad();
        Instantiate(pet);
    }

    private void Start()
    {
        _myCamera = Camera.main;
        Pet pet1 = PetSaverSystem.PetLoad();
        Instantiate(pet);
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

    private void OnApplicationQuit()
    {
        PetSaverSystem.SavePet(pet);
    }
}
