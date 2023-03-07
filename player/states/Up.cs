using Godot;

public class Up :  State<Player>
{
    public void Enter(Player entity)
    {
        GD.Print("Entre en up");
    }

    public void Exit(Player entity)
    {
        GD.Print("Sali en up");
    }

    public void Update(Player entity)
    {
        GD.Print("up");
    }
}