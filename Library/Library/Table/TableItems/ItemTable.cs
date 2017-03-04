using System.Collections.Generic;
using System.Xml.Serialization;

public class ItemProperty
{
    [XmlAttribute("ID")]
    readonly public int id;
    [XmlAttribute("Name")]
    readonly public string name;
    [XmlAttribute("Price")]
    readonly public int price;
}

[XmlRoot("ItemTable")]
public class ItemTable
{
    private static List<ItemProperty> s_datas = new List<ItemProperty>();

    [XmlArray("Items")]
    [XmlArrayItem("Item")]
    public ItemProperty[] Datas
    {
        get { return s_datas.ToArray(); }
        set { s_datas = new List<ItemProperty>(value); }
    }

    public static ItemProperty GetProperty(int id)
    {
        ItemProperty property = s_datas.Find(rhs => rhs.id == id);

        if (null == property)
        {
            UnityEngine.Debug.Log("찾으려는 Data가 존재하지 않습니다.");
            return null;
        }

        return property;
    }
}