using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")|| other.CompareTag("Platform"))
        {
            Destroy(other.gameObject);
        }
    }
}
