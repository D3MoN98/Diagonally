using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawnPath : MonoBehaviour
{
    public GameObject[] tilePrefab;
    public GameObject[] obPrefab;
    public Transform player;
    public float spawnZ = 0f;
    public float spawnLength = 50f;
    public int totalTilesOnScr = 2;
    private float softZone = 15.0f;
    private List<GameObject> activeTiles = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        SpawnObstacleOnFirstTile();

        for (int i = 0; i <= totalTilesOnScr; i++)
        {
            Spawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.z - softZone > spawnZ - (totalTilesOnScr * spawnLength))
        {
            Spawn();
            DeleteTile();
        }
    }

    void Spawn(int index = 0)
    {
        GameObject go;
        go = Instantiate(tilePrefab[index]) as GameObject;
        go.transform.position = Vector3.forward * spawnZ;

        SpawnObstacle(go);

        go.transform.SetParent(transform);
        activeTiles.Add(go);

        spawnZ += spawnLength;
    }

    void SpawnObstacle(GameObject parentOb)
    {
        int start = (int) spawnZ;
        int end = start + (int)spawnLength;

        while (start < end)
        {
            int times = Random.Range(1, 3);
            float randPosX = Random.Range(-4f, 4f);

            for (int i = 1; i <= times; i++)
            {
                randPosX = randPosX < 0 ? Random.Range(-4, -1f) : Random.Range(1, 4f);
                GameObject ob;
                ob = Instantiate(obPrefab[0]) as GameObject;
                Vector3 pos = new Vector3(randPosX, ob.transform.position.y, start);
                ob.transform.position = pos;

                ob.transform.SetParent(parentOb.transform);
            }

            start += 5;

        }

    }

    void SpawnObstacleOnFirstTile()
    {
        int start = 15;
        int end = 50;

        while (start < end)
        {
            int times = Random.Range(1, 3);
            float randPosX = Random.Range(-4f, 4f);

            for (int i = 1; i <= times; i++)
            {
                randPosX = randPosX < 0 ? Random.Range(-4, -1f) : Random.Range(1, 4f);
                GameObject ob;
                ob = Instantiate(obPrefab[0]) as GameObject;
                Vector3 pos = new Vector3(randPosX, ob.transform.position.y, start);
                ob.transform.position = pos;
            }

            start += 5;

        }
    }

    void DeleteTile()
    {
        Destroy(activeTiles[0]);
    }
}
