using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class PetSaverSystem
{
    static string path = Application.persistentDataPath + "/pet.bin";

    public static void SavePet(GameObject pet)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        Pet petComp = pet.GetComponent<Pet>();
        PetData data= new PetData(petComp);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameObject PetLoad(GameObject pet)
    {
        PetData data = new PetData();
        if (File.Exists(path) && File.ReadAllLines(path).Length!=0)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            data = formatter.Deserialize(stream) as PetData;
            stream.Close();
            pet.GetComponent<Pet>().SetValues(data);
        }
        else
        {
            Debug.LogError("No saved File:" + path);
            data.sceneIndex = 1;
        }
        if (SceneManager.GetActiveScene().buildIndex != data.sceneIndex)
            SceneManager.LoadScene(data.sceneIndex);
        return pet;

    }
}
