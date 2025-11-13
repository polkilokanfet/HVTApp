using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using HVTApp.Infrastructure.Extensions;
using HVTApp.Model.POCOs;
using HVTApp.Model.Services;
using HVTApp.Services.PrintService.Extensions;
using Infragistics.Documents.Word;
using Microsoft.Practices.Unity;

namespace HVTApp.Services.PrintService
{
    public abstract class PrintUnitsServiceBase : PrintServiceBase
    {
        private readonly PrintProductService _printProductService;

        protected PrintUnitsServiceBase(IUnityContainer container) : base(container)
        {
            _printProductService = container.Resolve<IPrintProductService>() as PrintProductService;
        }

        protected static List<UnitsGroup> GetUnitsGroups(IEnumerable<IUnit> offerUnits)
        {
            //разбиваем на группы, а их делим по объектам
            var offerUnitsGroupsByFacilities = offerUnits
                .Select(offerUnit => new Unit(offerUnit))
                .GroupBy(unit => unit, new Unit.Comparer())
                .Select(x => new UnitsGroup(x))
                .OrderBy(x => x.Units.First(), new Unit.ProductCostComparer())
                .GroupBy(offerUnitsGroup => offerUnitsGroup.Facility)
                .ToList();

            var offerUnitsGroups = offerUnitsGroupsByFacilities.SelectMany(x => x).ToList();

            //назначаем позиции ТКП
            var i = 1;
            offerUnitsGroups.ForEach(offerUnitsGroup => offerUnitsGroup.Position = i++);

            return offerUnitsGroups;
        }


        protected void PrintUnitsTable(List<UnitsGroup> unitsGroups, WordDocumentWriter docWriter,
            Font fontBold, List<IGrouping<Facility, UnitsGroup>> unitsGroupsByFacilities,
            IVatContainer vatContainer)
        {
            var printComments = false;
            if (unitsGroups.Any(x => string.IsNullOrWhiteSpace(x.Comment) == false))
            {
                printComments = MessageService.ConfirmationDialog("Печать комментариев", "Вы хотите включить в таблицу комментарии?", defaultNo: true);
            }
            int columnsCount = printComments ? 7 : 6;

            var colorTableHeader = Colors.AliceBlue;

            var tableBorderProperties = GetTableBorderProperties(docWriter);
            var tableRowProperties = docWriter.CreateTableRowProperties();
            var tableCellProperties = docWriter.CreateTableCellProperties();

            tableCellProperties.BorderProperties = tableBorderProperties;

            var tableProperties = GetTableProperties(docWriter, tableBorderProperties);
            tableProperties.Alignment = ParagraphAlignment.Left;
            docWriter.StartTable(columnsCount, tableProperties);

            tableRowProperties.IsHeaderRow = true;
            tableCellProperties.BackColor = colorTableHeader;
            var paragraphProps = docWriter.CreateParagraphProperties();
            paragraphProps.Alignment = ParagraphAlignment.Left;

            if (printComments)
                docWriter.PrintTableRow(tableCellProperties, tableRowProperties, paragraphProps, fontBold,
                    "№", "Тип", "Обозначение", "Комментарий", "Кол.", "Стоимость", "Сумма");
            else
                docWriter.PrintTableRow(tableCellProperties, tableRowProperties, paragraphProps, fontBold,
                    "№", "Тип", "Обозначение", "Кол.", "Стоимость", "Сумма");

            // Reset the cell properties, so that the cell properties are different from the header cells.
            tableCellProperties.Reset();
            tableCellProperties.VerticalAlignment = TableCellVerticalAlignment.Top;
            // Reset the row properties
            tableRowProperties.Reset();

            ParagraphProperties parPropRight = docWriter.CreateParagraphProperties();
            parPropRight.Alignment = ParagraphAlignment.Right;

            var dr2 = MessageService.ConfirmationDialog("Обозначение", "Использовать полное обозначение оборудования?", defaultYes: true);
            bool printFullDesignation = dr2;

            foreach (var unitsGroupByFacility in unitsGroupsByFacilities)
            {
                //Название объекта
                docWriter.StartTableRow();

                tableCellProperties.ColumnSpan = columnsCount;
                docWriter.PrintTableCell($"{unitsGroupByFacility.Key}", tableCellProperties, font: fontBold); //объект

                docWriter.EndTableRow();

                tableCellProperties.ColumnSpan = 1;
                foreach (var offerUnitsGroup in unitsGroupByFacility)
                {
                    docWriter.StartTableRow();

                    docWriter.PrintTableCell(offerUnitsGroup.Position.ToString(), tableCellProperties); //номер строки ТКП
                    docWriter.PrintTableCell(offerUnitsGroup.Product.ProductType?.Name, tableCellProperties); //тип оборудования
                    var des = printFullDesignation ? offerUnitsGroup.Product.Designation : offerUnitsGroup.Product.Category.NameShort;
                    docWriter.PrintTableCell(des, tableCellProperties); //обозначение
                    if (printComments) docWriter.PrintTableCell($"{offerUnitsGroup.Comment}", tableCellProperties); //комментарий
                    docWriter.PrintTableCell($"{offerUnitsGroup.Amount:D}", tableCellProperties, parPropRight); //количество
                    docWriter.PrintTableCell($"{offerUnitsGroup.Cost:N}", tableCellProperties, parPropRight); //стоимость
                    docWriter.PrintTableCell($"{offerUnitsGroup.Total:N}", tableCellProperties, parPropRight); //сумма

                    docWriter.EndTableRow();
                }
            }

            //сумма ТКП
            var sum = unitsGroups.Sum(x => x.Amount * x.Cost);

            tableCellProperties.BackColor = colorTableHeader;

            PrintSumTableString("Итого без НДС:", sum, docWriter, tableCellProperties, fontBold, parPropRight, columnsCount);
            PrintSumTableString($"НДС ({vatContainer.Vat} %):", sum * vatContainer.Vat / 100, docWriter, tableCellProperties, fontBold, parPropRight, columnsCount);
            PrintSumTableString("Итого с НДС:", sum * (1 + vatContainer.Vat / 100), docWriter, tableCellProperties, fontBold, parPropRight, columnsCount);

            docWriter.EndTable();
        }

        protected static void PrintSumTableString(
            string text, double sum, WordDocumentWriter docWriter, TableCellProperties tableCellProperties,
            Font font, ParagraphProperties parProp, int columnsCount)
        {
            docWriter.StartTableRow();
            tableCellProperties.ColumnSpan = columnsCount - 1;
            docWriter.PrintTableCell(text, tableCellProperties, null, font);
            tableCellProperties.ColumnSpan = 1;
            docWriter.PrintTableCell($"{sum:N}", tableCellProperties, parProp, font);
            docWriter.EndTableRow();
        }

        protected virtual string GetShipmentConditions(List<UnitsGroup> unitsGroups)
        {
            var shipmentPositions = unitsGroups
                .Where(x => x.CostDelivery.HasValue && x.CostDelivery > 0)
                .ToList();

            if (shipmentPositions.Any() == false)
                return "Отгрузка оборудования производится путём выборки товара (получение товара в месте поставки: склад Поставщика по адресу Российская Федерация, г.Екатеринбург, ул.Фронтовых бригад, д.22).";

            if (unitsGroups.Count == shipmentPositions.Count)
                return $"В стоимости оборудования учтены расходы, связанные с его доставкой на объект, расположенный по адресу {shipmentPositions.First().Facility}.";

            var s = shipmentPositions.Select(x => $"{x.Product.Category.NameShort} (поз. {x.Position})").ToStringEnum(", ");

            return $"В стоимости {s} учтены расходы, связанные с доставкой этого оборудования на объект, расположенный по адресу {shipmentPositions.First().Facility}.";
        }

        protected string GetSupervisionConditionsForOffer(List<UnitsGroup> unitsGroups)
        {
            var supervisionPositions = unitsGroups
                .Where(unitsGroup => unitsGroup.ProductsIncluded
                    .Any(productIncluded => productIncluded.Product.ProductBlock.IsSupervision))
                .ToList();

            if (supervisionPositions.Any() == false)
                return "В стоимости оборудования не учтены расходы, связанные с его шеф-монтажом на объекте.";

            var sb = new StringBuilder();

            if (unitsGroups.Count == supervisionPositions.Count)
                return "В стоимости оборудования учтены расходы, связанные с его шеф-монтажом на объекте.";
            
            var s = supervisionPositions.Select(x => $"{x.Product.Category.NameShort} (поз. {x.Position})").ToStringEnum(", ");
            return $"В стоимости {s} учтены расходы, связанные с шеф-монтажом этого оборудования на объекте.";
        }

        protected string GetSupervisionConditionsForSpecification(List<UnitsGroup> unitsGroups, bool addSupervisionAttachment)
        {
            var sb = new StringBuilder(this.GetSupervisionConditionsForOffer(unitsGroups));

            sb.AppendLine("\nНачало: после уведомления Покупателя о направлении шеф-инженера, окончание: в течение 3 дней после прибытия шеф-инженера на объект. Стоимость шефмонтажа входит в цену товара. В случае, если после прибытия специалиста на объект оказание услуг или их завершение в указанный срок стало невозможным по причинам не зависящим от специалиста Поставщик отзывает его с объекта либо вправе дать согласие о продлении срока услуг. В случае согласия Поставщика продлить срок оказания услуг Покупатель осуществляет доплату за сверх установленное пребывание специалиста из расчета 15 000 рублей, за каждый день пребывания сверх указанного срока окончания услуг.");

            sb.Append(addSupervisionAttachment
                ? "Условия шефмонтажа согласно приложениям №2, 3 к настоящей спецификации."
                : "Условия шефмонтажа согласно приложениям №1, 2 к договору поставки.");

            return sb.ToString();
        }

        protected static string PrintPaymentConditions(string text, IEnumerable<IGrouping<PaymentConditionSet, UnitsGroup>> offerUnitsGroupsGrouped, DateTime date)
        {
            var result = text;
            var g = offerUnitsGroupsGrouped as IGrouping<PaymentConditionSet, UnitsGroup>[] ?? offerUnitsGroupsGrouped.ToArray();
            if (g.Length == 1)
            {
                var paymentConditionSet = g.First().Key;
                return result + Environment.NewLine + paymentConditionSet.GetStringForOffer(date);
            }

            foreach (var unitsGroups in g)
            {
                result += Environment.NewLine + "- ";
                var positions = unitsGroups.Select(x => x.Position).ToStringEnum(", ");
                var prefix = unitsGroups.Count() == 1 ? "позиции" : "позиций";
                result += PrintPaymentConditions($"{prefix} {positions}:", unitsGroups.GroupBy(x => x.PaymentConditionSet), date);
            }
            return result;
        }

        protected static string PrintConditions<T>(string text, IEnumerable<IGrouping<T, UnitsGroup>> unitsGroupsGrouped)
        {
            var result = text;
            if (unitsGroupsGrouped.Count() == 1)
            {
                return $"{text} {unitsGroupsGrouped.First().Key}.";
            }

            foreach (var unitsGroups in unitsGroupsGrouped)
            {
                result += Environment.NewLine + "- ";
                var positions = unitsGroups.Select(x => x.Position).ToStringEnum(", ");
                var prefix = unitsGroups.Count() == 1 ? "позиции" : "позиций";
                result += $"{prefix} {positions}: {unitsGroups.Key}.";
            }
            return result;
        }

        protected void PrintTechnicalDetails(WordDocumentWriter docWriter, List<IGrouping<Facility, UnitsGroup>> unitsGroupsByFacilities)
        {
            docWriter.PrintParagraph("Технические характеристики оборудования:");
            foreach (var offerUnitsGroupsByFacility in unitsGroupsByFacilities)
            {
                foreach (var unitsGroup in offerUnitsGroupsByFacility)
                {
                    docWriter.PrintParagraph(Environment.NewLine + $"{unitsGroup.Position}. {unitsGroup.Product} - {unitsGroup.Amount} шт.:");
                    _printProductService.Print(docWriter, unitsGroup.Product);

                    // включенное в состав оборудование
                    if (unitsGroup.ProductsIncluded.Any())
                    {
                        docWriter.PrintParagraph(Environment.NewLine + "Дополнительное оборудование и услуги, включенные в состав:");

                        int n = 1;
                        var productsIncluded = unitsGroup.ProductsIncluded.GroupBy(productIncluded => new
                        {
                            productIncluded.Product,
                            productIncluded.Amount
                        });
                        foreach (var productIncluded in productsIncluded)
                        {
                            docWriter.PrintParagraph(Environment.NewLine + $"{unitsGroup.Position}.{n++} {productIncluded.Key.Product} - {productIncluded.Count() * productIncluded.Key.Amount} шт.:");
                            _printProductService.Print(docWriter, productIncluded.Key.Product);
                        }
                    }
                }
            }
        }


        protected override string GetFullPath(Document document, string path)
        {
            throw new NotImplementedException();
        }

        protected override void PrintBody(Document document, WordDocumentWriter docWriter)
        {
            throw new NotImplementedException();
        }

    }
}