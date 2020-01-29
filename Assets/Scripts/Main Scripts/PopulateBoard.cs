using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateBoard : MonoBehaviour
{
    public GameObject levelSquarePrefab;
    public GameObject levelSquareGroup;

    // Start is called before the first frame update
    void Start()
    {
        CreateBoard(levelSquarePrefab);
    }

    public void CreateBoard (GameObject square)
    {
        for(int o = 0; o < 10; o++)
        {
            for (int i = 0; i < 10; i++)
            {
                Instantiate(levelSquarePrefab, new Vector3(i, o, 0), levelSquarePrefab.transform.rotation, levelSquareGroup.transform);
                
            }
        }
    }
}
