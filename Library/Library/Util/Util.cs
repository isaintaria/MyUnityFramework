using UnityEngine;

public sealed class Util
{
    public static string GetDataPath(string filename)
    {
        string dataPath = "";

        switch (Application.platform)
        {
            case RuntimePlatform.Android:
                dataPath = Application.persistentDataPath + "/";
                break;
            case RuntimePlatform.IPhonePlayer:
                dataPath = Application.temporaryCachePath + "/";
                break;
            default:
                dataPath = Application.dataPath + "/";
                dataPath = dataPath.Substring(0, dataPath.LastIndexOf("/")) + "/Documents/";
                break;
        }

        if (0 != dataPath.Length && false == System.IO.Directory.Exists(dataPath))
        {
            System.IO.Directory.CreateDirectory(dataPath);
        }

        return dataPath + filename;
    }
}
