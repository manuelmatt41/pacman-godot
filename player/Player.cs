using Godot;
using System;

public partial class Player : Area2D
{

    [Export]
    public int Speed = 200; //How fast the player will move (pixels/sec)º
    public Vector2 Velocity = Vector2.Zero;
    public AnimatedSprite2D AnimatedSprite2D;

    private DefaultStateMachine<Player, State<Player>> DefaultStateMachine;
    public State<Player> nextState;

    //States
    public WalkDownState WalkDownState;
    public WalkUpState WalkUpState;
    public WalkLeftState WalkLeftState;
    public WalkRightState WalkRightState;

    public bool WantToDown { get => OnlyPresDown && !DefaultStateMachine.IsInState(WalkDownState); }
    public bool WantToUp { get => OnlyPressUp && !DefaultStateMachine.IsInState(WalkUpState); }
    public bool WantToLeft { get => OnlyPressLeft && !DefaultStateMachine.IsInState(WalkLeftState); }
    public bool WantToRight { get => OnlyPressRight && !DefaultStateMachine.IsInState(WalkRightState); }

    public bool OnlyPressRight { get => Input.IsActionPressed("moveRight") && !Input.IsActionPressed("moveLeft") && !Input.IsActionPressed("moveUp") && !Input.IsActionPressed("moveDown"); }
    public bool OnlyPressLeft { get => Input.IsActionPressed("moveLeft") && !Input.IsActionPressed("moveRight") && !Input.IsActionPressed("moveUp") && !Input.IsActionPressed("moveDown"); }
    public bool OnlyPressUp { get => Input.IsActionPressed("moveUp") && !Input.IsActionPressed("moveLeft") && !Input.IsActionPressed("moveRight") && !Input.IsActionPressed("moveDown"); }
    public bool OnlyPresDown { get => Input.IsActionPressed("moveDown") && !Input.IsActionPressed("moveLeft") && !Input.IsActionPressed("moveUp") && !Input.IsActionPressed("moveRight"); }


    public override void _Ready()
    {
        DefaultStateMachine = GetNode<DefaultStateMachineNode>("StateMachine").CreateDefaultStateMachine<Player, State<Player>>();
        AnimatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        DefaultStateMachine.Entity = this;
        WalkDownState = new WalkDownState();
        WalkUpState = new WalkUpState();
        WalkLeftState = new WalkLeftState();
        WalkRightState = new WalkRightState();
        DefaultStateMachine.ChangeState(WalkRightState);
    }

    public override void _Process(double delta)
    {
        DefaultStateMachine.Update();
        if (nextState != null)
        {
            DefaultStateMachine.ChangeState(nextState);
            nextState = null;
        }

        if (Velocity.Length() > 0)
        {
            Velocity = Velocity.Normalized() * Speed;
            AnimatedSprite2D.Play();
        }
        else
        {
            AnimatedSprite2D.Stop();
        }

        Position += Velocity * (float)delta;
    }
}
