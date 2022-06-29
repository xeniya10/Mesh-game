using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField _widthInput;
    [SerializeField] private TMP_InputField _heightInput;
    [SerializeField] private TextMeshProUGUI _warningText;

    private string _warningTooBigValue = "Input value is too big";
    private string _warningTooSmallValue = "Input value is too small";

    public event Action GenerateMeshEvent;
    public event Action JumbleCellEvent;

    public int Width
    {
        get
        {
            var width = Int32.Parse(_widthInput.text);
            return width;
        }
    }

    public int Height
    {
        get
        {
            var height = Int32.Parse(_heightInput.text);
            return height;
        }
    }

    public void SetWarningBigValue() => _warningText.SetText(_warningTooBigValue);

    public void SetWarningSmallValue() => _warningText.SetText(_warningTooSmallValue);

    public void ResetWarningText() => _warningText.SetText("");

    public void OnClickGenerateButton() => GenerateMeshEvent?.Invoke();

    public void OnClickJumbleButton() => JumbleCellEvent?.Invoke();
}
