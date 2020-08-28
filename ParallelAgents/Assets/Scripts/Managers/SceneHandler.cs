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
        GameManager.game.eventHandler.input.onJumpEnter += LoadGame;
    }

    public void LoadGame()
    {
        LoadScenes(GameSceneGroup);
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
}
