using MMTP_Parser.Entity.Custom;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTP_Parser.Entity.MMTP.DIFF.BusinessData.MessageContent
{
    public class Message_A6 : MessageContents //Length ==> 36 , Short description ==> DISPLAY OF BID OR OFFER
    {
        //********************************************************************************************
        public Message_A6()
        {
            _ObsFields = new ObservableCollection<Field>();
            Field xField;

            xField = new Field("POfDemVal", FieldType.QtmX, 14, 1, "Bid or Ask Price", "", "132", "");
            _ObsFields.Add(xField);

            xField = new Field("CSensOrdNrepVal", FieldType.Numerical, 2, 15, "Unfilled order(s) at opening flag", "", "99", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_1", FieldType.Alphanumerical, 20, 17, "", "", "", "");
            _ObsFields.Add(xField);
        }
    }
}
