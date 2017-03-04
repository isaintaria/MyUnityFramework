using UnityEngine;
using System.Collections.Generic;

public class AssetArchive : SingleTon<AssetArchive>
{
    Dictionary<string, AssetBundle> m_assetBundles = new Dictionary<string, AssetBundle>();

    public void Add(string name, AssetBundle bundle)
    {
        m_assetBundles[name] = bundle;
    }
}
