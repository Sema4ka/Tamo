using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class PetSaverSystem
{
    static string path = Application.persistentDataPath + "/pet.bin";

    public static void SavePet(Pet pet)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        PetData data= new PetData(pet);
        
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static Pet PetLoad()
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PetData data = formatter.Deserialize(stream) as PetData;
            stream.Close();
            Pet pet = new Pet();
            pet.saturation = data.saturation;
            //SceneManager.LoadScene(data.sceneIndex);
            return pet;
        }
        else
        {
            Debug.LogError("No saved File:" + path);
            return null;
        }
    }
}
