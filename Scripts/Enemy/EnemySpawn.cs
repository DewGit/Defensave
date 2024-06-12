using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public List<EnemyData> enemydatas;  // 스크립터블 적 데이터를 가져옴
    public GameObject enemyPrefab;  // 적 프리펩을 가져옴
    public Transform[] enemySpawnPositions; // 적 스폰 위치를 가져옴
    private TimerUI timerUI; // TimerUI스크립트

    private void Start()
    {      
        timerUI = FindObjectOfType<TimerUI>();  // TimerUI 스크립트를 찾아서 가져옴
        StartCoroutine(PeriodSpawnEnemy()); //PeriodSpawnEnemy 코루틴 실행
    }
    private IEnumerator PeriodSpawnEnemy()
    {
        //스테이지 증가 후 enemySpawn의 수에 따라서 적 소환 후 시간 초기화
        while (true)
        {
            yield return new WaitForSeconds(1f); // 1초마다 체크
            if (timerUI.IsTimeUp())
            {
                GameManager._GameManager.stage++;    //스테이지 증가

                //enemySpawn의 수에 따라서 적 소환 후 시간 초기화
                for (int i = 0; i < GameManager._GameManager.stage; i++)
                {
                    CreateEnemy();  
                }
                timerUI.ResetTimer();
            }
        }
    }

    public void CreateEnemy()
    {
        // 적의 스폰 지점을 정해준 후 적 소환 후 스크립터블 적 데이터 적용
        var enemySpawnPos = enemySpawnPositions[Random.Range(0, enemySpawnPositions.Length)];
        var newEnemy = Instantiate(enemyPrefab, enemySpawnPos.position, Quaternion.identity).GetComponent<Enemy>();

        newEnemy.enemyData = enemydatas[Random.Range(0, enemydatas.Count)];
    }
}
