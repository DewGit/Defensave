using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int stage = 0;   //���� ��������;

    Player player;  //�÷��̾� ��ũ��Ʈ
    UIManager uIManager;    //UIManager ��ũ��Ʈ
    PlayerInput playerInput;    //�÷��̾� ��ǲ ��ũ��Ʈ
    private void Start()
    {
        player = FindObjectOfType<Player>();    //�÷��̾� ��ũ��Ʈ ������
        uIManager = FindObjectOfType<UIManager>();  //UIManager ��ũ��Ʈ ������
        playerInput = player.gameObject.GetComponent<PlayerInput>(); //PlayerInput ��ũ��Ʈ ������ 
    }

    private void Update()
    {
        GameOver();
        End();
    }
    void GameOver()
    {
        //�÷��̾� hp�� 0�̵Ǹ� ��������
        if (player.curHp <= 0)
        {
            uIManager.GameOver();
            Time.timeScale = 0;
        }
    }

    void End()
    {
        //RŰ�� ������ �� ����� �� �ð� �۵�
        bool isRestart = playerInput.InputRestart();
        bool isEnd = playerInput.InputEnd();
        if (isRestart)
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }
        //escŰ�� ������ ����
        else if (isEnd)
            Application.Quit();
      
    }
    #region �̱���
    private static GameManager _gameManager;
    public static GameManager _GameManager
    {
        get
        {
            if (_gameManager == null)
            {
                // ���� GameManager�� ���� ��� ���� ����
                GameObject singleton = new GameObject(typeof(GameManager).ToString());
                _gameManager = singleton.AddComponent<GameManager>();
                DontDestroyOnLoad(singleton);
            }
            return _gameManager;
        }
    }

    private void Awake()
    {
        if (_gameManager == null)
        {
            _gameManager = this;
        }
        else if (_gameManager != this)
        {
            Destroy(gameObject);
        }
    }
}
#endregion


