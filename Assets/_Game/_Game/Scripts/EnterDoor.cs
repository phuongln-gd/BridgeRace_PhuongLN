using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDoor : MonoBehaviour
{
    public BoxCollider enterdoor;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            if(other.GetComponent<Character>().brickCount > 0)
            {
                enterdoor.isTrigger = true;
            }
            else
            {
                enterdoor.isTrigger = false;
            }
        }
    }
}
