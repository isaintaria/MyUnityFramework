using System;
using UnityEngine;

public class RightAttackTrigger : TriggerBase
{
    private float m_lifeTime = 0.05f;
    private float m_elapsedTime = 0.0f;
    private AudioSource audioSource;
    public AudioClip[] clips;

    public void Update()
    {
        m_elapsedTime += Time.deltaTime;

        if (m_elapsedTime > m_lifeTime)
        {
            m_elapsedTime = 0.0f;
            if (!isHit)
            {
                var fx = Resources.Load<FXBase>(string.Format("fx/{0}", "MissEffectRight"));
        
                GameObject.Instantiate(fx);
                IngameManager.Instance.FireMissedAttackEvent();
            }
            Restore();
        }
    }

    private void OnEnable()
    {
     //                       audioSource = GetComponent<AudioSource>();
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
            Debug.Log("parameter 에 값이 없음");
        }

    }

    bool justOne = false;
    private bool isHit = false;

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
                    justOne = true; // 중복 히트 방지
                    //     Debug.Log(string.Format("{0}이 {1}에게 공격", Owner.name, target.name));
                    var fx = Resources.Load<FXBase>(string.Format("fx/{0}", "AttackEffect"));
                    fx.transform.position = target.transform.position + new Vector3(0, 2, 0);
                    GameObject.Instantiate(fx);
                    Owner.GetComponent<CharacterBase>().DamagePipeline(target);
                    IngameManager.Instance.FireRightEnemyDamagedEvent();
                 
                    UIGameScene scene = GameObject.Find("UICanvas(Clone)/Contents/UIGameScene").GetComponent<UIGameScene>();
                    scene.Instance_EventEnemyDamagedRight();


                }

            }
        }
        catch (Exception e)
        {
            Debug.Log(e.StackTrace);
        }

    }
}

