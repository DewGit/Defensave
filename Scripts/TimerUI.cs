using UnityEngine;
public class TimerUI : MonoBehaviour
{
    float resetTimer = 40;  //초기화 타이머 값
    public float timer; // 현재 타이머 값
    void Start()
    {
        // 타이머 초기화
        timer = resetTimer;
    }

    void Update()
    {
        Timer();
    }
    void Timer()
    {
        //매초 시간이 줄어듬
        timer -= Time.deltaTime;
    }
    public void ResetTimer()
    {
        //타이머를 40초(ResetTimer)로 
        timer = resetTimer;
    }
    public bool IsTimeUp()
    {
        //타이머가 0이하인지 확인
        return timer <= 0;
    }
}
