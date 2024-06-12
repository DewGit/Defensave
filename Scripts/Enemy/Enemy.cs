using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData enemyData; //EnemyData ��ũ��Ʈ
    EnemySpawn enemySpawn;  //EnemySpawn ��ũ��Ʈ
    Player player;  //Player ��ũ��Ʈ
        
    private GameObject target;  //player������Ʈ
    private SpriteRenderer spriteRenderer;  //SpriteRenderer�� ������
    Rigidbody2D rigid;  //rigidbody2D�� ������
    
    float maxHp;    //�ִ�ü��
    float curHp;    //����ü��
    float dmg;  //������
    float speed;    //���ǵ�

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        target = FindObjectOfType<PlayerMove>().gameObject;
        enemySpawn = FindAnyObjectByType<EnemySpawn>();
        player = FindObjectOfType<Player>();
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        SettingEnemy();
    }


    public void SettingEnemy()
    {
        //�� �����Ϳ��� ��ġ�� ������ ���� ������Ʈ�� �־���
        maxHp = enemyData.hp;
        curHp = enemyData.hp;
        dmg = enemyData.dmg;
        speed = enemyData.speed;
        transform.localScale = enemyData.size;
        spriteRenderer.color = enemyData.color;
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        //�÷��̾ �߰��� ������ �÷��̾ ���� �ƴϸ� ���� ���� �̵�
        int dir;

        if (player.isCenter)
        {
            dir = target.transform.position.x - transform.position.x > 0 ? 1 : -1;
        }
        else
        {
            dir = 0 - transform.position.x > 0 ? 1 : -1;
        }

        var move = dir * speed * Time.deltaTime;
        transform.Translate(move, 0, 0);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �÷��̾ ���� ������ �������� �ְ� ��������Ʈ�� �ڷ���Ʈ
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Castle"))
        {         
            player.curHp -= dmg;
            curHp /= 2;
            TeleportSpawnPoint();
            dmg *= 2;
        }
       //�Ѿ˿� ���� ��� TakeDamage�޼ҵ� ����
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(player.dmg,collision.gameObject.transform.position);
        }
    }
    private void TakeDamage(float damage, Vector3 bulletPosition)
    {
        //�˹� �� �������� ����
        Vector3 knockbackDirection = (transform.position - bulletPosition).normalized;
        rigid.AddForce(knockbackDirection * (damage / curHp) * 100, ForceMode2D.Impulse);

        //������ ����
        curHp -= damage;
    }

    private void TeleportSpawnPoint()
    {
        //������������ �ڷ���Ʈ
        transform.position = enemySpawn.enemySpawnPositions[Random.Range(0, enemySpawn.enemySpawnPositions.Length)].position;
    }
}
