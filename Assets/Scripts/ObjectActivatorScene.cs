using UnityEngine;

public class ObjectActivatorScene : MonoBehaviour
{
    public GameObject[] objectsToActivate;

    private void Start()
    {
        Cheking();
        ChekStarsState();
    }

    public void Cheking() 
    {
        for (int x = 0; x < objectsToActivate.Length; x++)
        {
            ObjectActivatorSettings.ScenesIndex[x] = PlayerPrefs.GetInt("data["+x+"]");
        }
    }

    public void ChekStarsState() 
    {
        for (int i = 0; i < objectsToActivate.Length; i++)
        {
            if (ObjectActivatorSettings.ScenesIndex[i] == ObjectActivatorSettings.starActive) 
            {
                objectsToActivate[i - 1].SetActive(true);
            }
        }
    }
}
