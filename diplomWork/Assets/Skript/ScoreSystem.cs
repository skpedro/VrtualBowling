using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    private int count = 10;
    Vector3 position = new Vector3(0.5f, 0.462f, -3.668f);
    private void Update()
    {
        if (GameManager.gameOn)
        {
            transform.Translate(Vector3.forward * 0.04f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "pin")
        {
            count--;          
        }

        if (other.gameObject.tag == "wall")
        {
            GameManager.gameOn = false;
            GameManager.point = count;
            gameObject.transform.position = position;
            count = 10;
        }
    } 
}
