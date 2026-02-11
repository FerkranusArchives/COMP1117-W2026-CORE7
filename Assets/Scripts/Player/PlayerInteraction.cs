using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Interaction Settings")]
    [SerializeField] private float interactRange = 1.5f;
    [SerializeField] private LayerMask interactableLayer;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            PerformInteraction();
        }
    }

    private void PerformInteraction()
    {
        // find everything on interactable layer in circle around fox
        Collider2D hit = Physics2D.OverlapCircle(transform.position, interactRange, interactableLayer);

        // Check if something is hit
        if (hit != null )
        {
            if (hit.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                // Object on layer does have IInteractable
                interactable.Interact();
                Debug.Log($"Interacted with {hit.name}");
            }
        }
    }
}
