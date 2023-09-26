public class AkWeapon : WeaponBase
{
    public override float Damage =>20;
    public override float Rate => 0.1f;

    public override WeaponHandType HandType => WeaponHandType.Two;
}