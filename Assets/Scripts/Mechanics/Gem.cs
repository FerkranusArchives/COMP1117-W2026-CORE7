using UnityEngine;

public class Gem : Collectible
{
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollect();
    }

    protected override void OnCollect()
    {
        Debug.Log("Gem Collected!");
        base.OnCollect();
    }

    public void DoGemBehaviour()
    {
        Debug.Log("Gem Spawned!");
    }
}
