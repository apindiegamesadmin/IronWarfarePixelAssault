using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TutorialBossBattle : MonoBehaviour
{
    [SerializeField] TankController bossTankController;
    Damagable bossDamagable;

    private void Awake()
    {
        bossDamagable = bossTankController.GetComponent<Damagable>();
    }

    void Start()
    {
        int length = bossTankController.turrets.Count;
        for (int i = 1; i < length; i++)
        {
            bossTankController.turrets.RemoveAt(1);// Only main cannon active, Remove other guns
        }
    }

    void Update()
    {

    }

    public void CheckBossHealth()
    {
        if (bossDamagable.Health <= ((20.0f / 100) * bossDamagable.MaxHealth)) // If the boss health is less than or equal to the 20% of Max Health
        {
            Debug.Log("Stage 4");// Rampage
        }
        else if (bossDamagable.Health <= ((50.0f / 100) * bossDamagable.MaxHealth)) // If the boss health is less than or equal to the 50% of Max Health
        {
            Debug.Log("Stage 3");
            Turret[] turrent = bossTankController.GetComponentsInChildren<Turret>();
            bossTankController.turrets = turrent.ToList<Turret>();// All guns active
        }
        else if (bossDamagable.Health <= ((70.0f / 100) * bossDamagable.MaxHealth)) // If the boss health is less than or equal to the 70% of Max Health
        {
            Debug.Log("Stage 2");
            Turret[] turrent = bossTankController.GetComponentsInChildren<Turret>();
            bossTankController.turrets = turrent.ToList<Turret>();

            int length = bossTankController.turrets.Count;
            for (int i = 3; i < length; i++)
            {
                bossTankController.turrets.RemoveAt(3);// Only main cannon and front guns active, Remove other guns
            }
        }
    }
}
