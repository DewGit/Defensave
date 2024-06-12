using UnityEngine;

public class Player :MonoBehaviour
{
    public float maxHp = 100;   //플레이어 최대체력
    public float curHp = 100;   //플레이어 현재체력
    public int gold;    //플레이어 골드량
    public bool isCenter = true;    //플레이어가 중간에 있는 지 유무
    public float dmg = 10;   //플레이어 데미지
    public float chargingTime;  //현재 차징정도 
    public float fullCharingTime = 2f;    //공격 가능한 차징 정도
    public int bonus = 1; //골드획득량
    public float speed = 8f;   //이동속도

}
