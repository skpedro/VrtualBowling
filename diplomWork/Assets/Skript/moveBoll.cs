using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBoll : MonoBehaviour
{
    [SerializeField] float speed;
    private Rigidbody rb;
    private Vector3 vector3 = Vector3.forward;
    private bool addSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (addSpeed)
            rb.AddForce(vector3 * speed, ForceMode.Impulse);
    }

     // ����� ����������� ��� �������� � ������ ��������, � �������� ���� ��������� � Rigidbody 
    private void OnCollisionEnter(Collision collision)
    {
       // ��� �������� � �������� � ����� "floor" �� ��������� ���������� � ���� � �������� �������� �����������  ���������� gameOn
       if (collision.gameObject.tag == "floor")
       {
           addSpeed = true;
          
       }
       // ��� �������� � �������� � ����� "wall" �� ��������� ���������� ����
       if (collision.gameObject.tag == "wall")
       {
            GameManager.gameOn = true;
            addSpeed = false;
            StartCoroutine(CorountineDestroy());
       }
       IEnumerator CorountineDestroy()
       {
           yield return new WaitForSeconds(3);
           Destroy(gameObject);
           StopCoroutine(CorountineDestroy());
       }
    }
}
