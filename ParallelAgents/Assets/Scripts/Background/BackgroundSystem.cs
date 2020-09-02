using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSystem : MonoBehaviour
{
    public GameObject backLane;
    public GameObject midLane;
    public GameObject frontLane;
    public GameObject sky;
    public GameObject detail;

    public float backLaneSpeed = 1;
    public float midLaneSpeed = 1;
    public float frontLaneSpeed = 1;
    public float skyLaneSpeed = 1;
    public float detailLaneSpeed = 1;

    public float backLaneSpawnTime = 1;
    public float midLaneSpawnTime = 1;
    public float foreLaneSpawnTime = 1;
    public float skyLaneSpawnTime = 1;
    public float detailLaneSpawnTime = 1;

    public Backgrounds backgrounds;

    public Dictionary<string, Queue<GameObject>> poolDictionary;

    public List<GameObject> modernObjects;
    public List<GameObject> alienObjects;
    public List<GameObject> neonObjects;
    public List<GameObject> noirObjects;

    public SceneHandler.Universe currentBackgroundUniverse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.game.scene.currentUniverse != currentBackgroundUniverse)
        {
            switch (GameManager.game.scene.currentUniverse)
            {
                case SceneHandler.Universe.Main:EnableAllInList(modernObjects);break ;
                case SceneHandler.Universe.Neon:EnableAllInList(neonObjects); break;
                case SceneHandler.Universe.Noir:EnableAllInList(noirObjects); break;
                case SceneHandler.Universe.Space:EnableAllInList(alienObjects); break;

            }
            switch (currentBackgroundUniverse)
            {
                case SceneHandler.Universe.Main:DisableAllInList(modernObjects); break;
                case SceneHandler.Universe.Neon:DisableAllInList(neonObjects); break;
                case SceneHandler.Universe.Noir:DisableAllInList(noirObjects); break;
                case SceneHandler.Universe.Space:DisableAllInList(alienObjects); break;
            }

            currentBackgroundUniverse = GameManager.game.scene.currentUniverse;
        }
    }

    public void EnableAllInList(List<GameObject> objects)
    {
        foreach(GameObject currentObject in objects)
        {
            currentObject.SetActive(true);
        }
    }
    public void DisableAllInList(List<GameObject> objects)
    {
        foreach (GameObject currentObject in objects)
        {
            currentObject.SetActive(false);
        }
    }
}
