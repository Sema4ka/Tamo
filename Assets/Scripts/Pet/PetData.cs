using UnityEngine;
using UnityEngine.SceneManagement;
[System.Serializable]

public class PetData
{
    public int saturation;
    public int sceneIndex;
    public PetData (Pet pet)
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        saturation = pet.saturation;
    }
}
