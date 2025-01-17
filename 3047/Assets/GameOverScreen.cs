using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private float _score = 0;

    private void Start()
    {
        _scoreText.text = "Score: " + GameManager.instance.currentScore;
    }
}
