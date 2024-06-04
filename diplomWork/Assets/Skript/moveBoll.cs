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

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "floor")
            {
                addSpeed = true;
                GameManager.gameOn = true;
            }
        }
}
