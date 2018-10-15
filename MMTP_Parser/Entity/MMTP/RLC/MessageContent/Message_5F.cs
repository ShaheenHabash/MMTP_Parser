using MMTP_Parser.Entity.Custom;
using System.Collections.ObjectModel;
namespace MMTP_Parser.Entity.MMTP.RLC.MessageContent
{
    /// <summary>
    ///Definition
    /// This message identifies a Sector with a code and the corresponding characteristics.
    ///Transmission functions
    /// This type of message is sent:
    ///     * Every day within the referential data sequence (MMTP-50/51 – Start/End of Instrument Reference Data Flow messages)
    ///     * For each Sector defined by the Exchange in the RCE referential application.
    /// </summary>
    public class Message_5F : MessageContents //Length ==> 76 , Short description ==> Sectors
    {
        //********************************************************************************************
        public Message_5F()
        {
            _ObsFields = new ObservableCollection<Field>();
            Field xField;

            xField = new Field("CSecVal", FieldType.Alphanumerical, 3, 1, "Sector Code", "", "100", "");
            _ObsFields.Add(xField);

            xField = new Field("LsecVal", FieldType.Alphanumerical, 40, 4, "Sector Name", "", "129", "");
            _ObsFields.Add(xField);

            xField = new Field("CSuperSecVal", FieldType.Alphanumerical, 4, 44, "Super Sector Code", "", "103", "");
            _ObsFields.Add(xField);

            xField = new Field("CSecValICB", FieldType.Alphanumerical, 4, 48, "Sector Code ICB", "", "101", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_1", FieldType.Alphanumerical, 25, 52, "", "", "", "");
            _ObsFields.Add(xField);
        }
    }
}
