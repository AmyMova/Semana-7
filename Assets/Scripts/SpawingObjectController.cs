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

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        _rb.velocity = Vector2.left * speed * Time.fixedDeltaTime;
    }
    public int[] GetSpawningPoints()
    {
        return spawingPoints;
    }
}
