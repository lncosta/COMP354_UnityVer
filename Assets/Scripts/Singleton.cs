using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;
    public static T Instance {
        get => _instance;

        protected set {
            if (_instance != null) {
                Debug.Log($"Overriding singleton of type '{typeof(T).Name}'");
                Destroy(_instance); // Remove instance to be overriden.
            }
            _instance = value;
        }
    }

    /// <summary>
    /// Should be overriden and contain: <c>Instance = this;</c>
    /// <br>This isn't very clean, but it lets singletons assign
    /// themselves without requirng scene-wide searches.</br>
    /// </summary>
    protected virtual void Awake() { }
}