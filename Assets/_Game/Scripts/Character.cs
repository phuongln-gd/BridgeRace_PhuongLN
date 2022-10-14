using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private GameObject addBrickPosition;
    [SerializeField] private GameObject characterBrickPerfab;
    [SerializeField] private LayerMask stairGround;
    [SerializeField] private List<GameObject> characterBrickList;

    public MeshRenderer rend;
    public int currentStage = 0;

    private List<GameObject> listBrick = new List<GameObject>();
    private int countBrick = 0;

    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void OnInit()
    {
        countBrick = 0;
        characterBrickPerfab = getCharacterBrickPrefab();
    }


    // lay mau gach o lung character
    public GameObject getCharacterBrickPrefab()
    {
        for(int i = 0;i < characterBrickList.Count; i++)
        {
            if (characterBrickList[i].GetComponent<PlayerBrick>().rend.sharedMaterial.color == rend.material.color)
            {
                return characterBrickList[i];
            }
        }
        return null;
    }

    // xoa gach
    public void RemoveBrick()
    {
        if (listBrick.Count > 0)
        {
            Destroy(listBrick[listBrick.Count - 1]);
            listBrick.Remove(listBrick[listBrick.Count - 1]);
        }
        countBrick -= 1;
    }
    // them gach
    public void AddBrick()
    {
        if (listBrick.Count == 0)
        {
            GameObject newBrick = Instantiate(characterBrickPerfab,
                            addBrickPosition.transform.position,
                            addBrickPosition.transform.rotation);
            listBrick.Add(newBrick);
            newBrick.transform.SetParent(addBrickPosition.transform);
        }
        else if (listBrick.Count > 0)
        {
            GameObject newBrick = Instantiate(characterBrickPerfab,
                            listBrick[listBrick.Count-1].transform.position + new Vector3(0,(float)0.5,0),
                            addBrickPosition.transform.rotation);
            listBrick.Add(newBrick);
            newBrick.transform.SetParent(addBrickPosition.transform);
        }
        countBrick += 1;
    }

    
}
