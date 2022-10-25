using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : Character
{
    [SerializeField] private Transform tf;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject finishPoint;

    private bool IsMoveForward;
    private IState currentState;
    private void Start()
    {
        OnInit();  
    }

    void Update()
    {
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
        BuildBridge();
    }

    public override void OnInit() 
    {
        base.OnInit();
        IsMoveForward = true;
        ChangeState(new SeekBrickState());
    }
    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }

        currentState = newState;

        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }
    public override void BuildBridge()
    {
        /* Nhan vat kiem tra nextPoint co phai dang o tren stair khong?
         +,kiem tra rend da duoc bat chua?
                +,kiem tra stair cung mau khong?
                    +, neu cung mau thi di binh thuong
                    -, kiem tra so luong gach tren nguoi nhan vat > 0
                        +, removebrick va thay doi mau gach
                        -, khong di chuyen duoc
            -/ kiem tra so luong gach tren nguoi nhan vat > 0
                        +, removebrick va sinh stair cung mau
                        -, khong di chuyen duoc
       */
        base.BuildBridge();
        Vector3 nextPoint = tf.transform.position + Vector3.forward;
        RaycastHit hit;
        if (Physics.Raycast(nextPoint, Vector3.down, out hit, 5f, stairLayer))
        {
            if (hit.collider.GetComponent<StairBridge>().rend.enabled)
            {
                if (hit.collider.GetComponent<StairBridge>().rend.material.color != rend.material.color)
                {
                    if (brickCount > 0)
                    {
                        IsMoveForward = true;
                        RemoveBrick();
                        hit.collider.GetComponent<StairBridge>().rend.material.color = rend.material.color;
                    }
                    else
                    {
                        // sinh ra 1 vat can phia truoc de player khong di chuyen duoc
                        if (IsMoveForward)
                        {
                            IsMoveForward = false;
                        }
                    }
                }
                else
                {
                    IsMoveForward = true;
                }
            }
            else
            {
                if (brickCount > 0)
                {
                    IsMoveForward = true;
                    RemoveBrick();
                    // sinh ra 1 vien gach moi
                    hit.collider.GetComponent<StairBridge>().rend.enabled = true;
                    hit.collider.GetComponent<StairBridge>().rend.material.color = rend.material.color;
                }
                else
                {
                    if (IsMoveForward)
                    {
                        IsMoveForward = false;
                    }
                }
            }
        }
    }

    public bool IsDestination()
    {
        if (des.x == transform.position.x && des.z == transform.position.z)
        {
            return true;
        }
        return false;
    }

    Vector3 des;
    internal void SetDestination(Vector3 pos)
    {
        des = pos;
        agent.SetDestination(des);
    }

    internal Vector3 GetBrickPoint()
    {
        Collider[] colliders = Physics.OverlapSphere(tf.position,15f);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].CompareTag("BrickStage"))
            {
                if (colliders[i].GetComponent<BrickStage>().rend.material.color == rend.material.color)
                {
                    return colliders[i].transform.position;
                }
            }
        }
        return tf.position;
    }

    public void SetDestinationFinishPoint()
    {
        des = finishPoint.transform.position;
        agent.SetDestination(des);
    }
}
