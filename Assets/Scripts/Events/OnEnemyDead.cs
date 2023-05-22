using Scriptables.Events;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Events/" + nameof(OnEnemyDead))]
public class OnEnemyDead : BaseEventSO<Enemy>
{
}