using UnityEngine;

public class RotateSaw : MonoBehaviour
{
    [SerializeField] private float _direction;


    private void Update()
    {
        this.gameObject.transform.rotation *= Quaternion.Euler(0f, 0f, _direction);
    }
}
