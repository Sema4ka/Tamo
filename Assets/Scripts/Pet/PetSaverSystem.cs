using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
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
        if (File.Exists(path) && File.ReadAllLines(path).Length!=0)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PetData data = formatter.Deserialize(stream) as PetData;
            stream.Close();
            Pet petComp = pet.GetComponent<Pet>();
            petComp.GetValues(data);
        }
        else
        {
            Debug.LogError("No saved File:" + path);
        }
        return pet;

    }
}
