using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class StageBrick : MonoBehaviour
{
    [SerializeField] List<GameObject> listBrick;
    [SerializeField] List<GameObject> listBrickPrefab;
    
    private List<Vector3> newList;

    void Start()
    {
        OnInit();
    }

    public void OnInit()
    {
        newList = new List<Vector3>();
        for(int i = 0; i < listBrick.Count; i++)
        {
            newList.Add(listBrick[i].transform.position);
        }
        SpawnListBrick();
    }

    // spawn list brick 
    public void SpawnListBrick()
    {
        for (int i = 0; i < listBrick.Count; i++)
        {
            int numRand = Random.Range(0, newList.Count);
            listBrick[i].transform.position = newList[numRand];
            newList.Remove(newList[numRand]);
        }
    }

    // spawn new brick
    public void SpawnNewBrick(Vector3 newPosition)
    {
        StartCoroutine(DelaySpawnNewBrick(newPosition));
    }

    IEnumerator DelaySpawnNewBrick(Vector3 newPosition)
    {
        yield return new WaitForSeconds(5f); 
        GameObject newBrick = listBrickPrefab[Random.Range(0, listBrickPrefab.Count)] as GameObject;
        Instantiate(newBrick, newPosition, Quaternion.identity);
    }

}
