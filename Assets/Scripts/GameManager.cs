using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
    }

    //private void Start()
    //{
    //    pet = PetSaverSystem.PetLoad(pet);
    //    pet = Instantiate(pet);
    //}

    private void OnApplicationQuit()
    {
        PetSaverSystem.SavePet(pet);
    }
}
