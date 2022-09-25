using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphManager : MonoBehaviour
{
    public static GraphManager instance;//MARKER Singleton Pattern
    //private List<GameObject> listGO;

    public bool[,] connections = new bool[12, 12];

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        for (int i = 0; i < 12; i++)
        {
            for(int j = 0; j < 12; j++)
            {
                SetConnection(i, j, false);
            }
        }

        SetConnection(0, 1, true);
        SetConnection(0, 2, true);
        SetConnection(1, 3, true);
        SetConnection(1, 4, true);
        SetConnection(2, 5, true);
        SetConnection(3, 6, true);
        SetConnection(4, 6, true);
        SetConnection(5, 6, true);
        SetConnection(5, 7, true);
        SetConnection(6, 9, true);
        SetConnection(6, 10, true);
        SetConnection(7, 8, true);
        SetConnection(8, 11, true);
        SetConnection(9, 11, true);
        SetConnection(10, 11, true);
    }

    //void Push(GameObject go)
    //{
    //    listGO.Add(go); // push를 하면 list이기 때문에 선입후출 
    //}

    public bool ConnectionCheck(int self, int target)
    {
        return connections[self, target];
    }

    public void SetConnection(int self, int target, bool check = true)
    {
        connections[self, target] = check;
    }
}
