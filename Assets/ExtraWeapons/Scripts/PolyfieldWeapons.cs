using UnityEngine;
using System.Collections.Generic;
using InfimaGames.LowPolyShooterPack;

namespace InfimaGames.LowPolyShooterPack.Extra
{
    public class PolyfieldWeapons : MonoBehaviour
    {
        [System.Serializable]
        public struct WeaponData
        {
            public string name;
            public bool isAutomatic;
            public bool isBoltAction;
            public int rpm;
            public float spread;
            public float projectileImpulse;
            public GameObject basePrefab;
        }

        public List<WeaponData> extraWeapons = new List<WeaponData>();
        public Inventory playerInventory;

        private void Start()
        {
            // If no weapons defined, let's add some default Polyfield-style ones
            if (extraWeapons.Count == 0)
            {
                AddDefaultWeapons();
            }

            SpawnExtraWeapons();
        }

        private void AddDefaultWeapons()
        {
            // Note: In a real project, we would assign existing prefabs here.
            // For this demonstration, we define the stats.
            
            extraWeapons.Add(new WeaponData {
                name = "Kar98k",
                isAutomatic = false,
                isBoltAction = true,
                rpm = 50,
                spread = 0.01f,
                projectileImpulse = 800f
            });

            extraWeapons.Add(new WeaponData {
                name = "MP40",
                isAutomatic = true,
                isBoltAction = false,
                rpm = 500,
                spread = 0.15f,
                projectileImpulse = 400f
            });

            extraWeapons.Add(new WeaponData {
                name = "M1 Garand",
                isAutomatic = false,
                isBoltAction = false,
                rpm = 300,
                spread = 0.05f,
                projectileImpulse = 600f
            });
        }

        private void SpawnExtraWeapons()
        {
            if (playerInventory == null)
            {
                playerInventory = FindObjectOfType<Inventory>();
            }

            if (playerInventory == null) return;

            foreach (var data in extraWeapons)
            {
                if (data.basePrefab == null) continue;

                GameObject newWeaponObj = Instantiate(data.basePrefab, playerInventory.transform);
                newWeaponObj.name = "Extra_" + data.name;
                
                Weapon weaponScript = newWeaponObj.GetComponent<Weapon>();
                if (weaponScript != null)
                {
                    weaponScript.SetWeaponName(data.name);
                    weaponScript.SetAutomatic(data.isAutomatic);
                    weaponScript.SetBoltAction(data.isBoltAction);
                    weaponScript.SetRoundsPerMinute(data.rpm);
                    weaponScript.SetSpread(data.spread);
                    weaponScript.SetProjectileImpulse(data.projectileImpulse);
                }
            }
            
            // Re-initialize inventory to pick up new weapons
            playerInventory.Init();
        }
    }
}
