using TMPro;
using UnityEngine;

public class CoinsCounterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Collector collector;

    private void Update()
    {
        _text.text = "Coins: " + collector.QuantityCoins.ToString();

    }
}