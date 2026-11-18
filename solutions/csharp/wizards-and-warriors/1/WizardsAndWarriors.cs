using System.ComponentModel;
using Microsoft.VisualBasic;

abstract class Character
{
    protected readonly string _characterType;
    protected bool _vulerable = false;

    protected Character(string characterType)
    {
        _characterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
    {
        return false;
    }

    public override string ToString()
    {
        return $"Character is a {_characterType}";
    }
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
        return target.Vulnerable() ? 10 : 6;
    }
}

class Wizard : Character
{
    public Wizard() : base("Wizard")
    {
        _vulerable = true;
    }

    public override bool Vulnerable()
    {
        return _vulerable;
    }

    public override int DamagePoints(Character target)
    {
        return _vulerable == true ? 3 : 12;
    }

    public void PrepareSpell()
    {
        _vulerable = false;
    }
}
