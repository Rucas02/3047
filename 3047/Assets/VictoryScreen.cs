using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private float _score = 0;

    private void Start()
    {
        _scoreText.text = "Score: " + GameManager.instance.currentScore;
    }
}
