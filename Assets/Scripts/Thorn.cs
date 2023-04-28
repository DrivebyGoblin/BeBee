using UnityEngine;

public class Thorn : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Death>())
        {
            StartCoroutine(collision.gameObject.GetComponent<Death>().PuffEffect());
        }
    }
}
