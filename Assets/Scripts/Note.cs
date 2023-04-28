using System.Collections;
using UnityEngine;

public class Note : MonoBehaviour
{

    private IEnumerator DestroyNote()
    {
        yield return new WaitForSeconds(6f);
        StopCoroutine(DestroyNote());
        Destroy(this.gameObject);
    }

    private void Start()
    {
        StartCoroutine(DestroyNote());
    }


    private void FixedUpdate()
    {
        this.gameObject.transform.rotation *= Quaternion.Euler(0f, 0f, +1f);
    }
}
