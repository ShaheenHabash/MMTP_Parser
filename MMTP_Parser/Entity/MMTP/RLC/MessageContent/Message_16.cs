using MMTP_Parser.Entity.Custom;
using System.Collections.ObjectModel;
namespace MMTP_Parser.Entity.MMTP.RLC.MessageContent
{
    /// <summary>
    ///Processing rules
    /// Indicates a change in the state of an instrument group. The number of messages of this type corresponds to the number of NSC® trading units for the corresponding group, and the number of these links is stated in the message (ZPcsNSCEmetMsgRLCGrc).
    ///Transmission functions
    /// Session management in case of change of group instrument's status
    ///     An MMTP-16 – Group State Change message is transmitted every time the status of a group of instruments changes. Both the group of instruments code (CIdGrc) and the new status (CEtaGrc) are transmitted by the broadcasting process (except for change to post-session).
    /// Session management in case of trading interruption
    ///     An MMTP-16 – Group State Change message is transmitted whenever a group of instruments is interrupted. For an overall market interruption, one message is sent per group of instruments.
    /// Session management in case some groups of instrument are forbidden
    ///     An MMTP-16 – Group State Change message is transmitted whenever a group of instruments is forbidden. For an overall market interruption, one message is sent per group of instruments.
    /// </summary>
    public class Message_16 : MessageContents //Length ==>28 , Short description ==> Group State Change
    {
        //********************************************************************************************
        public Message_16()
        {
            _ObsFields = new ObservableCollection<Field>();
            Field xField;

            xField = new Field("CIdGrc", FieldType.Alphanumerical, 2, 1, "Instrument group identification", "", "93", "");
            _ObsFields.Add(xField);

            xField = new Field("CEtaGrc", FieldType.Alphanumerical, 1, 3, "Instrument group state", "89", "", "");
            _ObsFields.Add(xField);

            xField = new Field("ZPcsNSCEmetMsgRLCGrc", FieldType.Numerical, 2, 4, "Number of Trading Units used by the group", "", "183", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_1", FieldType.Alphanumerical, 22, 6, "", "", "", "");
            _ObsFields.Add(xField);
        }
    }
}
