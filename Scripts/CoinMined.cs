using UnityEngine;

public class CoinMined : MonoBehaviour
{

    //ȹ�� ��差
    private void OnTriggerStay2D(Collider2D collision)
    {
        //�÷��̰� ä���忡 ������� ���� 1(bonus)��ŭ ��� ȹ��
        if (collision.transform.CompareTag("Player"))
        {
            var player = collision.gameObject.GetComponent<Player>();
            player.gold += player.bonus;
        }
    }
}
