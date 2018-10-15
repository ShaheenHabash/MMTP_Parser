using MMTP_Parser.Entity.Custom;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTP_Parser.Entity.MMTP.DIFF.BusinessData.InstrumentCharacteristic
{
    public class InstrumentCharacteristicHeader//Length ==>52
    {
         public ObservableCollection<Field> _ObsFields { get; set; }
        //********************************************************************************************
         public InstrumentCharacteristicHeader()
        {
            _ObsFields = new ObservableCollection<Field>();
            Field xField;

            xField = new Field("Instrument_Characteristic_Header_Type", FieldType.Alphanumerical, 1, 0, "Type of the instrument characteristic header", "1", "", "");
            _ObsFields.Add(xField);

            xField = new Field("CFlmVal", FieldType.Alphanumerical, 2, 1, "Market flow code for an instrument", "","61","");
            _ObsFields.Add(xField);

            xField = new Field("Quote_Place_Code", FieldType.Alphanumerical, 3, 3, "Market place ID for instrument", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("Financial_Market_Code", FieldType.Alphanumerical, 3, 6, "Financial Market Code", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("CIdGrc", FieldType.Alphanumerical, 2, 9, "Instrument group identification", "", "113", "");
            _ObsFields.Add(xField);

            xField = new Field("InstrumentID", FieldType.Alphanumerical, 12, 11, "Instrument identifier", "", "86", "");
            _ObsFields.Add(xField);

            xField = new Field("CValMne", FieldType.Alphanumerical, 5, 23, "Instrument mnemonic code", "", "72", "");
            _ObsFields.Add(xField);

            xField = new Field("DEven", FieldType.Numerical, 8, 28, "Date of event", "YYYYMMDD", "74", "");
            _ObsFields.Add(xField);

            xField = new Field("HEven", FieldType.Numerical, 6, 36, "Time of event", "", "76", "");
            _ObsFields.Add(xField);

            xField = new Field("Message_Type_Code", FieldType.Alphanumerical, 4, 42, "Message type code", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("Sequence_By_Instrument_And_Message_Type", FieldType.Numerical, 6, 46, "Sequence number by instrument and message type code", "", "", "");
            _ObsFields.Add(xField);
        }
    }
}
