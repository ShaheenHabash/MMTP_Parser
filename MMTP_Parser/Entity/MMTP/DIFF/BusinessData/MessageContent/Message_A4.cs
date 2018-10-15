using MMTP_Parser.Entity.Custom;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTP_Parser.Entity.MMTP.DIFF.BusinessData.MessageContent
{
    /// <summary>
    ///Prrocceessssiing rrulleess
    ///     This message, which is sent by NSC®, indicates the deletion of an order for an instrument. This
    ///     processing concerns any order type except Stop orders. Indeed, Stop orders are not broadcast to the
    ///     market participants until their triggering, thus it is not necessary to broadcast an RLC-A4 – Delete N
    ///     Lines message in case of Stop order deletion.
    ///     This message makes it possible for the market participants to realign their order book by indicating
    ///     orders that should be deleted.
    ///     Three types of deletion are possible (YSupOm):
    ///     • Type 1: deletion of an order
    ///     • Type 2: deletion of all orders for a given side (buy or sell) starting with the referenced order
    ///     • Type 3: deletion of all orders for the instrument
    ///     The referenced order identification (entry date DSaiOm and sequence number NSeqOm) and side
    ///     ISensOm are provided to allow the message addressee to process the deletion in the market sheet.
    ///    Transmission functions
    ///    Processing in Pre-Opening
    ///         • For each order that is cancelled, an RLC-A4 – Delete N Lines message (YSupOm Type 1) is
    ///         sent.
    ///         • For each modified order, the system sends an RLC-A4 – Delete N Lines message (YSupOm
    ///         Type 1) and an RLC-A3 – Market Sheet message with an action code (CActFdm) of C
    ///         (Creation).
    ///    Opening of an instrument with its group
    ///         • If the instrument is neither reserved nor suspended
    ///         * If the TOP (Theoretical Opening Price) cannot be determined and there are no
    ///         unmatched Market On Opening orders or Market Orders for this instrument, then for
    ///         each FAK order in the order book, an RLC-A4 – Delete N Lines message (YSupOm Type 1)
    ///         is sent.
    ///             * If the TOP has been determined and falls within the price thresholds, in case of trade,
    ///         two RLC-A4 – Delete N Lines messages (one per side ISensOm) are sent (YSupOm Type
    ///         2), indicating up to which order, all orders should be deleted. And for each non-executed
    ///         FAK order, an RLC-A4 – Delete N Lines message (YSupOm Type 1) is sent.
    ///         • If the instrument is reserved or suspended:
    ///         The conditions for sending the message are identical to those of the function "Opening of an
    ///         Instrument" See below.
    ///    Opening of an instrument
    ///         • If the TOP (Theoretical Opening Price) cannot be determined and there are no unmatched
    ///         Must Be Filled orders, Market On Opening orders or Market Orders for this instrument, then
    ///         for each FAK order in the order book, an RLC-A4 – Delete N Lines message (YSupOm Type 1)
    ///         is sent.
    ///         • If the TOP has been determined and falls within the price thresholds, in case of trade, two
    ///         RLC-A4 – Delete N Lines messages (one per side ISensOm) are sent (YSupOm Type 2),
    ///         indicating up to which order, all orders should be deleted. And for each non-executed FAK
    ///         order, an RLC-A4 – Delete N Lines message (YSupOm Type 1) is sent.
    ///    Auction of an instrument
    ///         • If the TOP (Theoretical Opening Price) cannot be determined and there are no unmatched
    ///         Must Be Filled orders, Market On Opening orders or Market Orders for this instrument, then
    ///         for each FAK order in the order book, an RLC-A4 – Delete N Lines message (YSupOm Type 1)
    ///         is sent.
    ///         • If the TOP has been determined and falls within the price thresholds, in case of trade, two
    ///         RLC-A4 – Delete N Lines messages (one per side) are sent (YSupOm Type 2), indicating up
    ///         to which order, all orders should be deleted. And for each non-executed FAK order, an RLCA4
    ///         – Delete N Lines message (YSupOm Type 1) is sent.
    ///    Processing of an Order during Continuous Trading
    ///         • For each order that is cancelled, an RLC-A4 – Delete N Lines message is sent (YSupOm Type
    ///         1).
    ///         • For each order that is modified, the system sends an RLC-A4 – Delete N Lines message
    ///         (YSupOm Type 1) and an RLC-A3 – Market Sheet message with an action code (CActFdm)
    ///         set at C (Creation).
    ///         • For each partially executed order, the system sends an RLC-A3 – Market Sheet message
    ///         with an action code (CActFdm) of M (Modification). No RLC-A4 – Delete N Lines message is
    ///         sent in that case.
    ///         • For all fully executed orders, an RLC-A4 – Delete N Lines message (YSupOm Type 1) is sent.
    ///    Market Control Commands
    ///         Elimination of all orders in the book for an instrument
    ///         If at least, one order remains in the order book, an RLC-A4 – Delete N Lines message is sent with a
    ///         deletion type that indicates deletion of all orders (YSupOm Type 3).
    ///         Elimination of orders in the book for an instrument group
    ///         When the Market Control purges all orders for all instruments in a group, starting with a given time,
    ///         an RLC-A4 – Delete N Lines message is sent with a deletion type that indicates deletion of an
    ///         individual order (YSupOm Type 1).
    ///         Cancellation of all orders for a Member
    ///         An RLC-A4 – Delete N Lines message (YSupOm Type 1) is sent for each cancelled order.
    ///    Post-Session
    ///         Purging of orders (the order validity has been reached)
    ///         An RLC-A4 – Delete N Lines message (YSupOm Type 1) is sent for each cancelled order.
    ///         Purging of the orders for a Member (command entered by Market Control at the request of the
    ///         member, but executed by the system in Post-Session)
    ///         For each order in the order book, an RLC-A4 – Delete N Lines message (YSupOm Type 1) is sent.
    ///         Resending of the Market Sheet for one or more instruments
    ///         for each group for which Market Control has not explicitly forbidden resending, and for each
    ///         instrument in a group for which Market Control has not explicitly forbidden resending, an RLC-A4 –
    ///         Delete N Lines message (YSupOm Type 3) is sent.
    /// </summary>
    public class Message_A4 : MessageContents //Length ==> 24 , Short description ==> Delete N Lines
    {
        //********************************************************************************************
        public Message_A4()
        {
            _ObsFields = new ObservableCollection<Field>();
            Field xField;

            xField = new Field("YSupOm", FieldType.Alphanumerical, 1, 1, "Deletion type", "", "179", "");
            _ObsFields.Add(xField);

            //AIdOm ==> Order identification , Paga = 84
            xField = new Field("CIdAdh", FieldType.Alphanumerical, 8, 2, "Member ID", "", "92", "");
            _ObsFields.Add(xField);

            xField = new Field("DSaiOm", FieldType.Numerical, 8, 10, "Order entry date (in the Central Trading System)", "", "108", "");
            _ObsFields.Add(xField);

            xField = new Field("NSeqOm", FieldType.Numerical, 6, 18, "Order sequence number", "", "132", "");
            _ObsFields.Add(xField);


            xField = new Field("ISensOm", FieldType.Alphanumerical, 1, 24, "Side of order", "", "120", "");
            _ObsFields.Add(xField);
        }
    }
}
