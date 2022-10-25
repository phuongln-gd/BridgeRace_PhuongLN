using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using UnityEditor;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;
using Color = UnityEngine.Color;
using System.Threading;

public class Player : Character
{
    [SerializeField] private Transform tf;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask bridgeLayer;

    private bool IsMoveForward;
    private void Start()
    {
        IsMoveForward = true;
    }
    void FixedUpdate()
    {
         Move();
    }

    private void Update()
    {
        if (CheckStair())
        {
            Debug.Log("Player in stair");
        }
        BuildBridge();
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

   
    public void Move()
    {
        // di chuyen player bang ban phim
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        
        Vector3 moveDirection;
        if (!IsMoveForward && verticalInput > 0)
        {
            moveDirection = new Vector3(horizontalInput, 0, 0);
        }
        else
        {
            moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        }
        Vector3 nextpoint = moveDirection + transform.position;

        // quay nhan vat
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection,Vector3.up);
            tf.rotation = Quaternion.RotateTowards(tf.transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        RaycastHit hit;
        if (Physics.Raycast(nextpoint, Vector3.down,out hit, 5f, groundLayer) 
            || Physics.Raycast(nextpoint, Vector3.down, out hit, 5f, bridgeLayer))
        {
            //Debug.Log(tf.position  +"____ "+nextpoint);
            nextpoint = hit.point + Vector3.up * 1.3f;
            tf.position = Vector3.MoveTowards(tf.position, nextpoint, moveSpeed * Time.deltaTime);
           
        }
    }
}
