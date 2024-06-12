using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public  Slider hpBar;   //ü�� ��
    public TextMeshProUGUI stageText;   //�������� �ؽ�Ʈ
    public TextMeshProUGUI goldText;    //��� �ؽ�Ʈ
    public TextMeshProUGUI timerText;   //�ð��� �ؽ�Ʈ
    public TextMeshProUGUI messageText; //�޽��� �ؽ�Ʈ

    Player player;  //�÷��̾� ��ũ��Ʈ
    TimerUI timerUI;    //Ÿ�̸� ��ũ��Ʈ

    void Start()
    {
        timerUI = GetComponent<TimerUI>();  //Ÿ�̸� ��ũ��Ʈ ��������
        player = FindObjectOfType<Player>();   //�÷��̾� ��ũ��Ʈ ��������
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
        // ����ü���� ��üü������ �������� �ؽ�Ʈ�� ��ȯ�Ͽ� UI�� ǥ��
        hpBar.value = player.curHp / player.maxHp;
    }

    void UpdateStageText()
    {
        // �������� ���� �ؽ�Ʈ�� ��ȯ�Ͽ� UI�� ǥ��
        stageText.text = "Stage : " + GameManager._GameManager.stage;
    }

    void UpdateGoldText()
    {
        // ��� ���� �ؽ�Ʈ�� ��ȯ�Ͽ� UI�� ǥ��
        goldText.text = "Gold : " + player.gold;
    }

    void UpdateTimerText()
    {
        // Ÿ�̸� ���� �ؽ�Ʈ�� ��ȯ�Ͽ� UI�� ǥ��
        timerText.text = "Time : " + timerUI.timer.ToString("F2");
    }
    public void GameOver()
    {
        //���ӿ��� â�� ���
        messageText.text = "GameOver";
        messageText.gameObject.SetActive(true);
    }
}
