using UnityEngine;

namespace UI.EnterNameController.Signals
{
    public class SubmitNameSignal
    {
        public string Name;

        public SubmitNameSignal()
        {
            Debug.Log("SubmitNameSignal");
        }
    }
}