using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


// 구독하는 사람


public class ScoreText : MonoBehaviour
{
    private TextMeshProUGUI _ui;

    public void Awake()
    {
        _ui = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        // 구독자 추가
        GameManager.Instance.OnScoreChange.AddListener(UpdateText);


        //GameManager.Instance.OnScoreChanged2 += UpdateText; // 구독 추가
    }

    public void UpdateText(int score)
    {
        _ui.text = $"Score : {score}";
    }

    private void OnDisable()
    {
        // 구독자 제거
        GameManager.Instance.OnScoreChange.RemoveListener(UpdateText);

        //GameManager.Instance.OnScoreChanged2 -= UpdateText; // 구독 해제
    }

}
