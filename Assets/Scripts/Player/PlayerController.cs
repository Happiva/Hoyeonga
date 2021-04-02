using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;

    private float defaultMoveSpeed = 6f;
    private bool sitDown;
    private float movement;

    private Rigidbody2D rigid;
    private BoxCollider2D boxCollider;
    private PlayerHeadCheck headCheck;

    public Collider2D healthCollider;

    public Transform attackBox;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
    public LayerMask platformLayer;

    private Animator animator;
    
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        headCheck = GetComponentInChildren<PlayerHeadCheck>();
        animator = GetComponent<Animator>();

        moveSpeed = defaultMoveSpeed;

        sitDown = false;
    }

    void Update()
    {          
        //미끄럼 방지
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.x * 0.1f, rigid.velocity.y);
        }

        //점프        
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
            animator.SetBool("onGround", false);
        }

        //앉기
        if (Input.GetButton("Sit") && IsGrounded())
        {            
            sitDown = true;
        }
        else if (!Input.GetButton("Sit") && !headCheck.isSomethingOnHead)
        {
            sitDown = false;
        }

        //아이템
        if (Input.GetButtonDown("Interaction"))
        {            
            //Debug.Log(GetComponent<Inventory>().items.name);
        }

        //낙하 확인
        
        if (IsGrounded())
        {
            animator.SetBool("onGround", true);
            animator.SetBool("isJumping", false);
            animator.SetBool("isLanding", false);
        }
        else
        {
            if (rigid.velocity.y < 0)
            {
                animator.SetBool("isLanding", true);
            }

            animator.SetBool("onGround", false);
            animator.SetBool("isJumping", true);
        } 
    }

    void FixedUpdate()
    {

        PlayerMove();
               
        PlayerSit();

        //공격
        if (Input.GetButtonDown("Attack")) {
            PlayerAttack();            
        }
    }

    void PlayerMove()
    {
        //좌우 이동
        movement = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(movement));

        rigid.AddForce(Vector2.right * movement, ForceMode2D.Impulse);

        if (rigid.velocity.x > moveSpeed) rigid.velocity = new Vector2(moveSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < moveSpeed * (-1)) rigid.velocity = new Vector2(moveSpeed * (-1), rigid.velocity.y);
        
    }


    //Player의 앉기 동작
    //후에 애니메이션 재생 코드 입력 예정
    void PlayerSit()
    {
        if (sitDown)
        {
            healthCollider.GetComponent<Collider2D>().enabled = false;
            moveSpeed = defaultMoveSpeed / 2;
        }
        else
        {
            healthCollider.GetComponent<Collider2D>().enabled = true;
            moveSpeed = defaultMoveSpeed;
        }
    }

    //Player 공격
    void PlayerAttack()
    {
        Collider2D [] hitEnemies = Physics2D.OverlapCircleAll(attackBox.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.gameObject.layer == 10) //공격한 것이 파괴가능한 물체일 때
            {
                enemy.GetComponent<DestructableObstacle>().Damage(1);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackBox == null) return;

        Gizmos.DrawWireSphere(attackBox.position, attackRange);
    }

    private bool IsGrounded()
    {
        float extraHeight = .1f;

        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, extraHeight, platformLayer);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else {
            rayColor = Color.red;
        }

        /*
        Debug.DrawRay(boxCollider.bounds.center + new Vector3(boxCollider.bounds.extents.x, 0), Vector2.down * (boxCollider.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(boxCollider.bounds.center - new Vector3(boxCollider.bounds.extents.x, 0), Vector2.down * (boxCollider.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(boxCollider.bounds.center - new Vector3(boxCollider.bounds.extents.x, boxCollider.bounds.extents.y), Vector2.right * (boxCollider.bounds.extents.x), rayColor);

        Debug.Log(raycastHit.collider);        
        */

        return raycastHit.collider != null;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == ("Ground"))
        {
            //animator.SetBool("isLanding", false);
            animator.SetBool("isJumping", false);
        }
    }
   
}
