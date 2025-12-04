using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aize
{
    public class CursorMovement : MonoBehaviour
    {
        public List<GameObject> targets = new List<GameObject>();

        Vector2 desiredVelocity = Vector2.zero;
        float walkSpeed = 3.5f;
        public bool movementLock = true;

        public Rigidbody2D rb;
        public GameObject playerBody;

        float breakTimer = 1;
        bool timerActive = false;
        public int score = 0;



        // Start is called before the first frame update
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }




        // Update is called once per frame
        void Update()
        {

            desiredVelocity.x = Input.GetAxisRaw("Horizontal");
            desiredVelocity.y = Input.GetAxisRaw("Vertical");


            desiredVelocity.Normalize();



            if (timerActive)
            {
                breakTimer -= Time.deltaTime;

                if (breakTimer < 0)
                {
                    timerActive = false;
                    BreakTargets();
                    breakTimer = 1;

                }
            }
        }

        void FixedUpdate()
        {
            if (movementLock == false)
            {
                Vector2 vel = transform.up * desiredVelocity.y + transform.right * desiredVelocity.x;


                rb.velocity = vel * walkSpeed;
            }
            else
            {
                Vector2 vel = transform.up * desiredVelocity.y + transform.right * desiredVelocity.x;


                rb.velocity = vel * 0;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.GetComponent<Target>() != null)
            {
                targets.Add(collision.gameObject);
                timerActive = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.transform.GetComponent<Target>() != null)
            {
                targets.Remove(collision.gameObject);

                if (targets.Count <= 0)
                {
                    timerActive = false;
                }

            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.GetComponent<Target>().breakReady == true)
            {
                targets.Remove(collision.gameObject);
                collision.GetComponent<Target>().TargetBreak();
            }
        }

        void BreakTargets()
        {

            foreach (var target in targets)
            {
                score += 1;
                Debug.Log(score);
                target.GetComponent<Target>().breakReady = true;
            }

            Debug.Log(timerActive);
        }
    }
}
