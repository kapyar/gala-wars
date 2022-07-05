using UI.EnterNameController.Signals;
using UI.Helpers;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class EnterNameUIController : UIController
{
    [SerializeField] private InputField _inputField;
    [SerializeField] private Button _confirmBtn;

    public void OnSubmitName()
    {
        var name = _inputField.text;

        if (!Validators.ValidateName(name)) return;

        var signal = new SubmitNameSignal
        {
            Name = name
        };

        _signalBus.Fire(signal);

        Close();
    }

    public void OnValidate()
    {
        _confirmBtn.interactable = _inputField.text.Length > 2;
    }
}