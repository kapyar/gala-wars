using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class NameGeneratorUIController : MonoBehaviour
    {
        private const string FilePath = "names.json";

        [SerializeField] private InputField _inputField;

        private List<string> _names = new List<string>();

        private void Awake()
        {
            // var str = _fileService.FileToString(FilePath);

            // _names = JsonConvert.DeserializeObject<List<string>>(str);
            _names = new List<string>
            {
                "Bob",
                "Jake",
                "Albert",
                "SuperBoy"
            };
        }

        public void NextName()
        {
            _inputField.text = GetRandomName();
        }

        private string GetRandomName()
        {
            return _names.Count > 0 ? _names[Random.Range(0, _names.Count - 1)] : string.Empty;
        }
    }
}