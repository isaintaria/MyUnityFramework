using System;
using System.Xml.Serialization;

[Serializable]
public class EffectOption
{
    //  [XmlAttribute("Vibration")]
    public bool vibration;
    //  [XmlAttribute("Bulb")]
    public bool bulb;
    //  [XmlAttribute("Speaker")]
    public bool speaker;
    //  [XmlAttribute("Pattern_Vibration")]
    public int pattern_v;
    //  [XmlAttribute("Pattern_Bulb")]
    public int pattern_b;
}

[XmlRoot("Effect")]
public class EffectTable
{
    public EffectOption Player_Attack { get; set; }
}