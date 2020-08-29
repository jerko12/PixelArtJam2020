using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public SceneGroup MainMenuSceneGroup;
    public SceneGroup GameSceneGroup;


    private void Awake()
    {

        GameManager.game.scene = this;
    }

    public void LoadMainMenu()
    {
        LoadScenes(MainMenuSceneGroup);
        UnloadScenes(MainMenuSceneGroup);
        GameManager.game.eventHandler.input.onJumpEnter += LoadGame;
    }

    public void LoadGame()
    {
        LoadScenes(GameSceneGroup);
        UnloadScenes(GameSceneGroup);
        GameManager.game.eventHandler.input.onJumpEnter -= LoadGame;
        
    }

    private void LoadScenes(SceneGroup sceneGroup)
    {
        foreach (string path in sceneGroup.scenePaths)
        {
            Debug.Log(SceneManager.GetSceneByBuildIndex(SceneUtility.GetBuildIndexByScenePath(path)).path);
            Scene scene = SceneManager.GetSceneByBuildIndex(SceneUtility.GetBuildIndexByScenePath(path));
            if (scene.path == null)
            {
                SceneManager.LoadSceneAsync(SceneUtility.GetBuildIndexByScenePath(path), LoadSceneMode.Additive);
            }
        }
    }

    private void UnloadScenes(SceneGroup sceneGroup)
    {
        foreach (Scene scene in SceneManager.GetAllScenes()) ;
        for (int sceneIndex = 0; sceneIndex < SceneManager.sceneCount; sceneIndex++)
        {
            bool deleteScene = true;
            foreach(string path in sceneGroup.scenePaths)
            {
                if (SceneManager.GetSceneAt(sceneIndex).name == SceneManager.GetSceneByPath(path).name || SceneManager.GetSceneAt(sceneIndex).name == "Manager")
                {
                    deleteScene = false;
                }
            }
            if (deleteScene)
            {
                SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(sceneIndex).buildIndex);
            }
        }
    }
}
