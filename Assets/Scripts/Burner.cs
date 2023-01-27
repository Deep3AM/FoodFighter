using DG.Tweening;
using UnityEngine;

public class Burner : MonoBehaviour
{
    [SerializeField] private Transform bar;
    [SerializeField] private Transform movingSquare;
    [SerializeField] private Transform sweetSpot;
    Sequence movingSequence;
    // Start is called before the first frame update
    void Start()
    {
        MovingSquare();
    }

    private void MovingSquare()
    {
        float rand = Random.Range(0.0f, 1.0f);
        sweetSpot.localPosition = new Vector2(rand * Screen.width - Screen.width / 2, 0);
        movingSquare.localPosition = new Vector2(-Screen.width / 2, 0);
        movingSequence = DOTween.Sequence();
        movingSequence
            .Append(movingSquare.DOMoveX(Screen.width
            - movingSquare.GetComponent<RectTransform>().sizeDelta.x, 3f).SetEase(Ease.Linear))
            .Append(movingSquare.DOMoveX(0, 3f).SetEase(Ease.Linear))
            .SetLoops(-1);
    }

    public void OnClickFireButton()
    {
        if (movingSquare.position.x >= (sweetSpot.position.x - sweetSpot.GetComponent<RectTransform>().sizeDelta.x)
            && movingSquare.position.x <= (sweetSpot.position.x + sweetSpot.GetComponent<RectTransform>().sizeDelta.x))
        {
            Debug.Log("Success");
        }
        else
        {
            Debug.Log("Failed");
        }
        movingSequence.Pause();
        movingSequence.Rewind();
        this.gameObject.SetActive(false);
    }
}
