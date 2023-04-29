using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;

    // Start is called before the first frame update
    private void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacles();
        SpawnCoins();
        PickAndSpawnObj();
    }
    private void OnTriggerExit (Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 1);
    }

    [SerializeField] private List<GameObject> obstaclePrefabs;

    void SpawnObstacles()
    {   
        //choose a random point to spawn obstacles
        int obstacleSpawnIndex = Random.Range(1, 4);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        //spawn a random obstacle at the point
        int obstacleIndex = Random.Range(0, obstaclePrefabs.Count);
        Instantiate(obstaclePrefabs[obstacleIndex], spawnPoint.position, Quaternion.identity, transform);
    }

    public GameObject coinPrefab;
    void SpawnCoins()
    {
        int coinsToSpawn = 4;
        for (int i = 0; i< coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>()); //set the position of the coin
        }
    }

    Vector3 GetRandomPointInCollider (Collider collider)
    {
        Vector3 point = new Vector3
            (
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider); 
            //checks if the random point it gets is in the collider and will generate a new point if it isnt in the collider
        }

        point.y = 1;
        return point;
    }

    [SerializeField] private GameObject[] SpawnPoints = new GameObject[3];
    [SerializeField] private GameObject[] ObstaclePrefabs;
    void PickAndSpawnObj()
    {
        int SpawnIndex_SpawnPnts = Random.Range(0, SpawnPoints.Length); //For choosing spawnPoints;
        GameObject AreaToSpawn = SpawnPoints[SpawnIndex_SpawnPnts]; // The spawnpoint to choose when instantiating a randomly chosen object
        int SpawnIndex_Obstacle = Random.Range(0, ObstaclePrefabs.Length); //For picking variety of objs;
        GameObject ObjToSpawn = ObstaclePrefabs[SpawnIndex_Obstacle];// The obstacle to spawn on a chosen spawnpoint

        GameObject SpawnObjToSpawnPoint = Instantiate(ObjToSpawn, AreaToSpawn.transform.position, Quaternion.identity);

    }
}
