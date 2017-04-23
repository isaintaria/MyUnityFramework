using UnityEngine;

public abstract class TriggerBase : CachedAsset
{
    private     CharacterBase   m_owner;
    protected   FXBase          m_fx;
    protected   Collider        m_collider;

    public CharacterBase Owner
    {
        get { return m_owner; }
    }

    internal override void OnInitialize(params object[] parameters)
    {
        m_owner     = parameters[0] as CharacterBase;
        m_collider  = this.GetComponent<Collider>();
    }

    protected override void OnUse()
    {
        gameObject.SetActive(true);

        if (null == m_fx)
        {
        }
    }

    protected override void OnRestore()
    {
        gameObject.SetActive(false);
    }
}
