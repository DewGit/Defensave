using UnityEngine;
using UnityEngine.UI;
public class Charging : MonoBehaviour
{
    private Image chargingBar;  //��¡ �� 
    private float maxCharging;  //�ִ� ��¡��
    private float curCharging;  //���� ��¡��

    Player player;//�÷��̾� ��ũ��Ʈ
    private void Awake()
    {
        chargingBar = GetComponentInChildren<Image>();  //��¡�� �̹��� ��������
        curCharging = 0;    //���� ��¡�� �ʱ�ȭ
    }
    private void Start()
    {
        //�÷��̾� ��ũ��Ʈ ��������
        player = FindObjectOfType<Player>();

    }
    void Update()
    {
        ShowCharging();
        ChargingColor();
    }

    void ShowCharging()
    {
        //���� ��¡ ���� ���� UIǥ��
        curCharging = player.chargingTime;
        maxCharging = player.fullCharingTime;
        chargingBar.fillAmount = curCharging / maxCharging;
    }
    void ChargingColor()
    {
        //������ �Ϸ�Ǹ� �ʷϻ� �׷��� ������ ���������� ��ȭ
        if (curCharging >= maxCharging)
        {
            chargingBar.color = new Color(0, 180, 0);
        }
        else
        {
            chargingBar.color = new Color(180, 0, 0);
        }
    }
}
