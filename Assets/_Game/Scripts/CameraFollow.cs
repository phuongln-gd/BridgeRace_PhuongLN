using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed;
    [SerializeField] Vector3 offset;

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset,Time.deltaTime * speed);
    }
}
