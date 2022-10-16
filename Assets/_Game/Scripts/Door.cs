using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private BoxCollider door;
    [SerializeField] private GameObject target;

    private bool isClosed;

    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    // Update is called once per frame
    void Update()
    {
        SetStatusDoor();
    }
    public void OnInit()
    {
        closeDoor();
    }

    public void openDoor()
    {
        isClosed = false;
        door.isTrigger = true;
    }

    public void closeDoor()
    {
        isClosed = true;
        door.isTrigger = false;
    }

    public void SetStatusDoor()
    {
        if (!target.GetComponent<Character>().OnBridge && target.GetComponent<Character>().CountBrick <= 0)
        {
            closeDoor();
        }
        else
        {
            openDoor();
        }
    }
}
