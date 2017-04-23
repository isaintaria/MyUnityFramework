using UnityEngine;
using System.Xml.Serialization;
using System.IO;

public class LocalData
{
    private const string SaveFileName = "LocalSaveData.xml";

    #region LocalData
    [XmlElement("UserData")]
    public UserData m_userData = new UserData();
    #endregion
    private static LocalData s_intance = null;
    public static LocalData Instance
    {
        get { return s_intance; }
    }

   
    public static void Load()
    {
        string savePath = Util.GetDataPath(LocalData.SaveFileName);
        StreamReader sr = null;

        try
        {
            if (false == System.IO.File.Exists(savePath))
            {
                Save();
            }

            sr = new StreamReader(savePath);

            s_intance = (LocalData)TableSerializer.Derialize<LocalData>(sr);
            sr.Close();
            sr = null;
        }
        catch (System.Exception e)
        {
            if (null != sr)
            {
                sr.Close();
            }

            System.IO.File.Delete(savePath);
            Debug.Log("LocalSaveData Load Exception : " + e.Message);
            s_intance = new LocalData();
        }
    }

    public static void Save()
    {
        if (null == s_intance)
        {
            s_intance = new LocalData();
        }

        string savePath = Util.GetDataPath(LocalData.SaveFileName);
        Debug.Log(savePath);
        System.IO.StreamWriter sw = null;
        sw = new StreamWriter(savePath);

        TableSerializer.Serialize<LocalData>(sw, s_intance);
        sw.Close();
    }
}