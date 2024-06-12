using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable/EnemyData", fileName = "EnemyData")]
public class EnemyData : ScriptableObject
{
    public float hp = 100;    //체력
    public float dmg = 5;   //데미지
    public float speed = 3;     //스피드
    public Vector3 size;  //크기
    public Color color; //색
}