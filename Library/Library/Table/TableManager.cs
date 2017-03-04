using UnityEngine;
using System.Collections.Generic;

public sealed class TableManager 
{
    public static void Load()
    {
        LoadTable<ItemTable>("itemtable");
        LoadTable<LevelTable>("leveltable");
        LoadTable<MonsterTable>("monstertable");
    }

    private static void LoadTable<T>(string tableName)
    {
        TextAsset table = AssetManager.Instance.Table.Retrieve(tableName);
        TableSerializer.Derialize<T>(table.bytes);
    }
}