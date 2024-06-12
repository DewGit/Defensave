using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 6f;  //총알 스피드
    public float bulletTime = 2f;   //총알 유지 시간
    void Start()
    {
        //2초(bulletTime)후에 총알이 사라짐
        Invoke("DestroyBullet", bulletTime);
    }
    void Update()
    {
        //총알이 6(bulletSpeed)의 속도로 앞으로 나감
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //적과 충돌하면 총알을 없앰
        if (collision.gameObject.CompareTag("Enemy"))
        {
            DestroyBullet();
        }
    }
    void DestroyBullet()
    {
        //총알없애는 메소드
        Destroy(gameObject);
    }
}
