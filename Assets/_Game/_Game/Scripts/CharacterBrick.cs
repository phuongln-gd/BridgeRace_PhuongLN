using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBrick : MonoBehaviour
{
    public MeshRenderer rend;

    public void SetColor(Color c)
    {
        rend.material.color = c;
    }
}
