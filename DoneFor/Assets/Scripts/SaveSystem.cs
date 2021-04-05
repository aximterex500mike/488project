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
    public static string[] loadHighscores()
    {
        string path = Application.persistentDataPath + "/savescore.save";
        if (File.Exists(path))
        {
            BinaryFormatter format = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);
            ScoreSaver saved = format.Deserialize(fs) as ScoreSaver;
            fs.Close();
            return saved.scores;
        }
        else
        {
            string[] defaultScores = {"- 0", "- 0", "- 0", "- 0", "- 0", "- 0", "- 0", "- 0", "- 0", "- 0"};
            return defaultScores;
        }
    }

    public static void saveHighscores(string[] newscores)
    {
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "/savescore.save";
        FileStream fs = new FileStream(path, FileMode.Create);

        ScoreSaver save = new ScoreSaver(newscores);

        bf.Serialize(fs, save);
        fs.Close();
    }
}
