using UnityEngine;

public class Enemy : Character
{
    [Header("Enemy Settings")]
    [SerializeField] private float patrolDistance = 5.0f;

    private Vector2 startPos;
    private int direction = -1; // Direction facing
    protected override void Awake()
    {
        base.Awake();
        startPos = transform.position;
    }

    private void Update()
    {
        float leftBoundary = startPos.x - patrolDistance; // start pos - patrol dist
        float rightBoundary = startPos.x + patrolDistance;

        transform.Translate(Vector2.right * direction * MoveSpeed * Time.deltaTime);

        if(transform.position.x >= rightBoundary)
        {
            direction = -1; //go left
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (transform.position.x <= leftBoundary)
        {
            direction = 1; // go right
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
