using MMTP_Parser.Entity.Custom;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTP_Parser.Entity.MMTP.RLC.MessageContent
{
    /// <summary>
    ///Processing rules
    ///     This message indicates a modification of instrument specific prices.
    ///Transmission functions
    /// Change in previous day's adjusted closing price
    ///     This change leads to the transmission of a MMTP-03 – Price message with a price trend flag (YPMsgP) set to 34 indicating that the previous day's closing price has been modified. Then according to the type of price, another MMTP-03 – Price message is sent with a price trend flag set to 35 if the modified price is a settlement price, or with a price trend flag set at 36 if the modified price is a final settlement price, or with a price trend flag set to 38 if the modified price is a reference price.
    /// Change in settlement price (for derivatives)
    ///     This change leads to the transmission of a MMTP-03 – Price message with a price trend flag (YPMsgP) set to 34 indicating that the previous day's closing price has been modified and an MMTP-03 – Price message with the price trend flag set to 35 indicating that the settlement price has been modified.
    /// Change in final settlement price (for derivatives)
    ///     This change leads to the transmission of a MMTP-03 – Price message with the price trend flag (YPMsgP) set to 34 indicating that the previous day's closing price has been modified and a MMTP-03 – Price message with the price trend flag set to 36 indicating that the final settlement price has been modified.
    /// Change in reference price
    ///     This change leads to the transmission of a MMTP-03 – Price message with the price trend flag (YPMsgP) set to 34 indicating that the previous day's closing price has been modified, and an MMTP-03 – Price message with a price trend flag set to 38 indicating that the reference price has been modified. Note that this transmission is submitted to the parametrization of the trading rule [CALCUL-VAR], indeed if [CALCUL-VAR] = 0 (cash configuration), only one MMTP-03 – Price message is sent with a price trend flag set to 38.
    /// Trade cancellation
    ///     In the event of a modification to the previous traded price (trend flag YPMsgP set to 33), the first traded price (trend flag set to 30), to the highest traded price (trend flag set tot 31) or the lowest traded price (trend flag set to 32), a MMTP-03 – Price message is sent for each modified extreme value.
    /// </summary>
    public class Message_03 : MessageContents //Length ==>71 , Short description ==> Price
    {
        //********************************************************************************************
        public Message_03()
        {
            _ObsFields = new ObservableCollection<Field>();
            Field xField;

            xField = new Field("PobjMsgP", FieldType.QtmX, 14, 1, "Price", "", "140", "");
            _ObsFields.Add(xField);

            xField = new Field("PphSeaCotJ", FieldType.QtmX, 14, 15, "Highest trade price of the trading day", "", "140", "");
            _ObsFields.Add(xField);

            xField = new Field("PpbSeaCotJ", FieldType.QtmX, 14, 29, "Lowest trade price of the trading day", "", "140", "");
            _ObsFields.Add(xField);

            xField = new Field("YPMsgP", FieldType.Numerical, 2, 43, "Price type", "", "178", "");
            _ObsFields.Add(xField);

            xField = new Field("IsensVarP", FieldType.Alphanumerical, 1, 45, "Last trade price variation as compared to the reference price", "", "120", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_1", FieldType.Alphanumerical, 5, 46, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("CSensVarPValPP", FieldType.Numerical, 1, 51, "Trade price versus next to last trade price variation flag", "", "101", "");
            _ObsFields.Add(xField);

            xField = new Field("XQVarPJDrPRf", FieldType.QtmX, 14, 52, "Price Variation As Compared to Reference Price", "", "165", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_2", FieldType.Alphanumerical, 6, 66, "", "", "", "");
            _ObsFields.Add(xField);
        }
    }
}
