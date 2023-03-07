using Godot;
using System;

public partial class Player : Area2D
{

    [Export]
    public int Speed = 400; //How fast the player will move (pixels/sec)º
    public Vector2 Velocity = new Vector2(1f, 0f);

    private DefaultStateMachine<Player, State<Player>> DefaultStateMachine;
    public State<Player> nextState;

    //States
    public Walk WalkState;
    public Up UPState;

    public override void _Ready()
    {
        DefaultStateMachine = GetNode<DefaultStateMachineNode>("StateMachine").CreateDefaultStateMachine<Player, State<Player>>();
        WalkState = new Walk();
        UPState = new Up();
        DefaultStateMachine.ChangeState(WalkState);
    }

    public override void _Process(double delta)
    {
        Movement();
        DefaultStateMachine.Update();

        AnimatedSprite2D animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

        if (Velocity.Length() > 0)
        {
            Velocity = Velocity.Normalized() * Speed;
            animatedSprite2D.Play();
        }
        else
        {
            animatedSprite2D.Stop();
        }

        Position += Velocity * (float)delta;
    }

    private void Movement()
    {
        // if (Input.IsActionPressed("moveRight"))
        // {
        //    DefaultStateMachine.ChangeState()
        // }

        // if (Input.IsActionPressed("moveLeft"))
        // {
        //     Velocity.X -= 1;
        // }

        // if (Input.IsActionPressed("moveDown"))
        // {
        //     Velocity.Y += 1;
        // }

        if (Input.IsActionPressed("moveUp"))
        {
            DefaultStateMachine.ChangeState(UPState);
        }
    }
}
