using TMPro;
using UnityEngine;

public class LevelCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _tmpText;
    [SerializeField] private OnAllEnemyEnd _onAllEnemyEnd;
    [SerializeField] private OnPlayerDead _onPlayerDead;
    private int _Level = 1;

    private void OnEnable()
    {
        UpdateText();
        _onAllEnemyEnd.Subscribe(AddCount);
        _onPlayerDead.Subscribe(ResetCount);
    }

    private void OnDisable()
    {
        _onAllEnemyEnd.Unsubscribe(AddCount);
        _onPlayerDead.Unsubscribe(ResetCount);
    }

    private void AddCount()
    {
        _Level++;
        UpdateText();
    }

    private void ResetCount()
    {
        _Level = 1;
        UpdateText();
    }

    private void UpdateText() => _tmpText.text = $"LEVEL {_Level}";
}