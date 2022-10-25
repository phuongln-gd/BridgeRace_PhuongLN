using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExitDoorAfter : MonoBehaviour
{
    public GameObject exitdoor;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            if (other.GetComponent<Character>().currentStage >= exitdoor.GetComponent<ExitDoor>().currentStage)
            {
                exitdoor.GetComponent<BoxCollider>().isTrigger = false;
            }
        }
    }
}
