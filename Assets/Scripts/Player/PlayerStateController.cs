using Services;
using Services.Files;

namespace Player
{
    public class PlayerStateController: AbstractSerializableController<PlayerDto>
    {
        public PlayerStateController(IFileService fileService) : base(fileService)
        {
        }

        protected override string Filename { get; }
        protected override void SetInitialValues()
        {
            throw new System.NotImplementedException();
        }
    }
}