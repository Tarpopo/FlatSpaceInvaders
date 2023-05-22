using UnityEngine;

[CreateAssetMenu(menuName = "Data/PLayerData")]
public class PlayerData : ScriptableObject
{
    public OnPlayerDead OnPlayerDead;
    public OnPlayerTakeDamage OnPlayerTakeDamage;
    public float MoveSpeed = 0.1f;
}