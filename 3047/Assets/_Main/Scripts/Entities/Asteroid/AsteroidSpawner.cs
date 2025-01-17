using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class AsteroidSpawner : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Asteroid _asteroid;
    
    [Header("Info")]
    [SerializeField] private int _spawnAmount = 1;
    private float _spawnRange;
    
    [Header("Rate")]
    [SerializeField] private float _spawnRate = 2f;
    private float _lastSpawnedTime;
    
    [SerializeField] private float _minSize = .5f;
    [SerializeField] private float _maxSize = 2f;
    [SerializeField] [Range(0, 360)]  private float _angleX = 360;
    [SerializeField] [Range(0, 360)]  private float _angleY = 360;
    [SerializeField] [Range(0, 360)]  private float _angleZ = 360;
    [SerializeField] private float _trajectoryVariance = 15f;
    private void Start()
    {
        //InvokeRepeating(nameof(Spawn), _spawnRate, _spawnRate);
        _spawnRange = (1 / (Camera.main.WorldToViewportPoint(new Vector3(1, 1, 0)).y - .5f)) / 2;
    }

    private void Update()
    {
        //My idea was to use the InvokeRepeating, but I dont know how to make it so it calls Spawn(_spawnAmount)
        SpawnRepeating(_spawnRate, _spawnAmount);
    }

    private void Spawn()
    {
        Vector3 spawnPoint = new Vector3(transform.position.x, Random.Range(-_spawnRange, _spawnRange), 0f);



        float variance;
        if(spawnPoint.y > 0)
            variance = Random.Range(-_trajectoryVariance, 0);
        else
            variance = Random.Range(0, _trajectoryVariance);
        
        Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);
        
        Asteroid asteroid = Instantiate(_asteroid, spawnPoint, rotation);
        asteroid.InitData(new Vector3(-1, variance, 0).normalized, Random.Range(_minSize,_maxSize), new Vector3(_angleX, _angleY, _angleZ));
    }

    private void Spawn(int spawnAmount)
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            Spawn();
        }
    }
    private void SpawnRepeating(float repeatRate)
    {
        if (!(_lastSpawnedTime + repeatRate < Time.time)) return;
        _lastSpawnedTime = Time.time;
        Spawn();
    }
    private void SpawnRepeating(float repeatRate, int spawnAmount)
    {
        if (!(_lastSpawnedTime + repeatRate < Time.time)) return;
        _lastSpawnedTime = Time.time;
        Spawn(spawnAmount);
    }
}
