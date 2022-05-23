using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interacciondeodjetos : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "door")
        {
            other.GetComponentInParent<door>().OpenDoor();
        }

    }
}
