using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    public int currentStage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            if (other.GetComponent<Character>().currentStage > currentStage)
            {
                gameObject.GetComponent<BoxCollider>().isTrigger = false;
            }
        }
    }
}
