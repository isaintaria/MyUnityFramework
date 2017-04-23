using UnityEngine;
using System.Collections.Generic;

public sealed class TableManager 
{
    public static void Load()
    {
    }

    public static T LoadTable<T>(string tableName)
    {
        TextAsset table = AssetManager.Instance.Table.Retrieve(tableName);
        var ret =   TableSerializer.Derialize<T>(table.bytes);
        return ret;
    }
}