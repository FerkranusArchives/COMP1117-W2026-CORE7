using Unity.VisualScripting;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] public GameObject bridge;
    protected void OnTriggerEnter2D(UnityEngine.Collider2D other)
    {
        if (bridge.activeInHierarchy)
        {
            return;
        }

        if (bridge != null)
        {
            if (other.gameObject.CompareTag("Key"))
            {
                bridge.SetActive(true);
            }

        }
    }
}
