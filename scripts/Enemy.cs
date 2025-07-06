using Godot;

namespace FamilyMan;

public partial class Enemy : TurnMovement
{
    [Export] public float Hp { get; private set; }
    [Export] public float AttackDmg { get; private set; }

    public void TakeDamage(float amount)
    {
        Hp -= amount;
    }
}