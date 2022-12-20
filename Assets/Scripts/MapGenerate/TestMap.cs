using UnityEngine;

public class TestMap : MonoBehaviour
{
    [SerializeField] MapGenrator mapGenrator;
    Node currentNode = null;
    // Start is called before the first frame update
    void Start()
    {

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
        currentNode.pathImages[nextNodeIDX].color = Color.yellow;
        currentNode = currentNode.childNodes[nextNodeIDX];
        currentNode.image.color = Color.red;
    }
}
