using UnityEngine;
using System.Collections;

public class ZombieSpawner : MonoBehaviour
{

    public Transform zombie;
    public float spawnTime;
    public float spawnTimeRandom;
    private float spawnTimer;

    private bool canSpawn;

    void OnEnable()
    {
        Player.Dead += StopSpawning;
    }

    void OnDisable()
    {
        Player.Dead -= StopSpawning;
    }

	// Use this for initialization
	void Start ()
	{
	    canSpawn = true;
        ResetSpawnTimer();
	
	}
	
	// Update is called once per frame
	void Update () {

	    if (canSpawn)
	    {
	        spawnTimer -= Time.deltaTime;
	        if (spawnTimer <= 0.0f)
	        {
	            Instantiate(zombie, transform.position, Quaternion.identity);
	            ResetSpawnTimer();
	        }
	    }

	}

    void ResetSpawnTimer()
    {
        spawnTimer = (float)(spawnTime + Random.Range(0, spawnTimeRandom * 100) / 100.0);
    }

    void StopSpawning()
    {
        canSpawn = false;
    }
}
