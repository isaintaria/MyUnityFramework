using System;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    protected Player player;
    private Animator m_animator;

    public GameObject leftAttackSkillPos;
    public GameObject rightAttackSkillPos;

    public CharacterController cc;
    public float moveSpeed = 5f;
    public float turnSpeed = 400f;
    public float jumpSpeed = 6f;
    public float jumpTime = 0.5f;

    bool isMoveable = true;
    float elapsedJump = 0.0f;
    public void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (h == 0 && v == 0)
            m_animator.SetBool("IsMoving", false);
        else
            m_animator.SetBool("IsMoving", true);
        Vector3 moveVector = new Vector3();
        if (v != 0f)
        {
            moveVector = v * transform.forward * moveSpeed * Time.deltaTime + Physics.gravity;
            cc.Move(moveVector);
        }
        if (h != 0f)
        {
            moveVector = h * transform.right * moveSpeed * Time.deltaTime + Physics.gravity;
            cc.Move(moveVector);
        }




        //  Debug.Log("값: "+ h.ToString() + "ㅇㅅㅇ" +v.ToString());


    }
    public void OnEnable()
    {
        IngameManager.Instance.EventPlayerDamaged += Instance_EventPlayerDamaged;
    }

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
        player = GetComponent<Player>();
        isMoveable = IngameManager.Instance.Moveable;
    }

    private void Instance_EventPlayerDamaged()
    {
        var fx = Resources.Load<FXBase>(string.Format("fx/{0}", "HitEffect"));
        fx.transform.position = this.transform.position;
        GameObject.Instantiate(fx);
    }

    private float nextFire = 0.5f;
    public float attackCooltime = 0.5f;
    float h = 0.0f;
    float v = 0.0f;
    bool jump = false;

    private void Update()
    {
        if( isMoveable )
         Move();
        DoAttack();

        DoJump(); 
   
        nextFire += Time.deltaTime;
    }

    private float jElapsed = 1.0f;
    private void DoJump()
    {
        if( Input.GetButtonDown("Jump"))
        {
            jElapsed = 0.0f;
        }
        
        jElapsed += Time.deltaTime;
        if( jElapsed < jumpTime )
        {
            Vector3 jumpVector = Vector3.up * moveSpeed * Time.deltaTime + new Vector3(0, 0.1f, 0);
            cc.Move(jumpVector);
        }
              
    }

    private void DoAttack()
    {
        if (Input.GetButtonDown("Fire1") && nextFire > attackCooltime)
        {
            nextFire = 0.0f;
            player.AttackLeft();
        }
        else if (Input.GetButtonDown("Fire2") && nextFire > attackCooltime)
        {
            nextFire = 0.0f;
            player.AttackRight();
        }
    }

    private void FixedUpdate()
    {
       
    }

    private void Jump()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            m_animator.SetBool("Jump", false);
            jump = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground")
        {
            m_animator.SetBool("Jump", true);
            jump = true;
        }
    }

  


}

