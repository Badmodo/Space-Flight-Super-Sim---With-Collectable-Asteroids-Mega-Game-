using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHitAnything : MonoBehaviour
{
    private void Update()
    {
        //this can be seen in run time if the asteroid can see anything with a collider
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        //if the ray from the asteroid hits a collider it is red
        if (Physics.Raycast(ray, out hitInfo, 100))
        {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
        }
        else
        {
            //otherwise its green
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.green);
        }
    }
}
