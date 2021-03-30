using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void saveData(LevelController saveinfo)
    {
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save.save";
        FileStream fs = new FileStream(path, FileMode.Create);

        Saver save = new Saver(saveinfo);

        bf.Serialize(fs, save);
        fs.Close();
    }

    public static Saver loadData()
    {
        string path = Application.persistentDataPath + "/save.save";
        if (File.Exists(path))
        {
            BinaryFormatter format = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);
            Saver saved = format.Deserialize(fs) as Saver;
            fs.Close();
            return saved;
        }
        else
        {
            Debug.LogError("File missing when loading Data");
            return null;
        }
    }
}
