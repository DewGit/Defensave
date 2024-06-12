using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public List<EnemyData> enemydatas;  // ��ũ���ͺ� �� �����͸� ������
    public GameObject enemyPrefab;  // �� �������� ������
    public Transform[] enemySpawnPositions; // �� ���� ��ġ�� ������
    private TimerUI timerUI; // TimerUI��ũ��Ʈ

    private void Start()
    {      
        timerUI = FindObjectOfType<TimerUI>();  // TimerUI ��ũ��Ʈ�� ã�Ƽ� ������
        StartCoroutine(PeriodSpawnEnemy()); //PeriodSpawnEnemy �ڷ�ƾ ����
    }
    private IEnumerator PeriodSpawnEnemy()
    {
        //�������� ���� �� enemySpawn�� ���� ���� �� ��ȯ �� �ð� �ʱ�ȭ
        while (true)
        {
            yield return new WaitForSeconds(1f); // 1�ʸ��� üũ
            if (timerUI.IsTimeUp())
            {
                GameManager._GameManager.stage++;    //�������� ����

                //enemySpawn�� ���� ���� �� ��ȯ �� �ð� �ʱ�ȭ
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
        // ���� ���� ������ ������ �� �� ��ȯ �� ��ũ���ͺ� �� ������ ����
        var enemySpawnPos = enemySpawnPositions[Random.Range(0, enemySpawnPositions.Length)];
        var newEnemy = Instantiate(enemyPrefab, enemySpawnPos.position, Quaternion.identity).GetComponent<Enemy>();

        newEnemy.enemyData = enemydatas[Random.Range(0, enemydatas.Count)];
    }
}
