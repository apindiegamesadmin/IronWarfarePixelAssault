using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class TutorialBossBattle : MonoBehaviour
{
    [SerializeField] UnityEvent OnDead;
    [SerializeField] TankController bossTankController;
    [SerializeField] PatrolPath bossPath;
    Damagable bossDamagable;
    Transform playerTank;

    private void Awake()
    {
        bossDamagable = bossTankController.GetComponent<Damagable>();
        playerTank = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < 2; i++)
        {
            bossPath.patrolPoints.Add(playerTank);
        }
    }

    void Start()
    {
        int length = bossTankController.turrets.Count;
        for (int i = 1; i < length; i++)
        {
            bossTankController.turrets.RemoveAt(1);// Only main cannon active, Remove other guns
        }
    }

    public void CheckBossHealth()
    {
        if (bossDamagable.Health <= ((20.0f / 100) * bossDamagable.MaxHealth)) // If the boss health is less than or equal to the 20% of Max Health
        {
            // Rampage
        }
        else if (bossDamagable.Health <= ((50.0f / 100) * bossDamagable.MaxHealth)) // If the boss health is less than or equal to the 50% of Max Health
        {
            Turret[] turrent = bossTankController.GetComponentsInChildren<Turret>();
            bossTankController.turrets = turrent.ToList<Turret>();// All guns active
        }
        else if (bossDamagable.Health <= ((70.0f / 100) * bossDamagable.MaxHealth)) // If the boss health is less than or equal to the 70% of Max Health
        {
            Turret[] turrent = bossTankController.GetComponentsInChildren<Turret>();
            bossTankController.turrets = turrent.ToList<Turret>();

            int length = bossTankController.turrets.Count;
            for (int i = 3; i < length; i++)
            {
                bossTankController.turrets.RemoveAt(3);// Only main cannon and front guns active, Remove other guns
            }
        }
        else
        {
            int length = bossTankController.turrets.Count;
            for (int i = 1; i < length; i++)
            {
                bossTankController.turrets.RemoveAt(1);// Only main cannon active, Remove other guns
            }
        }
    }

    public void NextBoss()
    {
        OnDead.Invoke();
    }

    public void MissionCompleted()
    {
        UnlockMissions missionUnlock = FindObjectOfType<UnlockMissions>();
        missionUnlock.UnlockMission();
        OnDead.Invoke();
        Time.timeScale = 0;
        playerTank.GetComponentInChildren<TankMachineGun>().StopShooting();
    }
}
