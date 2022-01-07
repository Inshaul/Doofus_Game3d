using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUpdater : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    private int score;
    public float waitTime = 3f;
    
    private void Start() {
        textMesh = GetComponent<TextMeshProUGUI>();
        score = 0;
    }

    private void Update()
    {
        textMesh.text = score.ToString();
        if (waitTime > 0) {
            waitTime -= 1 * Time.deltaTime;
        }
        else {
            score++;
            waitTime = 3f;
        }

    }
}
