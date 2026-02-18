using UnityEngine;

public class EntitySpawner : MonoBehaviour // No T because it's only 1 function
                                           // no class variables
{
    public T Spawn<T>(T prefab, Vector3 position) where T : Component // Restrict to anything that is a component
    {
        T gObj = Instantiate(prefab, position, Quaternion.identity);
        return gObj;
    }
}
