using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MeshCell : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _charText;
    private const int _initialFontSize = 1000;

    private char _char;

    public char Char
    {
        get => _char;
        set
        {
            _char = value;
            _charText.text = _char.ToString();
        }
    }

    public void Show() => gameObject.SetActive(true);

    public void Hide() => gameObject.SetActive(false);

    public void SetFontSize(int maxSide)
    {
        _charText.fontSize = _initialFontSize / maxSide;
    }
}
