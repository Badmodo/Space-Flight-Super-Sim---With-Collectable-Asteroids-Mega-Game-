using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerLeaveTrigger : MonoBehaviour
{
    public Animator player;
    public GameObject youDied;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.enabled = true;
            youDied.SetActive(true);
        }
    }
}
