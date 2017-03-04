using UnityEngine;
using System.Collections.Generic;

public class ScriptableObjectFactory<T> : AssetFactory where T : ScriptableObject
{
    private List<T> m_resourceList = new List<T>();

    public ScriptableObjectFactory(string key) : base(key)
    {
    }

    public override void DestroyAllAsset()
    {
        Debug.Log(string.Format("(ScriptableObjectFactory.DestroyAllResource) {0} 타입의 모든 리소스를 파괴합니다.", typeof(T).ToString()));
        foreach (T resource in m_resourceList)
        {
            Object.Destroy(resource);
        }
        m_resourceList.Clear();
    }

    public T Retrieve(string resourceName, params object[] parameters)
    {
        T resource = m_resourceList.Find(rhs => rhs.name == resourceName);

        if (null == resource)
        {
            resource        = base.LoadInternal<T>(m_nodeName, resourceName);
            resource.name   = resourceName;
            m_resourceList.Add(resource);
        }

        return resource;
    }
}

