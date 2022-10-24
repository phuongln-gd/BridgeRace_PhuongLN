using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickStage : MonoBehaviour
{
    public MeshRenderer rend;


    public void OnDespawn()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            Character character = other.GetComponent<Character>();
            if (character.rend.material.color == rend.material.color)
            {
                OnDespawn();
                character.AddBrick();
            }
        }
    }
}
