using MMTP_Parser.Entity.Custom;
using System.Collections.ObjectModel;
namespace MMTP_Parser.Entity.MMTP.DIFF.BusinessData.MessageContent
{
    /// <summary>
    ///Processing rules
    /// The MMTP-37 – Static Thresholds message informs Subscribers of modifications in authorized price intervals (from PSGelStaMin to PSGelStaMax) for an instrument. This message is subjected to selective transmission according to the group of instruments to which the instrument belongs.
    ///Transmission functions
    /// Post-Session
    ///     During the Post-Session processing, static thresholds may be recalculated for some groups of instruments from the previous day's adjusted closing price.
    /// Opening a group of instruments
    ///     Static thresholds may be recalculated during the instruments group opening processing with respect to the reference price. The latter is updated:
    ///         * Either on the basis of the Theoretical Opening Price, if valid.
    ///         * Or on the basis of the crossed threshold if the Theoretical Opening Price lies outside the static thresholds.
    ///     The new static thresholds may or may not be broadcast, depending on the group of instruments concerned.
    /// Changes in static thresholds
    ///     Modifications to static thresholds may or may not lead to the broadcasting of an MMTP-37 – Static Thresholds message, depending on the group of the instrument concerned.
    /// Changes in instrument tick limit
    ///     Any modification of the static tick limit leads to a recalculation of static thresholds and possibly a broadcast to that effect.
    /// Changes in reference price
    ///     Any modification of the reference price leads to a recalculation of static thresholds and possibly a broadcast to that effect.
    /// Changes in previous day’s adjusted closing price
    ///     Any modification to the previous day’s adjusted closing price implies a reference price update, which leads to a recalculation of static thresholds and possibly to a broadcast, depending on the instrument update flags for the post-session static thresholds and the broadcast flag for the static thresholds.
    /// </summary>
    public class Message_37 : MessageContents //Length ==> 48 , Short description ==> Static Thresholds
    {
        //********************************************************************************************
        public Message_37()
        {
            _ObsFields = new ObservableCollection<Field>();
            Field xField;

            xField = new Field("PSGelStaMax", FieldType.QtmX, 14, 1, "Upper static threshold of freezing", "", "109", "");
            _ObsFields.Add(xField);

            xField = new Field("PSGelStaMin", FieldType.QtmX, 14, 15, "Lower static threshold of freezing", "", "109", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_1", FieldType.Alphanumerical, 20, 29, "", "", "", "");
            _ObsFields.Add(xField);
        }
    }
}
