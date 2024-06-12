using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bullet;   //�Ѿ�
    public Transform pos;   //�Ѿ��� ������ ��ġ

    Player player;
    private PlayerInput playerInput;    //�÷��̾� ��ǲ ��ũ��Ʈ

    private void Start()
    {
        //�÷��̾� ��ǲ ��ũ��Ʈ�� �޾ƿ�
        playerInput = GetComponentInParent<PlayerInput>();
        player = GetComponentInParent<Player>();
    }
    void Update()
    {
        AttackDirection();
        Attack();
    }

    void AttackDirection()
    {
        //���콺 ��ġ�� ���� ���� ������ ������
        Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);
    }
    void Attack()
    {
        bool isCharging = playerInput.InputCharging();
        bool isAttack = playerInput.InputAttack();

        //���콺�� ������ ������¡�� ��
        if (isCharging)
        {
            if (player.chargingTime < player.fullCharingTime)
            {
                player.chargingTime += Time.deltaTime;
            }
        }
        //���ݰ����� ��¡���� ��¡�ϰ� ���콺�� �ø��� �Ѿ��� �����ǰ� ��¡�ð��� �ʱ�ȭ��
        else if (isAttack)
        {
            if (player.chargingTime >= player.fullCharingTime)
            {
                Instantiate(bullet, pos.position, transform.rotation);
            }
            player.chargingTime = 0;
        }
    }
}
