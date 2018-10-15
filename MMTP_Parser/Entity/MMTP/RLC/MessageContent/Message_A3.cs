using MMTP_Parser.Entity.Custom;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTP_Parser.Entity.MMTP.RLC.MessageContent
{
    ///     <summary>
    ///Processing rules
    ///     This message, which is sent by NSC®, indicates the creation or modification of an order for an
    ///     instrument. It is also used when the Market Sheet is rebroadcast. The deletion of an order is
    ///     indicated via an RLC-A4 – Delete N Lines message. This processing concerns any order type except
    ///     Stop orders. Indeed, Stop orders are not broadcast to the market participants until their triggering.
    ///     This message enables the market participant to consult the full market depth.
    ///     The action code (CActFdm) defines whether the order is to be added or updated or whether the
    ///     message is sent during rebroadcasting of the market sheets.
    ///     The order identification (entry date DSaiOm and sequence number NSeqOm) and characteristics
    ///     (side ISensOm, original price PLimSaiOm, displayed price PAffOm, displayed quantity QTitMtrOm,
    ///     remaining quantity QTitRestOm, type of clearing account YCpteOm, technical origin YOm, type of limit
    ///     YPLimSaiOm, priority date & time DHPriOm) are also provided.
    ///Transmission functions
    ///Processing in Pre-Opening
    ///     • For each incoming order into the order book, the system sends a Market Sheet message
    ///     with an action code (CActFdm) of C (Creation).
    ///     • For each modified order, the system sends an RLC-A4 – Delete N Lines message with a
    ///     deletion type (YSupOm) set to 1 (Delete one order) and a RLC-A3 – Market Sheet message
    ///     with an action code (CActFdm) of C (Creation).
    ///Opening of an instrument with its group
    ///     • During opening processing, in case of matching with Market Orders and Market On Opening
    ///     orders.
    ///     If Market On Opening orders are not executed, then sending of an RLC-A4 – Delete N Lines
    ///     message with a deletion type (YSupOm) set to 2 for the Market Orders, and sending of a A4
    ///     – Delete N Lines message with a deletion type set to 1 for each unfilled Market On Opening
    ///     orders. And then sending of a Market Sheet message with an action code (CActFdm) of C
    ///     (Creation) for each unfilled Market On Opening order.
    ///     If Market On Opening orders are partially executed, then sending of a RLC-A4 – Delete N
    ///     Lines message with a deletion type (YSupOm) set to 2 indicating that the Market On
    ///     Opening order has been cancelled and sending of a Market Sheet message with an action
    ///     code (CActFdm) of C (Creation) allowing to recreate the unfilled Market On Opening orders
    ///     as Limited orders.
    ///     • During opening processing, sending of an RLC-A3 – Market Sheet message with an action
    ///     code (CActFdm) of C (Creation) for each triggered Stop order.
    ///Opening of an instrument
    ///     Same as Opening of an instrument with its group.
    ///Auction of an instrument
    ///     Same as Opening of an instrument with its group.
    ///Processing of an Order during Continuous Trading
    ///     • When an order is entered into the order book, the system sends an RLC-A3 – Market Sheet
    ///     message with an action code (CActFdm) of C (Creation)
    ///     • When an order is modified in the order book, the system sends a RLC-A4 – Delete N Lines
    ///     message with a deletion type (YSupOm) of 1 and an RLC-A3 – Market Sheet message with
    ///     an action code (CActFdm) of C (Creation)
    ///     • For each partially executed order, the system sends an RLC-A3 – Market Sheet message
    ///     with an action code (CActFdm) of M (Modification)
    ///     • In case of order with a disclosed quantity matching
    ///     In case of complete "first round of matching": the system sends a RLC-A4 – Delete N Lines message
    ///     with a deletion type (YSupOm) of 1 and an RLC-A3 – Market Sheet message with an action code
    ///     (CActFdm) of C (Creation)
    ///     In case of non complete "round of matching": the system sends an RLC-A3 – Market Sheet message
    ///     with an action code (CActFdm) of M (Modification)
    ///Market Control Commands
    ///     Modification of the Market Sheet broadcasting flag
    ///     In case of transition from Fast Market to Slow Market, the resumption of the broadcasting of the
    ///     Market Sheet update message is preceded by a re-broadcasting of the entire Market Sheet. NSC®
    ///     sends an RLC-A3 – Market Sheet message (action code CActFdm of R) for each order remaining in
    ///     the order book for the instrument, these messages are surrounded by two RLC-AO – Start / End of
    ///     Market Sheet Broadcasting messages.
    ///         Post-Session
    ///     When the Market Sheet for one, several, or all instruments is rebroadcast, then for each group where
    ///     re-broadcasting has not explicitly forbidden, for each instrument in a group which is not in Fast
    ///     Market and where rebroadcasting has not been explicitly forbidden, for each normal order present in
    ///     the order book, the system sends an RLC-A3 – Market Sheet message with an action code CActFdm)
    ///     of R (Rebroadcasting). These messages are surrounded by two RLC-AO – Start / End of Market Sheet
    ///     Broadcasting messages.
    ///     </summary>
    public class Message_A3 : MessageContents //Length ==> 101 , Short description ==> Market Sheet
    {
        //********************************************************************************************
        public Message_A3()
        {
            _ObsFields = new ObservableCollection<Field>();
            Field xField;

            xField = new Field("CActFdm", FieldType.Alphanumerical, 1, 1, "Market sheet action code", "", "86", "");
            _ObsFields.Add(xField);

            xField = new Field("ISensOm", FieldType.Alphanumerical, 1, 2, "Side of order of order", "", "120", "");
            _ObsFields.Add(xField);

            xField = new Field("PLimSaiOm", FieldType.QtmX, 14, 3, "Original Order Price", "", "138", "");
            _ObsFields.Add(xField);

            xField = new Field("QTitMtrOm", FieldType.Numerical, 12, 17, "Order displayed quantity", "", "151", "");
            _ObsFields.Add(xField);

            xField = new Field("QTitRestOm", FieldType.Numerical, 12, 29, "Remaining Quantity of the Order", "", "152", "");
            _ObsFields.Add(xField);

            xField = new Field("PAffOm", FieldType.QtmX, 14, 41, "Displayed order price", "", "134", "");
            _ObsFields.Add(xField);

            xField = new Field("YCpteOm", FieldType.Alphanumerical, 1, 55, "Type of Clearing Account for Member that owns the order", "", "169", "");
            _ObsFields.Add(xField);

            xField = new Field("YOm", FieldType.Numerical, 1, 56, "Code for the Technical Origin of the Order", "", "175", "");
            _ObsFields.Add(xField);

            xField = new Field("Filler_1", FieldType.Alphanumerical, 1, 57, "", "", "", "");
            _ObsFields.Add(xField);

            //AIdOm ==> Order identification , Paga = 84
            xField = new Field("CIdAdh", FieldType.Alphanumerical, 8, 58, "Member ID", "", "92", "");
            _ObsFields.Add(xField);

            xField = new Field("DSaiOm", FieldType.Numerical, 8, 66, "Order entry date (in the Central Trading System)", "", "108", "");
            _ObsFields.Add(xField);

            xField = new Field("NSeqOm", FieldType.Numerical, 6, 74, "Order sequence number", "", "132", "");
            _ObsFields.Add(xField);


            xField = new Field("YPLimSaiOm", FieldType.Alphanumerical, 1, 80, "Type of Limit for an Order", "", "177", "");
            _ObsFields.Add(xField);

            xField = new Field("DHPriOm", FieldType.Alphanumerical, 20, 81, "Order priority date time", "", "107", "");
            _ObsFields.Add(xField);

            xField = new Field("YAppaValMdv", FieldType.Alphanumerical, 1, 101, "Matching type", "", "168", "");
            _ObsFields.Add(xField);
        }
    }
}
