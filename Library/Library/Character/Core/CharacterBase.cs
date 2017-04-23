using System.Collections;
using UnityEngine;

public abstract class CharacterBase : CachedAsset
{
    private     string          m_name;
    private     CharacterStatus m_status;
   
    protected   Animator        m_animator;
    protected Rigidbody rigid;

    public float speed;
    public float jumpPower;
      

    public CharacterStatus Status
    {
        get { return m_status; }
    }

    public void Awake()
    {
        m_animator = gameObject.GetComponent<Animator>();
    }

    protected override void OnUse()
    {
        m_animator.SetTrigger("Revive");
        gameObject.SetActive(true);
    }
    private void Start()
    {

    }

    protected override void OnRestore()
    {
        m_animator.SetBool("dead", false);       
        transform.rotation = new Quaternion(0, 0, 0, 0);
        gameObject.SetActive(false);
    }

    public virtual void Hitted()
    {
        m_animator.SetTrigger("Hitted");
    }

    //public void Move(Vector2 direction)
    //{
    //    if (direction.x == 0 && direction.y == 0)
    //    {
    //        m_animator.SetBool("IsMoving", false);
    //        return;
    //    }
    //    m_animator.SetBool("IsMoving", true);
    //    Vector3 movement = new Vector3(direction.x, 0, direction.y);
    //    Quaternion newRotation = Quaternion.LookRotation(movement);
    //    rigid.rotation = Quaternion.Slerp(rigid.rotation, newRotation, 10.0f * Time.deltaTime);
    //    movement = movement.normalized * speed * Time.deltaTime;
    //    rigid.MovePosition(transform.position + movement);
    //}

    public void Look( Transform target )
    {
        transform.LookAt(target);
    }

    public void LookThere( Vector2 direction)
    {
        
        //Vector3 movement = new Vector3(direction.x, 0, direction.y);
        //Quaternion newRotation = Quaternion.LookRotation(movement);
        //transform.rotation = newRotation;
        //rigid.rotation = Quaternion.Slerp(rigid.rotation, newRotation, 10.0f * Time.deltaTime);
    }
    //public void Jump()
    //{        
    //    rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    //}

    public void Dead()
    {       
        Restore();
    }    
                                                                                                                                             

    public void DamagePipeline(CharacterBase target)
    {
        target.Hitted();             
        Debug.Log(name + " 이 " + target.name + " 에게" +10 + "의 피해를 입혔습니다.");

    }
}

