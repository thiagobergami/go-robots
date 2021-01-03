using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float _nextSpawnTime;

    [SerializeField] float _delay = 2f;
    [SerializeField] Enemy[] _enemies;
    [SerializeField] Transform[] _spawnPoints;

    // Update is called once per frame
    void Update()
    {
        if (ShouldSpawn()) {
            Spawn();
        }
    }

    void Spawn()
    {
        _nextSpawnTime = Time.time + _delay;

        Transform spawPoint = ChooseSpawPoint();
        Enemy enemy = ChooseEnemy();
        
        Instantiate(enemy, spawPoint.position, spawPoint.rotation);
    }

    Enemy ChooseEnemy() {
        int randomIndex = UnityEngine.Random.Range(0, _enemies.Length);
        var enemy = _enemies[randomIndex];
        return enemy;
    }

    Transform ChooseSpawPoint() {
        int randomIndex = UnityEngine.Random.Range(0, _spawnPoints.Length);
        var spawPoint = _spawnPoints[randomIndex];
        return spawPoint;
    }
    private bool ShouldSpawn()
    {
        return Time.time >= _nextSpawnTime;
    }
}
