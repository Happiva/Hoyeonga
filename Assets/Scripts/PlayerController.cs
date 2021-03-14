using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;

    private float defaultMoveSpeed = 6f;

    private bool sitDown;
    private bool onGround;

    private float movement;

    private Rigidbody2D rigid;

    public Collider2D healthCollider;

    public Transform attackBox;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
    
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

        moveSpeed = defaultMoveSpeed;

        onGround = true;
        sitDown = false;
    }

    
    void FixedUpdate()
    {

        //좌우 이동
        movement = Input.GetAxisRaw("Horizontal");

        rigid.AddForce(Vector2.right * movement, ForceMode2D.Impulse);

        if (rigid.velocity.x > moveSpeed) rigid.velocity = new Vector2(moveSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < moveSpeed * (-1)) rigid.velocity = new Vector2(moveSpeed * (-1), rigid.velocity.y);


        //점프 (임시)
        if (Input.GetButtonDown("Jump") && onGround) {

            //다중 점프 차단
            rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            onGround = false;
        }


        //앉기
        if (Input.GetButton("Sit"))
        {
            sitDown = true;            
        }
        else if (Input.GetButtonUp("Sit"))
        {
            sitDown = false;
            
        }

        PlayerSit();


        //공격
        if (Input.GetButtonDown("Attack")) {
            Debug.Log("Attack");
            PlayerAttack();            
        }


        //상호작용    
        if (Input.GetButtonDown("Interaction")) {

        }
    }

    //Player의 앉기 동작
    //후에 애니메이션 재생 코드 입력 예정
    void PlayerSit()
    {
        if (sitDown)
        {
            GetComponent<Collider2D>().enabled = false;
            moveSpeed = defaultMoveSpeed / 2;
        }
        else
        {
            GetComponent<Collider2D>().enabled = true;
            moveSpeed = defaultMoveSpeed;
        }
    }

    //Player 공격
    void PlayerAttack()
    {
        Collider2D [] hitEnemies = Physics2D.OverlapCircleAll(attackBox.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Hit");

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


    //충돌 감지
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground") onGround = true;      
    }
}
