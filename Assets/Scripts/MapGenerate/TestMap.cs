using System.Collections.Generic;
using UnityEngine;

public class TestMap : MonoBehaviour
{
    [SerializeField] MapGenrator mapGenrator;
    [HideInInspector] public List<int> idx = new List<int>();
    Node currentNode = null;
    // Start is called before the first frame update
    public void LoadState()
    {
        idx = (List<int>)ES3.Load("testtesttest", Application.persistentDataPath + "/testint");
        currentNode = mapGenrator.nodes[0][0];
        currentNode.image.color = Color.red;
        for (int i = 0; i < idx.Count; i++)
        {
            if (currentNode.isLast)
            {
                Debug.Log("this is the last node");
                return;
            }
            int nextNodeIDX = idx[i];
            currentNode.pathImages[nextNodeIDX].color = Color.yellow;
            currentNode = currentNode.childNodes[nextNodeIDX];
            currentNode.image.color = Color.red;
        }
    }

    public void StartNode()
    {
        currentNode = mapGenrator.nodes[0][0];
        currentNode.image.color = Color.red;
    }

    public void NextNode()
    {
        if (currentNode.isLast)
        {
            Debug.Log("this is the last node");
            return;
        }
        int nextNodeIDX = Random.Range(0, currentNode.childNodes.Count);
        idx.Add(nextNodeIDX);
        ES3.Save("testtesttest", idx, Application.persistentDataPath + "/testint");
        currentNode.pathImages[nextNodeIDX].color = Color.yellow;
        currentNode = currentNode.childNodes[nextNodeIDX];
        currentNode.image.color = Color.red;
        //if (currentNode.MapNodeType == Enum.MapNodeType.Monster || currentNode.MapNodeType == Enum.MapNodeType.EpicMonster)
        //    SceneManager.LoadScene("BattleDemo");
    }
}
