using UnityEngine;

public abstract class CharacterBase : CachedAsset
{
    private     string          m_name;
    private     CharacterStatus m_status;
    protected   Animator        m_animator;

    public CharacterStatus Status
    {
        get { return m_status; }
    }

    public void Awake()
    {
        m_animator = gameObject.GetComponent<Animator>();
    }

    protected override void OnUse()
    {
        gameObject.SetActive(true);
    }

    protected override void OnRestore()
    {
        gameObject.SetActive(false);
    }

    protected void SetInfo(string name, LevelProperty property)
    {
        m_name      = name;
        m_status    = new CharacterStatus(property);
    }

    protected void SetInfo(MonsterProperty property)
    {
        m_name      = property.name;
        m_status    = new CharacterStatus(property);
    }

    public void Dead()
    {
        Restore();
    }

    public void DamagePipeline(CharacterBase target)
    {

        int Damage = Status.Attack;
        target.Status.HP -= Damage;
        Debug.Log(name + " 이 " + target.name + " 에게" + Damage + "의 피해를 입혔습니다.");
        if(target.Status.HP < 0)
        {
            target.Dead();
        }
    }
}

