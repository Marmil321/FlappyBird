using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;

    public GameObject pipesPrefab;
    bool startGame = true;

    public Text startText;
    public Text scoreText;
    public Text bestScoreText;
    public Image showScoreImage;

    private void Start()
    {
        StartCoroutine(SpawnPiepes());

        Time.timeScale = 0;
    }

    private void Update()
    {

        scoreText.text = score.ToString();

        //Start The Game
        if (startGame && Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;
            startGame = false;

            startText.gameObject.SetActive(false);
        }

        //HighScore
        if (score > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", score);
        }
        
        bestScoreText.text = "Best: " + PlayerPrefs.GetInt("highscore").ToString();

    }

    IEnumerator SpawnPiepes()
    {
        yield return new WaitForSeconds(1.3f);
        GameObject pipes = Instantiate(pipesPrefab, new Vector2(11, Random.Range(4.75f, 7.75f)), Quaternion.identity);
        StartCoroutine(SpawnPiepes());

        yield return new WaitForSeconds(6f);
        Destroy(pipes);
        
    }

}
