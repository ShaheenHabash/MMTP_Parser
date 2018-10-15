using MMTP_Parser.Entity.Custom;
using System.Collections.ObjectModel;
namespace MMTP_Parser.Entity.MMTP.DIFF.BusinessData.MessageContent
{
    /// <summary>
    ///Processing rules
    ///      The MMTP-04 – Best Limits message is broadcast as changes occur to the order books of an instrument. For each of the 5 best limits on each side, it shows:
    ///          * The number of orders at that level (limit);
    ///          * The total quantity of orders at that level;
    ///          * The price.
    ///      This message is broadcast as soon as something changes in these five best limits. In pre-opening mode, an additional occurrence is broadcast in the message called Market summary.
    /// The concept of market summary for an instrument
    ///      The Market summary for an instrument is the summary of the orders that would be executed if the Opening of the instrument took place at the moment this message was sent. The market summary has no meaning except when the TOP (Theoretical Opening Price) has been determined during the Pre-opening phase.
    /// Orders participating in the calculation of the best limits
    ///      Non-triggered Stop orders are not included is the MMTP-04 – Best Limits message. To minimize the message length, only the modified limits (Bid and Ask) are broadcast. In pre-opening mode, if a Theoretical Opening Price (TOP) is determined:
    ///          * The first occurrence contains the Market Order (MO) limit if it exists
    ///          * The second occurrence contains the Market On Opening (MOO) limit if it exists
    ///          * The third occurrence contains the price overridden limit at the TOP
    ///          * The sixth occurrence is the sum of the MO limit, the MOO limit and total price overwrites. If the sixth occurrence is equal to the first one (no buy or sell "Market Order" and no buy or sell "Market On Opening" orders for an instrument) it is not filled in and its corresponding flag in ItabModMeLim is set to "0".
    ///      In Continuous Trading mode, the sixth element is meaningless and the corresponding change flag in ItabModMeLim is set to "0".
    /// Best Limits sent when the order book is modified
    ///      In order to minimize the size of MMTP-04 – Best Limits messages, only the best limits that have been modified or deleted are sent. The market summary is only present during the Pre-Opening phase.
    ///      The MMTP-04 – Best Limits message therefore has a variable length. The presence in the message of modified or deleted best limits and of the market summary is indicated via a table (ItabModMeLim) with 6 Boolean flags:
    ///          * Flags 1 to 5 indicate whether or not the best limit for rank 1, 2, 3, 4 or 5 respectively is presented in the message.
    ///          * Flag 6 indicates whether the market summary is present.
    ///      Caution: It is important to note that, except by chance, the position of a best limit in the message does not correspond to its rank in the order book, because not all best limits in the book appear in the message: the first limit present in a given occurrence of the Best Limits message can for example correspond to the limit with a rank of 3 in the order book.
    ///      The relative order of the best limits in the message is the same as the relative order of the best limits in the book; thus, the rank N in the order book of the best limit that has the position X in the message is equal to the position in the flags table of the Xth flag that has the value of 1. For example, if the flags are 001000, this means that there is only one best limit in the message and its rank is 3.
    ///Transmission functions
    /// Preparation for the Session
    ///     At the beginning of a new trading session, for each instrument whose order book has been modified by Post-Session processing (elimination of orders in the order book after a corporate event or after the expiration of a derivative instrument or after the order validity date has been reached), an MMTP-04 – Best Limits message is sent.
    /// Entry, modification, cancellation of an order during the Pre-Opening
    ///     For each order (except non triggered Stop orders) which modifies one of the values associated with the five best limits of the instrument (quantity, number of orders, price), an MMTP-04 – Best Limits message is sent.
    /// Opening of an Instrument with Its Group
    ///     For each instrument for which a TOP has been determined that falls within the price thresholds, a MMTP-04 – Best Limits message is sent.
    /// Opening/Auction of an Instrument
    ///     Same as Opening of an Instrument with Its Group.
    /// Modification of the Last Adjusted Closing Price
    ///     The modification of the last adjusted closing price can cause the recalculation of the theoretical opening price because of an update to the static reference price, and therefore can also result in the modification of the best limits whose prices are overwritten by the theoretical opening price. Consequently, if the instrument group is in Pre-Opening, or if the instrument is suspended or reserved, a MMTP-04 – Best Limits message is sent.
    /// Order Entry and Processing During Continuous Trading
    ///     For each order entered into the order book, modified or cancelled, if one of the values associated with the best limits for the instrument is modified (in particular, if a trade modifies the cumulative displayed quantities), a MMTP-04 – Best Limits message is sent.
    /// Modification of the Static Reference Price and the Static Authorized Price Fluctuation for an Instrument
    ///     The modification of the static reference price can cause the recalculation of the theoretical opening price and therefore a modification of the best limits.
    /// Immediate Rebroadcasting of the Best Limits
    ///     For each instrument affected by the command (for a given instrument or all instruments in a group or all instruments): an MMTP-04 – Best Limits message is sent, with the 5 best limits provided if they exist, and the market summary is provided if appropriate.
    /// Elimination of All Orders for an Instrument
    ///     An MMTP-04 – Best Limits message is sent.
    /// Cancellation of All Orders for a Member
    ///     For each instrument for which at least one of the 5 best limits is affected, an MMTP-04 – Best Limits message is sent.
    /// Elimination of All Orders for a Group (Orders whose timestamps are later than a time specified in the command)
    ///     For each instrument for which at least one of the 5 best limits is modified, an MMTP-04 – Best Limits message is sent.
    /// Post-Session
    ///     * Purging of the Orders for a Member (command entered by Market Control at the request of the member, but executed by the system during Post-Session): for each instrument for which at least one of the 5 best limits is affected, an MMTP-04 – Best Limits message is sent.
    ///     * Rebroadcasting of the market sheet for one or more instruments or for all instruments: for each group for which rebroadcasting has not been explicitly forbidden and for each instrument in a group for which rebroadcasting has not been explicitly forbidden, an MMTP-04 – Best Limits message is sent.
    /// </summary>
    public class Message_04 : MessageContents //Length ==>75-385 , Short description ==> Best Limits
    {
        //********************************************************************************************
        public Message_04()
        {
            _ObsFields = new ObservableCollection<Field>();
            Field xField;

            xField = new Field("YOmOrgTran", FieldType.Alphanumerical, 1, 1, "Type of orders at the origin of a trade", "", "142", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_1", FieldType.Alphanumerical, 6, 2, "", "", "", "");
            _ObsFields.Add(xField);

            //Occ. 6
            xField = new Field("ItabModMeLim_1", FieldType.Alphanumerical, 1, 8, "Change of best limit flag", "", "90", "6");
            _ObsFields.Add(xField);


            xField = new Field("ItabModMeLim_2", FieldType.Alphanumerical, 1, 9, "Change of best limit flag", "", "90", "6");
            _ObsFields.Add(xField);


            xField = new Field("ItabModMeLim_3", FieldType.Alphanumerical, 1, 10, "Change of best limit flag", "", "90", "6");
            _ObsFields.Add(xField);


            xField = new Field("ItabModMeLim_4", FieldType.Alphanumerical, 1, 11, "Change of best limit flag", "", "90", "6");
            _ObsFields.Add(xField);


            xField = new Field("ItabModMeLim_5", FieldType.Alphanumerical, 1, 12, "Change of best limit flag", "", "90", "6");
            _ObsFields.Add(xField);


            xField = new Field("ItabModMeLim_6", FieldType.Alphanumerical, 1, 13, "Change of best limit flag", "", "90", "6");
            _ObsFields.Add(xField);

            //AMeLim ==> Best limit aggregate ,Occ. 6
            xField = new Field("QTitMeDem_1", FieldType.Numerical, 12, 14, "Best buy limit quantity", "", "118", "");
            _ObsFields.Add(xField);

            xField = new Field("ZOrdMeDem_1", FieldType.Numerical, 4, 26, "Number of orders at a best buy limit", "", "149", "");
            _ObsFields.Add(xField);

            xField = new Field("PmeDem_1", FieldType.QtmX, 14, 30, "Best buy limit price", "", "106", "");
            _ObsFields.Add(xField);

            xField = new Field("PmeOf_1", FieldType.QtmX, 14, 44, "Best sell limit price", "", "107", "");
            _ObsFields.Add(xField);

            xField = new Field("ZOrdMeOf_1", FieldType.Numerical, 4, 58, "Number of orders at a best sell limit", "", "149", "");
            _ObsFields.Add(xField);

            xField = new Field("QTitMeOf_1", FieldType.Numerical, 12, 62, "Best sell limit quantity", "", "119", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_2", FieldType.Alphanumerical, 2, 74, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("QTitMeDem_2", FieldType.Numerical, 12, 76, "Best buy limit quantity", "", "118", "");
            _ObsFields.Add(xField);

            xField = new Field("ZOrdMeDem_2", FieldType.Numerical, 4, 88, "Number of orders at a best buy limit", "", "149", "");
            _ObsFields.Add(xField);

            xField = new Field("PmeDem_2", FieldType.QtmX, 14, 92, "Best buy limit price", "", "106", "");
            _ObsFields.Add(xField);

            xField = new Field("PmeOf_2", FieldType.QtmX, 14, 106, "Best sell limit price", "", "107", "");
            _ObsFields.Add(xField);

            xField = new Field("ZOrdMeOf_2", FieldType.Numerical, 4, 120, "Number of orders at a best sell limit", "", "149", "");
            _ObsFields.Add(xField);

            xField = new Field("QTitMeOf_2", FieldType.Numerical, 12, 124, "Best sell limit quantity", "", "119", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_3", FieldType.Alphanumerical, 2, 136, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("QTitMeDem_3", FieldType.Numerical, 12, 138, "Best buy limit quantity", "", "118", "");
            _ObsFields.Add(xField);

            xField = new Field("ZOrdMeDem_3", FieldType.Numerical, 4, 150, "Number of orders at a best buy limit", "", "149", "");
            _ObsFields.Add(xField);

            xField = new Field("PmeDem_3", FieldType.QtmX, 14, 154, "Best buy limit price", "", "106", "");
            _ObsFields.Add(xField);

            xField = new Field("PmeOf_3", FieldType.QtmX, 14, 168, "Best sell limit price", "", "107", "");
            _ObsFields.Add(xField);

            xField = new Field("ZOrdMeOf_3", FieldType.Numerical, 4, 182, "Number of orders at a best sell limit", "", "149", "");
            _ObsFields.Add(xField);

            xField = new Field("QTitMeOf_3", FieldType.Numerical, 12, 182, "Best sell limit quantity", "", "119", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_4", FieldType.Alphanumerical, 2, 198, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("QTitMeDem_4", FieldType.Numerical, 12, 200, "Best buy limit quantity", "", "118", "");
            _ObsFields.Add(xField);

            xField = new Field("ZOrdMeDem_4", FieldType.Numerical, 4, 212, "Number of orders at a best buy limit", "", "149", "");
            _ObsFields.Add(xField);

            xField = new Field("PmeDem_4", FieldType.QtmX, 14, 216, "Best buy limit price", "", "106", "");
            _ObsFields.Add(xField);

            xField = new Field("PmeOf_4", FieldType.QtmX, 14, 230, "Best sell limit price", "", "107", "");
            _ObsFields.Add(xField);

            xField = new Field("ZOrdMeOf_4", FieldType.Numerical, 4, 244, "Number of orders at a best sell limit", "", "149", "");
            _ObsFields.Add(xField);

            xField = new Field("QTitMeOf_4", FieldType.Numerical, 12, 248, "Best sell limit quantity", "", "119", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_5", FieldType.Alphanumerical, 2, 260, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("QTitMeDem_5", FieldType.Numerical, 12, 262, "Best buy limit quantity", "", "118", "");
            _ObsFields.Add(xField);

            xField = new Field("ZOrdMeDem_5", FieldType.Numerical, 4, 274, "Number of orders at a best buy limit", "", "149", "");
            _ObsFields.Add(xField);

            xField = new Field("PmeDem_5", FieldType.QtmX, 14, 278, "Best buy limit price", "", "106", "");
            _ObsFields.Add(xField);

            xField = new Field("PmeOf_5", FieldType.QtmX, 14, 292, "Best sell limit price", "", "107", "");
            _ObsFields.Add(xField);

            xField = new Field("ZOrdMeOf_5", FieldType.Numerical, 4, 306, "Number of orders at a best sell limit", "", "149", "");
            _ObsFields.Add(xField);

            xField = new Field("QTitMeOf_5", FieldType.Numerical, 12, 314, "Best sell limit quantity", "", "119", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_6", FieldType.Alphanumerical, 2, 322, "", "", "", "");
            _ObsFields.Add(xField);

            xField = new Field("QTitMeDem_6", FieldType.Numerical, 12, 324, "Best buy limit quantity", "", "118", "");
            _ObsFields.Add(xField);

            xField = new Field("ZOrdMeDem_6", FieldType.Numerical, 4, 336, "Number of orders at a best buy limit", "", "149", "");
            _ObsFields.Add(xField);

            xField = new Field("PmeDem_6", FieldType.QtmX, 14, 340, "Best buy limit price", "", "106", "");
            _ObsFields.Add(xField);

            xField = new Field("PmeOf_6", FieldType.QtmX, 14, 354, "Best sell limit price", "", "107", "");
            _ObsFields.Add(xField);

            xField = new Field("ZOrdMeOf_6", FieldType.Numerical, 4, 368, "Number of orders at a best sell limit", "", "149", "");
            _ObsFields.Add(xField);

            xField = new Field("QTitMeOf_6", FieldType.Numerical, 12, 372, "Best sell limit quantity", "", "119", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_7", FieldType.Alphanumerical, 2, 384, "", "", "", "");
            _ObsFields.Add(xField);
        }
    }
}
