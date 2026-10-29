using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField] private float redColorDuration = 1;
    public float currentTimeInGame;
    public float lastTimeWasDamaged;

    public void TakeDamage()
    {
        spriteRenderer.color = Color.red;

        lastTimeWasDamaged = currentTimeInGame;
    }

    private void Update()
    {
        HandleChangeColor();
    }

    private void HandleChangeColor()
    {
        currentTimeInGame = Time.time;

        if (currentTimeInGame > lastTimeWasDamaged + redColorDuration
            && spriteRenderer.color != Color.white)
            TurnWhite();
    }

    private void TurnWhite()
    {
        spriteRenderer.color = Color.white;
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
