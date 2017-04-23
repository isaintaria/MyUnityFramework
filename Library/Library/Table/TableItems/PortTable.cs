
using System;
using System.Xml.Serialization;

[Serializable]
public class PortProperty
{
    public string PORT { get; set; }
}
[XmlRoot("PortTable")]
public class PortTable
{
    PortProperty Data { get; set; }
}