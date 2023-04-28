using UnityEngine;
using TMPro;
using System;

public class FlowerControl : MonoBehaviour
{
    [SerializeField] private AudioClip _flowerClip;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Death _death;
    [SerializeField] private TextMeshProUGUI _flowerCountUI;
    [SerializeField] private int _allFlowers;
    private Flowers[] _flowerObjects;
    private int _currentFlowers;


    public static Action onLevelCompleted;
    

    private void OnDisable()
    {
        _death.onPlayerDied -= RespawnFlowers;
        Flowers.onFlowerTaked -= ChangeFlowersCount;
        Flowers.onFlowerTaked -= NoiseFromFlower;
    }
    private void OnEnable()
    {
        _death.onPlayerDied += RespawnFlowers;
        Flowers.onFlowerTaked += ChangeFlowersCount;
        Flowers.onFlowerTaked += NoiseFromFlower;
    }

    private void Start()
    {
        _flowerObjects = FindObjectsOfType<Flowers>();
        _currentFlowers = _allFlowers;
        _flowerCountUI.text = _currentFlowers.ToString();
    }


    public void ChangeFlowersCount()
    {
        
        _currentFlowers = _currentFlowers - 1;
        _flowerCountUI.text = _currentFlowers.ToString();
        if (_currentFlowers == 0)
        {
            
            onLevelCompleted?.Invoke();
        }
    }

    public void NoiseFromFlower()
    {
        _audioSource.PlayOneShot(_flowerClip);
    }

    public void RespawnFlowers()
    {     
        for (int i = 0; i < _flowerObjects.Length; i++)
        {
            _flowerObjects[i].gameObject.SetActive(true);
        }

        _currentFlowers = _allFlowers;
        _flowerCountUI.text = _allFlowers.ToString();
    }

    


}
