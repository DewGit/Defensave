using UnityEngine;
public class TimerUI : MonoBehaviour
{
    float resetTimer = 40;  //�ʱ�ȭ Ÿ�̸� ��
    public float timer; // ���� Ÿ�̸� ��
    void Start()
    {
        // Ÿ�̸� �ʱ�ȭ
        timer = resetTimer;
    }

    void Update()
    {
        Timer();
    }
    void Timer()
    {
        //���� �ð��� �پ��
        timer -= Time.deltaTime;
    }
    public void ResetTimer()
    {
        //Ÿ�̸Ӹ� 40��(ResetTimer)�� 
        timer = resetTimer;
    }
    public bool IsTimeUp()
    {
        //Ÿ�̸Ӱ� 0�������� Ȯ��
        return timer <= 0;
    }
}
