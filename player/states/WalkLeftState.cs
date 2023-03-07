using Godot;

public class WalkLeftState :  State<Player>
{
    public void Enter(Player entity)
    {
        entity.Velocity.X = -1f;
        entity.AnimatedSprite2D.RotationDegrees = 180;
    }

    public void Exit(Player entity)
    {
        entity.Velocity.X = 0f;
    }

    public void Update(Player entity)
    {
         if (entity.WantToDown)
        {
            entity.nextState = entity.WalkDownState;
            return;
        }

        if (entity.WantToRight)
        {
            entity.nextState = entity.WalkRightState;
            return;
        }

        if (entity.WantToUp)
        {
            entity.nextState = entity.WalkUpState;
            return;
        }
    }
}