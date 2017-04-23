﻿using System;
using System.Collections;
using UnityEngine;


public class EnemyAIController : MonoBehaviour
{

    Enemy enemy;
    Rigidbody rigid;
    Animator m_animator;

    public float enemyAttackCooltime;
    GameObject leftJumpPosition;
    GameObject rightJumpPosition;
    GameObject playerLocation;
    public float jumpTime;

    private float spawnMinTime = 1.0f;
    private float spawnMaxTime = 3.0f;
    private float attackTime = 1.0f;


    private Vector3 jumpPosition;

    private bool jump = false;

    public bool Mode;

    public void Awake()
    {
        enemy = GetComponent<Enemy>();
        rigid = GetComponent<Rigidbody>();
        m_animator = GetComponent<Animator>();
        leftJumpPosition = GameObject.Find("Jump_Position_Left");
        rightJumpPosition = GameObject.Find("Jump_Position_Right");


    }

    public void SetSpawnProperty( SpawnProperty property )
    {
        spawnMinTime = property.SpawnTimeMin;
        spawnMaxTime = property.SpawnTimeMax;
        attackTime = property.IdleTime;
    }

    
    public void Start()
    {
        // StartCoroutine(MoveToPlayer());
    }

    public void Spawn(bool mode)
    {
        if (mode)
            jumpPosition = leftJumpPosition.transform.position;
        else
            jumpPosition = rightJumpPosition.transform.position; 
        StartCoroutine(MoveToPlayer2());
    }

    
    public void OnEnable()
    {


    }

    private IEnumerator Jumping()
    {
        while (true)
        {
            yield return new WaitForSeconds(3.0f);
        }       
    }

    //private void Jump()
    //{
    //    if (jump)
    //        return;
    //    enemy.Jump();
    //}

    private void MoveCurvy(Vector3 from, Vector3 to)
    {
       
    }

    public IEnumerator MoveToPlayer2()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(spawnMinTime, spawnMaxTime));        
                       
        jumpTime = 1.0f;
        var startTime = Time.time;
        var goPosition = jumpPosition;
        var startPosition = transform.position;
        
        var action = new Action<Vector3, Vector3,float>((to, from,time) =>
        {
            Vector3 center = (to + from) * 0.5F;
            center -= new Vector3(0, 1, 0);
            enemy.Look(GameObject.Find("character/player").transform);
            Vector3 setRelCenter = to - center;
            Vector3 riseRelCenter = from - center;
            float fracComplete = (Time.time - startTime) / time;
            transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
            transform.position += center;
        });

        while ( Time.time - startTime <  jumpTime  )
        {           
            action( goPosition , startPosition, 1.0f);
            yield return new WaitForSeconds(0);
        } 

        while( true )
        {
            yield return new WaitForSeconds(attackTime);
            enemy.Attack();          
        }      
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            m_animator.SetBool("isJump", false);
            jump = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground")
        {
            m_animator.SetBool("isJump", true);
            jump = true;
        }
    }
    public void Update()
    {
    }
}


