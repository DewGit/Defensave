using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public  Slider hpBar;   //체력 바
    public TextMeshProUGUI stageText;   //스테이지 텍스트
    public TextMeshProUGUI goldText;    //골드 텍스트
    public TextMeshProUGUI timerText;   //시간초 텍스트
    public TextMeshProUGUI messageText; //메시지 텍스트

    Player player;  //플레이어 스크립트
    TimerUI timerUI;    //타이머 스크립트

    void Start()
    {
        timerUI = GetComponent<TimerUI>();  //타이머 스크립트 가져오기
        player = FindObjectOfType<Player>();   //플레이어 스크립트 가져오기
    }

    private void Update()
    {
        UpdateHpBar();
        UpdateStageText();
        UpdateGoldText();
        UpdateTimerText();
    }

    void UpdateHpBar()
    {
        // 현재체력을 전체체력으로 나눈값을 텍스트로 변환하여 UI에 표시
        hpBar.value = player.curHp / player.maxHp;
    }

    void UpdateStageText()
    {
        // 스테이지 값을 텍스트로 변환하여 UI에 표시
        stageText.text = "Stage : " + GameManager._GameManager.stage;
    }

    void UpdateGoldText()
    {
        // 골드 값을 텍스트로 변환하여 UI에 표시
        goldText.text = "Gold : " + player.gold;
    }

    void UpdateTimerText()
    {
        // 타이머 값을 텍스트로 변환하여 UI에 표시
        timerText.text = "Time : " + timerUI.timer.ToString("F2");
    }
    public void GameOver()
    {
        //게임오버 창을 띄움
        messageText.text = "GameOver";
        messageText.gameObject.SetActive(true);
    }
}
