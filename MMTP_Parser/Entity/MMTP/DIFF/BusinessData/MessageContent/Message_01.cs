using MMTP_Parser.Entity.Custom;
using System.Collections.ObjectModel;
namespace MMTP_Parser.Entity.MMTP.DIFF.BusinessData.MessageContent
{
    /// <summary>
    ///Processing rules
    ///     This message is sent for the first trades occurring for one instrument during a trading day. The Opening Trade message could be sent at the opening or during the continuous trading phase.
    /// At opening:
    ///     For the first opening of an instrument since the start of the trading day, an Opening Trade message is sent for each trade that is generated. The Flag Indicating End of Trades at the Same Price (IfinTran) is set to 0 for all the opening trades except for the last trade, where it is set to 1.
    ///     For the second and subsequent openings of the day, the MMTP-02 – Trade message is used.
    /// During continuous trading phase:
    ///     If the instrument has not traded at the Opening, an Opening Trade message is sent for the first trade generated during Continuous Trading. The subsequent trades will be MMTP-02 – Trade messages.
    ///     Caution: In case of an Opening Trade cancellation, the cancelled trade is broadcast using a
    ///     MMTP-02 – Trade message with a trade cancellation flag (IAnuTran) set to “00”.
    ///Transmission functions
    /// Opening a group of instruments
    ///     If it is the first opening of the instrument, all trades generated are broadcast with an Opening Trade message. The last trade at the same price indicator is set to 0 for all the opening trades except for the last one which is set to 1.
    /// Instrument opening
    ///     Same as Opening a group of instruments.
    /// Order entry during continuous trading
    ///     When an instrument is traded for the first time of the trading day, an Opening Trade message is sent. Subsequent trades are broadcast with MMTP-02 – Trade messages.
    /// </summary>
    public class Message_01 : MessageContents //Length ==>196 , Short description ==> Opening Trade
    {
        
        //********************************************************************************************
        public Message_01()
        {
            _ObsFields = new ObservableCollection<Field>();
            Field xField;

            xField = new Field("QtitTran", FieldType.Numerical, 12, 1, "Traded quantity", "", "120", "");
            _ObsFields.Add(xField);

            xField = new Field("PTran", FieldType.QtmX, 14, 13, "Trade Price", "", "109", "");
            _ObsFields.Add(xField);

            xField = new Field("CIdAdhNSCAc", FieldType.Alphanumerical, 8, 27, "ID of NSC® Buying Member", "62", "", "");
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

            xField = new Field("Filler_2", FieldType.Alphanumerical, 2, 63, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("ItranYApl", FieldType.Numerical, 1, 65, "Cross Trade Flag", "", "90", "");
            _ObsFields.Add(xField);

            xField = new Field("IfinTran", FieldType.Alphanumerical, 1, 66, "Flag indicating end of trades at the same price", "", "83", "");
            _ObsFields.Add(xField);

            xField = new Field("YOmAc", FieldType.Alphanumerical, 1, 67, "Code for the technical origin of the buy order", "", "142", "");
            _ObsFields.Add(xField);

            xField = new Field("YOmVt", FieldType.Alphanumerical, 1, 68, "Code for the technicalorigin of the sell order", "", "142", "");
            _ObsFields.Add(xField);

            xField = new Field("CSensVarPTranPP", FieldType.Alphanumerical, 1, 69, "Sign of price variation as compared to the previous price", "", "69", "");
            _ObsFields.Add(xField);

            xField = new Field("NTran", FieldType.Numerical, 7, 70, "Trade number", "", "101", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_3", FieldType.Alphanumerical, 3, 77, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("YMarNSC", FieldType.Alphanumerical, 2, 80, "NSC® market segment", "", "141", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_4", FieldType.Alphanumerical, 86, 82, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("DHTran", FieldType.Numerical, 14, 168, "Trade Date and Time", "", "75", "");
            _ObsFields.Add(xField);

            xField = new Field("YOmOrgTran", FieldType.Alphanumerical, 1, 182, "Type of orders at the origin of a trade", "", "142", "");
            _ObsFields.Add(xField);

            xField = new Field("XQVarPJDrPRf", FieldType.QtmX, 14, 183, "Price Variation As Compared to Reference Price", "", "132", "");
            _ObsFields.Add(xField);
         }
    }
}
