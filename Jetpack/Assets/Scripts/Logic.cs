using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Logic : MonoBehaviour
{
    public GameObject PlanetSpawner;
    public Player Player;
    public Text fuelLeft;
    public Text Score;
    public GameObject GameOverScreen;

    public int score = 0;
    public void IncreaseScore()
    {
        score++;
        Score.text = "Score: " + score.ToString();
    }

    public void DecreaseFuel()
    {
        Player.fuelLeft--;
        fuelLeft.text = "Fuel Left: " + Player.fuelLeft.ToString();
    }

    public void ResetFuel()
    {
        Player.fuelLeft = Player.maxFuel;
        fuelLeft.text = "Fuel Left: " + Player.fuelLeft.ToString();
    }

    public void GameOver()
    {
        GameOverScreen.SetActive(true);
        PlanetSpawner.SetActive(false);
        Destroy(Player.gameObject);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
