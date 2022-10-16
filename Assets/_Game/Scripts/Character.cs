using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Character : MonoBehaviour
{
    [SerializeField] private GameObject addBrickPosition; // vi tri them gach tren lung character
    //prefabs
    [SerializeField] private GameObject characterBrickPerfab; // prefab mau gach character
    //list color player brick 
    [SerializeField] private List<GameObject> characterBrickList; // danh sach mau gach character

    public MeshRenderer rend; // rend cua character
    public int currentStage = 0; // tang hien tai cua character

    private bool onBridge;
    public bool OnBridge
    {
        get { return onBridge; }
        set { onBridge = value; }
    } 
    private List<GameObject> listBrick = new List<GameObject>(); // danh sach gach tren lung player
    private int countBrick = 0; // so gach tren lung player
    public int CountBrick
    {
        get { return countBrick; }
        set { countBrick = value; }
    }
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
        onBridge = false;
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

    // Check character in bridge

}
