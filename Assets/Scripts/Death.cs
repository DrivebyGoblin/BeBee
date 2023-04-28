using System.Collections;
using UnityEngine;
using System;

public class Death : MonoBehaviour
{
    public event Action onPlayerDied;
    public static event Action<bool> onTimerStopped;
    public static event Action onTimerRestarted;

    [SerializeField] private Transform _player;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private SpriteRenderer[] OpacityPartsOfBody = new SpriteRenderer[4];
    [SerializeField] private AudioClip _deathAudio;
    [SerializeField] private AudioSource _audioSource;
    private Movement _movement;


    private void Start()
    {
        _movement = GetComponent<Movement>();
    }

    private void OnDisable()
    {
        LevelComplete.onPlayerFreeze -= FreezeHero;
    }
    private void OnEnable()
    {
        LevelComplete.onPlayerFreeze += FreezeHero;
    }

    private void NoiseFromDeath()
    {
        _audioSource.PlayOneShot(_deathAudio);
    }
    private void FreezeHero()
    {
        var _rigidBody = _player.GetComponent<Rigidbody2D>();
        _rigidBody.velocity = Vector2.zero;
        _rigidBody.isKinematic = true;
        _movement.ChangeFlyState(true);
    }

    private void SetOpacity(bool value)
    {
        foreach (var item in OpacityPartsOfBody)
        {
            item.gameObject.SetActive(value);
        }
    }

    private void SpawnBee()
    {
        _player.GetComponent<Rigidbody2D>().isKinematic = false;
        _player.transform.position = _spawnPosition.position;
    }

    public IEnumerator PuffEffect() // работающий
    {
        onTimerStopped?.Invoke(false);
        SetOpacity(false);
        NoiseFromDeath();
        FreezeHero();
        var puff = Instantiate(_particleSystem, _player.transform.position, Quaternion.identity);
        puff.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(1.5f);
        _movement.ChangeFlyState(false);
        SpawnBee();
        Destroy(puff.gameObject);
        StopCoroutine("PuffEffect");
        SetOpacity(true);
        onPlayerDied?.Invoke();
        onTimerRestarted?.Invoke();
    }

    


}
