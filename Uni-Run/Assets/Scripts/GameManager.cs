using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : SingletonBehaviour<GameManager>
{
    public int ScoreIncreaseAmount = 1;

    private bool _isEnd = false;
    private int _currentScore = -1;

    public UnityEvent OnGameEnd = new UnityEvent(); // void ()
    //public event UnityAction OnGameEnd2;

    public UnityEvent<int> OnScoreChange = new UnityEvent<int>(); // void (int)
    //public event UnityAction<int> OnScoreChanged2;

    public int CurrentScore
    {
        get
        {
            return _currentScore;
        }
        set
        {
            _currentScore = value;
            OnScoreChange.Invoke(_currentScore);
            //OnScoreChanged2?.Invoke(_currentScore); // 구독자가 있니?
        }
    }
    private void Update()
    {
        if (_isEnd && Input.GetKeyDown(KeyCode.R))
        {
            Reset();
            SceneManager.LoadScene(0);
        }
    }
    public void AddScore()
    {
        CurrentScore += ScoreIncreaseAmount;
    }

    public void End()
    {
        _isEnd = true;
        OnGameEnd.Invoke();
        //OnGameEnd2?.Invoke();
    }
    private void Reset()
    {
        _currentScore = 0;
        _isEnd = false;
    }
}