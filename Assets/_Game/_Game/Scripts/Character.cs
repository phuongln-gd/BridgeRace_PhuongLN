using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected float moveSpeed;
    [SerializeField] Transform firstBrickPosition;
    public MeshRenderer rend;

    [SerializeField] GameObject brickPrefab;
    [SerializeField] GameObject listBrick;
    [SerializeField] protected LayerMask stairLayer;

    List<GameObject> bricks;
    protected int brickCount;

    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnInit()
    {
        bricks = new List<GameObject>();
        brickCount = bricks.Count;
    }

    public virtual void BuildBridge()
    {
        
    }
    public bool CheckStair()
    {
        return (Physics.Raycast(transform.position, Vector3.down, 5f, stairLayer));
    }
    internal virtual void AddBrick()
    {
        brickCount += 1;
        // TH1: bricks chua co gach
        // --> them gach vao vi tri fistBrickPosition ,them vao list
        // TH2: bricks da co gach
        // --> them gach vao vi tri bricks[bricks.count-1] + vector3.up * 0.5f

        if (bricks.Count == 0)
        {
            GameObject newBrick = Instantiate(brickPrefab, firstBrickPosition.transform.position,
                firstBrickPosition.transform.rotation) as GameObject;
            newBrick.GetComponent<CharacterBrick>().SetColor(rend.material.color);
            bricks.Add(newBrick);
            newBrick.transform.SetParent(listBrick.transform);
        }
        else
        {
            GameObject newBrick = Instantiate(brickPrefab, bricks[bricks.Count - 1].transform.position + Vector3.up * 0.5f,
                firstBrickPosition.transform.rotation) as GameObject;
            newBrick.GetComponent<CharacterBrick>().SetColor(rend.material.color);
            bricks.Add(newBrick);
            newBrick.transform.SetParent(listBrick.transform);
        }
    }
    internal virtual void RemoveBrick()
    {
        
    }

}
