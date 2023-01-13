using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Pool;

public class FoodTouchImageUI : MonoBehaviour, IPointerDownHandler
{
    private IObjectPool<FoodTouchImageUI> foodTouchImageUIPool;
    Sequence seq;
    private void Awake()
    {
        seq = DOTween.Sequence()
        .OnStart(() =>
        {
            transform.localScale = Vector2.zero;
            GetComponent<CanvasGroup>().alpha = 0;
        })
        .Append(transform.DOScale(1.2f, 3))
        .Join(GetComponent<CanvasGroup>().DOFade(1f, 3))
        .Append(transform.DOScale(0f, 3))
        .Join(GetComponent<CanvasGroup>().DOFade(0f, 3))
        .OnComplete(() => { foodTouchImageUIPool.Release(this); });
    }

    private void OnEnable()
    {
        seq.Restart();
    }

    private void OnDisable()
    {
        seq.Rewind();
    }

    public void SetPool(IObjectPool<FoodTouchImageUI> pool)
    {
        foodTouchImageUIPool = pool;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        foodTouchImageUIPool.Release(this);
    }
}
