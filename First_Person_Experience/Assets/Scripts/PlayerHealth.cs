using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float health;
    public Slider healthSlider;



    void Start()
    {
        healthSlider.maxValue = health;
    }


    void Update()
    {
        healthSlider.value = health;
        if(health <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
