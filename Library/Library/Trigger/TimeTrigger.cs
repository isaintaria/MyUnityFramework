using UnityEngine;

public class TimeTrigger : TriggerBase
{
    public  float m_lifeTime;

    private float m_elapsedTime = 0.0f;

    public void Update()
    {
        // 없어질 조건 체크
        m_elapsedTime += Time.deltaTime;

        if (m_elapsedTime > m_lifeTime)
        {
            Restore();
        }

        // 이동 로직
        transform.position = transform.position + transform.forward * Time.deltaTime * 20.0f;
    }

    internal override void OnInitialize(params object[] parameters)
    {
        base.OnInitialize(parameters);
        m_elapsedTime = 0.0f;
        transform.position = Owner.transform.position + Owner.transform.forward * 5.0f;
        transform.position = new Vector3(transform.position.x, transform.position.y + 2.0f, transform.position.z);
        transform.forward = Owner.transform.forward;
    }

    public void OnTriggerEnter(Collider col)
    {
        Enemy enemy = col.GetComponent<Enemy>();
        if(null != enemy)
        {
            Owner.DamagePipeline(enemy);

            Restore();
        }
    }
}

