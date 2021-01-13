using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{


    public static void SaveAll (Money money, ONE one)
    {
        string path = Application.persistentDataPath + "/data.json";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData saveData = new SaveData(money, one);

        string data = JsonUtility.ToJson(saveData);
        File.WriteAllText(path, data);

        Debug.Log(data);
        stream.Close();
    }

    public static SaveData LoadData()
    {
        string path = Application.persistentDataPath + "/data.json";
        if (File.Exists(path))
        {
            FileStream stream = new FileStream(path, FileMode.Open);

            string dataJSON = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(dataJSON);
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path + " generating new file");
            return null;
        }
    }
}
