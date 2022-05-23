using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public Animator animator;
    
    public void OpenDoor ()
    {
        animator.SetTrigger("openDoor");
    }

}