using MMTP_Parser.Entity.Custom;
using System;
using System.Collections.ObjectModel;
namespace MMTP_Parser.Entity.MMTP.DIFF.BusinessData.Technical
{
    public class TechnicalHeader//Length ==>25
    {
        public ObservableCollection<Field> _ObsFields { get; set; }
        //********************************************************************************************
        public TechnicalHeader()
        {
            _ObsFields = new ObservableCollection<Field>();
            Field xField;

            xField = new Field("Technical_Header_Type", FieldType.Alphanumerical, 1, 0, "Technical Header Type", "1");
            _ObsFields.Add(xField);

            xField = new Field("Item_Code", FieldType.Binary, 2, 1, "Item code", "");
            _ObsFields.Add(xField);

            xField = new Field("Session_Number", FieldType.Binary, 2, 3, "Session number", "");
            _ObsFields.Add(xField);

            xField = new Field("Absolute_Message_Number", FieldType.Binary, 4, 5, "Absolute Message Number", "");
            _ObsFields.Add(xField);

            xField = new Field("Message_Number_For_The_Item_Code", FieldType.Binary, 4, 9, "Message number for the item code", "");
            _ObsFields.Add(xField);

            xField = new Field("Broadcast_Timestamp", FieldType.Binary, 4, 13, "Broadcast timestamp", "");
            _ObsFields.Add(xField);

            xField = new Field("Transmitter_Signature", FieldType.Binary, 8, 17, "Reserved for future use", "");
            _ObsFields.Add(xField);

        }
        //********************************************************************************************
    }
}
