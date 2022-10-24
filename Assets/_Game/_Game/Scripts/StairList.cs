using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairList : MonoBehaviour
{
    /* 
     */
    [SerializeField] List<Transform> listStair;
    private List<Vector3> listStairPosition;

    private void Start()
    {
        OnInit();
    }

    public void OnInit()
    {
        listStairPosition = new List<Vector3>();
    }

    
}
