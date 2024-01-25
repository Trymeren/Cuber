using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private float startDelay;
    private float delay = 3;
    public bool gameOver = false;
    public int score = 0;

    //ENCAPSULATION
    public float timer { get; protected set;}


    void Start()
    {
        // ABSTRACTION
        StartCoroutine(SpawnObstacle());
        StartCoroutine(UpdateScore());
    }

    void Update()
    {
        //Check if the buttons are supposed to be active
        if(!gameOver)
        {
            restartButton.SetActive(false);
        }
        else
        {
            restartButton.SetActive(true);
        }

        //Increase spawnrate based on score
        delay = startDelay / (1 + (float)score / 100) + Random.Range(-0.5f, 0.5f);


        timer += Time.deltaTime;
    }

    IEnumerator UpdateScore()
    {
        yield return new WaitForSeconds(1);
        score++;
        scoreText.text = "Score: " + score.ToString();
        if(!gameOver)
        {
            StartCoroutine(UpdateScore());
        }
    }

    IEnumerator SpawnObstacle()
    {
        int index = Random.Range(0,obstaclePrefabs.Length);
        Vector3 spawnPos = new Vector3(14, 0.5f, 0);
        Instantiate(obstaclePrefabs[index], spawnPos, obstaclePrefabs[index].transform.rotation);
        yield return new WaitForSeconds(delay);
        if(!gameOver)
        {
            StartCoroutine(SpawnObstacle());
        }
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
