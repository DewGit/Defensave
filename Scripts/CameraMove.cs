using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMove : MonoBehaviour
{
    public GameObject target;   //카메라가 따라다닐 대상
    public float speed; //카메라 속도

    void Update()
    { 
        //카메라가 target(대상)을 서서히 따라감
        transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * speed);
        //2D에서는 카메라의 z값이 -10f이기 때문에 바뀌지 않도록 고정
        transform.position = new Vector3(transform.position.x, 0, -10f);
    }
}
