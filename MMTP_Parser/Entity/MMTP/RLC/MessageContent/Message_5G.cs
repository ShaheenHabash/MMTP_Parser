using MMTP_Parser.Entity.Custom;
using System.Collections.ObjectModel;
namespace MMTP_Parser.Entity.MMTP.RLC.MessageContent
{
    /// <summary>
    ///Definition
    /// This message identifies a Sub-sector with a code and the corresponding characteristics.
    ///Transmission functions
    /// This type of message is sent:
    ///     * Every day at the start-up of the X-DIFF application
    ///     * For each Sub-sector defined by the Exchange in the RCE referential application.
    /// </summary>
    public class Message_5G : MessageContents //Length ==> 76 , Short description ==> Sub-sectors
    {
        //********************************************************************************************
        public Message_5G()
        {
            _ObsFields = new ObservableCollection<Field>();
            Field xField;

            xField = new Field("CSecVal", FieldType.Alphanumerical, 3, 1, "Sector Code", "", "100", "");
            _ObsFields.Add(xField);

            xField = new Field("CSoSecVal", FieldType.Alphanumerical, 4, 4, "Sub-sector Code", "", "103", "");
            _ObsFields.Add(xField);

            xField = new Field("LSoSecVal", FieldType.Alphanumerical, 40, 8, "Sub-sector Name", "", "129", "");
            _ObsFields.Add(xField);

            xField = new Field("CSecValICB", FieldType.Alphanumerical, 4, 48, "Sector Code ICB", "", "101", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_1", FieldType.Alphanumerical, 25, 52, "", "", "", "");
            _ObsFields.Add(xField);
        }
    }
}
