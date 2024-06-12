using UnityEngine;
using UnityEngine.UI;
public class Charging : MonoBehaviour
{
    private Image chargingBar;  //차징 바 
    private float maxCharging;  //최대 차징량
    private float curCharging;  //현재 차징량

    Player player;//플레이어 스크립트
    private void Awake()
    {
        chargingBar = GetComponentInChildren<Image>();  //차징바 이미지 가져오기
        curCharging = 0;    //현재 차징량 초기화
    }
    private void Start()
    {
        //플레이어 스크립트 가져오기
        player = FindObjectOfType<Player>();

    }
    void Update()
    {
        ShowCharging();
        ChargingColor();
    }

    void ShowCharging()
    {
        //공격 차징 양의 따라서 UI표시
        curCharging = player.chargingTime;
        maxCharging = player.fullCharingTime;
        chargingBar.fillAmount = curCharging / maxCharging;
    }
    void ChargingColor()
    {
        //공격이 완료되면 초록색 그렇지 않으면 빨간색으로 변화
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
