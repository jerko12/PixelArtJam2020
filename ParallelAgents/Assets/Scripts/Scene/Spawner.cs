using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject wall;

    public GameObject EnergyEnemy;
    public GameObject ShootingEnemy;
    public GameObject RushingEnemy;

    public GameObject BigEnemy;


    public GameObject lane1;
    public GameObject lane2;
    public GameObject lane3;

    public float spawnTime = 2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("spawn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime/2);
            int SpawnLane1 = Random.Range(0, 6);
            int SpawnLane2 = Random.Range(0, 6);
            int SpawnLane3 = Random.Range(0, 6);

            if(SpawnLane1 < 3)
            {
                GameObject enemyLane1 = new GameObject();
                switch (SpawnLane1)
                {
                    case 0: enemyLane1 = Instantiate(EnergyEnemy, lane1.transform);break;
                    case 1: enemyLane1 = Instantiate(RushingEnemy, lane1.transform); break;
                    case 2: enemyLane1 = Instantiate(ShootingEnemy, lane1.transform); break;
                }

                if(enemyLane1 != null)
                {
                    enemyLane1.transform.SetParent(lane1.transform);
                }
            }

            if (SpawnLane2 < 3)
            {
                GameObject enemyLane2 = new GameObject();
                switch (SpawnLane2)
                {
                    case 0: enemyLane2 = Instantiate(EnergyEnemy, lane2.transform); break;
                    case 1: enemyLane2 = Instantiate(RushingEnemy, lane2.transform); break;
                    case 2: enemyLane2 = Instantiate(ShootingEnemy, lane2.transform); break;
                }

                if (enemyLane2 != null)
                {
                    enemyLane2.transform.SetParent(lane1.transform);
                }
            }

            if (SpawnLane3 < 3)
            {
                GameObject enemyLane3 = new GameObject();
                switch (SpawnLane3)
                {
                    case 0: enemyLane3 = Instantiate(EnergyEnemy, lane3.transform); break;
                    case 1: enemyLane3 = Instantiate(RushingEnemy, lane3.transform); break;
                    case 2: enemyLane3 = Instantiate(ShootingEnemy, lane3.transform); break;
                }

                if (enemyLane3 != null)
                {
                    enemyLane3.transform.SetParent(lane1.transform);
                }
            }

            yield return new WaitForSeconds(spawnTime/2);
            Debug.Log("Spawn");
            int noSpawnLane = Random.Range(0, 3);
            switch(noSpawnLane)
            {
                case 0: spawnNoLane1(); break;
                case 1: spawnNoLane2(); break;
                case 2: spawnNoLane3(); break;
            }
        }
    }
    void spawnNoLane1()
    {
        GameObject object1 = Instantiate(wall,lane2.transform);
        GameObject object2 = Instantiate(wall, lane3.transform);
        //object1.transform.SetParent(lane2.transform);
        //object2.transform.SetParent(lane3.transform);
    }
    void spawnNoLane2()
    {
        GameObject object1 = Instantiate(wall, lane1.transform);
        GameObject object2 = Instantiate(wall, lane3.transform);
        //object1.transform.SetParent(lane1.transform);
        //object2.transform.SetParent(lane3.transform);
    }

    void spawnNoLane3()
    {
        GameObject object1 = Instantiate(wall, lane2.transform);
        GameObject object2 = Instantiate(wall, lane1.transform);
        //object1.transform.SetParent(lane2.transform);
        //object2.transform.SetParent(lane1.transform);
    }
}
