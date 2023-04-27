using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public GameObject[] GameTiles;//1.grass,2.Tree,3.Mountain,4.Water
    public GameObject MapObj;
    public GameObject cammove;
    public Button[] Button;
    public int MapType;
    public bool CreateMap = false;
    public Text MapSize;
    int size;
	// Use this for initialization
	void Start () {
        MapType = 1;
    }

    // Update is called once per frame
    void Update() {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        float z = Input.GetAxisRaw("Mouse ScrollWheel");

        cammove.transform.position = cammove.transform.position + new Vector3(x, y, z * 100.0f) * 3.0f * Time.deltaTime;

        if (CreateMap == true)
        {
            CreateMap = false;
            if (MapType == 1)
                size = 11;
            else if (MapType == 2)
                size = 13;
            else
                size = 15;

            for (int a = -size/2; a < size/2; a++)
            {
                for (int b = -size/2; b < size/2; b++)
                {
                    int rnd = Random.Range(0, 3);
                    if (a == (size / 2) + 1 && b == (size / 2) + 1)
                    {
                        rnd = 3;
                    }
                    else
                    {
                        if (rnd == 2)
                        {
                            rnd = Random.Range(0, 3);
                        }
                    }
                    GameObject Obj = Instantiate(GameTiles[rnd], MapObj.transform);
                    Obj.transform.position = new Vector2(a, b);
                }
            }
        }
	}

    public void NewGame()
    {
        Button[0].gameObject.SetActive(false);
        CreateMap = true;
    }

    public void SizeUpbutton()
    {
        if (MapType < 3)
        {
            MapType++;
            MapSize.text = MapType.ToString();
        }
    }

    public void SizeDownbutton()
    {
        if (MapType > 1)
        {
            MapType--;
            MapSize.text = MapType.ToString();
        }
    }
}
