using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Camera mainCam;

    public SceneHandler scene;
    public InputHandler input;
    public EventHandler eventHandler;
    public AudioHandler audioHandler;
    private void Awake()
    {
        scene.LoadMainMenu();
        //scene = GetComponentInChildren<SceneHandler>();
        //input = GetComponentInChildren<InputHandler>();
    }

    // Start is called before the first frame update
    void Start()
    {
        

        GameObject[] EssentialsObjects = SceneManager.GetSceneByName("Essentials").GetRootGameObjects();
        for(int i = 0; i < EssentialsObjects.Length-1; i++)
        {
            if (EssentialsObjects[i].CompareTag("MainCamera"))
            {
                mainCam = EssentialsObjects[i].GetComponent<Camera>();
            }
        }
    }
 
    // Update is called once per frame
    void Update()
    {
        
    }

    

    

    private static GameManager _instance;
    public static GameManager game
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    _instance = new GameObject().AddComponent<GameManager>();
                }
            }

            return _instance;
        }
    }
}
