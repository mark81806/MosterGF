using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;
public class SaveLoadData
{
    public const string SAVE_NAME = "PlayerSave";
    public static PlayerSaveData LoadData() 
    {
        PlayerSaveData result = new PlayerSaveData();
        if (PlayerPrefs.HasKey(SAVE_NAME)) 
        {
            string saveString = PlayerPrefs.GetString(SAVE_NAME);

            try
            {
                saveString = System.Text.Encoding.Unicode.GetString(System.Convert.FromBase64String(saveString));
                XmlSerializer ser = new XmlSerializer(typeof(PlayerSaveData));
                StringReader sr = new StringReader(saveString);
                result = ser.Deserialize(sr) as PlayerSaveData;
            }
            catch (System.Exception e) 
            {
                Debug.LogError(e.Message);
                return new PlayerSaveData();
            }
        }
        return result;
    }
    public static void SaveData(PlayerSaveData saveData) 
    {
        XmlSerializer ser = new XmlSerializer(typeof(PlayerSaveData));
        StringWriter sw = new StringWriter();
        ser.Serialize(sw, saveData);
        string saveString = sw.ToString();
        try
        {
            saveString = System.Convert.ToBase64String(System.Text.Encoding.Unicode.GetBytes(saveString));
        }
        catch (System.Exception e) 
        {
            Debug.LogError(e.Message);
        }
        try
        {
            PlayerPrefs.SetString(SAVE_NAME, saveString);
        }
        catch (PlayerPrefsException err) 
        {
            Debug.Log("Got:" + err);
        }
        PlayerPrefs.Save();

    }
}
/*讀檔:
PlayerSaveData saveData = new PlayerSaveData();
saveData = SaveLoadData.LoadData();

存檔
SaveLoadData.SaveData(saveData   );*/