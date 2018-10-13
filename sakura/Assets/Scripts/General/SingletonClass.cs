public class SingletonClass<T> where T : class, new() {
    private static T m_instance = null;

    public static T Instance
    {
        get
        {
            return m_instance;
        }
    }

    public static void Create() {
        m_instance = new T();
    }

    public static void Release() {
        m_instance = null;
    }
}