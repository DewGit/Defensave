using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float InputMove()
    {
        //좌우 움직임(a, d)을 입력받아주는 메소드
        return Input.GetAxis("Horizontal");
    }

    public bool InputJump()
    {
        //점프(space)를 입력받아주는 메소드
        return Input.GetKeyDown(KeyCode.Space); ;
    }

    public bool InputCharging()
    {
        //마우스 차징(좌클릭 유지)을 입력받아주는 메소드
        return Input.GetKey(KeyCode.Mouse0);
    }
    public bool InputAttack()
    {
        //공격(좌클릭 업)을 입력받아주는 메소드
        return Input.GetKeyUp(KeyCode.Mouse0);
    }

    public bool InputRestart()
    {
        //재시작(R)을 입력받아주는 메소드
        return Input.GetKeyDown(KeyCode.R); ;
    }
    
    public bool InputEnd()
    {
        //종료(esc)를 입력받아주는 메소드
        return Input.GetKeyUp(KeyCode.Escape);
    }
}
