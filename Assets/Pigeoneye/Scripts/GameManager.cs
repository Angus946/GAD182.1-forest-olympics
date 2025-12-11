using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aize
{
    public class GameManager : MonoBehaviour
    {
        public GameObject player;

        public GameObject spawner;

        [SerializeField]
        float gameTimer = 60;
        bool gameTimerActive = false;

        float startTimer = 3;
        bool startTimerActive = false;

        // Start is called before the first frame update
        void Start()
        {
            startTimerActive = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (startTimerActive)
            {
                startTimer -= Time.deltaTime;

                if (startTimer < 0)
                {
                    startTimerActive = false;
                    startTimer = 0;
                    Debug.Log("gamestart");
                    spawner.GetComponent<Spawner>().gameStarted = true;
                    player.GetComponent<CursorMovement>().movementLock = false;
                    gameTimerActive = true;
                }
            }

            if (gameTimerActive)
            {
                gameTimer -= Time.deltaTime;

                if (gameTimer < 0)
                {
                    gameTimerActive = false;
                    gameTimer = 0;
                    spawner.GetComponent<Spawner>().gameStarted = false;
                    player.GetComponent<CursorMovement>().movementLock = true;
                    Debug.Log("Game over! You got a score of " + player.GetComponent<CursorMovement>().score);
                }
            }
        }
    }
}