using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsLoad : MonoBehaviour
{
    public void LoadLevel(int sceneIndex) => SceneManager.LoadScene(sceneIndex);
}
