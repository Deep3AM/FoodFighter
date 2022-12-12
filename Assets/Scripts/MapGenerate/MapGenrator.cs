using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Node
{
    [SerializeField] int x;
    [SerializeField] int y;
    public List<Node> childNodes;

    public Node(int x, int y)
    {
        this.x = x;
        this.y = y;
        childNodes = new List<Node>();
    }
}

public class MapGenrator : MonoBehaviour
{
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private List<List<Node>> nodes = new List<List<Node>>();
    [SerializeField] private GameObject pNodeImage;
    [SerializeField] private GameObject pLineImage;
    private List<List<GameObject>> nodeImages = new List<List<GameObject>>();


    public void Generate()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        nodes.Clear();
        foreach (List<GameObject> images in nodeImages)
        {
            foreach (GameObject image in images)
                Destroy(image);
        }
        nodeImages.Clear();
        float heightScale = Screen.height / (float)height;
        float startY = heightScale / 2;
        for (int y = 0; y < height; y++)
        {
            int currentNodetargetNum = Random.Range(1, width);
            Debug.Log(currentNodetargetNum);
            float widthScale = Screen.width / (float)currentNodetargetNum;
            float startX = widthScale / 2;
            List<Node> currentNodes = new List<Node>();
            List<GameObject> nodeImagesList = new List<GameObject>();
            for (int x = 0; x < currentNodetargetNum; x++)
            {
                Node newNode = new Node(x, y);
                currentNodes.Add(newNode);
                GameObject tempImage = Instantiate(pNodeImage);
                tempImage.transform.SetParent(this.gameObject.transform);
                tempImage.transform.position = new Vector2(startX + x * widthScale, startY + y * heightScale);
                nodeImagesList.Add(tempImage);
            }
            nodeImages.Add(nodeImagesList);
            nodes.Add(currentNodes);
        }
        LinkNode();
    }

    public void LinkNode()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        for (int i = 0; i < nodes.Count - 1; i++)
        {
            int maxChildNum = nodes[i + 1].Count;
            for (int j = 0; j < nodes[i].Count; j++)
            {
                int randChildNum = Random.Range(1, maxChildNum + 1);
                List<int> couldBeChildListIdx = new List<int>();
                for (int idx = 0; idx < maxChildNum; idx++)
                {
                    couldBeChildListIdx.Add(idx);
                }
                for (int randCountNum = 0; randCountNum < randChildNum; randCountNum++)
                {
                    int randIdx = Random.Range(0, couldBeChildListIdx.Count);
                    nodes[i][j].childNodes.Add(nodes[i + 1][couldBeChildListIdx[randIdx]]);
                    GameObject line = Instantiate(pLineImage);
                    line.transform.SetParent(transform);
                    line.GetComponent<RectTransform>().sizeDelta = new Vector2(Vector2.Distance(nodeImages[i][j].transform.position, nodeImages[i + 1][couldBeChildListIdx[randIdx]].transform.position), 4.5f);
                    Vector2 tempVector = new Vector2((nodeImages[i][j].transform.position.x + nodeImages[i + 1][couldBeChildListIdx[randIdx]].transform.position.x) / 2, (nodeImages[i][j].transform.position.y + nodeImages[i + 1][couldBeChildListIdx[randIdx]].transform.position.y) / 2);
                    line.transform.position = tempVector;
                    Vector2 dir = nodeImages[i][j].transform.position - nodeImages[i + 1][couldBeChildListIdx[randIdx]].transform.position;
                    line.transform.rotation = Quaternion.FromToRotation(Vector2.right, dir);
                    couldBeChildListIdx.Remove(couldBeChildListIdx[randIdx]);
                }
            }
        }
    }
}

