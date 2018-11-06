using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] spawnPoints;

    [SerializeField]
    private float spawnRate = 5;

    private float timeSinceTick;

    [SerializeField]
    private string prefabName;

    public static bool spawnerOn = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeSinceTick += Time.deltaTime;

        if (timeSinceTick >= spawnRate && spawnerOn)
        {
            timeSinceTick = 0;
            Spawn();
        }
    }

    private void Spawn()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        GameObject prefab = GameManager.Instance.Pool.GetObject(prefabName);
        EnemyCollisions enemyCollisions = prefab.GetComponent<EnemyCollisions>();
        if (enemyCollisions != null)
        {
            enemyCollisions.startLife();
        }
        prefab.transform.position = spawnPoints[spawnIndex].transform.position;
    }
}
