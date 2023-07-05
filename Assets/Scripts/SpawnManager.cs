using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{

    [SerializeField]
    Transform[] spawningObjects;

    [SerializeField]
    float timeBetweenSpawn = 3.0F;

    [SerializeField]
    Transform[] spawningPoints;

    float _currentTime;

    float _speedMultiplier;

    bool _isSpawning;



    void Start()
    {
        _currentTime = timeBetweenSpawn;

    }
    public void Update()
    {
        if (!_isSpawning)
        {
            return;
        }

        // Incrementa el tiempo por cada frame
        _currentTime += Time.deltaTime;

        _speedMultiplier += Time.deltaTime * 0.1F;

        //Si el tiempo es igual o mayor al tiempo entre objetos por aparecer
        if (_currentTime >= timeBetweenSpawn)
        {
            //Resetea el tiempo
            _currentTime = 0.0F;

            //Asigna aleatoreamente un nuevo objeto para ahcerlo aparecer
            int spawningIndex = Random.Range(0, spawningObjects.Length);
            Transform prefab = spawningObjects[spawningIndex];

            //Asigna la posicion en la que puede aparecer
            SpawingObjectController controller = prefab.GetComponent<SpawingObjectController>();
            int[] spawningPoints = controller.GetSpawningPoints();
            spawningIndex = spawningPoints[Random.Range(0, spawningPoints.Length)];
            //Crea la instancias del prefab

            foreach (Transform point in this.spawningPoints)
            {
                if (point.gameObject.name.Equals("Point " + spawningIndex.ToString()))
                {
                    Instantiate(prefab, point.position, Quaternion.identity);
                    break;
                }
            }
        }
    }
    public float GetSpeedMultiplier()
    {
        return _speedMultiplier;
    }
    public void SetIsSpawning(bool isSpawning)
    {
        _speedMultiplier = 0.8F;
        _isSpawning = isSpawning;
    }
}
