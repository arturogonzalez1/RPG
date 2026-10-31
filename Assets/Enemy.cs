using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float MoveSpeed;

    public string EnemyName { get; private set; }

    private void Update()
    {
        //MoveAround();

        if (Input.GetKeyDown(KeyCode.F))
            Attack();
    }

    public virtual void TakeDamage()
    {
        Debug.Log(EnemyName + " takes damage!");
    }

    protected virtual void Attack()
    {
        Debug.Log(EnemyName + " attacks!");
    }

    private void MoveAround()
    {
        Debug.Log(EnemyName + " moves at speed " + MoveSpeed);
    }
}
