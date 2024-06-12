using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bullet;   //총알
    public Transform pos;   //총알이 나가는 위치

    Player player;
    private PlayerInput playerInput;    //플레이어 인풋 스크립트

    private void Start()
    {
        //플레이어 인풋 스크립트를 받아옴
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
        //마우스 위치에 따라서 공격 방향을 정해줌
        Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);
    }
    void Attack()
    {
        bool isCharging = playerInput.InputCharging();
        bool isAttack = playerInput.InputAttack();

        //마우스를 누르면 공격차징이 됨
        if (isCharging)
        {
            if (player.chargingTime < player.fullCharingTime)
            {
                player.chargingTime += Time.deltaTime;
            }
        }
        //공격가능한 차징까지 차징하고 마우스를 올리면 총알이 생성되고 차징시간을 초기화함
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
