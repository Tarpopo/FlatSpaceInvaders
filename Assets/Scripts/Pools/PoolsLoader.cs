using UnityEngine;
using Utils;

public class PoolsLoader : MonoBehaviour
{
    [SerializeField] private ScriptableObject[] _scriptableObjects;

    private void Awake()
    {
        foreach (var scriptable in _scriptableObjects)
        {
            var loadable = scriptable as ILoadable;
            loadable?.Load();
        }
    }
}