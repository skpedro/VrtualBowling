using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int point;
    public static bool gameOn;
    [SerializeField] TextMeshProUGUI textpoint;
    public void Update()
    {
        textpoint.text= "point:" + point.ToString();       
    }

    public static void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // сохранение данных 
}
