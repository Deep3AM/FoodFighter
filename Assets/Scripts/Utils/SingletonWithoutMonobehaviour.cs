public abstract class SingletonWithoutMonobehaviour<T> where T : SingletonWithoutMonobehaviour<T>, new()
{
    private static T _instance = null;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new T();
                _instance.init();
            }
            return _instance;
        }
    }

    protected virtual void init()
    {

    }
}
