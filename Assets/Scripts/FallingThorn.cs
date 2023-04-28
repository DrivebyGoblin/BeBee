using System.Collections;
using UnityEngine;

public class FallingThorn : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D throunsForDrop;


    private Vector3[] _thornSpawnPositions = new Vector3[3];

    private void Update()
    {
        _thornSpawnPositions[0] = new Vector3(-1.88f, player.transform.position.y + 10f, 0f);
        _thornSpawnPositions[1] = new Vector3(-0.21f, player.transform.position.y + 10f, 0f);
        _thornSpawnPositions[2] = new Vector3(1.44f, player.transform.position.y + 10f, 0f);
    }
    public void SpawnFlyThroun()
    {
        var _spawnPosition = Random.Range(0, _thornSpawnPositions.Length);
        var _fallingThorn = Instantiate(throunsForDrop, _thornSpawnPositions[_spawnPosition], Quaternion.identity);
        StartCoroutine(DestroyFallingObject(_fallingThorn));

    }



    private IEnumerator DestroyFallingObject(Rigidbody2D _rb)
    {
        yield return new WaitForSeconds(5f);
        Destroy(_rb.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Movement>())
        {
            SpawnFlyThroun();
        }
    }
}
