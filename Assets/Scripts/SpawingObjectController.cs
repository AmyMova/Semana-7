using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawingObjectController : MonoBehaviour
{
    [SerializeField]
    float speed = 50.0F;

    [SerializeField]
    int[] spawingPoints;

    Rigidbody2D _rb;

    SpawnManager _spawnManager;

    float _speedMultiplier;


    void Start()
    {
        _spawnManager = SpawnManager.Instance;

        _rb = GetComponent<Rigidbody2D>();

        _speedMultiplier = _spawnManager.GetSpeedMultiplier();
    }
    void FixedUpdate()
    {
        _rb.velocity = Vector2.left * speed * Time.fixedDeltaTime * _speedMultiplier;
    }
    public int[] GetSpawningPoints()
    {
        return spawingPoints;
    }
}
