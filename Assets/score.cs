using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentScoreText;
    public static Score instance;

    private int _score;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        _currentScoreText.text = _score.ToString();
    }
    // Update is called once per frame
    public void UpdateScore()
           {
             _score++;
             _currentScoreText.text = _score.ToString();
           }
}
