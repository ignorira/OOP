using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject car; //������ ������

    public GameObject brokenPrefab; //������ ��������� ������
    public GameObject modelHolder; //������, � ������� ���������� ������

    public Controls control; //������ ����������

    private float speed = 0f; //�������� �� ������

    private float maxSpeed = 0.5f; //������������ ��������
    private float minSpeed = 0f; //����������� ��������

    private bool isAlive = true; //���� �� ������. ���� ��, �� ��� ����� ���������
    private bool isKilled = false; //��� ���������� �����, ����� ������� �������� ������ ���� ���

    public List<GameObject> wheels; //����� ������

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            float newSpeed = speed; //�������� �������� �����
            float sideSpeed = 0f; //�������� �������� ����

            if (newSpeed > maxSpeed)
            {
                newSpeed = maxSpeed; //�������� �� ���������� ������������ ��������
            }

            if (newSpeed < minSpeed)
            {
                newSpeed = minSpeed; //�������� �� ������� ������ ��������
            }

            //��������� ��������� ������ - ��� ��������� �����
            //��� ����� � � ��������� �� ��� X ������������ ����� ��������, ��������� �� Y ������� �������
            //� ��������� �� ��� Z ������������ 0.1f, ���������� �� ������� �������� 
            transform.position = new Vector3(transform.position.x + newSpeed, transform.position.y, transform.position.z + 0.1f * sideSpeed);

            if (control != null)
            {
                control.sideSpeed = 0f; //����� ������� ��������
            }

            if (wheels.Count > 0) //���� ���� �����
            {
                foreach (var wheel in wheels)
                {
                    wheel.transform.Rotate(-3f, 0f, 0f); //�������� ������� ������ �� ��� X
                }
            }

            if (tag == "Car")
            {
                if (transform.position.y < -50f)
                {
                    Destroy(gameObject); //���� ��� ������ NPC, �� ��� ����� ��������� �� �����, ���� ����� ���� -50f
                }
            }
        }
    }
}
