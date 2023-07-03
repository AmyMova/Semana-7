using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    //ESTE SCRIPT SE LE PONE A CUALQUIER COSA QUE TENGA EL TAG ENEMY

    string playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            //ACA SE REDIRIJE A LA ESCENA DE GAME OVER
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
