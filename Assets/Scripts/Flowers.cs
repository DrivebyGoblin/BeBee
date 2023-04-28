using UnityEngine;
using System;

public class Flowers : MonoBehaviour
{
    public static Action onFlowerTaked;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Movement>())
        {
            onFlowerTaked?.Invoke();
            this.gameObject.SetActive(false);
        }
    }
}
