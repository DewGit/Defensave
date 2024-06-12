using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 6f;  //�Ѿ� ���ǵ�
    public float bulletTime = 2f;   //�Ѿ� ���� �ð�
    void Start()
    {
        //2��(bulletTime)�Ŀ� �Ѿ��� �����
        Invoke("DestroyBullet", bulletTime);
    }
    void Update()
    {
        //�Ѿ��� 6(bulletSpeed)�� �ӵ��� ������ ����
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //���� �浹�ϸ� �Ѿ��� ����
        if (collision.gameObject.CompareTag("Enemy"))
        {
            DestroyBullet();
        }
    }
    void DestroyBullet()
    {
        //�Ѿ˾��ִ� �޼ҵ�
        Destroy(gameObject);
    }
}
