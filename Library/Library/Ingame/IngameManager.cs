using UnityEngine;
using System.Collections.Generic;
using System;

public class IngameManager : MonoSingleTon<IngameManager>
{
    public delegate void HitEvent();
    public delegate void MissedEvent(bool isLeft);
    public event HitEvent EventPlayerDamaged = delegate { };
    public event HitEvent EventEnemyDamagedLeft  = delegate { };
    public event HitEvent EventEnemyDamagedRight = delegate { };
    public event HitEvent MissedAttackEvent = delegate { };
    public event HitEvent GameStart = delegate { };
    public event HitEvent GameEnd = delegate { };
        
    public bool Moveable = true;
    public bool isCamera3rd = true;
    internal bool isCameraNormalMode;

    public void FIreGameStart()
    {
        GameStart();
    }

    private IngameManager()
    {

    }

    public void Init()
    {
         #pragma warning 각종 테이블 로드 구현 장소
    }

    public void FireMissedAttackEvent()
    {
        MissedAttackEvent();
    }

    public void FireGameEnd()
    {
        GameEnd(); 
    }
    
    public void FirePlayerDamagedEvent()
    {
 //       EffectManager.Instance.MakeEffect(null);
        EventPlayerDamaged();
    }
    public void FireLeftEnemyDamagedEvent()
    {
        EventEnemyDamagedLeft();
    }
    public void FireRightEnemyDamagedEvent( )
    {
        EventEnemyDamagedRight();
    }
}
