using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float InputMove()
    {
        //�¿� ������(a, d)�� �Է¹޾��ִ� �޼ҵ�
        return Input.GetAxis("Horizontal");
    }

    public bool InputJump()
    {
        //����(space)�� �Է¹޾��ִ� �޼ҵ�
        return Input.GetKeyDown(KeyCode.Space); ;
    }

    public bool InputCharging()
    {
        //���콺 ��¡(��Ŭ�� ����)�� �Է¹޾��ִ� �޼ҵ�
        return Input.GetKey(KeyCode.Mouse0);
    }
    public bool InputAttack()
    {
        //����(��Ŭ�� ��)�� �Է¹޾��ִ� �޼ҵ�
        return Input.GetKeyUp(KeyCode.Mouse0);
    }

    public bool InputRestart()
    {
        //�����(R)�� �Է¹޾��ִ� �޼ҵ�
        return Input.GetKeyDown(KeyCode.R); ;
    }
    
    public bool InputEnd()
    {
        //����(esc)�� �Է¹޾��ִ� �޼ҵ�
        return Input.GetKeyUp(KeyCode.Escape);
    }
}
