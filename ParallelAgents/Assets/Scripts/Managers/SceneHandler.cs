using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public SceneGroup MainMenuSceneGroup;
    public SceneGroup GameSceneGroup;

    public void LoadMainMenu()
    {
        LoadScenes(MainMenuSceneGroup);
    }

    public void LoadGame()
    {
        LoadScenes(GameSceneGroup);
    }

    private void LoadScenes(SceneGroup sceneGroup)
    {
        foreach (string sceneName in sceneGroup.sceneNames)
        {
            Scene scene = SceneManager.get;
            if (!scene.isLoaded)
            {
                SceneManager.LoadSceneAsync(scene.buildIndex, LoadSceneMode.Additive);
            }
        }
    }
}
