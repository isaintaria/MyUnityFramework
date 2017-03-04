using UnityEngine;

public class TargetTrigger : TriggerBase
{
    private Vector3 m_targetPosition;

    public void Update()
    {
        // 없어질 조건 체크

        // 이동 로직
        Vector3 newDirection = (m_targetPosition - transform.position).normalized;
        Quaternion.LookRotation(newDirection);

        transform.position = transform.position + transform.forward * Time.deltaTime;
    }

    internal override void OnInitialize(params object[] parameters)
    {
        base.OnInitialize(parameters);
    }
}

