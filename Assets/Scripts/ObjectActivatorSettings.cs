using UnityEngine;


public static class ObjectActivatorSettings
{
    public static int starActive = 1;
    public static int[] ScenesIndex = new int[19]; 
    public static void SetActiveIndex(int _SceneIndex) 
    {
        PlayerPrefs.SetInt("data["+_SceneIndex+"]", ScenesIndex[_SceneIndex] = starActive);
        PlayerPrefs.Save();
    }

}
