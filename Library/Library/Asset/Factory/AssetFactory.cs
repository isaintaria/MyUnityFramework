using UnityEngine;

public abstract class AssetFactory
{
    protected string m_nodeName = string.Empty;

    public abstract void DestroyAllAsset();

    public AssetFactory(string nodeName)
    {
        m_nodeName = nodeName;
    }

    protected T LoadInternal<T>(string nodeName, string assetName) where T : Object
    {
        T resource = Resources.Load<T>(string.Format("{0}/{1}", nodeName, assetName));
        if (null == resource)
        {
            Debug.Log(string.Format("{0}에 Resource : {1}이 존재하지 않습니다.", nodeName, assetName));
        }
        return resource;
    }
}