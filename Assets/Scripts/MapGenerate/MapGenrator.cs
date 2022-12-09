using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Node
{
    [SerializeField] int x;
    [SerializeField] int y;

    public Node(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}

[System.Serializable]
public class NodeList
{
    public List<Node> nodes;

    public NodeList()
    {
        nodes = new List<Node>();
    }

    public void Add(Node node)
    {
        nodes.Add(node);
    }
}

public class MapGenrator : MonoBehaviour
{
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private List<NodeList> nodes = new List<NodeList>();
    [SerializeField] private GameObject pNodeImage;
    private List<GameObject> nodeImages = new List<GameObject>();

    public void Generate()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        nodes.Clear();
        foreach (GameObject image in nodeImages)
        {
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
            NodeList currentNodes = new NodeList();
            for (int x = 0; x < currentNodetargetNum; x++)
            {
                Node newNode = new Node(x, y);
                currentNodes.Add(newNode);
                GameObject tempImage = Instantiate(pNodeImage);
                tempImage.transform.SetParent(this.gameObject.transform);
                tempImage.transform.position = new Vector2(startX + x * widthScale, startY + y * heightScale);
                nodeImages.Add(tempImage);
            }
            nodes.Add(currentNodes);
        }
    }
}

