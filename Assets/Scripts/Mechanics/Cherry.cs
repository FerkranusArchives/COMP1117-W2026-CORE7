using UnityEngine;

public class Cherry : Collectible
{
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollect();
    }
    protected override void OnCollect()
    {
        Debug.Log("Cherry Collected!");
        base.OnCollect();
    }
}
