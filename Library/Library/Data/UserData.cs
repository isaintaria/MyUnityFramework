using System.Xml.Serialization;

public class UserData
{
    private string  m_nickName  = "COM7";

    [XmlAttribute("Port")]
    public string Port
    {
        get { return m_nickName; }
        set { m_nickName = value; }
    }
}