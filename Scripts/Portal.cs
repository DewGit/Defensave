using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject end;  //포탈 목적지

    private void OnTriggerStay2D(Collider2D collision)
    {
        //플레이어가 포탈에 닿았을 때 포탈목적지(end)로 이동 후 isCenter(플레이어가 중간에있는 지 유무) 전환
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.position = end.transform.position;
            var player = collision.gameObject.GetComponent<Player>();
            player.isCenter = !player.isCenter;
        }
    }
}
