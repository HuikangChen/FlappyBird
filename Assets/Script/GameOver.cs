using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Gives us access to load scenes/levels

public class GameOver : MonoBehaviour {

    public GameObject gameOver; //the GameOver gameobject under the Canvas gameobject
    public string gameSceneName; //the name of our game scene

    void Awake()
    {
        Kill.onKill += OnGameOver; //Subscibes OnGameOver to the onKill event
    }

    void OnGameOver()
    {
        gameOver.SetActive(true); // sets the active state of the gameOver panel to true
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(gameSceneName); //Loads the game scene again
    }


    void OnDestroy()
    {
        Kill.onKill -= OnGameOver; //Unsubscribe when gameobject is destroyed
    }
}
