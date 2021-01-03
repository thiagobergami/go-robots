using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    int _player1;
    int _player2;

    static int _highScore;
    static ScoreSystem _instance;

    [SerializeField] TMP_Text _playe1text;
    [SerializeField] TMP_Text _player2text;
    [SerializeField] TMP_Text _highScoreText;

    void Awake() => _instance = this;

    public void ResetHighScore() 
    {
        _highScore = 0;
        PlayerPrefs.SetInt("HighScore", _highScore);
    }

    private void OnEnable()
    {
        _highScore = PlayerPrefs.GetInt("HighScore");
        UpdateText();
        
    }
    void UpdateText()
    {
        _playe1text.SetText(_player1.ToString());
        _player2text.SetText(_player2.ToString());
        _highScoreText.SetText(_highScore.ToString());
    }
    public static void Add(int points, int playerNumber)
    {
        _instance.AddPoints(points, playerNumber);
    }

     void AddPoints(int points, int playerNumber)
    {
        if (playerNumber == 1)
        {
            _player1 += points;
            if (_player1 >= _highScore)
                _highScore = _player1;
                PlayerPrefs.SetInt("HighScore", _highScore);
        }
        else 
        {
            _player2 += points;
            if (_player2 >= _highScore)
                _highScore = _player2;
                PlayerPrefs.SetInt("HighScore", _highScore);
        }
           

        UpdateText();
    }

}
