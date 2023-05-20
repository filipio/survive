using UnityEngine;

public abstract class WeaponComponent : MonoBehaviour
{
    private Weapon weapon;

    protected abstract void OnWeaponFire();

    protected virtual void Awake()
    {
        weapon = GetComponent<Weapon>();
        weapon.OnFire += OnWeaponFire;
    }

    private void OnDestroy()
    {
        weapon.OnFire -= OnWeaponFire;
    }
}