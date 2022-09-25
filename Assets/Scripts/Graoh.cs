using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graoh
{
    public List<GameObject> listGO;

    public bool[,] connections = new bool[12,12];
    
    //리스트에 먼저 스킬들을 전부 집어넣어놓고 셋커넥션을 사용하여 방향그래프를 완성시키고
    //스킬을 찍을때 커넥션 체크를 하여서 true면 찍을수 있고 false면 불가 

    void Push(GameObject go)
    {
        listGO.Add(go); // push를 하면 list이기 때문에 선입후출 
    } 

    bool ConnectionCheck(int self, int target)
    {
        return connections[self, target];
    }

    void SetConnection(int self, int target, bool check = true)
    {
        connections[self, target] = check;
    }

}
