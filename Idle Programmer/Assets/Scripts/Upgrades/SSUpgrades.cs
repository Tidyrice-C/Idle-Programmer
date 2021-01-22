using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class SSUpgrades : MonoBehaviour
{
    public static void SaveAll()
    {
        string path = Application.persistentDataPath + "/upgrades.json";
        FileStream stream = new FileStream(path, FileMode.Create);
        UpgradeData upgradeData = new UpgradeData();

        string data = JsonUtility.ToJson(upgradeData, true);

        using (StreamWriter writer = new StreamWriter(stream))
        {
            writer.Write(data);
        }

        stream.Close();
    }

    public static UpgradeData LoadData()
    {
        string path = Application.persistentDataPath + "/upgrades.json";
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string dataJSON = reader.ReadToEnd();

                UpgradeData data;

                try
                {
                    data = JsonUtility.FromJson<UpgradeData>(dataJSON);
                }
                catch
                {
                    Debug.Log("Error in try block in script SaveSystem Upgrades");
                    return null;
                }
                return data;
            }
        }
        else
        {
            Debug.LogError("Save upgrade file not found in " + path + " generating new file");
            return null;
        }
    }
}
