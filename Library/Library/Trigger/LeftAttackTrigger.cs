using System;
using UnityEngine;

public class LeftAttackTrigger : TriggerBase
{
    private float m_lifeTime    = 0.05f;
    private float m_elapsedTime = 0.0f;
    bool isHit = false;
    

    public void Update()
    {
        m_elapsedTime += Time.deltaTime;

        if (m_elapsedTime > m_lifeTime)
        {
            m_elapsedTime = 0.0f;
            if( !isHit )
            {
                Debug.Log("몇번 일어나나 체크");
                var fx = Resources.Load<FXBase>(string.Format("fx/{0}", "MissEffect"));
                fx.transform.position = this.transform.position;
                GameObject.Instantiate(fx);
                IngameManager.Instance.FireMissedAttackEvent();
            }
            Restore();
            
        }
    }

    private void OnEnable()
    {
      //  audiosSource = GetComponent<AudioSource>();
        justOne = false;
        isHit = false;
        
    }

    internal override void OnInitialize(params object[] parameters)
    {
        base.OnInitialize(parameters);
        try
        {
            if (parameters[1] is Vector3)
            {
                this.transform.position = (Vector3)parameters[1];
            }
        }
        catch
        {

        }      
    }

    bool justOne = false;

    public void OnTriggerEnter(Collider col)
    {
        try
        {
            if (col.tag != "Enemy")
                return;

            CharacterBase target = col.GetComponent<CharacterBase>();
            if (null != target)
            {
                if (!justOne)
                {
                    isHit = true;
                    justOne = true;
                    //     Debug.Log(string.Format("{0}이 {1}에게 공격", Owner.name, target.name));
                    var fx = Resources.Load<FXBase>(string.Format("fx/{0}", "AttackEffect"));
                    fx.transform.position = this.transform.position;
                    GameObject.Instantiate(fx);
                    Owner.GetComponent<CharacterBase>().DamagePipeline(target);
                    IngameManager.Instance.FireLeftEnemyDamagedEvent();
                }

            }
        }
        catch ( Exception e)
        {
            Debug.Log(e.StackTrace);
        }
      
    }
}

