using Enum;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node
{
    private int x;
    private int y;
    public bool isConnected = false;
    public List<Node> childNodes;
    public Image image;
    public List<Image> pathImages;
    public bool isLast = false;
    private Enum.MapNodeType mapNodeType;
    public int X { get { return x; } }
    public int Y { get { return y; } }
    public Enum.MapNodeType MapNodeType { get { return mapNodeType; } }


    public Node(int x, int y)
    {
        this.x = x;
        this.y = y;
        isConnected = false;
        childNodes = new List<Node>();
        pathImages = new List<Image>();
        mapNodeType = Enum.MapNodeType.None;
    }

    public Node(int x, int y, Enum.MapNodeType mapNodeType)
    {
        this.x = x;
        this.y = y;
        isConnected = false;
        childNodes = new List<Node>();
        pathImages = new List<Image>();
        this.mapNodeType = mapNodeType;
    }
}

[System.Serializable]
public class EssentialNodeData
{
    public int x;
    public int y;
    public Enum.MapNodeType mapNodeType;
    public List<Vector2Int> childNodeXY;

    public EssentialNodeData(int x, int y, MapNodeType mapNodeType, List<Vector2Int> childNodeXY)
    {
        this.x = x;
        this.y = y;
        this.mapNodeType = mapNodeType;
        this.childNodeXY = childNodeXY;
    }
}

[System.Serializable]
public class SavableMapData
{
    public int width;
    public int height;
    public List<EssentialNodeData> nodes = new List<EssentialNodeData>();
}


public class MapGenrator : MonoBehaviour
{
    [SerializeField] private int width;
    [SerializeField] private int height;
    public List<List<Node>> nodes = new List<List<Node>>();
    [SerializeField] private GameObject pNodeImage;
    [SerializeField] private GameObject pLineImage;
    [SerializeField] private AnimationCurve randomCurve;
    private List<List<GameObject>> nodeImages = new List<List<GameObject>>();
    private List<GameObject> pathImages = new List<GameObject>();
    [HideInInspector] public SavableMapData savableMapData;


    public void Generate()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        nodes.Clear();
        foreach (List<GameObject> images in nodeImages)
        {
            foreach (GameObject image in images)
            {
                Destroy(image);
            }
        }
        foreach (GameObject path in pathImages)
        {
            Destroy(path);
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
                Node newNode;
                if (y == 0)
                {
                    newNode = new Node(0, y);
                }
                else
                {
                    newNode = new Node(0, y, Enum.MapNodeType.Boss);
                    newNode.isLast = true;
                }
                currentNodes.Add(newNode);
                GameObject tempImage = Instantiate(pNodeImage);
                tempImage.transform.SetParent(this.gameObject.transform);
                tempImage.transform.position = new Vector2(Screen.width / 2, startY + y * heightScale);
                newNode.image = tempImage.GetComponent<Image>();
                newNode.image.color = DebugNodeColor(newNode.MapNodeType);
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
                    Node newNode = new Node(x, y, SelectMapNodeType(randomCurve));
                    currentNodes.Add(newNode);
                    GameObject tempImage = Instantiate(pNodeImage);
                    tempImage.transform.SetParent(this.gameObject.transform);
                    tempImage.transform.position = new Vector2(startX + x * widthScale, startY + y * heightScale);
                    newNode.image = tempImage.GetComponent<Image>();
                    newNode.image.color = DebugNodeColor(newNode.MapNodeType);
                    nodeImagesList.Add(tempImage);
                }
                nodeImages.Add(nodeImagesList);
                nodes.Add(currentNodes);
            }
        }
        LinkNode();
        ExportMap();
    }

    private void LinkNode()
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
                    pathImages.Add(line);
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
                    pathImages.Add(line);
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

    private Color DebugNodeColor(Enum.MapNodeType mapNodeType)
    {
        switch (mapNodeType)
        {
            case Enum.MapNodeType.Monster:
                return Color.yellow;
            case Enum.MapNodeType.EpicMonster:
                return Color.cyan;
            case Enum.MapNodeType.Regain:
                return Color.green;
            case Enum.MapNodeType.Enchant:
                return Color.blue;
            case Enum.MapNodeType.Boss:
                return Color.grey;
            default: return Color.white;
        }
    }

    private Enum.MapNodeType SelectMapNodeType(AnimationCurve randomCurve)
    {
        float randomValue = randomCurve.Evaluate(Random.value);
        if (randomValue <= 0.1f)
            return Enum.MapNodeType.EpicMonster;
        else if (randomValue <= 0.2f)
            return Enum.MapNodeType.Regain;
        else if (randomValue <= 0.3f)
            return Enum.MapNodeType.Enchant;
        else
            return Enum.MapNodeType.Monster;
    }

    public void ExportMap()
    {
        savableMapData = new SavableMapData();
        savableMapData.width = width;
        savableMapData.height = height;
        foreach (List<Node> nodeList in nodes)
        {
            foreach (Node node in nodeList)
            {
                List<Vector2Int> tempChildNodes = new List<Vector2Int>();
                foreach (Node child in node.childNodes)
                {
                    tempChildNodes.Add(new Vector2Int(child.X, child.Y));
                }
                EssentialNodeData tempNodeData = new EssentialNodeData(node.X, node.Y, node.MapNodeType, tempChildNodes);
                savableMapData.nodes.Add(tempNodeData);
            }
        }
        ES3.Save("testtest", savableMapData, Application.persistentDataPath + "/test");
    }
}

