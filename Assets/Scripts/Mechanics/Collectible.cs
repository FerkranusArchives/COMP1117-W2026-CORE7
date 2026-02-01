using Unity.VisualScripting;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    protected virtual void OnCollect()
    {
        Debug.Log("Item Picked Up!");
        Destroy(gameObject);
    }
}
