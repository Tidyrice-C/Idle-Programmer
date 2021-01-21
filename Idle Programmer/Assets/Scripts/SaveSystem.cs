using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    public static void SaveAll ()
    {
        string path = Application.persistentDataPath + "/data.json";
        FileStream stream = new FileStream(path, FileMode.Create);
        SaveData saveData = new SaveData();

        string data = JsonUtility.ToJson(saveData, true);

        using (StreamWriter writer = new StreamWriter(stream))
        {
            writer.Write(data);
        }

        stream.Close();
    }

    public static SaveData LoadData()
    {
        string path = Application.persistentDataPath + "/data.json";
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string dataJSON = reader.ReadToEnd();

                SaveData data;

                try
                {
                    data = JsonUtility.FromJson<SaveData>(dataJSON);
                }
                catch 
                {
                    Debug.Log("Error in try block in script SaveSystem");
                    return null;
                }
                return data;
            }
        }
        else
        {
            Debug.LogError("Save file not found in " + path + " generating new file");
            return null;
        }
    }
}
