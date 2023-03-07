using Godot;

public class Walk : State<Player>
{
    public void Enter(Player entity)
    {
        GD.Print("Entre en walk");
    }

    public void Exit(Player entity)
    {
        GD.Print("Sali en walk");
    }

    public void Update(Player entity)
    {
        GD.Print(entity is Player);
    }
}