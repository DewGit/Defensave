using UnityEngine;

public class DeadZone : MonoBehaviour
{
    //������Ʈ�� �������� �������� ������Ʈ �ı�
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }
}
