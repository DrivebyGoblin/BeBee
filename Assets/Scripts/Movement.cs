using UnityEngine;

public class Movement : MonoBehaviour
{
    private readonly float _flySpeed = 120f;
    private Rigidbody2D _rigidbody2D;
    private float _moveSpeed = 1f;
    private bool _isDead;
    private bool _moveLeft = false;
    private bool _moveRight = false;
    private bool _isFly = false;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void GoLeft()
    {
        _moveLeft = true;
        _moveRight = false;
    }

    public void GoRight()
    {
        _moveLeft = false;
        _moveRight = true;
    }

    public void ButtonsUp()
    {
        _moveRight = false;
        _moveLeft = false;
    }

    public void GoFly()
    {
        _isFly = true;
    }

    public void FlyButtonUp()
    {
        _isFly = false;
    }

    public void ChangeFlyState(bool isDead)
    {
        _isDead = isDead;
    }

    public void FlyUp()
    {
        _rigidbody2D.AddForce(Vector2.up * _flySpeed * Time.deltaTime, ForceMode2D.Force);
    }

    void FixedUpdate()
    {
        if (_moveLeft == true && !_isDead)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 15f);
            transform.Translate(Vector2.left * _moveSpeed * Time.deltaTime, Space.Self);
        }
        else if (_moveRight == true && !_isDead)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -15f);
            transform.Translate(Vector2.right * _moveSpeed * Time.deltaTime, Space.Self);
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }


        if (_isFly && !_isDead)
        {
            _rigidbody2D.AddForce(Vector2.up * _flySpeed * Time.deltaTime, ForceMode2D.Force);
        }
    }
}
