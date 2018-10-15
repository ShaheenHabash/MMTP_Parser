using MMTP_Parser.Entity.Custom;
using System.Collections.ObjectModel;
namespace MMTP_Parser.Entity.MMTP.DIFF.BusinessData.MessageContent
{
    /// <summary>
    ///Processing rules
    /// Summarizes an instrument's opening trades.
    /// The MMTP-32 – Opening Summary message is sent after an instrument opening (fixing) that has been traded to summarize the opening (fixing), or if the first trade(s) occurred during continuous trading.
    /// The message provides the first (PPrCJ), highest (PphSeaCotJ), lowest (PpbSeaCotJ) and last (PDrCotJ) trade prices for the trading day, the total traded quantity at opening (QtitNgOvVal), as well as the sign of variation (CSensVarPTranPP) as compared to the previous traded price and the variation (XQVarPJDrPRf) as compared to the reference price of the instrument. The trend indicator YPOvVal() indicates whether this corresponds to the 1st opening on the instrument or to the first traded price (value 04) or the nth opening if the instrument has already traded (value 07).
    ///Transmission functions
    /// Opening a group of instruments
    ///     For each instrument with a TOP between the thresholds, an MMTP-32 – Opening Summary message is sent. Trades take place at the TOP. The message summaries the opening.
    /// Instrument opening
    ///     If the instrument has a TOP between the thresholds, an MMTP-32 – Opening Summary message is sent.
    /// Instrument fixing
    ///     If the instrument has a TOP between the thresholds, an MMTP-32 – Opening Summary message is sent.
    /// Entering and processing the order in continuous trade mode
    ///     During continuous trading, when an instrument is traded for the first time (first trade of the day), an Opening Summary message is sent after the MMTP-01 – Opening Trade messages. This message summaries the Opening trade.
    /// </summary>
    public class Message_32 : MessageContents //Length ==>117 , Short description ==> Opening Summary
    {
        //********************************************************************************************
        public Message_32()
        {
            _ObsFields = new ObservableCollection<Field>();
            Field xField;

            xField = new Field("PPrCJ", FieldType.QtmX, 14, 1, "First trade price of the trading day", "", "108", "");
            _ObsFields.Add(xField);

            xField = new Field("PDrCotJ", FieldType.QtmX, 14, 15, "Last trade price of the trading day", "", "104", "");
            _ObsFields.Add(xField);

            xField = new Field("PphSeaCotJ", FieldType.QtmX, 14, 29, "Highest trade price of the trading day", "", "108", "");
            _ObsFields.Add(xField);

            xField = new Field("PpbSeaCotJ", FieldType.QtmX, 14, 43, "Lowest trade price of the trading day", "", "107", "");
            _ObsFields.Add(xField);

            xField = new Field("YPOvVal", FieldType.Numerical, 2, 57, "Trend flag", "", "144", "");
            _ObsFields.Add(xField);

            xField = new Field("QtitNgOvVal", FieldType.Numerical, 12, 59, "Total traded quantity at opening", "", "120", "");
            _ObsFields.Add(xField);

            xField = new Field("IsensVarP", FieldType.Alphanumerical, 1, 71, "Last trade price variation as compared to the reference price", "", "87", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler", FieldType.Alphanumerical, 5, 72, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("CSensVarPTranPP", FieldType.Alphanumerical, 1, 77, "Sign of price variation as compared to the previous price", "", "69", "");
            _ObsFields.Add(xField);

            xField = new Field("XQVarPJDrPRf", FieldType.QtmX, 14, 78, "Price Variation As Compared to Reference Price", "", "132", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_2", FieldType.Alphanumerical, 26, 92, "", "", "", "");
            _ObsFields.Add(xField);
        }
    }
}
