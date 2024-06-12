using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int stage = 0;   //현재 스테이지;

    Player player;  //플레이어 스크립트
    UIManager uIManager;    //UIManager 스크립트
    PlayerInput playerInput;    //플레이어 인풋 스크립트
    private void Start()
    {
        player = FindObjectOfType<Player>();    //플레이어 스크립트 가져옴
        uIManager = FindObjectOfType<UIManager>();  //UIManager 스크립트 가져옴
        playerInput = player.gameObject.GetComponent<PlayerInput>(); //PlayerInput 스크립트 가져옴 
    }

    private void Update()
    {
        GameOver();
        End();
    }
    void GameOver()
    {
        //플레이어 hp가 0이되면 게임종료
        if (player.curHp <= 0)
        {
            uIManager.GameOver();
            Time.timeScale = 0;
        }
    }

    void End()
    {
        //R키를 누르면 씬 재시작 후 시간 작동
        bool isRestart = playerInput.InputRestart();
        bool isEnd = playerInput.InputEnd();
        if (isRestart)
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }
        //esc키를 누르면 종료
        else if (isEnd)
            Application.Quit();
      
    }
    #region 싱글톤
    private static GameManager _gameManager;
    public static GameManager _GameManager
    {
        get
        {
            if (_gameManager == null)
            {
                // 씬에 GameManager가 없을 경우 새로 생성
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


