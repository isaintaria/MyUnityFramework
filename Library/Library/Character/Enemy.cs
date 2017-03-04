using UnityEngine;

public class Enemy : CharacterBase
{
    internal override void OnInitialize(params object[] parameters)
    {
        int             monsterID = (int)parameters[0];
        MonsterProperty property  = MonsterTable.GetProperty(monsterID);

        SetInfo(property);
    }
}

