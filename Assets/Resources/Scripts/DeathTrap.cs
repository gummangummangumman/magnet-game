using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrap : MonoBehaviour
{

    public bool split = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && split)
        {

        }
    }
}
