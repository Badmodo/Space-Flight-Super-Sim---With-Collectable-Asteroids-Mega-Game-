using System.Collections;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager Instance;

    public GameObject pf_Explosion;

    ObjectPool pool_Explosion;

    private void Awake()
    {
        Instance = this;
        pool_Explosion = new ObjectPool(pf_Explosion, transform);
    }

    public void SpawnEnemyDeathParticle (Vector3 pos, Quaternion rotation)
    {
        Debug.Log("SpawnEnemyExplosion");
        pool_Explosion.Spawn(pos, rotation);
    } 
}