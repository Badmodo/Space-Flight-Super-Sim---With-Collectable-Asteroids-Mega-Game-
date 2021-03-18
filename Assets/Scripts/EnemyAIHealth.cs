using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIHealth : MonoBehaviour
{
    public GameObject Drone;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            EnemyAi.health = -1;
            //Destroy(collision.gameObject);
            Drone.SetActive(false);
        }
    }
}
