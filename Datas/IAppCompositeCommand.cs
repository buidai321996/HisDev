using Prism.Commands;

namespace Datas
{
    public interface IAppCompositeCommand
    {
        CompositeCommand CompositeCommandSave { get; }
    }
}