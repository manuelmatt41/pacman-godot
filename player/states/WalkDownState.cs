using Godot;

public class WalkDownState : State<Player>
{
    public void Enter(Player entity)
    {
        entity.Velocity.Y = 1f;
        entity.AnimatedSprite2D.RotationDegrees = 90;
    }

    public void Exit(Player entity)
    {
        entity.Velocity.Y = 0f;
    }

    public void Update(Player entity)
    {
         if (entity.WantToRight)
        {
            entity.nextState = entity.WalkRightState;
            return;
        }

        if (entity.WantToLeft)
        {
            entity.nextState = entity.WalkLeftState;
            return;
        }

        if (entity.WantToUp)
        {
            entity.nextState = entity.WalkUpState;
            return;
        }
    }
}