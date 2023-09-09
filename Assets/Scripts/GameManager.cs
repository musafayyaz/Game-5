using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject titleScreen;
    public List<GameObject> targets;
    public bool isGameActive;
    private float spawnRate = 1f; 
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button reStartButton;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnTarget()
    { while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index=Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            
        } }
   public void ScoreUpdate(int scoreToAdd)
    { score += scoreToAdd;
        scoreText.text ="Sco " + score;
    }
    public void GameOver()
    {
        reStartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }
    public void Restart()
    { SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame(int difficulty)
    {

        isGameActive = true;
        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());
        score = 0;
        titleScreen.gameObject.SetActive(false);

    }

}
