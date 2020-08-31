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
    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
