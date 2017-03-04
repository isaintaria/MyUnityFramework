using UnityEngine;
using System.Collections.Generic;

public class IngameManager : SingleTon<IngameManager>
{
    private const int       spawnGroupCount = 5;

    private Vector3         m_playerInitPos;
    private Player          m_player;

    private List<Enemy>     m_enemy = new List<Enemy>();

    private IngameManager()
    {
        m_playerInitPos = GameObject.Find("PlayerPos").transform.position;
    }

    public void Init()
    {
        m_player = AssetManager.Instance.Character.Retrieve("Player", LocalData.Instance.Nickname, LocalData.Instance.Level) as Player;
        m_player.transform.position = m_playerInitPos;
        TrackingCamera.SetTarget(m_player.transform);
    }

    public Player Player
    {
        get { return m_player; }
    }

    public void EnemyRegister(Enemy enemy)
    {
        m_enemy.Add(enemy);
    }

    public int EnemyCount()
    {
        int remainCount = 0;

        for(int i = 0; i < m_enemy.Count; ++i)
        {
            if(AssetState.Using == m_enemy[i].AssetState)
            {
                ++remainCount;
            }
        }

        return remainCount;
    }
}
