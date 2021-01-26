using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

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

    public static void SaveUpgrades()
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

    public static void ResetSave ()
    {
        string path = Application.persistentDataPath + "/upgrades.json";
        FileStream stream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(stream))
        {
            writer.Write("");
        }

        stream.Close();

        path = Application.persistentDataPath + "/data.json";
        stream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(stream))
        {
            writer.Write("");
        }

        stream.Close();

        SceneManager.LoadScene(0);
    }

    public static void ResetUpgrades ()
    {
        string path = Application.persistentDataPath + "/upgrades.json";
        FileStream stream = new FileStream(path, FileMode.Create);

        UpgradeData upgradeData = new UpgradeData();

        using (StreamWriter writer = new StreamWriter(stream))
        {
            writer.Write(upgradeData);
        }

        ONE.profitModifier = 1;
        TWO.profitModifier = 1;
        THREE.profitModifier = 1;
        FOUR.profitModifier = 1;

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

                reader.Close();

                try
                {
                    data = JsonUtility.FromJson<SaveData>(dataJSON);
                }
                catch 
                {
                    Debug.Log("Error when loading saveData");
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
    public static UpgradeData LoadUpgradeData()
    {
        string path = Application.persistentDataPath + "/upgrades.json";
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string dataJSON = reader.ReadToEnd();

                UpgradeData data;

                reader.Close();

                try
                {
                    data = JsonUtility.FromJson<UpgradeData>(dataJSON);
                }
                catch
                {
                    Debug.Log("Error when loading upgradeData");
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
