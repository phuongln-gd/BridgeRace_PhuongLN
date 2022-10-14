using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


// gach tren stage
public class Brick : MonoBehaviour
{
    public MeshRenderer rend;
    public StageBrick stageBrick;
    private void Start()
    {
        stageBrick = FindObjectOfType<StageBrick>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.GetComponent<Character>().rend.material.color == rend.material.color && rend.enabled)
            {
                other.GetComponent<Character>().AddBrick();
                stageBrick.SpawnNewBrick(transform.position);
                Destroy(gameObject);
            }
        }
    }
}
