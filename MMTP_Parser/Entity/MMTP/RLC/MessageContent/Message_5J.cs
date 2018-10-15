using MMTP_Parser.Entity.Custom;
using System.Collections.ObjectModel;
namespace MMTP_Parser.Entity.MMTP.RLC.MessageContent
{
    /// <summary>
    ///Definition
    /// This message indicates the closing price of an instrument which can be one of the following:
    ///     * NSC® Last Traded Price,
    ///     * NSC® Last Traded Price adjusted,
    ///     * VWAP price,
    ///     * VWAP price adjusted.
    ///Transmission functions
    /// Depending on an RCE application parameter this message is sent on a real time basis or at the end of the Trading Day.
    /// </summary>
    public class Message_5J : MessageContents //Length ==> 226 , Short description ==> Closing Price
    {
        //********************************************************************************************
        public Message_5J()
        {
            _ObsFields = new ObservableCollection<Field>();
            Field xField;

            xField = new Field("PClosing", FieldType.QtmX, 1, 14, "Closing price", "", "134", "");
            _ObsFields.Add(xField);

            xField = new Field("Iclose", FieldType.Alphanumerical, 1, 15, "Close indicator", "", "113", "");
            _ObsFields.Add(xField);

            xField = new Field("YClose", FieldType.Alphanumerical, 1, 16, "Type of closing price", "", "169", "");
            _ObsFields.Add(xField);

            xField = new Field("PClosingNoAdj", FieldType.QtmX, 14, 17, "Closing price not adjusted", "", "134", "");
            _ObsFields.Add(xField);

            xField = new Field("PVWAP", FieldType.QtmX, 14, 31, "Value-Weighted Average Price", "", "143", "");
            _ObsFields.Add(xField);

            xField = new Field("PVWAPNoAdj", FieldType.QtmX, 14, 45, "VWAP not adjusted", "", "143", "");
            _ObsFields.Add(xField);

            xField = new Field("PdrCotVal", FieldType.QtmX, 14, 59, "Last Traded Price", "", "137", "");
            _ObsFields.Add(xField);

            xField = new Field("PdrCotValNoAdj", FieldType.QtmX, 14, 73, "Last Traded price not adjusted", "", "137", "");
            _ObsFields.Add(xField);

            xField = new Field("ZTotTran", FieldType.Numerical, 12, 87, "Total number of trades", "", "184", "");
            _ObsFields.Add(xField);

            xField = new Field("QtotTran5J", FieldType.Alphanumerical, 12, 99, "Total number of shares traded", "", "153", "");
            _ObsFields.Add(xField);

            xField = new Field("QtotCap", FieldType.QtmX, 14, 111, "Total trade value", "", "152", "");
            _ObsFields.Add(xField);

            xField = new Field("XTickPdr", FieldType.Numerical, 7, 125, "Percentage threshold normal trade", "165");
            _ObsFields.Add(xField);

            xField = new Field("XTickPdrApl", FieldType.Numerical, 7, 132, "Percentage threshold cross trade", "166");
            _ObsFields.Add(xField);

            xField = new Field("ZTitMoyEhgMS", FieldType.Numerical, 12, 139, "Daily average shares traded 30 days", "184");
            _ObsFields.Add(xField);

            xField = new Field("XMaxEhgMoy", FieldType.Numerical, 7, 151, "Ratio maximum shares traded normal trade / Daily average shares traded 30 days", "158");
            _ObsFields.Add(xField);

            xField = new Field("XMaxEhgMoyApl", FieldType.Numerical, 7, 158, "Ratio maximum shares traded cross trade / Daily average shares traded 30 days", "158");
            _ObsFields.Add(xField);

            xField = new Field("XMaxEhgAdm", FieldType.Numerical, 7, 165, "Ratio maximum shares traded normal trade / Outstanding number of shares", "158");
            _ObsFields.Add(xField);

            xField = new Field("XMaxEhgAdmApl", FieldType.Numerical, 7, 172, "Ratio maximum shares traded cross trade / Outstanding number of shares", "158");
            _ObsFields.Add(xField);

            xField = new Field("Filler_1", FieldType.Alphanumerical, 48, 179, "", "", "", "");
            _ObsFields.Add(xField);
        }
    }
}
