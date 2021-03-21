using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIHealth : MonoBehaviour
{
    public GameObject Drone;
    public GameObject Explosion;
    ObjectPoolManager poolManager;


    private void Start()
    {
        poolManager = ObjectPoolManager.Instance;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            EnemyAi.health = -1;
            //Explosion.SetActive(true);
            //Destroy(collision.gameObject);
            DieParticle(collision.transform.position);
            Drone.SetActive(false);
        }
    }
    void DieParticle(Vector3 particlePosition)
    {
        poolManager.SpawnEnemyDeathParticle(particlePosition, Quaternion.identity);
    }

}
