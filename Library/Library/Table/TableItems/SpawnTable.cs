using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

    [Serializable]
    public class SpawnProperty
    {
        public float IdleTime { get; set; }
        public float LeftSpawnTimeMin { get; set; }
        public float LeftSpawnTimeMax { get; set; }
        public float RightSpawnTimeMin { get; set; }
        public float RightSpawnTimeMax { get; set; }
}
    [XmlRoot("SpawnTable")]
    public class SpawnTable
    {
        private static List<SpawnProperty> s_datas = new List<SpawnProperty>();

        [XmlArray("SpawnDatas")]
        [XmlArrayItem("Data")]
        public SpawnProperty[] Datas
        {
            get { return s_datas.ToArray(); }
            set { s_datas = new List<SpawnProperty>(value); }
        }
    }

