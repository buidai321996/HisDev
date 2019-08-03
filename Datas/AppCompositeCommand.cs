using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datas
{
    public class AppCompositeCommand : IAppCompositeCommand
    {
        private readonly CompositeCommand _compositeCommand = new CompositeCommand();

        public CompositeCommand CompositeCommandSave
        {
            get { return _compositeCommand; }
        }
    }
}
