using MMTP_Parser.Entity.Custom;
using System.Collections.ObjectModel;
namespace MMTP_Parser.Entity.MMTP.DIFF.BusinessData.MessageContent
{
    /// <summary>
    ///Processing rules
    /// Enables the Market Control to send a free text to the market participants. This type of message is sent by the Market Control to inform brokerage firms about events of general interest that occurred in the market (halting of stocks, deletion of order books, new listing of stocks, various technical messages, etc.) A long message can be split into several transmissions, each of which is a separate message (type 23). Information in the header enables to rebuild the entire message.
    ///Transmission functions
    /// The message is sent through the Market Surveillance tool SPI MAIL.
    /// </summary>
    public class Message_23 : MessageContents //Length ==>947 , Short description ==> Text Message
    {
        //********************************************************************************************
        public Message_23()
        {
            _ObsFields = new ObservableCollection<Field>();
            Field xField;

            xField = new Field("YMarMsg", FieldType.Alphanumerical, 2, 1, "Type of Market concerned by the message", "", "140", "");
            _ObsFields.Add(xField);

            xField = new Field("IUrg", FieldType.Alphanumerical, 1, 3, "Priority Indicator", "", "91", "");
            _ObsFields.Add(xField);

            xField = new Field("YCrl", FieldType.Alphanumerical, 1, 4, "Nature of Message", "", "139", "");
            _ObsFields.Add(xField);

            xField = new Field("YDest", FieldType.Alphanumerical, 2, 5, "Address Type", "", "139", "");
            _ObsFields.Add(xField);

            xField = new Field("CIdMsg", FieldType.Alphanumerical, 3, 7, "Message Number", "", "63", "");
            _ObsFields.Add(xField);

            xField = new Field("ZTotSeg", FieldType.Alphanumerical, 2, 10, "Number of messages in this message", "", "150", "");
            _ObsFields.Add(xField);

            xField = new Field("NSeqSeq", FieldType.Alphanumerical, 1, 12, "Sequence number of message within this message", "", "100", "");
            _ObsFields.Add(xField);

            xField = new Field("LTit", FieldType.Alphanumerical, 80, 14, "Message title", "", "97", "");
            _ObsFields.Add(xField);

            xField = new Field("LMsg", FieldType.Alphanumerical, 854, 94, "Message text", "", "96", "");
            _ObsFields.Add(xField);
        }
    }
}
