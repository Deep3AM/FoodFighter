using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Node
{
    [SerializeField] int x;
    [SerializeField] int y;
    public bool isConnected = false;
    public List<Node> childNodes;
    public Image image;
    public List<Image> pathImages;
    public bool isLast = false;
    public int X { get { return x; } }
    public int Y { get { return y; } }


    public Node(int x, int y)
    {
        this.x = x;
        this.y = y;
        isConnected = false;
        childNodes = new List<Node>();
        pathImages = new List<Image>();
    }
}

public class MapGenrator : MonoBehaviour
{
    [SerializeField] private int width;
    [SerializeField] private int height;
    public List<List<Node>> nodes = new List<List<Node>>();
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

            List<Node> currentNodes = new List<Node>();
            List<GameObject> nodeImagesList = new List<GameObject>();
            if (y == 0 || y == (height - 1))
            {
                Node newNode = new Node(0, y);
                if (y == height - 1)
                    newNode.isLast = true;
                currentNodes.Add(newNode);
                GameObject tempImage = Instantiate(pNodeImage);
                tempImage.transform.SetParent(this.gameObject.transform);
                tempImage.transform.position = new Vector2(Screen.width / 2, startY + y * heightScale);
                newNode.image = tempImage.GetComponent<Image>();
                Debug.Log(newNode.image);
                nodeImagesList.Add(tempImage);
                nodeImages.Add(nodeImagesList);
                nodes.Add(currentNodes);
            }
            else
            {
                int currentNodetargetNum = Random.Range(1, width);
                Debug.Log(currentNodetargetNum);
                float widthScale = Screen.width / (float)currentNodetargetNum;
                float startX = widthScale / 2;
                for (int x = 0; x < currentNodetargetNum; x++)
                {
                    Node newNode = new Node(x, y);
                    currentNodes.Add(newNode);
                    GameObject tempImage = Instantiate(pNodeImage);
                    tempImage.transform.SetParent(this.gameObject.transform);
                    tempImage.transform.position = new Vector2(startX + x * widthScale, startY + y * heightScale);
                    newNode.image = tempImage.GetComponent<Image>();
                    nodeImagesList.Add(tempImage);
                }
                nodeImages.Add(nodeImagesList);
                nodes.Add(currentNodes);
            }
        }
        LinkNode();
    }

    public void LinkNode()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        for (int i = 0; i < nodes.Count - 1; i++)
        {
            int maxChildNum;
            if (nodes[i + 1].Count > 1)
            {
                maxChildNum = nodes[i + 1].Count - 1;
            }
            else
            {
                maxChildNum = 1;
            }
            for (int j = 0; j < nodes[i].Count; j++)
            {
                int randChildNum = Random.Range(1, maxChildNum + 1);
                List<int> couldBeChildListIdx = new List<int>();
                for (int idx = 0; idx < nodes[i + 1].Count; idx++)
                {
                    couldBeChildListIdx.Add(idx);
                }
                for (int randCountNum = 0; randCountNum < randChildNum; randCountNum++)
                {
                    int randIdx = Random.Range(0, couldBeChildListIdx.Count);
                    nodes[i][j].childNodes.Add(nodes[i + 1][couldBeChildListIdx[randIdx]]);
                    nodes[i + 1][couldBeChildListIdx[randIdx]].isConnected = true;
                    GameObject line = Instantiate(pLineImage);
                    nodes[i][j].pathImages.Add(line.GetComponent<Image>());
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
        for (int i = 1; i < nodes.Count; i++)
        {
            for (int j = 0; j < nodes[i].Count; j++)
            {
                if (!nodes[i][j].isConnected)
                {
                    int randIdx = Random.Range(0, nodes[i - 1].Count);
                    nodes[i - 1][randIdx].childNodes.Add(nodes[i][j]);
                    nodes[i][j].isConnected = true;
                    GameObject line = Instantiate(pLineImage);
                    nodes[i - 1][randIdx].pathImages.Add(line.GetComponent<Image>());
                    line.transform.SetParent(transform);
                    line.GetComponent<RectTransform>().sizeDelta = new Vector2(Vector2.Distance(nodeImages[i - 1][randIdx].transform.position, nodeImages[i][j].transform.position), 4.5f);
                    Vector2 tempVector = new Vector2((nodeImages[i - 1][randIdx].transform.position.x + nodeImages[i][j].transform.position.x) / 2, (nodeImages[i - 1][randIdx].transform.position.y + nodeImages[i][j].transform.position.y) / 2);
                    line.transform.position = tempVector;
                    Vector2 dir = nodeImages[i - 1][randIdx].transform.position - nodeImages[i][j].transform.position;
                    line.transform.rotation = Quaternion.FromToRotation(Vector2.right, dir);
                }
            }
        }
    }
}

