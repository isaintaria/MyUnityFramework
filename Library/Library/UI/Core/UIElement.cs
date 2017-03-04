using UnityEngine;

public class UIElement : MonoBehaviour
{
    public string m_openAnimation;
    public string m_closeAnimation;

    private EasingAnimator m_animator = null;

    public float OpenAnimation()
    {
        if (null == m_animator)
        {
            m_animator = gameObject.AddComponent<EasingAnimator>();
        }

        if (true == string.IsNullOrEmpty(m_openAnimation))
        {
            return 0.0f;
        }

        return m_animator.Play(m_openAnimation);
    }

    public float CloseAnimation()
    {
        if (null == m_animator)
        {
            m_animator = gameObject.AddComponent<EasingAnimator>();
        }

        if (true == string.IsNullOrEmpty(m_closeAnimation))
        {
            return 0.0f;
        }

        return m_animator.Play(m_closeAnimation);
    }
}

