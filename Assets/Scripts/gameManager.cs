using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreDisplay;

    public int maxLives;
    private int lives;
    public float safetyRadius;

    public TextMeshProUGUI liveDisplay;
    public GameObject GameOverDisplay;
    public Vector3 spawnPoint = Vector3.zero;
    public GameObject shipPrefab;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore();
        lives = maxLives;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore()
    {
        scoreDisplay.text = $"Score: {score}";
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScore();
    }

    public void Updatelives()
    {
        liveDisplay.text = $"Lives: {lives}";
    }

    public void LoseLife()
    {
        lives--;
        Updatelives();
    }

    IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(1);

        GameObject[] Asteriods = GameObject.FindGameObjectsWithTag("Asteroid");
        bool canSpawn = false;

        while (!canSpawn)
        {
            canSpawn = true;
            foreach(GameObject Asteroid in Asteriods)
            {
                if ((Asteroid.transform.position - spawnPoint).magnitude < safetyRadius)
                {
                    canSpawn = false;
                    yield return new WaitForEndOfFrame();
                }
            }
        }

        Instantiate(shipPrefab, spawnPoint, shipPrefab.transform.rotation);
    }

    public void GameOver()
    {
        GameOverDisplay.SetActive(true);
    }

    public void PlayerDie()
    {
        LoseLife();
        if (lives < 0)
        {
            GameOver();
        }
        else
        {
          StartCoroutine(RespawnPlayer());
        }
        
    }
}
