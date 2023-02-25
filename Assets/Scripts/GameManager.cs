using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Camera _myCamera;
    public GameObject pet;
    private static bool isExist = false;
    
    private void Awake()
    {
        if (isExist)
        {
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(this);
        isExist = true;
        _myCamera = Camera.main;

    }
    
    private void Start()
    {
        pet = PetSaverSystem.PetLoad(pet);
        pet = Instantiate(pet);
    }
    
    private void OnApplicationQuit()
    {
        PetSaverSystem.SavePet(pet);
    }
}
