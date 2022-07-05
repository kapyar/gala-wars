using Newtonsoft.Json;
using Services.Files;
using UnityEngine;

namespace Services
{
    public abstract class AbstractSerializableController<T>
        where T : new()
    {
        protected T _data;

        private readonly IFileService _fileService;
        private readonly string _filePath;

        public AbstractSerializableController(IFileService fileService)
        {
            _fileService = fileService;
            _filePath = string.Format("{0}/{1}.json", Application.persistentDataPath, Filename);
        }

        protected abstract string Filename { get; }

        protected abstract void SetInitialValues();

        protected virtual void ValidateValues()
        {
        }

        protected void LoadData()
        {
            if (!_fileService.FileExists(_filePath))
            {
                _data = new T();

                SetInitialValues();

                ValidateValues();

                SaveData();
            }
            else
            {
                var str = _fileService.FileToString(_filePath);
                _data = JsonConvert.DeserializeObject<T>(str);

                ValidateValues();
            }
        }


        public void SaveData()
        {
#if UNITY_EDITOR
            var str = JsonConvert.SerializeObject(_data, Formatting.Indented);
#else
            var str = JsonConvert.SerializeObject(_data);
#endif
            _fileService.StringToFile(str, _filePath);

            OnDataSaved();
        }

        protected virtual void OnDataSaved()
        {
        }
    }
}