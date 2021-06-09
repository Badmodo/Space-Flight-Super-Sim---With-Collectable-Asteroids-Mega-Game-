using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHitPlayer : MonoBehaviour
{
    
    public LayerMask player;

    private void Update()
    {
        //this can be seen in run time if the space junk can see the player
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        //if the ray from the space junk hits the player it is red
        if (Physics.Raycast(ray, out hitInfo, 100, player))
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
