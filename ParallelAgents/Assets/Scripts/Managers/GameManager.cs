using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SceneHandler scene;
    public InputHandler input;
    public EventHandler eventHandler;
    public AudioHandler audioHandler;
    private void Awake()
    {
        //scene = GetComponentInChildren<SceneHandler>();
        //input = GetComponentInChildren<InputHandler>();
    }

    // Start is called before the first frame update
    void Start()
    {
        scene.LoadMainMenu();
        
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
