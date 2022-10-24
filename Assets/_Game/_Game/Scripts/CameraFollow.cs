using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] float speed;
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,target.position + offset,speed * Time.deltaTime);
    }
}
