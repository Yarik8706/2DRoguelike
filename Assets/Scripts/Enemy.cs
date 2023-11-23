using UnityEngine;

public class Enemy : MonoBehaviour, IEssence
{
    public void GetDamage()
    {
        Debug.Log("Attack");
    }
}