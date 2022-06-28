using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField _widthInput;
    [SerializeField] private TMP_InputField _heightInput;
    [SerializeField] private TextMeshProUGUI _warningText;

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

    public void SetWarningText(string text)
    {
        _warningText.SetText(text);
    }

    public void OnClickGenerateButton() => GenerateMeshEvent?.Invoke();

    public void OnClickJumbleButton() => JumbleCellEvent?.Invoke();
}
