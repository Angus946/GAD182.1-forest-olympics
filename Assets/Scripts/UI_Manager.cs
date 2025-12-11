using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject endPanel;
    public Vulture vulture;

    private bool gameStarted = false;

    void Awake()
    {
        Time.timeScale = 0f;  // Pause the game before starting
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If the game hasn’t started yet, wait for “E”
        if (!gameStarted && Input.GetKeyDown(KeyCode.E))
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1f;   // Unpause the game
        gameStarted = true;    // Mark the game as started
       // vulture.EnableFlight(); // Enable vulture movement
        startPanel.SetActive(false); // Hide start menu
    }

    public void ShowEndPanel(float distance)
    {
        Time.timeScale = 0f;   // Pause game when finished
        endPanel.SetActive(true);
        endPanel.GetComponentInChildren<TextMeshProUGUI>().text =
            $"You glided {distance:F1} metres! Press R to retry.";
    }
}
