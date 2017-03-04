
public class CharacterStatus
{
    private int m_hp        = 0;
    private int m_attack    = 0;
    private int m_defence   = 0;
    private int m_speed     = 0;

    public CharacterStatus(LevelProperty property)
    {
        m_hp        = property.hp;
        m_attack    = property.attack;
        m_defence   = property.defence;
        m_speed     = property.speed;
    }

    public CharacterStatus(MonsterProperty property)
    {
        m_hp        = property.hp;
        m_attack    = property.attack;
        m_defence   = property.defence;
        m_speed     = property.speed;
    }

    public int HP
    {
        get { return m_hp; }
        set { m_hp = value; }
    }

    public int Attack
    {
        get { return m_attack; }
    }
}

