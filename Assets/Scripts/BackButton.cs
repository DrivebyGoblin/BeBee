using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public void LoadScene(int _index) => SceneManager.LoadScene(_index);
}
