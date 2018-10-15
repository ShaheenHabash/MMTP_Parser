using MMTP_Parser.Entity.Custom;
using System.Collections.ObjectModel;
namespace MMTP_Parser.Entity.MMTP.DIFF.BusinessData.MessageContent
{
    /// <summary>
    ///Definition
    /// This message identifies a Board with a code and a name.
    ///Transmission functions
    /// This type of message is sent:
    ///     * Every day within the referential data sequence (MMTP-50/51 – Start/End of Instrument Reference Data Flow messages)
    ///     * For each Board defined by the Exchange in the RCE referential application.
    /// </summary>
    public class Message_5E : MessageContents //Length ==> 76 , Short description ==> Boards
    {
        //********************************************************************************************
        public Message_5E()
        {
            _ObsFields = new ObservableCollection<Field>();
            Field xField;

            xField = new Field("CComVal", FieldType.Alphanumerical, 1, 1, "Board Code", "", "57", "");
            _ObsFields.Add(xField);

            xField = new Field("LBoard", FieldType.Alphanumerical, 40, 2, "Board Name", "", "96", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_1", FieldType.Alphanumerical, 35, 42, "", "", "", "");
            _ObsFields.Add(xField);
        }
    }
}
