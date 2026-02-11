using UnityEngine;

public class TreasureChest : MonoBehaviour, IInteractable
{
    [Header("Loot Settings")]
    [SerializeField] private GameObject gemPrefab; // "__Prefab" is ocmmon convention
    [SerializeField] private int gemCount = 3; // How many drop
    [SerializeField] private float launchForce = 5f; // forcew launching gems

    [Header("Visuals")]
    [SerializeField] private Sprite openChestSprite;

    private SpriteRenderer sRend;
    private bool isOpened = false;

    private void Awake()
    {
        sRend = GetComponent<SpriteRenderer>(); // Caching References, get once store variable forever
    }

    public void Interact()
    {
        if(isOpened)
        {
            return;
        }
        
        isOpened = true;
        OpenChest();
    }

    private void OpenChest()
    {
        if(sRend != null && openChestSprite != null)
        {
            sRend.sprite = openChestSprite;
        }
        
        for(int i =0; i < gemCount; i++)
        {
            GameObject gem = Instantiate(gemPrefab, transform.position, Quaternion.identity);
            Rigidbody2D gemRB = gem.GetComponent<Rigidbody2D>();

            if(gemRB != null)
            {
                Vector2 force = new Vector2(Random.Range(-1f, 1f), 1.5f).normalized * launchForce; // mult unit vector by launch force
                gemRB.AddForce(force, ForceMode2D.Impulse);
            }
        }
    }
}
