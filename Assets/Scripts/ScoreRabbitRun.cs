using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreRabbitRun : MonoBehaviour
{

    [SerializeField] public bool playing;

    [SerializeField] TMP_Text Timer;
    [SerializeField] float PlayTime = 0;

    [SerializeField] private RabbitMovement movementScript;
    // Start is called before the first frame update
    void Start()
    {
        Timer.GetComponent<TMP_Text>();
        playing = true;
        movementScript = FindObjectOfType<RabbitMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            PlayTime = (PlayTime + Time.deltaTime);
        }
        Timer.text = "Time: " + PlayTime.ToString("F3") + " Seconds";

    }
}
