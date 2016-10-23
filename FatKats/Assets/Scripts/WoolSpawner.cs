using UnityEngine;
using System.Collections.Generic;

public class WoolSpawner : MonoBehaviour {
    public GameObject wool;
    public List<GameObject> woolSpawnPoint;
    public float minRespawnTime;
    public float maxRespawnTime;

    private float time;
    private float nextRespawnTime;

    void Start() {
        nextRespawnTime = Random.Range(minRespawnTime, maxRespawnTime);
    }

    void Update() {
        time += Time.deltaTime;
        if (time >= nextRespawnTime) {
            Spawn();
            time = 0.0f;
            nextRespawnTime = Random.Range(minRespawnTime, maxRespawnTime);
        }
    }

    void Spawn() {
        GameObject sp = woolSpawnPoint[Random.Range(0, woolSpawnPoint.Count)];
        Instantiate(wool, sp.transform.position, Quaternion.identity);
    }
}