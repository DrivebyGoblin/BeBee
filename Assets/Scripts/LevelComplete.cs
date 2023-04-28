using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    [SerializeField] private AudioClip _levelCompletedAudio;
    [SerializeField] private Button[] gameButtons;
    public static Action onPlayerFreeze;
    public static Action onMovingThrounStopped;
    public static Action<bool> onTimerFreeze;
    private AudioSource _audioSource;
    private Animator _animator;
    private int _sceneIndex;


    private void FreezeAll()
    {
        onPlayerFreeze?.Invoke();
        for (int i = 0; i < gameButtons.Length; i++)
        {
            gameButtons[i].interactable = false;
        }
    }

    private void Start()
    {
        _sceneIndex = SceneManager.GetActiveScene().buildIndex;
        _animator = GetComponent<Animator>();
        _animator.enabled = false;
        _audioSource = GetComponent<AudioSource>();
    }
    public void LevelEnd()
    {
        _animator.enabled = true;
        _audioSource.PlayOneShot(_levelCompletedAudio);
        FreezeAll();
        onTimerFreeze?.Invoke(false);
        onMovingThrounStopped?.Invoke();
        ObjectActivatorSettings.SetActiveIndex(_sceneIndex);
    }

    private void OnDisable()
    {
        FlowerControl.onLevelCompleted -= LevelEnd;
    }
    
    private void OnEnable()
    {
        FlowerControl.onLevelCompleted += LevelEnd;
    }
}
