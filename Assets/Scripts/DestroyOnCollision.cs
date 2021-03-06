using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public GameObject PickUps;
    public GameObject Asteroid;
    public GameObject Explosion;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Asteroid.SetActive(false);
            PickUps.SetActive(true);
            Explosion.SetActive(true);
        }
    }
}
