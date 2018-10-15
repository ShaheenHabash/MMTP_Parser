using MMTP_Parser.Entity.Custom;
using System.Collections.ObjectModel;
namespace MMTP_Parser.Entity.MMTP.DIFF.BusinessData.MessageContent
{
    /// <summary>
    ///Processing rules
    /// Indicates an instrument's Theoretical Opening Price, or TOP (also known as an Indicative Opening Price, or IOP): what the trading price would be if the instrument were to open at the moment when the calculation was made (PTeoOvJ). Furthermore, the message provides for both sides the simulated prices (PmeLimSimAcVal and PmeLimSimVtVal), the total simulated quantities (QTitMeLimSimAc and QTitMeLimSimVt), as well as the side (CSensQNrepOv) and quantity (QnrepOv) that would remain unfilled and the price variation as compared to the reference price (XQVarPJDrPRf).
    /// An MMTP-30 – Theoretical Opening Price message is transmitted if the theoretical price or if any datum of the message (except the variation) varies.
    /// If the theoretical price remain undetermined, but the reason for this indetermination changes, then an MMTP-30 – Theoretical Opening Price message is sent.
    ///Transmission functions
    /// Every function capable of entailing recalculation of the Theoretical Opening Price can trigger the transmission of this message.
    ///     * Management of the group of instruments pre-opening preparation session: This processing can be triggered either in Session or in Post-session.
    ///     * Entering and Order processing in pre-opening mode
    ///     * Changes in previous day's adjusted closing price
    ///     * Changes to reference price and tick limit
    ///     * Overall cancellation of a Subscriber's orders
    ///     * Overall cancellation of orders for a group of instruments
    ///     * Cancellation of orders in the book for an instrument
    /// Note: If the variation is the only modified item, the message is not sent because the variation is not stored in the database.
    /// </summary>
    public class Message_30 : MessageContents //Length ==>117 , Short description ==> Theoretical Opening Price
    {
        //********************************************************************************************
        public Message_30()
        {
            _ObsFields = new ObservableCollection<Field>();
            Field xField;

            xField = new Field("PTeoOvJ", FieldType.QtmX, 14, 1, "Theoretical Opening Price", "", "109", "");
            _ObsFields.Add(xField);

            xField = new Field("QXtePTeoOvj", FieldType.Numerical, 12, 15, "Total traded quantity at pening", "", "121", "");
            _ObsFields.Add(xField);

            xField = new Field("IsensVarP", FieldType.Alphanumerical, 1, 27, "Last trade price variation as compared to the reference price", "", "87", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_1", FieldType.Alphanumerical, 5, 28, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("CSensQNrepOv", FieldType.Alphanumerical, 1, 33, "Unfilled quantity side at opening price", "", "69", "");
            _ObsFields.Add(xField);

            xField = new Field("QnrepOv", FieldType.Numerical, 12, 34, "Unfilled quantity at opening", "", "116", "");
            _ObsFields.Add(xField);

            xField = new Field("QTitMeLimSimAc", FieldType.Numerical, 12, 46, "Total simulated buy quantity", "", "118", "");
            _ObsFields.Add(xField);

            xField = new Field("PmeLimSimAcVal", FieldType.QtmX, 14, 58, "Simulated buy price", "", "106", "");
            _ObsFields.Add(xField);

            xField = new Field("PmeLimSimVtVal", FieldType.QtmX, 14, 72, "Simulated sell price", "", "106", "");
            _ObsFields.Add(xField);

            xField = new Field("QTitMeLimSimVt", FieldType.Numerical, 12, 86, "Total simulated sell quantity", "", "119", "");
            _ObsFields.Add(xField);

            xField = new Field("XQVarPJDrPRf", FieldType.QtmX, 14, 98, "Price Variation As Compared to Reference Price", "", "132", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_2", FieldType.Alphanumerical, 6, 112, "", "", "", "");
            _ObsFields.Add(xField);
        }
    }
}
