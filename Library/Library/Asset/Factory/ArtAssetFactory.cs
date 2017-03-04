using UnityEngine;
using System.Collections.Generic;

public class ArtAssetFactory<T> : AssetFactory where T : Object
{
    private List<T> m_resourceList = new List<T>();

    public ArtAssetFactory(string key) : base(key)
    {
    }

    public override void DestroyAllAsset()
    {
    }

    public T Retrieve(string resourceName)
    {
        T resource = m_resourceList.Find(rhs => rhs.name == resourceName);

        if (null == resource)
        {
            resource = base.LoadInternal<T>(m_nodeName, resourceName);
            m_resourceList.Add(resource);
        }

        return resource;
    }
}
