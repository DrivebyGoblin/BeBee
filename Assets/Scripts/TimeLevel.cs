using UnityEngine;
using UnityEngine.UI;
public class TimeLevel : MonoBehaviour
{
    [SerializeField] private Death _playerDeath;
    [SerializeField] private GameObject _player;
    [SerializeField] private Image _timeBar;
    [SerializeField] private float _levelTime;

    private bool isTimeRunning;
    private float _timeLeft;


    private void Start()
    {
        isTimeRunning = true;
        _timeLeft = _levelTime;
    }


    public void TimeFreezer(bool doFreeze)
    {
        isTimeRunning = doFreeze;
    }

    public void TimerRestart()
    {
        ResetTime();
        TimeFreezer(true);
    }

    private void ResetTime()
    {
        _timeLeft = _levelTime;
    }

    private void Update()
    {

        if (isTimeRunning == true)
        {
            _timeLeft -= Time.deltaTime;
            _timeBar.fillAmount = _timeLeft / _levelTime;
            if (_timeLeft <= 0)
            {
                StartCoroutine(_playerDeath.PuffEffect());
            }
        }
        
    }

    private void OnDisable()
    {
        Death.onTimerStopped -= TimeFreezer;
        Death.onTimerRestarted -= TimerRestart;
        LevelComplete.onTimerFreeze -= TimeFreezer;
    }

    private void OnEnable()
    {
        Death.onTimerStopped += TimeFreezer;
        Death.onTimerRestarted += TimerRestart;
        LevelComplete.onTimerFreeze += TimeFreezer;
    }
}
