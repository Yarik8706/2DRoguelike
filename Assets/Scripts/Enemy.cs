using UnityEngine;

public class Enemy : MonoBehaviour, IEssence
{
    public void GetDamage(int damage)
    {
        Debug.Log("Attack");
    }
}