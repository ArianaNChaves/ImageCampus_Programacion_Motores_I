using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BuffSpawn : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPointsBuffList;
    [SerializeField] private PoolController poolController;
    [SerializeField, Range(5.0f, 10.0f)] private float buffSpawnInterval;
    
    private GameObject _buff;
    private void OnEnable()
    {
        Buff.OnBuffDespawn += StartRespawnBuff;
    }

    private void Start()
    {
        Invoke(nameof(SpawnBuff), buffSpawnInterval);
    }

    private void OnDisable()
    {
        Buff.OnBuffDespawn -= StartRespawnBuff;
    }
    private void SpawnBuff()
    {
        int randomPosition = RandomIntBetween(0, spawnPointsBuffList.Length);
        _buff = poolController.GetObjectFromPool(ObjectType.Buff);
        _buff.transform.position = spawnPointsBuffList[randomPosition].position;
        _buff.SetActive(true);
    }
    private void StartRespawnBuff()
    {
        poolController.ReturnToPool(ObjectType.Buff, _buff);
        Invoke(nameof(SpawnBuff), buffSpawnInterval);   
    }
    private int RandomIntBetween(int min, int max)
    {
        return Random.Range(min, max);
    }
}
