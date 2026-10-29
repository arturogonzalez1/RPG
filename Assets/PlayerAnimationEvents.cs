using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = GetComponentInParent<Player>();
    }

    private void EnableMovementAndJump() => player.EnableMovementAndJump(true);

    private void DisableMovementAndJump() => player.EnableMovementAndJump(false);
}
