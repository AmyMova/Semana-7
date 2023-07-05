using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject gameOver;

    [SerializeField]
    TextMeshProUGUI scoreText;

    [SerializeField]
    TextMeshProUGUI recordText;

    SpawnManager _spawnManager;
    int _enemiesKilled;

    private void Awake()
    {
        _spawnManager = SpawnManager.Instance;

        _spawnManager.SetIsSpawning(true);
    }

    IEnumerator GameOverCoroutine()
    {
        Character2DController player = FindObjectOfType<Character2DController>();

        player.gameObject.SetActive(false);

        SpawnManager.Instance.SetIsSpawning(false);

        gameOver.SetActive(true);

        scoreText.text = string.Format(scoreText.text, _enemiesKilled);

        int enemiesKilled = PlayerPrefs.GetInt("Enemies_Killed", 0);
        if (_enemiesKilled > enemiesKilled)
        {
            PlayerPrefs.SetInt("Enemies_Killed", _enemiesKilled);
            recordText.gameObject.SetActive(true);
        }

        yield return new WaitForSeconds(4);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GameOver()
    {

        StartCoroutine(GameOverCoroutine());
    }

    public void IncreaseEnemiesKilled()
    {
        _enemiesKilled++;
    }
}
