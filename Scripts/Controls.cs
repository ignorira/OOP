using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public float speed = 0f; //��������
    public float maxSpeed = 0.5f; //������������ ��������
    public float sideSpeed = 0f; //������� ��������

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveSide = Input.GetAxis("Horizontal"); //����� ����� ����� �������� �� ��������� ����� ��� ������, ���� ����� ����������� 1f ��� -1f
        float moveForward = Input.GetAxis("Vertical"); //�� �� �����, �� �� ����������� ����� � ����

        if (moveSide != 0)
        {
            sideSpeed = moveSide * -1f; //���� ����� ����� �� ��������� ����� ��� ������, ����� ������� ��������
        }

        if (moveForward != 0)
        {
            speed += 0.01f * moveForward; //���� ����� ����� ����� ��� ����
        }
        else //���� ����� �� ����� �� �����, �� ����, �� �������� ����� ���������� ������������ � ����
        {
            if (speed > 0)
            {
                speed -= 0.01f;
            }
            else
            {
                speed += 0.01f;
            }
        }

        if (speed > maxSpeed)
        {
            speed = maxSpeed; //�������� �� ���������� ������������ ��������
        }
    }
}
