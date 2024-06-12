using UnityEngine;

public class CoinMined : MonoBehaviour
{

    //»πµÊ ∞ÒµÂ∑Æ
    private void OnTriggerStay2D(Collider2D collision)
    {
        //«√∑π¿Ã∞° √§±º¿Âø° ¿÷¿ª∞ÊøÏ ∏≈√  1(bonus)∏∏≈≠ ∞ÒµÂ »πµÊ
        if (collision.transform.CompareTag("Player"))
        {
            var player = collision.gameObject.GetComponent<Player>();
            player.gold += player.bonus;
        }
    }
}
