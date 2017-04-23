
public class CharacterStatus
{
    private int m_hp        = 0;
    private int m_attack    = 0;
    private int m_defence   = 0;
    private int m_speed     = 0;


    public int HP
    {
        get { return m_hp; }
        set { m_hp = value; }
    }

    public int Attack
    {
        get { return m_attack; }
    }

    public int Speed
    {
        get
        {
            return m_speed;
        }

        set
        {
            m_speed = value;
        }
    }

    public int Defence
    {
        get
        {
            return m_defence;
        }

        set
        {
            m_defence = value;
        }
    }

}

