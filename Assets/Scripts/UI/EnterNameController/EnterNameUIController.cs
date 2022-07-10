using Game;
using UI.EnterNameController.Signals;
using UI.Helpers;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using Zenject;

public class EnterNameUIController : UIController
{
    [SerializeField] private InputField _inputField;
    [SerializeField] private Button _confirmBtn;

    [Inject] private SignalBus _signalBus;

    private void Start()
    {
        _signalBus.Subscribe<OpenEnterNameWindowSignal>(Open);
    }

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

    public void OnForceClose()
    {
        Close();

        _signalBus.Fire<StartGameSignal>();
    }

    public void OnValidate()
    {
        _confirmBtn.interactable = _inputField.text.Length > 2;
    }
}