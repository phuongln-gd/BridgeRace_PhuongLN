using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField] private List<GameObject> bricks;
    [SerializeField] private List<GameObject> listBrickPrefabs;
    List<Vector3> brickPositions;
    void Start()
    {
        OnInit();
    }

    public void OnInit()
    {
        brickPositions = new List<Vector3>();
        for (int i = 0; i < bricks.Count; i++)
        {
            brickPositions.Add(bricks[i].transform.position);
        }
        for (int i = 0; i < bricks.Count; i++)
        {
            int numRand = Random.Range(0, brickPositions.Count);
            bricks[i].transform.position = brickPositions[numRand];
            brickPositions.Remove(brickPositions[numRand]);
        }
    }

    internal void SpawnBrickAgain(Vector3 pos,Color c)
    {
        StartCoroutine(DelaySpawnNewBrick(pos,c));
    }

    IEnumerator DelaySpawnNewBrick(Vector3 pos, Color c)
    {
        int timeDelay = Random.Range(5, 10);
        yield return new WaitForSeconds(timeDelay);
        GameObject newBrick;
        for(int i = 0; i < listBrickPrefabs.Count; i++)
        {
            if (listBrickPrefabs[i].GetComponent<BrickStage>().rend.sharedMaterial.color == c)
            {
                newBrick = listBrickPrefabs[i] as GameObject;
                Instantiate(newBrick, pos, Quaternion.identity);
                break;
            }
        }
    }
}
