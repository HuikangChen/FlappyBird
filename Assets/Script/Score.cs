using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //Gives us access to TextMeshPro components

public class Score : MonoBehaviour {

    public static Score instance; //Our singleton

    public TextMeshProUGUI scoreText;

    [HideInInspector]
    public int score;
    [HideInInspector]
    public int highScore;

    /// <summary>
    /// A typical Singleton pattern initialization, always do it in the Awake function
    /// </summary>
    void Awake()
    {
        //First we check if there are multiple instances of this gameobject/component, if there is then destroy this gameobject
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this; //Then we set our singleton to this instance
        }

        Kill.onKill += OnDeath;
    }

    void Start()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt("HighScore", 0); //Loads the highscore from the saved key of "HighScore" into our highScore variable
        UpdateUI();
    }

    public void AddScore(int amount) 
    {
        score += amount;
        UpdateUI();
    }

    public int HighScore //Use this to access the high score int
    {
        get
        {
            return highScore;
        }
    }

    void UpdateUI()
    {
        scoreText.text = score + "";
    }

    void OnDeath()
    {
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score); //Saves the high score into our "HighScore" key 
        }
    }

    void OnDestroy()
    {
        Kill.onKill -= OnDeath; //Unsubscribe when gameobject is destroyed
    }
}
