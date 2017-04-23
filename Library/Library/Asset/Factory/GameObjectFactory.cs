using UnityEngine;
using System.Collections.Generic;

public class GameObjectFactory<T> : AssetFactory where T : CachedAsset
{
    private Dictionary<string, List<T>> m_createdObjects    = new Dictionary<string, List<T>>();
    private GameObject                  m_resourceNode      = null;

    public GameObjectFactory(string key) : base(key)
    {
        InitNode();
    }

    public override void DestroyAllAsset()
    {
        foreach (KeyValuePair<string, List<T>> p in m_createdObjects)
        {
            p.Value.ForEach(rhs => Object.Destroy(rhs.gameObject));
            p.Value.Clear();
        }
        m_createdObjects.Clear();
    }

    public void InitNode()
    {
        if ("ui" == m_nodeName) // 통상적으로 UI는 게임마다 방식이달라 node 정의를 따로 해준다
        {
            Debug.Log("UI이므로 노드 따로생성");
            return;
        }

        m_resourceNode = GameObject.Find(m_nodeName);

        if (null == m_resourceNode)
        {
            m_resourceNode = new GameObject(m_nodeName);
            m_resourceNode.transform.position = Vector3.zero;
            m_resourceNode.transform.rotation = Quaternion.identity;
           Object.DontDestroyOnLoad(m_resourceNode);
        }
    }

    public T Retrieve(string resourceName, params object[] parameters)
    {
        bool isContainsResource = m_createdObjects.ContainsKey(resourceName);
        
        if (true == isContainsResource)
        {
            T existed = m_createdObjects[resourceName].Find(rhs => AssetState.Waiting == rhs.AssetState) as T;

            if (null != existed)
            {
                existed.OnInitialize(parameters);
                existed.Use();
                Debug.Log(string.Format("리소스 {0}을 사용중 상태로 만듭니다.", existed.name));
                return existed;
            }
        }

        GameObject createdObject    = base.LoadInternal<GameObject>(m_nodeName, resourceName);
        GameObject clone            = GameObject.Instantiate(createdObject);
        clone.name                  = createdObject.name;

        T tComponent = clone.GetComponent<T>();
        if (null == tComponent)
        {
            Debug.LogError(string.Format("{0} Object에 {1} 가 없습니다. 확인 바랍니다.", clone.name, tComponent));
            return null;
        }

        if (null == m_resourceNode)
        {
            tComponent.ResourceNode = null;
        }
        else
        {
            tComponent.ResourceNode = m_resourceNode.transform;
        }

        if (false == isContainsResource)
        {
            m_createdObjects[resourceName] = new List<T>();
        }
        m_createdObjects[resourceName].Add(tComponent);
        
        if (null != tComponent.ResourceNode)
        {
            tComponent.transform.SetParent(tComponent.ResourceNode, false);
        }
        tComponent.OnInitialize(parameters);
        tComponent.Use();

        return tComponent;
    }
}