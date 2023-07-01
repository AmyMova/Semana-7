using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager _instance { get; private set; }
    static readonly object _syncLock = new object();

    [Header("Enemigos")]

    [SerializeField]
    Transform[] spawningEnemies;

    [SerializeField]
    float timeBetweenSpawnEnemies = 3.0F;

    [Header("Plataformas")]

    [SerializeField]
    Transform[] spawningPlatforms;

    [SerializeField]
    float timeBetweenSpawnPlatforms = 3.0F;

    [Header("Otros")]

    [SerializeField]
    Transform[] spawningPoints;

    float _currentTime, _currentTime2;

    float _speedMultiplier;

    //Singleton
    void Awake()
    {
        bool destroyCurrentInstance = true;
        if (_instance == null)
        {
            lock (_syncLock)
            {
                if (_instance == null)
                {
                    _instance = this;
                    DontDestroyOnLoad(gameObject);
                    destroyCurrentInstance = false;
                }
            }
        }
        if (destroyCurrentInstance)
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        _currentTime = timeBetweenSpawnPlatforms;
        _currentTime2 = timeBetweenSpawnEnemies;
    }
    public void Update()
    {
        // Incrementa el tiempo por cada frame
        _currentTime += Time.deltaTime;
        _currentTime2 += Time.deltaTime;
        _speedMultiplier += Time.deltaTime * 0.1F;

        //Si el tiempo es igual o mayor al tiempo entre objetos por aparecer
        if (_currentTime >= timeBetweenSpawnPlatforms)
        {
            //Resetea el tiempo
            _currentTime = 0.0F;

            //Asigna aleatoreamente un nuevo objeto para ahcerlo aparecer
            int spawningIndex = Random.Range(0, spawningPlatforms.Length);
            Transform prefab = spawningPlatforms[spawningIndex];

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
        if (_currentTime2 >= timeBetweenSpawnEnemies)
        {
            //Resetea el tiempo
            _currentTime2 = 0.0F;

            //Asigna aleatoreamente un nuevo objeto para ahcerlo aparecer
            int spawningIndex = Random.Range(0, spawningEnemies.Length);
            Transform prefab = spawningEnemies[spawningIndex];

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
}
