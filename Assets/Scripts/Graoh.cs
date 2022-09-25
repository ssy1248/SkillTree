using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graoh
{
    public List<GameObject> listGO;

    public bool[,] connections = new bool[12,12];
    
    //����Ʈ�� ���� ��ų���� ���� ����־���� ��Ŀ�ؼ��� ����Ͽ� ����׷����� �ϼ���Ű��
    //��ų�� ������ Ŀ�ؼ� üũ�� �Ͽ��� true�� ������ �ְ� false�� �Ұ� 

    void Push(GameObject go)
    {
        listGO.Add(go); // push�� �ϸ� list�̱� ������ �������� 
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
