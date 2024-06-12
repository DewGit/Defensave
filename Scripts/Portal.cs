using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject end;  //��Ż ������

    private void OnTriggerStay2D(Collider2D collision)
    {
        //�÷��̾ ��Ż�� ����� �� ��Ż������(end)�� �̵� �� isCenter(�÷��̾ �߰����ִ� �� ����) ��ȯ
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.position = end.transform.position;
            var player = collision.gameObject.GetComponent<Player>();
            player.isCenter = !player.isCenter;
        }
    }
}
