using System;
using System.Collections;
using UnityEngine;

public class Enemy : CharacterBase
{
    public AudioClip[] clips;
    private AudioSource audioSource;
    
    internal override void OnInitialize(params object[] parameters)
    {
        name = "zombie";
    }
    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Attack()
    {
        if( !m_animator.GetBool("dead"))
        {
            audioSource.clip = clips[UnityEngine.Random.Range(0, 1)];
            audioSource.Play();
            m_animator.SetTrigger("Attack");
        }
          
    }
    
    public void AttackSuccess()
    {
        NGTest test = GameObject.Find("qweqwe").GetComponent<NGTest>();
        UIGameScene scene = GameObject.Find("UIGameScene").GetComponent<UIGameScene>();
        test.Instance_EventPlayerDamaged();
        scene.Instance_EventPlayerDamaged();
        test.player.GetComponent<PlayerController>().Instance_EventPlayerDamaged();
        
    }
            
    public override void Hitted()
    {        
        m_animator.SetBool("dead", true);
        m_animator.SetTrigger("Dead");
        StartCoroutine(Hitted_Routine());
    }   

    private IEnumerator Hitted_Routine()
    {
        var elapsed = 0.0f;
        var life = 1.0f;
        var pos = GameObject.Find("player").transform.position;
        Vector3 movement = transform.position - pos;
        var x = UnityEngine.Random.Range(-0.5f,0.5f);


        while ( life > elapsed )
        {
            elapsed += Time.deltaTime;            
            transform.Translate(new Vector3(x, 1,-1) * Time.deltaTime * speed);
            yield return new WaitForSeconds(0);
        }              

        Dead(); 
    }
}