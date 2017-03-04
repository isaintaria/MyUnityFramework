using System.Collections.Generic;
using System.Xml.Serialization;

public class MonsterProperty
{
    [XmlAttribute("ID")]
    readonly public int id;
    [XmlAttribute("PrefabName")]
    readonly public string prefabName;
    [XmlAttribute("Name")]
    readonly public string name;
    [XmlAttribute("HP")]
    readonly public int hp;
    [XmlAttribute("Attack")]
    readonly public int attack;
    [XmlAttribute("Defence")]
    readonly public int defence;
    [XmlAttribute("Speed")]
    readonly public int speed;
}

[XmlRoot("MonsterTable")]
public class MonsterTable
{
    private static List<MonsterProperty> s_datas = new List<MonsterProperty>();

    [XmlArray("Monsters")]
    [XmlArrayItem("Monster")]
    public MonsterProperty[] Datas
    {
        get { return s_datas.ToArray(); }
        set { s_datas = new List<MonsterProperty>(value); }
    }

    public static MonsterProperty GetProperty(int id)
    {
        MonsterProperty property = s_datas.Find(rhs => rhs.id == id);

        if (null == property)
        {
            UnityEngine.Debug.Log("찾으려는 Data가 존재하지 않습니다.");
            return null;
        }

        return property;
    }
}