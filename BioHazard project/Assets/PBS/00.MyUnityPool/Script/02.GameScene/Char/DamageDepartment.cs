using System.Collections;
using System.Collections.Generic;

public class DamageDepartment
{
    public float Damage;

    public DamageDepartment(float damage_)
    {
        this.Damage = damage_;
    }
}

public interface IDamageDepartment
{
    public void HitDamage(DamageDepartment damage_)
    {
        /* Virtual method */
    }
}
