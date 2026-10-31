using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    public string enemyName;

    private void Update()
    {
        MoveAround();

        if (Input.GetKeyDown(KeyCode.F))
            Attack();
    }

    public virtual void TakeDamage()
    {
        Debug.Log(enemyName + " takes damage!");
    }

    protected virtual void Attack()
    {
        Debug.Log(enemyName + " attacks!");
    }

    private void MoveAround()
    {
        Debug.Log(enemyName + " moves at speed " + moveSpeed);
    }
}
