using System.Linq;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    private float timeToSpawn = 2f;
    public float timeBetweenWaves = 1f;
    public Transform playerTransform;
    public float zOffset = 60f;
    public GameObject obstaclePrefab;

    void Update()
    {
        Vector3 playerZVector = new Vector3(0, 0, playerTransform.position.z);
        Vector3 offsetVector = new Vector3(0, 1, zOffset);
        transform.position = playerZVector + offsetVector;
        if (Time.time >= timeToSpawn)
        {
            SpawnBlocks();
            timeToSpawn = Time.time + timeBetweenWaves;
        }
    }

    void SpawnBlocks() {
        int randomNumberOfBlocks = Random.Range(1, spawnPoints.Length);
        int numberOfSpaces = spawnPoints.Length - randomNumberOfBlocks;
        int[] spacesIndexes = new int[numberOfSpaces];
        for (int i = 0; i < numberOfSpaces; i++)
        {
            int randomIndex;
            do
            {
                randomIndex = Random.Range(0, spawnPoints.Length);
            } while (spacesIndexes.Contains(randomIndex));
            spacesIndexes[i] = randomIndex;
        }
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if(!spacesIndexes.Contains(i))
            {
                Instantiate(obstaclePrefab, spawnPoints[i].position, Quaternion.identity);
            }
        }
    }
}
