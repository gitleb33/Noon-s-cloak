using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static void SaveLevel(save_Data level)
    {

        //Binary formatýna çevirecek olan deðiþken
        BinaryFormatter formatter = new BinaryFormatter();

        // Oluþturulacak olan kaydýn Dosya yolu oluþturuluyor.
        string path = Application.persistentDataPath + "/level.saveFile";

        //Oluþturulan dosya yolu içerisine dosya yerleþtiriliyor
        FileStream stream = new FileStream(path, FileMode.Create);

        //Kaydedilecek paramterler 'data' parametresinin içerisine çekiliyor.
        LevelData data = new LevelData(level);

        //Kaydedilecek parametreler oluþturulan dosyanýn içerisine aktarýlýyor.
        formatter.Serialize(stream , data);

        stream.Close();
    }

    public static LevelData LoadLevel()
    {
        string path = Application.persistentDataPath + "/level.saveFile";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            LevelData data = formatter.Deserialize(stream) as LevelData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }
}
