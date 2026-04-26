using UnityEngine;
using InfimaGames.LowPolyShooterPack;

namespace InfimaGames.LowPolyShooterPack.Extra
{
    /// <summary>
    /// This script allows for creating new weapon variations by modifying an existing weapon prefab at runtime.
    /// It can be used to simulate different WW2 weapons like those in Polyfield.
    /// </summary>
    public class ExtraWeapon : MonoBehaviour
    {
        [Header("Base Weapon Setup")]
        public GameObject baseWeaponPrefab; // The prefab to clone (e.g., M4 or Handgun)
        
        [Header("Polyfield Weapon Stats")]
        public string weaponName;
        public bool isAutomatic;
        public bool isBoltAction;
        public int rpm = 600;
        public float spread = 0.1f;
        public float projectileImpulse = 500f;
        public int magazineSize = 30;

        public void ApplyToWeapon(Weapon weapon)
        {
            // We use reflection or public setters if available. 
            // Since some fields in Weapon are private, we might need to modify Weapon.cs to make them accessible 
            // or use a custom initialization method.
            
            // For now, let's assume we can set these if we modify Weapon.cs or use a subclass.
            Debug.Log($"Applying stats for {weaponName} to weapon {weapon.name}");
        }
    }
}
