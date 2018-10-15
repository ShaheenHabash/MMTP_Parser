using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTP_Parser.Entity.Custom
{
    public class MessageContents
    {
        public ObservableCollection<Field> _ObsFields { get; set; }
    }
}
