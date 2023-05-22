using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private OnEnemyDead _onEnemyDead;
    [SerializeField] private string _name;

    private readonly Dictionary<EnemyType, int> _enemyCounts = new Dictionary<EnemyType, int>()
    {
        { EnemyType.Easy, 50 },
        { EnemyType.Middle, 120 },
        { EnemyType.Hard, 300 },
    };

    private int _count;

    private void Start() => UpdateTextValue();

    private void OnEnable() => _onEnemyDead.Subscribe(AddValue);

    private void OnDisable() => _onEnemyDead.Unsubscribe(AddValue);

    private void UpdateTextValue() => _text.text = _name + _count;

    private void AddValue(Enemy enemy)
    {
        _count += _enemyCounts[enemy.EnemyType];
        UpdateTextValue();
    }
}