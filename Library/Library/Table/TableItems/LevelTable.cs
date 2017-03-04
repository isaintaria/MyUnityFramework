using System.Collections.Generic;
using System.Xml.Serialization;

public class LevelProperty
{
    [XmlAttribute("Level")]
    readonly public int level;
    [XmlAttribute("Attack")]
    readonly public int attack;
    [XmlAttribute("Defence")]
    readonly public int defence;
    [XmlAttribute("HP")]
    readonly public int hp;
    [XmlAttribute("Speed")]
    readonly public int speed;
}

[XmlRoot("LevelTable")]
public class LevelTable
{
    private static List<LevelProperty> s_datas = new List<LevelProperty>();

    [XmlArray("Levels")]
    [XmlArrayItem("Level")]
    public LevelProperty[] Datas
    {
        get { return s_datas.ToArray(); }
        set { s_datas = new List<LevelProperty>(value); }
    }

    public static LevelProperty GetProperty(int level)
    {
        LevelProperty property = s_datas.Find(rhs => rhs.level == level);

        if (null == property)
        {
            UnityEngine.Debug.Log("찾으려는 Data가 존재하지 않습니다.");
            return null;
        }

        return property;
    }
}