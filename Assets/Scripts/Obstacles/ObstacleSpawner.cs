using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public GameObject obstaclePrefab;
    public GameObject collectablePrefab;
    public float spawnInterval;
    public float spawnDistance;

    public AudioClip trashCanFallClip;

    private float _spawnTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        spawnInterval = 2f;
        spawnDistance = 0f;
        _spawnTimer = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        _spawnTimer -= Time.deltaTime;

        if(_spawnTimer <= 0)
        {
            spawnDistance = Random.Range(0, 5) * 2;
            _spawnTimer = spawnInterval;
            int selectObject = Random.Range(0, 2);
            if (selectObject == 0) {
                SpawnObstacle();
            } else {
                SpawnCollectable();
            }
        }
    }

    private void SpawnObstacle()
    {
        var obstacle = Instantiate(obstaclePrefab, transform.position + transform.forward * spawnDistance, Quaternion.identity);
        obstacle.transform.parent = transform;
        GetComponent<AudioSource>().clip = trashCanFallClip;
        GetComponent<AudioSource>().Play();
    }

    private void SpawnCollectable()
    {
        var collectable = Instantiate(collectablePrefab, transform.position + transform.forward * spawnDistance, Quaternion.identity);
        collectable.transform.parent = transform;
    }
}
