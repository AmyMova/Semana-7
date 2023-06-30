using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    Transform[] spawningObjects;

    [SerializeField]
    Transform[] spawningPoints;

    [SerializeField]
    float timeBetweenSpawn = 3.0F;

    float currentTime;
    private void Start()
    {
        currentTime = timeBetweenSpawn;
    }
    void Update()
    {
        // Incrementa el tiempo por cada frame
        currentTime += Time.deltaTime;

        //Si el tiempo es igual o mayor al tiempo entre objetos por aparecer
        if (currentTime >= timeBetweenSpawn)
        {
            //Resetea el tiempo
            currentTime = 0.0F;

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
}
