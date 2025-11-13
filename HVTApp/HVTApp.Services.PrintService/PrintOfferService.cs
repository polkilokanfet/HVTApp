using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HVTApp.Infrastructure;
using HVTApp.Infrastructure.Extensions;
using HVTApp.Infrastructure.Services;
using HVTApp.Model;
using HVTApp.Model.POCOs;
using HVTApp.Services.PrintService.Extensions;
using Infragistics.Documents.Word;
using Microsoft.Practices.Unity;

namespace HVTApp.Services.PrintService
{
    public class PrintOfferService : PrintUnitsServiceBase, IPrintOfferService
    {
        public PrintOfferService(IUnityContainer container) : base(container)
        {
        }

        public void PrintOffer(Guid offerId, string path = "")
        {
            var offer = Container.Resolve<IUnitOfWork>().Repository<Offer>().GetById(offerId);
            var unitsGroups = GetUnitsGroups(offer.OfferUnits);
            var unitsGroupsByFacilities = unitsGroups.GroupBy(offerUnitsGroup => offerUnitsGroup.Facility).ToList();

            //полный путь к файлу (с именем файла)
            var fullPath = offer.GetPath(path);

            if (File.Exists(fullPath))
            {
                var dr = MessageService.ConfirmationDialog("Внимание", "Это ТКП уже напечатано. Заменить его?", defaultNo: true);
                if (dr == false)
                    return;
            }

            var docWriter = GetWordDocumentWriter(fullPath);
            if (docWriter == null) return;
            docWriter.StartDocument();

            #region Print Header

            docWriter.StartParagraph();
            docWriter.AddInlinePicture(GetImage("header.jpg"));
            docWriter.EndParagraph();

            Font fontBold = docWriter.CreateFont();
            fontBold.Bold = true;

            var noBordersTableBorderProperties = docWriter.CreateTableBorderProperties();
            noBordersTableBorderProperties.Style = TableBorderStyle.None;
            noBordersTableBorderProperties.Sides = TableBorderSides.None;

            var headTableProperties = GetTableProperties(docWriter, noBordersTableBorderProperties);
            headTableProperties.Alignment = ParagraphAlignment.Left;
            headTableProperties.PreferredWidthAsPercentage = 100;
            docWriter.StartTable(2, headTableProperties);

            //таблица с номером ТКП
            docWriter.StartTableRow();
            TableCellProperties tableCellProperties1 = docWriter.CreateTableCellProperties();
            tableCellProperties1.PreferredWidthAsPercentage = 50;
            docWriter.StartTableCell(tableCellProperties1);
            docWriter.StartTable(4, headTableProperties);

            docWriter.PrintTableRow(docWriter.CreateTableCellProperties(), docWriter.CreateTableRowProperties(), docWriter.CreateParagraphProperties(), docWriter.CreateFont(),
                "исх.№ ", 
                $"{offer.RegNumber}", 
                "от", 
                $"{offer.Date.ToShortDateString()} г.");

            docWriter.PrintTableRow(docWriter.CreateTableCellProperties(), docWriter.CreateTableRowProperties(), docWriter.CreateParagraphProperties(), docWriter.CreateFont(),
                "на № ", 
                offer.RequestDocument == null ? string.Empty : $"{offer.RequestDocument.RegNumber}", 
                "от", 
                offer.RequestDocument == null ? string.Empty : $"{offer.RequestDocument.Date.ToShortDateString()} г.");

            docWriter.EndTable();
            docWriter.EndTableCell();

            var recipient = offer.RecipientEmployee;
            docWriter.PrintTableCell("Получатель: " + Environment.NewLine + $"{recipient.Position} {recipient.Company.Form.ShortName} \"{recipient.Company.ShortName}\"" + Environment.NewLine + $"{recipient.Person}");

            docWriter.EndTableRow();

            docWriter.PrintTableRow(docWriter.CreateTableCellProperties(), docWriter.CreateTableRowProperties(), docWriter.CreateParagraphProperties(), docWriter.CreateFont(),
                $"О предложении поставки оборудования для нужд объектов: {unitsGroups.Select(x => x.Facility.ToString()).Distinct().OrderBy(x => x).ToStringEnum(", ")}", string.Empty);

            docWriter.EndTable();

            #endregion

            #region Print Text Above Table

            docWriter.PrintParagraph(string.Empty);

            var paraFormat = docWriter.CreateParagraphProperties();
            paraFormat.Alignment = ParagraphAlignment.Center;
            var prefix = offer.RecipientEmployee.Person.IsMan ? "Уважаемый" : "Уважаемая";
            docWriter.PrintParagraph($"{prefix} {offer.RecipientEmployee.Person.Name} {offer.RecipientEmployee.Person.Patronymic}!", paraFormat, fontBold);

            var paraFormat1 = docWriter.CreateParagraphProperties();
            //paraFormat1.LeftIndent = 12;
            paraFormat1.Alignment = ParagraphAlignment.Both;
            docWriter.PrintParagraph($"В ответ на Ваш запрос, предоставляем технико-коммерческое предложение на поставку оборудования по проекту \"{offer.Project.Name}\".", paraFormat1);

            docWriter.PrintParagraph("Стоимость оборудования/услуг (в рублях) приведена в таблице:", paraFormat1, font: fontBold);

            #endregion

            #region Print Main Table

            PrintUnitsTable(unitsGroups, docWriter, fontBold, unitsGroupsByFacilities, offer);

            #endregion

            #region Print Conditions

            var paragraphProperties = docWriter.CreateParagraphProperties();
            paragraphProperties.Alignment = ParagraphAlignment.Both;
            docWriter.PrintParagraph("Условия поставки и оплаты оборудования:", paragraphProperties, fontBold);

            var conditions = new List<string>
            {
                GetSupervisionConditionsForOffer(unitsGroups),
                GetShipmentConditions(unitsGroups),
                PrintPaymentConditions("Условия оплаты:", unitsGroups.GroupBy(x => x.PaymentConditionSet), offer.ValidityDate),
                PrintConditions("Срок производства (календарных дней, с правом досрочной поставки):", unitsGroups.GroupBy(offerUnitsGroup => offerUnitsGroup.ProductionTerm)),
                $"Настоящее предложение действительно при заключении контракта до {offer.ValidityDate.ToShortDateString()} года.",
                "Комплектация и характеристики оборудования в соответствии с техническим приложением к настоящему предложению.",
                "В случае изменения технических характеристик оборудования, объёма поставки или сроков заключения контракта условия предложения могут быть пересмотрены.",
            };

            docWriter.StartTable(2, GetTableProperties(docWriter, noBordersTableBorderProperties));

            var nn = 1;
            foreach (var condition in conditions)
            {
                docWriter.PrintTableRow(docWriter.CreateTableCellProperties(), docWriter.CreateTableRowProperties(), docWriter.CreateParagraphProperties(), docWriter.CreateFont(),
                    $"{nn++}.", condition);
            }

            docWriter.EndTable();

            #endregion

            #region Sender

            docWriter.PrintParagraph(string.Empty);

            var bordProps = docWriter.CreateTableBorderProperties();
            bordProps.Style = TableBorderStyle.None;
            bordProps.Sides = TableBorderSides.None;

            TableProperties tableProperties2 = GetTableProperties(docWriter, bordProps);
            tableProperties2.PreferredWidthAsPercentage = 100;
            docWriter.StartTable(3, tableProperties2);

            TableCellProperties tableCellProperties2 = docWriter.CreateTableCellProperties();
            tableCellProperties2.PreferredWidthAsPercentage = 33;

            docWriter.StartTableRow();

            var part1 = "С уважением," + Environment.NewLine + $"{offer.SenderEmployee.Position}";
            docWriter.PrintTableCell(part1, tableCellProperties2);

            //подпись
            if (GlobalAppProperties.User.Id == GlobalAppProperties.Actual.Developer?.Id)
            {
                var drt = MessageService.ConfirmationDialog("Подпись", "Печать с подписью?", defaultNo:true);
                if (drt)
                {
                    try
                    {
                        docWriter.StartTableCell(tableCellProperties2);

                        var prpr = docWriter.CreateParagraphProperties();
                        prpr.Alignment = ParagraphAlignment.Center;
                        docWriter.StartParagraph(prpr);
                        docWriter.AddInlinePicture(GetImage("sign_deev.png"));
                        docWriter.EndParagraph();

                        docWriter.EndTableCell();

                    }
                    catch (Exception e)
                    {
                        MessageService.Message(e.GetType().ToString(), e.PrintAllExceptions());
                        docWriter.PrintTableCell(string.Empty);
                    }
                }
                else
                {
                    docWriter.PrintTableCell(string.Empty);
                }
            }
            else
            {
                docWriter.PrintTableCell(string.Empty);                
            }

            //ФИО подписывающего лица
            var part3 = Environment.NewLine + $"{offer.SenderEmployee.Person.Name[0]}.{offer.SenderEmployee.Person.Patronymic?[0]}.{offer.SenderEmployee.Person.Surname}";
            var pp = docWriter.CreateParagraphProperties();
            pp.Alignment = ParagraphAlignment.Right;
            docWriter.PrintTableCell(part3, tableCellProperties2, pp);

            docWriter.EndTableRow();

            //docWriter.PrintTableRow(
            //    tableCellProperties2,
            //    docWriter.CreateTableRowProperties(),
            //    docWriter.CreateParagraphProperties(),
            //    docWriter.CreateFont(),
            //    "С уважением," + Environment.NewLine + $"{offer.SenderEmployee.Position}",
            //    string.Empty,
            //    Environment.NewLine + $"{offer.SenderEmployee.Person.Name[0]}.{offer.SenderEmployee.Person.Patronymic?[0]}.{offer.SenderEmployee.Person.Surname}");

            docWriter.EndTable();

            #endregion

            #region Print Technical Details

            paragraphProperties = docWriter.CreateParagraphProperties();
            paragraphProperties.PageBreakBefore = true;
            docWriter.PrintParagraph($"Техническое приложение к предложению исх.№ {offer.RegNumber} от {offer.Date.ToShortDateString()} г.", paragraphProperties, fontBold);
            
            PrintTechnicalDetails(docWriter, unitsGroupsByFacilities);

            #endregion

            #region Author Footer

            var parts = SectionHeaderFooterParts.FooterAllPages;
            var writerSet = docWriter.AddSectionHeaderFooter(parts);
            writerSet.FooterWriterAllPages.Open();

            writerSet.FooterWriterAllPages.StartParagraph();
            writerSet.FooterWriterAllPages.AddTextRun("Исполнитель:" + Environment.NewLine + $"{offer.Author}" + Environment.NewLine + $"тел.: {offer.Author.PhoneNumber}; e-mail: {offer.Author.Email}; ");
            writerSet.FooterWriterAllPages.AddHyperlink(@"http://www.uetm.ru", "uetm.ru");
            writerSet.FooterWriterAllPages.AddTextRun(Environment.NewLine + $"{offer.RegNumber} от {offer.Date.ToShortDateString()} г. - стр. ");
            writerSet.FooterWriterAllPages.AddPageNumberField(PageNumberFieldFormat.Decimal);
            writerSet.FooterWriterAllPages.EndParagraph();

            writerSet.FooterWriterAllPages.Close();

            #endregion

            docWriter.EndDocument();
            docWriter.Close();

            OpenDocument(fullPath);
        }

        protected override string GetShipmentConditions(List<UnitsGroup> unitsGroups)
        {
            var shipmentPositions = unitsGroups
                .Where(x => x.CostDelivery.HasValue && x.CostDelivery > 0)
                .ToList();

            if (shipmentPositions.Any() == false)
                return "В стоимости оборудования не учтены расходы, связанные с его доставкой на объект.";

            if (unitsGroups.Count == shipmentPositions.Count)
                return "В стоимости оборудования учтены расходы, связанные с его доставкой на объект.";

            var s = shipmentPositions.Select(x => $"{x.Product.Category.NameShort} (поз. {x.Position})").ToStringEnum(", ");

            return $"В стоимости {s} учтены расходы, связанные с доставкой этого оборудования на объект.";
        }

    }
}