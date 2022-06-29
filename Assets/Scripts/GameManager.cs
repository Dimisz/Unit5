using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> prefabs;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    private int score;

    public bool isGameActive;
    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            float randomSpawnDelay = Random.Range(1.0f, 3.0f);
            yield return new WaitForSeconds(randomSpawnDelay);
            int randomTargetIndex = Random.Range(0, prefabs.Count);
            Instantiate(prefabs[randomTargetIndex]);
        }
    }


    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }


    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }
}
