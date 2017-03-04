using System.IO;
using System.Xml.Serialization;
using UnityEngine;

// static memeber 만 허용, sealed class
public static class TableSerializer
{
    #region Serialize
    public static void Serialize<T>(string filename, object instance)
    {
        if (null == instance)
        {
            return;
        }

        if (0 == filename.Length)
        {
            return;
        }

        FileStream fileStream = new FileStream(filename, FileMode.Create, FileAccess.Write);
        if (null == fileStream)
        {
            return;
        }

        // 파일스트림을 시리얼라이저에 그냥 넘기면, 현재 윈도우에 설정된 언어팩 기준으로 인코딩을 하는 듯
        StreamWriter streamWriter = new StreamWriter(fileStream);
        XmlSerializer toData = new XmlSerializer(typeof(T));
        toData.Serialize(streamWriter, instance);
        streamWriter.Close();
    }

    public static void Serialize<T>(Stream stream, object instance)
    {
        if (null == instance)
        {
            return;
        }

        StreamWriter streamWriter = new StreamWriter(stream);
        XmlSerializer toData = new XmlSerializer(typeof(T));
        toData.Serialize(streamWriter, instance);
        streamWriter.Close();
    }

    public static void Serialize<T>(StreamWriter streamWriter, object instance)
    {
        if (null == instance)
        {
            return;
        }

        XmlSerializer toData = new XmlSerializer(typeof(T));
        toData.Serialize(streamWriter, instance);
    }
    #endregion

    #region Deserialize
    public static T Derialize<T>(string filename)
    {
        Debug.Log(string.Format("Table Derialize : " + typeof(T), " Filename : ", filename));
        FileStream fileStream = null;
        try
        {
            fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            if (null == fileStream)
            {
                return default(T);
            }

            XmlSerializer toData = new XmlSerializer(typeof(T));
            object instance = toData.Deserialize(fileStream);
            return (T)instance;
        }
        finally
        {
            fileStream.Close();
        }
    }

    public static T Derialize<T>(Stream stream)
    {
        Debug.Log(string.Format("Table Derialize : ", typeof(T)));
        XmlSerializer toData = new XmlSerializer(typeof(T));
        object instance = toData.Deserialize(stream);
        return (T)instance;
    }

    public static T Derialize<T>(StreamReader streamReader)
    {
        Debug.Log(string.Format("Table Derialize : ", typeof(T)));
        XmlSerializer toData = new XmlSerializer(typeof(T));
        object instance = toData.Deserialize(streamReader);
        streamReader.Close();
        return (T)instance;
    }

    public static T Derialize<T>(byte[] stream)
    {
        MemoryStream memoryStream = new MemoryStream(stream);
        return Derialize<T>(memoryStream);
    }
    #endregion
}
