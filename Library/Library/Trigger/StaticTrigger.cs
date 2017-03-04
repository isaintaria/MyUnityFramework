using UnityEngine;

public class StaticTrigger : TriggerBase
{
    private float m_lifeTime    = 1.0f;
    private float m_elapsedTime = 0.0f;

    public void Update()
    {
        m_elapsedTime += Time.deltaTime;

        if (m_elapsedTime > m_lifeTime)
        {
            m_elapsedTime = 0.0f;
            Restore();
        }
    }

    internal override void OnInitialize(params object[] parameters)
    {
        base.OnInitialize(parameters);
        transform.position = Owner.transform.position + Owner.transform.forward;
    }

    public void OnTriggerEnter(Collider col)
    {
        CharacterBase target = col.GetComponent<CharacterBase>();

        if (null != target)
        {
            Owner.GetComponent<CharacterBase>().DamagePipeline(target);
        }
    }
}

