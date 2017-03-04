using System.Xml.Serialization;

public class UserData
{
    private string  m_nickName  = string.Empty;
    private int     m_gold      = 0;
    private int     m_level     = 0;

    [XmlAttribute("NickName")]
    public string NickName
    {
        get { return m_nickName; }
        set { m_nickName = value; }
    }

    [XmlAttribute("Gold")]
    public int Gold
    {
        get { return m_gold; }
        set { m_gold = value; }
    }

    [XmlAttribute("Level")]
    public int Level
    {
        get { return m_level; }
        set { m_level = value; }
    }
}