# RPG

Prototipo 2D en Unity de plataformas y combate cuerpo a cuerpo. El jugador se mueve, salta y ataca. Los enemigos heredan de `Enemy` (`EnemyGoblin`, `EnemyArcher`).

## Requisitos

Unity **6000.3.16f1**, plantilla 2D con URP.

## Cómo abrirlo

1. Abre esta carpeta en Unity Hub con esa versión.
2. Carga `Assets/Scenes/SampleScene.unity` y pulsa Play.

## Controles

| Acción | Entrada |
| --- | --- |
| Moverse | A/D o flechas |
| Saltar | Espacio (en el suelo) |
| Atacar | Clic izquierdo (en el suelo) |
| Ataque de enemigos | F (solo escribe en la consola) |

El jugador usa el Input Manager clásico. El asset de Input System todavía no está conectado.

## Scripts

- `Player.cs` y `PlayerAnimationEvents.cs`: movimiento, salto, giro y golpe por animación.
- `Enemy.cs`, `EnemyGoblin.cs`, `EnemyArcher.cs`: daño y ataques de ejemplo.
- `ColdownExample.cs` y `Example.cs`: ejemplos de enfriamiento y del ciclo de vida de un `MonoBehaviour`.
