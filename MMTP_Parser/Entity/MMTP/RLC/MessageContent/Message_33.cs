using MMTP_Parser.Entity.Custom;
using System.Collections.ObjectModel;
namespace MMTP_Parser.Entity.MMTP.RLC.MessageContent
{
    /// <summary>
    ///Processing rules
    /// Indicates a trade on TCS, or a trade cancellation.
    /// This message informs all addresses of any trades occurred on TCS during the trading day. The cross trade indicator is set at 1 if trading results from a cross order, else it is filled in at 0.
    ///Creation/cancellation of trade
    /// TCS sends a TRADE message in case of creation or cancellation of trade. The trade cancellation indicator is set at:
    ///     * '07' for trading.
    ///     * '00' for cancellation
    /// </summary>
    public class Message_33 : MessageContents //Length ==>242 , Short description ==> TCS Trade
    {
        //********************************************************************************************
        public Message_33()
        {
            _ObsFields = new ObservableCollection<Field>();
            Field xField;

            xField = new Field("QtitTran", FieldType.Numerical, 12, 1, "Traded quantity", "", "152", "");
            _ObsFields.Add(xField);

            xField = new Field("PTran", FieldType.QtmX, 14, 13, "Trade Price", "", "142", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_1", FieldType.Alphanumerical, 16, 27, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("QTitNgJ", FieldType.Numerical, 12, 43, "Total traded quantity of the trading day", "", "152", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_2", FieldType.Alphanumerical, 8, 55, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("PphSeaCotJ", FieldType.QtmX, 14, 63, "Highest trade price of the trading day", "", "140", "");
            _ObsFields.Add(xField);

            xField = new Field("PpbSeaCotJ", FieldType.QtmX, 14, 77, "Lowest trade price of the trading day", "", "140", "");
            _ObsFields.Add(xField);

            xField = new Field("IAnuTran", FieldType.Numerical, 2, 91, "Trade cancellation flag", "", "113", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_3", FieldType.Alphanumerical, 2, 93, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("ItranYApl", FieldType.Numerical, 1, 95, "Cross Trade Flag", "", "123", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_4", FieldType.Alphanumerical, 15, 96, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("YMarNSC", FieldType.Alphanumerical, 2, 111, "NSC® market segment", "", "173", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_5", FieldType.Alphanumerical, 86, 113, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("DHTran", FieldType.Alphanumerical, 14, 199, "Trade Date and Time", "", "108", "");
            _ObsFields.Add(xField);

            xField = new Field("XQVarPJDrPRf", FieldType.QtmX, 14, 213, "Price Variation As Compared to Reference Price", "", "165", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_6", FieldType.Alphanumerical, 16, 227, "", "", "", "");
            _ObsFields.Add(xField);
        }
    }
}
