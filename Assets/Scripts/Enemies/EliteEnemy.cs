using UnityEngine;

public class EliteEnemy : Enemy
{
    protected override void Awake()
    {
        base.Awake();
        
    }


    protected override void Update()
    {
        base.Update();

    }

    protected void EliteTransform()
    {
        transform.localScale *= 2f;
    }
}
