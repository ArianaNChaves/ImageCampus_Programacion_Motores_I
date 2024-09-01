using System;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    Ball,
    Obstacle,
    Buff
}

public class PoolController : MonoBehaviour
{
    public event Action<ObjectType, GameObject> OnReturnCall;

    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private GameObject buffPrefab;
    [SerializeField] private int initialCountOfBalls;
    [SerializeField] private int initialCountOfObstacles;
    [SerializeField] private int initialCountOfBuffs;

    private Dictionary<ObjectType, List<GameObject>> _pool;

    private void OnEnable()
    {
        OnReturnCall += ReturnToPool;
    }

    private void OnDisable()
    {
        OnReturnCall -= ReturnToPool;
    }

    private void Start()
    {
        _pool = new Dictionary<ObjectType, List<GameObject>>();
        
        InitializePool(ObjectType.Ball, ballPrefab, initialCountOfBalls);
        InitializePool(ObjectType.Obstacle, obstaclePrefab, initialCountOfObstacles);
        InitializePool(ObjectType.Buff, buffPrefab, initialCountOfBuffs);
    }

    private void InitializePool(ObjectType type, GameObject prefab, int initialCount)
    {
        _pool[type] = new List<GameObject>();
        for (int i = 0; i < initialCount; i++)
        {
            var obj = Instantiate(prefab);
            obj.SetActive(false);
            _pool[type].Add(obj);
        }
    }

    public GameObject GetObjectFromPool(ObjectType type)
    {
        GameObject objectFromPool = null;
        if (_pool[type].Count > 0)
        {
            objectFromPool = _pool[type][0];
            _pool[type].RemoveAt(0);
            return objectFromPool;
        }
        else
        {
            switch (type)
            {
                case ObjectType.Ball:
                    objectFromPool = Instantiate(ballPrefab);
                    break;
                case ObjectType.Obstacle:
                    objectFromPool = Instantiate(obstaclePrefab);
                    break;
                case ObjectType.Buff:
                    objectFromPool = Instantiate(buffPrefab);
                    break;
                default:
                    Debug.LogError("PoolCOntroller - GetObjectFromPool - ELSE - type error");
                    break;
            }
        }
        return objectFromPool;
    }

    public void ReturnToPool(ObjectType type, GameObject objectToReturn)
    {
        objectToReturn.SetActive(false);
        _pool[type].Add(objectToReturn);
    }
}