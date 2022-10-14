using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isClosed;
    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    public void OnInit()
    {
        isClosed = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
