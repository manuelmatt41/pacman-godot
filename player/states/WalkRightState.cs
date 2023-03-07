using Godot;

public class WalkRightState : State<Player>
{
    public void Enter(Player entity)
    {
        entity.Velocity.X = 1f;
        entity.AnimatedSprite2D.RotationDegrees = 360;
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