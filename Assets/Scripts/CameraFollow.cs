using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        _camera.transform.position = new Vector3(_camera.transform.position.x, _player.transform.position.y + 2f, _camera.transform.position.z);
    }
}
