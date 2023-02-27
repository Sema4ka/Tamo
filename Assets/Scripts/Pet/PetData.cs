using UnityEngine;
using UnityEngine.SceneManagement;
[System.Serializable]

public class PetData
{
    public int saturation;
    public int sceneIndex;
    public string petName;
    public string pathToScriptableObj;
    public PetData (Pet pet)
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        saturation = pet.saturation;
        petName = pet.petName;
        pathToScriptableObj = pet.petConsts.name;
    }
}
