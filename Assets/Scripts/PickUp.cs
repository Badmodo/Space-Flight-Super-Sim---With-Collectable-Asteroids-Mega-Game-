using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject PickUpAsteroid;
    public GameObject Text;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(TextPopUp());
        }
    }

    IEnumerator TextPopUp()
    {
        Text.SetActive(true);
        yield return new WaitForSeconds(1f);
        Text.SetActive(false);
        PickUpAsteroid.SetActive(false);

    }
}
