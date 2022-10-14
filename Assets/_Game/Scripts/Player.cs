using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Player : Character
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private Joystick joystick;
    void Update()
    {
        Moving();
    }
    
    public override void OnInit()
    {
        base.OnInit();
    }

    // Moving
    public void Moving()
    {
        float moveX = joystick.Horizontal * speed;
        float moveZ = joystick.Vertical * speed;   
        rb.velocity = new Vector3(moveX,rb.velocity.y,moveZ);
    }
}
