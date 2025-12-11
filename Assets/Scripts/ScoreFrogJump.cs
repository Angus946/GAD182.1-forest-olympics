using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreFrogJump : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("collider entered" + col.name);
        if (col.name == "lowScore")
        {
            Debug.Log("you got a low score :( ");
        }
    }
}
