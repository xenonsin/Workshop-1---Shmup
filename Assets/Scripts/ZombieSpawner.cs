using UnityEngine;
using System.Collections;

public class ZombieSpawner : MonoBehaviour
{

    public Transform zombie;
    public float spawnTime;
    public float spawnTimeRandom;
    public float spawnTimer;

	// Use this for initialization
	void Start () {
        ResetSpawnTimer();
	
	}
	
	// Update is called once per frame
	void Update () {

        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0.0f)
        {
            Instantiate(zombie, transform.position, Quaternion.identity);
            ResetSpawnTimer();
        }
	
	}

    void ResetSpawnTimer()
    {
        spawnTimer = (float)(spawnTime + Random.Range(0, spawnTimeRandom * 100) / 100.0);
    }

}
