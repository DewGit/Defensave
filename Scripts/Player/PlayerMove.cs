using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Player player; 
    private PlayerInput playerInput;    //�÷��̾� ��ǲ ��ũ��Ʈ
    private Rigidbody2D rigid;  //������ٵ�
    
    private float jumpPower = 7f;   //���� ����
    bool isJump;    //��������

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();    //������ٵ� ��������
        playerInput = GetComponent<PlayerInput>();  //�÷��̾� ��ǲ ��ũ��Ʈ ��������
        player = GetComponent<Player>();
    }

    void Update()
    {
        Move();
        Jump();
    }
    void Move()
    {
        //a : -1 , d : 1, none : 0 -> Ű�� �Է¹޾� �̵�
        float x = playerInput.InputMove();
        rigid.velocity = new Vector2(x * player.speed, rigid.velocity.y);
    }

    void Jump()
    {
        //�����̽��ٸ� �Է¹޾� ����
        bool y = playerInput.InputJump();


        //�������� �ƴҶ� ����(Space)�� ������ ����
        if (y && !isJump)
        {           
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJump = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�ٴڿ� ������ ���� �ʱ�ȭ
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
    }
}
