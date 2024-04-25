using System;
using TMPro;
using UniRx;
using UnityEngine;

public sealed class Timer : MonoBehaviour
{
    private const string TimerFormat = @"mm\:ss";
    [SerializeField, Range(1,120)] private int _totalSeconds;
    [SerializeField, Range(5,30)] private int _stepsSeconds;
    [SerializeField] private TMP_Text _timerLabel;
    private int _currentSeconds;
    private IDisposable _timer;

    private void Awake()
    {
        _currentSeconds = _totalSeconds;
        _timerLabel.text = _totalSeconds.ToString();
        ShowTimeAsString();
    }

    private void OnDestroy() => _timer?.Dispose();

    public void PauseClicked() => _timer.Dispose();

    public void PlayClicked() => _timer = Observable.Interval(TimeSpan.FromSeconds(1)).Subscribe(TimerCounter);

    public void AddSeconds()
    {
        if (_timer != null) return;
        _totalSeconds += _stepsSeconds;
        if (_totalSeconds > 120) _totalSeconds = 120;
        _currentSeconds = _totalSeconds;
        ShowTimeAsString();
    }

    public void RemoveSeconds()
    {
        if (_timer != null) return;
        _totalSeconds -= _stepsSeconds;
        if (_totalSeconds < _stepsSeconds) _totalSeconds = _stepsSeconds;
        _currentSeconds = _totalSeconds;
        ShowTimeAsString();
    }

    private void ShowTimeAsString() => _timerLabel.text = TimeSpan.FromSeconds(_currentSeconds).ToString(@"mm\:ss");

    private void TimerCounter(long obj)
    {
        _currentSeconds--;
        ShowTimeAsString();
        if (_currentSeconds == 0)
        {
            _currentSeconds = _totalSeconds;
            _timer.Dispose();
            _timer = null;
            Handheld.Vibrate();
        }
    }

    public void ResetClicked()
    {
        _timer.Dispose();
        _timer = null;
        _currentSeconds = _totalSeconds;
        ShowTimeAsString();
    }
}
