using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] private Player playerController;

    //private void Start()
    //{
    //    var playerController = GetComponent<Player>();
    //}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        playerController.TakeDamage(20);
    }
}
