using System;
using UnityEngine;

public class Player : CharacterBase
{
     
     GameObject leftAttackSkillPos;
     GameObject rightAttackSkillPos;

    public AudioClip[] clips;

    public AudioSource audioSource;

    internal override void OnInitialize(params object[] parameters)
    {  
        name = "player";
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();        
        leftAttackSkillPos = GameObject.Find("Jump_Position_Left");
        rightAttackSkillPos = GameObject.Find("Jump_Position_Right");        
    }

    private void FixedUpdate()
    {          
    }    

    public void AttackLeft()
    {       
        m_animator.SetTrigger("Attack Left");
        audioSource.clip = clips[0];
        audioSource.Play();
    }
    public void AttackRight()
    {
        m_animator.SetTrigger("Attack Right");
        audioSource.clip = clips[1];
        audioSource.Play();
    }

    public void LeftAttackEvent()
    {
        if (leftAttackSkillPos != null)
        {           
            AssetManager.Instance.Trigger.Retrieve("Left Attack", this,leftAttackSkillPos.transform.position);
        }
    }
    public void RightAttackEvent()
    {
        if (rightAttackSkillPos != null)
        {
            AssetManager.Instance.Trigger.Retrieve("Right Attack", this, rightAttackSkillPos.transform.position);
        }
    }


}