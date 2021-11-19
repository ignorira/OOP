using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject car; //Модель машины

    public GameObject brokenPrefab; //Префаб сломанной машины
    public GameObject modelHolder; //Объект, в который помещается модель

    public Controls control; //Скрипт управления

    private float speed = 0f; //Скорость на старте

    private float maxSpeed = 0.5f; //Максимальная скорость
    private float minSpeed = 0f; //Минимальная скорость

    private bool isAlive = true; //Жива ли машина. Если да, то она будет двигаться
    private bool isKilled = false; //Эта переменная нужна, чтобы триггер сработал только один раз

    public List<GameObject> wheels; //Колёса машины

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
            float newSpeed = speed; //Скорость движения вперёд
            float sideSpeed = 0f; //Скорость движения вбок

            if (newSpeed > maxSpeed)
            {
                newSpeed = maxSpeed; //Проверка на превышение максимальной скорости
            }

            if (newSpeed < minSpeed)
            {
                newSpeed = minSpeed; //Проверка на слишком низкую скорость
            }

            //Изменение положения машины - она двигается вперёд
            //Для этого к её положению по оси X прибавляется новая скорость, положение по Y остаётся прежним
            //К положение по оси Z прибавляется 0.1f, умноженная на боковую скорость 
            transform.position = new Vector3(transform.position.x + newSpeed, transform.position.y, transform.position.z + 0.1f * sideSpeed);

            if (control != null)
            {
                control.sideSpeed = 0f; //Сброс боковой скорости
            }

            if (wheels.Count > 0) //Если есть колёса
            {
                foreach (var wheel in wheels)
                {
                    wheel.transform.Rotate(-3f, 0f, 0f); //Вращение каждого колеса по оси X
                }
            }

            if (tag == "Car")
            {
                if (transform.position.y < -50f)
                {
                    Destroy(gameObject); //Если это машина NPC, то она будет удаляться со сцены, если упадёт ниже -50f
                }
            }
        }
    }
}
