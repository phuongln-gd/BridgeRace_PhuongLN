using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickStage : MonoBehaviour
{
    public MeshRenderer rend;
    public Stage stage;

    private void Awake()
    {
        stage = FindObjectOfType<Stage>();
    }
    public void OnInit()
    {
    }
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
                character.AddBrick();
                stage.SpawnBrickAgain(gameObject.transform.position,rend.material.color);
                OnDespawn();
            }
        }
    }
}
