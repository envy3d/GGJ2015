using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int maxHealth;

    private int health;

    void Awake()
    {
        health = maxHealth;
    }

    public void RemoveHealth()
    {
        health -= 1;
    }

}
