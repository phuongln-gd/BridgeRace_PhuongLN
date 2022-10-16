using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;

public class Slope : MonoBehaviour
{
    [SerializeField] private List<GameObject> bridgeBrickList;
    [SerializeField] private List<GameObject> colorStairList;
    [SerializeField] private Character target;
    public Character Target
    {
        get { return target; }
        set { target = value; }
    }

    //layermask
    [SerializeField] protected LayerMask bridgeGround;
    [SerializeField] protected LayerMask stairGround;

    private List<Vector3> listStair;
    private List<Vector3> stairPositionList;
    private int currentStairNum;

    private GameObject currentColorStairPrefab;

    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnNewStair();
    }

    public void OnInit()
    {
        SetCurrentColorStair();
        currentStairNum = 0;
        listStair = new List<Vector3>();
        stairPositionList = new List<Vector3>();
        for (int i = 0; i < bridgeBrickList.Count; i++)
        {
            stairPositionList.Add(bridgeBrickList[i].transform.position);
        }
        for(int  i = 0; i < bridgeBrickList.Count; i++)
        {
            Destroy(bridgeBrickList[i]);
        }
        bridgeBrickList.Clear();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Debug.Log("character in bridge");
        }
    }

    // set target in bridge
    public void SetTargetInBridge(Character character)
    {
        this.target = character;
    }
    // set current color brick in bridge
    public void SetCurrentColorStair()
    {
        for (int i = 0; i < colorStairList.Count; i++)
        {
            if (colorStairList[i].GetComponent<Stair>().rend.sharedMaterial.color == target.rend.material.color)
            {
                currentColorStairPrefab = colorStairList[i];
                break;
            }
        }
    }

    // Check character in bridge
    public bool CheckCharacterInBridge()
    {
        bool rs = false;
        rs = Physics.Raycast(target.transform.position, Vector3.down, 5f, bridgeGround);
        if (rs)
        {
            target.OnBridge = true;
        }
        else
        {
            target.OnBridge = false;
        }
        return rs;
    }

    // Check character in stair
    public bool CheckCharacterInStair()
    {
        bool rs = false;
        rs = Physics.Raycast(target.transform.position, Vector3.down, 5f, stairGround);
        return rs;
    }

    // spawn new stair
    public void SpawnNewStair()
    {
        // dung tren cau va chua co stair 
        if (CheckCharacterInBridge() && !CheckCharacterInStair())
        {
            if ( Mathf.Abs(target.transform.position.z - stairPositionList[currentStairNum].z) < 0.5f && target.CountBrick >0)
            {
                GameObject newStair = Instantiate(currentColorStairPrefab, stairPositionList[currentStairNum], Quaternion.identity);
                if (currentStairNum < stairPositionList.Count-1)
                {
                    currentStairNum++;
                }
                target.RemoveBrick();
            }
        }
    }
}
