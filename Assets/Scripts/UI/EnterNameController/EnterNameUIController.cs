using UI.EnterNameController.Signals;
using UI.Helpers;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class EnterNameUIController : UIController
{
    [SerializeField] private InputField _inputField;
    [SerializeField] private Text _errorField;


    public void OnSubmitName()
    {
        var name = _inputField.text;

        if (!Validators.ValidateName(name)) return;

        var signal = new SubmitNameSignal
        {
            Name = name
        };

        _signalBus.Fire(signal);
    }
}