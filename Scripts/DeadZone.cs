using UnityEngine;

public class DeadZone : MonoBehaviour
{
    //오브젝트가 데드존에 닿았을경우 오브젝트 파괴
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }
}
