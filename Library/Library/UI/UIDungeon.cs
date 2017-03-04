using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIDungeon : UIBase
{
    public  Transform   m_joystick;
    private bool        m_isMove;
    private Vector2     m_direction;

    protected override void OpenComplete()
    {
    }

    protected override void CloseComplete()
    {
    }

    public void OnDragJoystick(BaseEventData data)
    {
        if(false == m_isMove)
        {
            return;
        }

        PointerEventData    pointerData = data as PointerEventData;
        m_joystick.position             = pointerData.position;
        m_direction                     = pointerData.delta.normalized;
    }

    public void OnPointerEnter()
    {
        m_isMove = true;
    }

    public void OnPointerExit()
    {
        m_isMove = false;
        m_joystick.localPosition = Vector3.zero;
        m_direction = Vector2.zero;
        IngameManager.Instance.Player.Stop();
    }

    public void OnAttack()
    {
        IngameManager.Instance.Player.Attack();
    }

    public void OnSkill1()
    {
        IngameManager.Instance.Player.Skill(0);
    }

    public void Update()
    {
        if(false == m_isMove || Vector2.zero == m_direction)
        {
            return;
        }

        IngameManager.Instance.Player.Move(m_direction);
    }
}
