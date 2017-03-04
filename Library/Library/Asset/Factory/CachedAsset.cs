using UnityEngine;

public enum AssetState
{
    Waiting,
    Using,
}

public abstract class CachedAsset : MonoBehaviour
{
    private AssetState  m_assetState        = AssetState.Waiting;
    private Transform   m_assetNode         = null;
    private Transform   m_cachedTransform;

    public new Transform transform
    {
        get
        {
            if(null == m_cachedTransform)
            {
                m_cachedTransform = GetComponent<Transform>();
            }

            return m_cachedTransform;
        }
    }

    public AssetState AssetState
    {
        get
        {
            return m_assetState;
        }
        private set
        {
            m_assetState = value;
            switch (m_assetState)
            {
                case AssetState.Using:
                    OnUse();
                    break;
                case AssetState.Waiting:
                    OnRestore();
                    break;
            }
        }
    }

    protected internal Transform ResourceNode
    {
        get { return m_assetNode; }
        set { m_assetNode = value; }
    }

    public void Use()
    {
        AssetState = AssetState.Using;
    }

    public void Restore()
    {
        AssetState = AssetState.Waiting;
    }

    internal    abstract void OnInitialize(params object[] parameters);
    protected   abstract void OnUse();
    protected   abstract void OnRestore();
}