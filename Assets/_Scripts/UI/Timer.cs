using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _timeLimit;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private SceneUI _sceneUI;

    private float _secondsCount = 0;
    private int _minutes;
    private int _seconds;
    private int _hours;
    private bool _timerAllowed = false;

    public event UnityAction TimerStarted;
    public event UnityAction TimerStopped;

    private void Start()
    {
        _secondsCount = _timeLimit;
        SetMinutesAndSecondsAndHours(_secondsCount);
        ChangeTimerUI(_hours, _minutes, _seconds);
        
        StartTimer();
    }

    private void StartTimer()
    {
        _timerAllowed = true;
        StartCoroutine(TimerCoroutine());
        TimerStarted?.Invoke();
    }

    private void SetMinutesAndSecondsAndHours(float value)
    {
        _minutes = (int)value / 60;
        _seconds = (int)value % 60;

        if(_minutes >= 60)
        {
            _minutes = 0;
            _hours++;
        }
    }

    private IEnumerator TimerCoroutine()
    {
        while (_timerAllowed && _secondsCount > 0)
        {
            _secondsCount -= Time.deltaTime;

            SetMinutesAndSecondsAndHours(_secondsCount);
            ChangeTimerUI(_hours, _minutes, _seconds);

            yield return null;
        }
        
        TimerStopped?.Invoke();
    }

    private void ChangeTimerUI(int hours, int minutes, int seconds)
    {
        string secondsForUI;

        secondsForUI = seconds < 10 ? $"0{seconds}" : seconds.ToString();

        if(hours == 0)
            _timerText.text = $"{minutes}:{secondsForUI}";
        else if(hours > 0)
            _timerText.text = $"{hours}:{minutes}:{secondsForUI}";
    }
}