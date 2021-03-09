using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    /*
    public static void saveData(SaveInfo saveinfo)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save.save";
        FileStream fs = new FileStream(path, FileMode.Create);

        SaveData save = new SaveData(saveinfo);

        formmater.Serialize(fs, save);
        fs.close();
    }

    public static SaveData loadData()
    {
        string path = Application.persistentDataPath + "/save.save";
        if (File.Exists(path))
        {
            BinaryFormatter format = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);
            SaveData saved = format.Deserialize(fs) as SaveData;
            fs.Close();
            return saved;
        }
        else
        {
            Debug.LogError("File missing when loading Data");
            return null;
        }
    }
    */
}
