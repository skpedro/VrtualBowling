using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBoll : MonoBehaviour
{
        [SerializeField] float speed;
        Rigidbody rb;
        Vector3 vector3 = Vector3.forward;
        bool addSpeed;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (addSpeed)
                rb.AddForce(vector3 * speed, ForceMode.Impulse);
        }

        // Метод срабатывает при коллизии с другим объектом, у которого есть коллайдер и Rigidbody 
        private void OnCollisionEnter(Collision collision)
        {
            // при коллизии с объектом с тегом "floor" мы добавляем скольжение к шару и передаем значение статической  переменной gameOn
            if (collision.gameObject.tag == "floor")
            {
                addSpeed = true;
                GameManager.gameOn = true;
            }
        // при коллизии с объектом с тегом "wall" мы выключаем скольжение шара
            if (collision.gameObject.tag == "wall")
            {
                 addSpeed = false;
            }
        }
}
