using UnityEngine;

public class UISetter : MonoBehaviour
{
    [SerializeField] private UILine _deadLine;
    [SerializeField] private UILine _levelLine;
    [SerializeField] private OnPlayerDead _onPlayerDead;
    [SerializeField] private OnAllEnemyEnd _onAllEnemyEnd;

    private void OnEnable()
    {
        _levelLine.Show();
        _onPlayerDead.Subscribe(_deadLine.Show);
        _onAllEnemyEnd.Subscribe(_levelLine.Show);
    }

    private void OnDisable()
    {
        _onPlayerDead.Unsubscribe(_deadLine.Show);
        _onAllEnemyEnd.Unsubscribe(_levelLine.Show);
    }
}