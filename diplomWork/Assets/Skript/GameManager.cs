using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // ключ по которому ищется значение  
    private int key;
    public static int point;
    public static bool gameOn;
    [SerializeField] TextMeshProUGUI textpoint;
    public List<TextMeshProUGUI> textpointsAttempt = new List<TextMeshProUGUI>();

    private void Start()
    {
        point = 0;
        //PlayerPrefs.DeleteAll();
        key = PlayerPrefs.GetInt("key");

        for (int i = 0; i < 8; i++)
        {
            textpointsAttempt[i].text = textpointsAttempt[i].text + PlayerPrefs.GetInt($"point{i}");
        }

    }
    public void Update()
    {       
        textpoint.text= "point:" + point.ToString();       
    }

    public  void Restart()
    {
        // класс SceneManager отвечает за работу всех сцен в проекте, метод LoadScene загружает сцену по индексу.
        PlayerPrefs.SetInt($"point{key}", point);

        if (key > 7)
        {
            key = 0;
            PlayerPrefs.SetInt($"point{key}", point);
        }

        key++;

        PlayerPrefs.SetInt("key", key);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void DeleateData()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
