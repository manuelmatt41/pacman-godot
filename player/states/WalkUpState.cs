using Godot;

public class WalkUpState : State<Player>
{
    public void Enter(Player entity)
    {
        entity.Velocity.Y = -1f;
        entity.AnimatedSprite2D.RotationDegrees = 270;
    }

    public void Exit(Player entity)
    {
        entity.Velocity.Y = 0f;
    }

    public void Update(Player entity)
    {
        if (entity.WantToDown)
        {
            entity.nextState = entity.WalkDownState;
            return;
        }

        if (entity.WantToLeft)
        {
            entity.nextState = entity.WalkLeftState;
            return;
        }

        if (entity.WantToRight)
        {
            entity.nextState = entity.WalkRightState;
            return;
        }
    }
}