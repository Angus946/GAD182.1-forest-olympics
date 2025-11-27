using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Aize
{
    public class Spawner : MonoBehaviour
    {
        public GameObject target;
        public GameObject spawner;


        float cooldownTimer;
        bool cooldownTimerActive = false;

        public bool gameStarted = false;

        Vector2 selfPos;

        // Start is called before the first frame update
        void Start()
        {
            selfPos = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (gameStarted == true)
            {
                if (cooldownTimerActive)
                {
                    cooldownTimer -= Time.deltaTime;

                    if (cooldownTimer < 0)
                    {
                        cooldownTimer = 0;
                        cooldownTimerActive = false;
                        Debug.Log("fire");
                        spawnTarget();
                    }
                }

                else
                {
                    cooldownTimer = Random.Range(1, 5);
                    Debug.Log("reload takes " + cooldownTimer);
                    cooldownTimerActive = true;
                }
            }
        }

        void spawnTarget()
        {
            GameObject newTarget = Instantiate(target, spawner.transform.position, spawner.transform.rotation);
        }
    }
}