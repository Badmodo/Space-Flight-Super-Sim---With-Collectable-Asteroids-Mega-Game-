using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryCatches : MonoBehaviour
{
    void Start()
    {
        try
        {
            int.Parse("Come to eat all the asteroids");
        }
        catch (MissingComponentException)
        {
            Debug.LogError("Component Missing");
        }
        catch (PlayerPrefsException)
        {
            Debug.LogError("Your save info has not been kept, live alone");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("x"))
        {
            try
            {
                int.Parse("Why did you press X");
            }
            catch (MissingComponentException)
            {
                Debug.LogError("Not all the bits that need to on there are, sort it out");
            }
            catch (PlayerPrefsException)
            {
                Debug.LogError("This is not being saved, what'd you do?");
            }
        }
    }
}
