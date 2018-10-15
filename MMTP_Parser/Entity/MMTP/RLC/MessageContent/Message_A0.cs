using MMTP_Parser.Entity.Custom;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTP_Parser.Entity.MMTP.RLC.MessageContent
{
    public class Message_A0 : MessageContents //Length ==> 3 , Short description ==> START / END OF MARKET SHEET BROADCASTING
    {
        //********************************************************************************************
        public Message_A0()
        {
            _ObsFields = new ObservableCollection<Field>();
            Field xField;

            xField = new Field("IMsgA0DebFin", FieldType.Alphanumerical, 1, 1, "Start/end indicator for RLC market sheet messages", "", "144", "");
            _ObsFields.Add(xField);
            
            xField = new Field("ZTotPcsNSCEmetMsgRLC", FieldType.Numerical, 2,2, "Total Number of NSC® Trading Units", "", "172", "");
            _ObsFields.Add(xField);
        }
    }
}
