using UnityEngine;
using UnityEngine.Events;
public class WorldSwitch : MonoBehaviour, IInteractable
{
    [SerializeField] private Sprite offSprite;
    [SerializeField] private Sprite onSprite;
    [SerializeField] private UnityEvent onActivated;

    private SpriteRenderer sRend;
    private bool isFlipped = false;

    private void Awake()
    {
        sRend = GetComponent<SpriteRenderer>();
    }

    public void Interact()
    {
        isFlipped = !isFlipped;

        sRend.sprite = isFlipped ? onSprite : offSprite;

        if (isFlipped)
        {
            onActivated.Invoke();
        }
    }
}
