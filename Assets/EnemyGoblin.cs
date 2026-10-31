using UnityEngine;

public class EnemyGoblin : Enemy
{
    protected override void Attack()
    {
        base.Attack();

        StealMoney();
    }

    public override void TakeDamage()
    {
        base.TakeDamage();

        // Additional logic for goblin-specific damage behavior can be added here
    }

    [ContextMenu("Steal money")]
    private void StealMoney()
    {
        Debug.Log(enemyName + " steal's gold from the player!");
    }
}
