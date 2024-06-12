using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable/EnemyData", fileName = "EnemyData")]
public class EnemyData : ScriptableObject
{
    public float hp = 100;    //ü��
    public float dmg = 5;   //������
    public float speed = 3;     //���ǵ�
    public Vector3 size;  //ũ��
    public Color color; //��
}