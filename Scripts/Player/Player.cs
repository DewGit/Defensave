using UnityEngine;

public class Player :MonoBehaviour
{
    public float maxHp = 100;   //�÷��̾� �ִ�ü��
    public float curHp = 100;   //�÷��̾� ����ü��
    public int gold;    //�÷��̾� ��差
    public bool isCenter = true;    //�÷��̾ �߰��� �ִ� �� ����
    public float dmg = 10;   //�÷��̾� ������
    public float chargingTime;  //���� ��¡���� 
    public float fullCharingTime = 2f;    //���� ������ ��¡ ����
    public int bonus = 1; //���ȹ�淮
    public float speed = 8f;   //�̵��ӵ�

}
