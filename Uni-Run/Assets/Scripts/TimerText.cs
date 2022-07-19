using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerText : MonoBehaviour
{
    public float SurvivalTime { get; set; }
    public bool IsOn { get; set; }

    private TextMeshProUGUI _ui;
    private float _elapsedTime;

    void Start()
    {
        _ui = GetComponent<TextMeshProUGUI>();
        _ui.text = $"Score : {(int)SurvivalTime}";
        IsOn = true;
    }

    void Update()
    {
        // 1초에 한번씩만 업데이트
        if (IsOn)
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= 1f)
            {
                SurvivalTime += _elapsedTime;
                _elapsedTime = 0f;
                _ui.text = $"Score : {(int)SurvivalTime}";
            }
        }
    }
}
