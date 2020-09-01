using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public SceneGroup MainMenuSceneGroup;
    public SceneGroup GameSceneGroup;

    public bool inAlternateUniverse;
    public enum Universe
    {
        Main,
        Neon,
        Noir,
        Space
    }

    public Universe currentUniverse = Universe.Main;


    private void Awake()
    {

        GameManager.game.scene = this;
    }

    public void SwitchUniverse()
    {
        //Switch this later on
        Universe newUniverse = Universe.Main;
        int randomUniverseIndex = Random.Range(0, 4);
        switch (randomUniverseIndex)
        {
            case 0: newUniverse = Universe.Main; break;
            case 1: newUniverse = Universe.Neon; break;
            case 2: newUniverse = Universe.Noir; break;
            case 3: newUniverse = Universe.Space; break;
        }
        

        if (currentUniverse != newUniverse)
        {
            GameManager.game.eventHandler.game.BeforeChangeUniverse();
            currentUniverse = newUniverse;
            GameManager.game.eventHandler.game.AfterChangeUniverse();
        }
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
        SceneManager.GetSceneAt(3).GetRootGameObjects();
        
        GameManager.game.eventHandler.input.onJumpEnter -= LoadGame;
        GameManager.game.eventHandler.input.onJumpEnter += SwitchUniverse;
        
    }

    private void LoadScenes(SceneGroup sceneGroup)
    {
        foreach (string path in sceneGroup.scenePaths)
        {
            Scene scene = SceneManager.GetSceneByBuildIndex(SceneUtility.GetBuildIndexByScenePath(path));
            if (scene.path == null)
            {
                SceneManager.LoadSceneAsync(SceneUtility.GetBuildIndexByScenePath(path), LoadSceneMode.Additive);
            }
        }
    }

    private void UnloadScenes(SceneGroup sceneGroup)
    {
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
