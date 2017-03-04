using UnityEngine;

public class TrackingCamera :MonoBehaviour
{
    private static Transform m_target;

    public  Vector3     m_offset;
    public  float       m_distance      = 15.0f;
    public  float		m_springness	= 4.0f;

    private Transform   m_myTransform   = null;

    public static void SetTarget(Transform target)
    {
        m_target = target;
    }

    public void Start()
    {
        m_myTransform = transform;
    }

    private Vector3 GetGoalPosition()
    {
        Vector3 goalPosition = Vector3.zero;

        goalPosition = m_target.position - m_myTransform.forward * m_distance;

        return goalPosition;
    }

    public void LateUpdate()
    {
        if (null != m_target)
        {
            Vector3 goalPosition    = GetGoalPosition() + m_offset;
            goalPosition.y          = transform.position.y;
            goalPosition            = Vector3.Lerp(m_myTransform.position, goalPosition, Time.deltaTime * m_springness);
            m_myTransform.position  = goalPosition;
        }
    }
}

