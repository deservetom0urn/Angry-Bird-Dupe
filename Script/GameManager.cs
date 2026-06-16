using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int enemyCount = 0;
    public GameObject[] birds;
    public int currentBird = 0;
    public Text birdleft;
    public AudioSource enemyhit;

    public GameObject victoryUI;
    public GameObject gameOverUI;
    // Start is called before the first frame update
    void Start()
    {
        enemyCount = FindObjectsOfType<EnemyScript>().Length;
        currentBird = 0;
        foreach (GameObject bird in birds)
        {
            bird.SetActive(false);
        }
        birds[currentBird].SetActive(true);
        birdleft.text="Birds left: " + (birds.Length-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextBird()
    {
        if (currentBird < birds.Length-1)
        {
            currentBird++;
            birds[currentBird].SetActive(true);

            birdleft.text = "Birds Left: " + ((birds.Length-currentBird)-1);
        }
        else
        {
            if (enemyCount > 0)
                gameOverUI.SetActive(true);
                Debug.Log("Game Over!");
        }
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GotoMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void GoToLevelOne()
    {
        SceneManager.LoadScene("LevelOneScene");
    }

    public void GoToLevelTwo()
    {
        SceneManager.LoadScene("LevelTwoScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void EnemyDie()
    {
        enemyCount--;
        enemyhit.Play();
        if (enemyCount<=0)
        {
            victoryUI.SetActive(true);
        }
    }
}
