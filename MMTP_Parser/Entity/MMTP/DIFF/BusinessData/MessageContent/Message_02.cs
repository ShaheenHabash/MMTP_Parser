using MMTP_Parser.Entity.Custom;
using System.Collections.ObjectModel;
namespace MMTP_Parser.Entity.MMTP.DIFF.BusinessData.MessageContent
{
    /// <summary>
    ///Processing rules
    ///     This message is sent for all the trades occurring after the Opening trades or to indicate a trade cancellation. The Flag Indicating End of Trades at the Same Price (IfinTran) is set for the last trade at a given price in case of order entry.
    ///Transmission functions
    /// Opening a group of instruments
    ///     If the instrument has already been traded (instrument’s first traded price filled in), all trades generated are broadcast with a Trade message.
    /// Instrument opening
    ///     Same as Opening a group of instruments.
    /// Order entry and processing in session
    ///     If the instrument has already been traded, all trades generated are broadcast with a Trade message.
    /// Cancellation of trade by the Market Control
    ///     When a trade is cancelled by Market Control, the cancelled trade is broadcasted using a MMTP-02 – Trade message with a trade cancellation flag (IAnuTran) set to “00”.
    /// </summary>
    public class Message_02 : MessageContents //Length ==>242 , Short description ==> Trade
    {
        //********************************************************************************************
        public Message_02()
        {
            _ObsFields = new ObservableCollection<Field>();
            Field xField;

            xField = new Field("QtitTran", FieldType.Numerical, 12, 1, "Traded quantity", "", "120", "");
            _ObsFields.Add(xField);

            xField = new Field("PTran", FieldType.QtmX, 14, 13, "Trade Price", "", "109", "");
            _ObsFields.Add(xField);

            xField = new Field("CIdAdhNSCAc", FieldType.Alphanumerical, 8, 27, "", "62", "", "");
            _ObsFields.Add(xField);

            xField = new Field("CIdAdhNSCVt", FieldType.Alphanumerical, 8, 35, "ID of NSC® Selling Member", "", "63", "");
            _ObsFields.Add(xField);

            xField = new Field("QTitNgJ", FieldType.Numerical, 12, 43, "Total traded quantity of the trading day", "", "119", "");
            _ObsFields.Add(xField);

            xField = new Field("IsensVarP", FieldType.Alphanumerical, 1, 55, "Last trade price variation as compared to the reference price", "", "87", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_1", FieldType.Alphanumerical, 5, 56, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("YCpteOmAc", FieldType.Alphanumerical, 1, 61, "Type of Clearing Account for the buyer Member in the Trade", "", "137", "");
            _ObsFields.Add(xField);

            xField = new Field("YCpteOmVt", FieldType.Alphanumerical, 1, 62, "Type of Clearing Account for the seller Member in the Trade", "", "138", "");
            _ObsFields.Add(xField);

            xField = new Field("PphSeaCotJ", FieldType.QtmX, 14, 63, "Highest trade price of the trading day", "", "108", "");
            _ObsFields.Add(xField);

            xField = new Field("PpbSeaCotJ", FieldType.QtmX, 14, 77, "Lowest trade price of the trading day", "", "107", "");
            _ObsFields.Add(xField);

            xField = new Field("IAnuTran", FieldType.Numerical, 2, 91, "Trade cancellation flag", "", "81", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_2", FieldType.Alphanumerical, 2, 93, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("ItranYApl", FieldType.Numerical, 1, 95, "Cross Trade Flag", "", "90", "");
            _ObsFields.Add(xField);

            xField = new Field("IfinTran", FieldType.Alphanumerical, 1, 96, "Flag indicating end of trades at the same price", "", "83", "");
            _ObsFields.Add(xField);

            xField = new Field("YOmOrgTran", FieldType.Numerical, 1, 97, "Type of orders at the origin of a trade", "", "142", "");
            _ObsFields.Add(xField);

            xField = new Field("YOmAc", FieldType.Alphanumerical, 1, 98, "Code for the technical origin of the buy order", "", "142", "");
            _ObsFields.Add(xField);

            xField = new Field("YOmVt", FieldType.Alphanumerical, 1, 99, "Code for the technicalorigin of the sell order", "", "142", "");
            _ObsFields.Add(xField);

            xField = new Field("CSensVarPTranPP", FieldType.Alphanumerical, 1, 100, "Sign of price variation as compared to the previous price", "", "69", "");
            _ObsFields.Add(xField);

            xField = new Field("NTran", FieldType.Numerical, 7, 101, "Trade number", "", "101", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_3", FieldType.Alphanumerical, 3, 108, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("YMarNSC", FieldType.Alphanumerical, 2, 111, "NSC® market segment", "", "141", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_4", FieldType.Alphanumerical, 86, 113, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("DHTran", FieldType.Numerical, 14, 199, "Trade Date and Time", "", "75", "");
            _ObsFields.Add(xField);

            xField = new Field("XQVarPJDrPRf", FieldType.QtmX, 14, 213, "Price Variation As Compared to Reference Price", "", "132", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_5", FieldType.Alphanumerical, 16, 227, "", "", "", "");
            _ObsFields.Add(xField);
        }
    }
}
