using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    [SerializeField] private List<GameObject> bridgeBrickList;
    [SerializeField] private List<GameObject> colorStairList;
    [SerializeField] private Character target;
    
    private GameObject currentColorStair;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // set target in bridge
    public void SetTargetInBridge(Character character)
    {
        this.target = character;
    }
    // set color bridge brick
    public void SetCurrentColorStair()
    {
        for (int i = 0; i < colorStairList.Count; i++)
        {
            if (colorStairList[i].GetComponent<Stair>().rend.sharedMaterial.color == target.rend.material.color)
            {
                currentColorStair = colorStairList[i];
                break;
            }
        }
    }
}
