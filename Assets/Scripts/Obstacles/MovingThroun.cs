using System.Collections;
using UnityEngine;

public class MovingThroun : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private float _moveSpeed;
    private Vector3 StartPos;
    private void Start()
    {
        StartPos = transform.position;
    }

    private IEnumerator StartMove()
    {
        yield return new WaitForSeconds(3f);
        MoveUp();
    }

    public void StopThroun()
    {
        transform.position = StartPos;
    }

    private void OnDisable()
    {
        LevelComplete.onMovingThrounStopped -= StopThroun;
    }

    private void OnEnable()
    {
        LevelComplete.onMovingThrounStopped += StopThroun;
    }

    private void MoveUp()
    {
        transform.Translate(Vector3.up * _moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>())
        {
            SetPos();
            StopAllCoroutines();
        }
    }

    private void SetPos()
    {
        transform.position = StartPos;
    }

    private void Update()
    {
        if (!Player.activeSelf)
        {
            SetPos();
            StopAllCoroutines();
        }
    }

    private void FixedUpdate()
    {
        StartCoroutine(StartMove());
    }
}
