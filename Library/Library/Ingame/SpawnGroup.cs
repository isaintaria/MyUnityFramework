using UnityEngine;
using System.Collections.Generic;

public class SpawnGroup : MonoBehaviour
{
    public List<int> m_monsterIDs = new List<int>();

    public void Start()
    {
        for(int i = 0; i < m_monsterIDs.Count; ++i)
        {
            MonsterProperty property = MonsterTable.GetProperty(m_monsterIDs[i]);

            if (null == property)
            {
                return;
            }

            CharacterBase   result      = AssetManager.Instance.Character.Retrieve(property.prefabName, m_monsterIDs[i]);
            float           randomPos   = Random.Range(-2.0f, 2.0f);
            Vector3         initPos     = this.transform.position;
            initPos.x += randomPos;
            initPos.z += randomPos;

            result.transform.position   = initPos;

            IngameManager.Instance.EnemyRegister(result as Enemy);
        }
    }
}

