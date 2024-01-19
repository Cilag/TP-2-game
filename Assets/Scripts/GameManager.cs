using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public float currentScore = 0f;
    public float speed = 1f; // Add the speed variable here

    public bool isPlaying = false;

    public UnityEvent onPlay = new UnityEvent();

    public UnityEvent onGameOver = new UnityEvent();

    private void Update()
    {
        if (isPlaying)
        {
            UpdateSpeed(); // Call the method to update speed
            currentScore += Time.deltaTime;
        }

        if (Input.GetKeyDown("k"))
        {
            isPlaying = true;
        }
    }

    private void UpdateSpeed()
    {
        speed = 1f + currentScore * 0.1f; // Update the speed based on the current score
    }

    public void StartGame()
    {
        onPlay.Invoke();
        isPlaying = true;
    }

    public void GameOver()
    {
        onGameOver.Invoke();
        currentScore = 0;
        isPlaying = false;
    }

    public string PrettyScore()
    {
        return Mathf.RoundToInt(currentScore).ToString();
    }

    public void AddScore(float points)
    {
        currentScore += points;
    }
}
