using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExitDoorBefore : MonoBehaviour
{
    public BoxCollider exitdoor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            other.GetComponent<Character>().currentStage += 1;
            exitdoor.isTrigger = true;
        }
    }
}
