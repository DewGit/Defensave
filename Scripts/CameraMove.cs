using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMove : MonoBehaviour
{
    public GameObject target;   //ī�޶� ����ٴ� ���
    public float speed; //ī�޶� �ӵ�

    void Update()
    { 
        //ī�޶� target(���)�� ������ ����
        transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * speed);
        //2D������ ī�޶��� z���� -10f�̱� ������ �ٲ��� �ʵ��� ����
        transform.position = new Vector3(transform.position.x, 0, -10f);
    }
}
