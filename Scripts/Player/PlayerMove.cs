using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Player player; 
    private PlayerInput playerInput;    //플레이어 인풋 스크립트
    private Rigidbody2D rigid;  //리지드바디
    
    private float jumpPower = 7f;   //점프 세기
    bool isJump;    //점프유무

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();    //리지드바디 가져오기
        playerInput = GetComponent<PlayerInput>();  //플레이어 인풋 스크립트 가져오기
        player = GetComponent<Player>();
    }

    void Update()
    {
        Move();
        Jump();
    }
    void Move()
    {
        //a : -1 , d : 1, none : 0 -> 키를 입력받아 이동
        float x = playerInput.InputMove();
        rigid.velocity = new Vector2(x * player.speed, rigid.velocity.y);
    }

    void Jump()
    {
        //스페이스바를 입력받아 점프
        bool y = playerInput.InputJump();


        //점프중이 아닐때 점프(Space)를 누르면 점프
        if (y && !isJump)
        {           
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJump = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //바닥에 닿으면 점프 초기화
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
    }
}
