using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aize
{
    public class Target : MonoBehaviour
    {
        public bool breakReady = false;

        float speed;
        float deviateY;

        bool dropping = false;
        float dropTimer;
        bool dropTimerActive = true;

        float autoBreakTimer = 5;
        bool autoBreakTimerActive = false;

        [SerializeField]
        Rigidbody2D rb;

        // Start is called before the first frame update
        void Start()
        {

        }

        private void OnEnable()
        {
            Debug.Log("Spawned");
            speed = Random.Range(2, 6);
            deviateY = Random.Range(1, 1.3f);
            dropTimer = 8 - speed;
        }

        // Update is called once per frame
        void Update()
        {
            if (dropping)
            {
                deviateY -= 0.01f;
                Vector2 vel = transform.up * deviateY + transform.right * speed;
                rb.velocity = vel;
            }
            else
            {
                Vector2 vel = transform.up * deviateY + transform.right * speed;
                rb.velocity = vel;
            }

            if (dropTimerActive)
            {
                dropTimer -= Time.deltaTime;

                if (dropTimer < 0)
                {
                    dropTimer = 0;
                    dropTimerActive = false;
                    dropping = true;
                    autoBreakTimerActive = true;
                }
            }

            if (autoBreakTimerActive)
            {
                autoBreakTimer -= Time.deltaTime;

                if (autoBreakTimer < 0)
                {
                    autoBreakTimer = 0;
                    TargetBreak();
                }
            }
        }



        public void TargetBreak()
        {
            Destroy(gameObject);

        }
    }
}