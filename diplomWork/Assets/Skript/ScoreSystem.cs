using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    int count = 10;
    bool stay;

    private void Update()
    {
        if (!stay && GameManager.gameOn)
        {
            transform.Translate(Vector3.forward * 0.02f);
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
            stay = true;
            GameManager.point = count;
        }
    } 
}
