using UnityEngine;

public class Player : CharacterBase
{
    internal override void OnInitialize(params object[] parameters)
    {
        string name = (string)parameters[0];
        int level = (int)parameters[1];

        LevelProperty property = LevelTable.GetProperty(level);
        SetInfo(name, property);
    }

    public void Attack()
    {
        m_animator.SetTrigger("Attack_1");
        AssetManager.Instance.Trigger.Retrieve("NormalAttack", this);
    }

    public void Skill(int skillID)
    {
        m_animator.SetTrigger("Attack_2");
        AssetManager.Instance.Trigger.Retrieve("SkillAttack", this);
    }

    public void Move(Vector2 direction)
    {
        transform.forward = new Vector3(transform.forward.x + direction.y, transform.forward.y, transform.forward.z - direction.x);
        m_animator.SetFloat("Speed", 1.0f);
        transform.position = new Vector3(transform.position.x + (direction.y / 5.0f), transform.position.y, transform.position.z - (direction.x / 5.0f));
    }

    public void Stop()
    {
        m_animator.SetFloat("Speed", 0.0f);
    }
}