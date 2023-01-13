using System.Collections;
using UnityEngine;
using UnityEngine.Pool;
public class FoodTouchImagePool : MonoBehaviour
{
    [SerializeField] private FoodTouchImageUI pFoodTouchImageUI;
    private IObjectPool<FoodTouchImageUI> pool;

    private void Awake()
    {
        pool = new ObjectPool<FoodTouchImageUI>
            (
            InitPool,
            OnGet,
            OnRelease,
            OnDestroyInPool,
            defaultCapacity: 100,
            maxSize: 100
            );
    }

    private void Start()
    {
        StartCoroutine(TestCo());
    }

    private FoodTouchImageUI InitPool()
    {
        FoodTouchImageUI foodTouchImageUI = Instantiate(pFoodTouchImageUI);
        foodTouchImageUI.SetPool(pool);
        return foodTouchImageUI;
    }

    private void OnGet(FoodTouchImageUI foodTouchImageUI)
    {
        foodTouchImageUI.gameObject.SetActive(true);
        foodTouchImageUI.transform.SetParent(this.transform);
        float x = Random.Range(0.0f, 1.0f);
        float y = Random.Range(0.0f, 1.0f);
        foodTouchImageUI.transform.position = new Vector2(x * Screen.width, y * Screen.height);
    }

    private void OnRelease(FoodTouchImageUI foodTouchImageUI)
    {
        foodTouchImageUI.gameObject.SetActive(false);
    }

    private void OnDestroyInPool(FoodTouchImageUI foodTouchImageUI)
    {
        Destroy(foodTouchImageUI.gameObject);
    }

    private IEnumerator TestCo()
    {
        pool.Get();
        yield return new WaitForSeconds(1f);
        yield return TestCo();
    }
}
