using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData enemyData; //EnemyData 스크립트
    EnemySpawn enemySpawn;  //EnemySpawn 스크립트
    Player player;  //Player 스크립트
        
    private GameObject target;  //player오브젝트
    private SpriteRenderer spriteRenderer;  //SpriteRenderer를 가져옴
    Rigidbody2D rigid;  //rigidbody2D를 가져옴
    
    float maxHp;    //최대체력
    float curHp;    //현재체력
    float dmg;  //데미지
    float speed;    //스피드

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
        //적 데이터에서 수치를 가져와 현재 오브젝트에 넣어줌
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
        //플레이어가 중간에 있으면 플레이어를 향해 아니면 성을 향해 이동
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
        // 플레이어나 성에 닿으면 데미지를 주고 스폰포인트로 텔레포트
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Castle"))
        {         
            player.curHp -= dmg;
            curHp /= 2;
            TeleportSpawnPoint();
            dmg *= 2;
        }
       //총알에 닿을 경우 TakeDamage메소드 실행
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(player.dmg,collision.gameObject.transform.position);
        }
    }
    private void TakeDamage(float damage, Vector3 bulletPosition)
    {
        //넉백 후 데미지를 입음
        Vector3 knockbackDirection = (transform.position - bulletPosition).normalized;
        rigid.AddForce(knockbackDirection * (damage / curHp) * 100, ForceMode2D.Impulse);

        //데미지 적용
        curHp -= damage;
    }

    private void TeleportSpawnPoint()
    {
        //스폰지점으로 텔레포트
        transform.position = enemySpawn.enemySpawnPositions[Random.Range(0, enemySpawn.enemySpawnPositions.Length)].position;
    }
}
