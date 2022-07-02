using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> prefabs;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    

    private int score;

    public bool isGameActive;
    // Start is called before the first frame update
    void Start()
    {
        //StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        //Debug.Log("INSIDE COROOUTINE");
        while (isGameActive)
        {
            //Debug.Log("INSIDE WHILLE");
            float randomSpawnDelay = Random.Range(1.0f, 3.0f);
            //Debug.Log("randomSpawnDelay declared: " + randomSpawnDelay);
            yield return new WaitForSeconds(randomSpawnDelay);
            //Debug.Log("Waited for seconds");
            int randomTargetIndex = Random.Range(0, prefabs.Count);
            Instantiate(prefabs[randomTargetIndex]);
            //Debug.Log("END OF WHILE");
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
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        //Debug.Log("Inside StartGame function");
        isGameActive = true;
        //Debug.Log("isGameActive set to: " + isGameActive);
        score = 0;
        //Debug.Log("score set to: " + score);
        StartCoroutine(SpawnTarget());
        //Debug.Log("StartCoroutine called");
        
        UpdateScore(0);
        //Debug.Log("Update Score called");
        //Debug.Log("isGameActive set to: " + isGameActive);
    }
}
