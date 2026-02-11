using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using HVTApp.Model.POCOs;
using HVTApp.Model.Services;
using HVTApp.Services.PrintService.Extensions;
using Infragistics.Documents.Word;
using Microsoft.Practices.Unity;

namespace HVTApp.Services.PrintService
{
    public class PrintSupervisionLetterService : PrintServiceBase, IPrintSupervisionLetterService
    {
        public PrintSupervisionLetterService(IUnityContainer container) : base(container) { }

        private List<Supervision> _supervisions;
        private string _supervisionContractNumber;
        private DateTime _supervisionContractDate;
        public void PrintSupervisionLetter(
            IEnumerable<Supervision> supervisions1,
            string supervisionContractNumber,
            DateTime supervisionContractDate, 
            Document letter, string path = "")
        {
            _supervisions = supervisions1.OrderBy(x => x.SalesUnit.SerialNumber).ToList();
            _supervisionContractNumber = supervisionContractNumber;
            _supervisionContractDate = supervisionContractDate;
            this.PrintOnLetterhead(letter, path);
        }

        protected override string GetFullPath(Document document, string path)
        {
            return document.GetPath(path);
        }

        protected override void PrintBody(Document document, WordDocumentWriter docWriter)
        {
            Font fontBold = docWriter.CreateFont();
            fontBold.Bold = true;

            var paraFormat1 = docWriter.CreateParagraphProperties();
            paraFormat1.Alignment = ParagraphAlignment.Both;
            var specification = _supervisions.First().SalesUnit.Specification;
            docWriter.PrintParagraph($"В соответствии с договором {_supervisionContractNumber} от {_supervisionContractDate.ToShortDateString()} г., прошу Вас организовать выезд специалиста для проведения шеф-монтажных работ (согласно спецификации {specification?.Number} к договору {specification?.Contract.Number} от {specification?.Contract.Date.ToShortDateString()}) на следующем оборудовании:", paraFormat1);
            
            #region Print Main Table

            var colorTableHeader = Colors.AliceBlue;

            var tableBorderProperties = GetTableBorderProperties(docWriter);
            var tableRowProperties = docWriter.CreateTableRowProperties();
            var tableCellProperties = docWriter.CreateTableCellProperties();

            tableCellProperties.BorderProperties = tableBorderProperties;

            var tableProperties = GetTableProperties(docWriter, tableBorderProperties);
            tableProperties.Alignment = ParagraphAlignment.Left;
            docWriter.StartTable(8, tableProperties);

            tableRowProperties.IsHeaderRow = true;
            tableCellProperties.BackColor = colorTableHeader;
            var paragraphProps = docWriter.CreateParagraphProperties();
            paragraphProps.Alignment = ParagraphAlignment.Left;

            docWriter.PrintTableRow(tableCellProperties, tableRowProperties, paragraphProps, fontBold, 
                "№", "Тип оборудования", "Обозначение оборудования", "з/з (поз.)", "зав.№", "Заказ клиента", "Сервисный заказ", "Требуемая дата монтажа");

            // Reset the cell properties, so that the cell properties are different from the header cells.
            tableCellProperties.Reset();
            tableCellProperties.VerticalAlignment = TableCellVerticalAlignment.Top;
            // Reset the row properties
            tableRowProperties.Reset();

            ParagraphProperties parPropRight = docWriter.CreateParagraphProperties();
            parPropRight.Alignment = ParagraphAlignment.Right;

            int num = 0;
            foreach (var supervisionsGroupsByFacility in _supervisions.GroupBy(x => x.SalesUnit.Facility))
            {

                //Название объекта
                docWriter.StartTableRow();

                tableCellProperties.ColumnSpan = 7;
                var facility = supervisionsGroupsByFacility.Key;
                var address = facility.Address.ToString();
                docWriter.PrintTableCell($"{facility} ({address})", tableCellProperties, font: fontBold); //объект

                docWriter.EndTableRow();

                tableCellProperties.ColumnSpan = 1;
                foreach (var supervision in supervisionsGroupsByFacility)
                {
                    docWriter.StartTableRow();

                    num++;
                    docWriter.PrintTableCell(num.ToString(), tableCellProperties); //номер строки
                    docWriter.PrintTableCell(supervision.SalesUnit.Product.ProductType?.Name, tableCellProperties);
                    //тип оборудования
                    docWriter.PrintTableCell(supervision.SalesUnit.Product.Designation, tableCellProperties); //обозначение
                    docWriter.PrintTableCell($"{supervision.SalesUnit.Order} ({supervision.SalesUnit.OrderPosition})", tableCellProperties);
                    docWriter.PrintTableCell($"{supervision.SalesUnit.SerialNumber}", tableCellProperties);
                    docWriter.PrintTableCell($"{supervision.ClientOrderNumber}", tableCellProperties);
                    docWriter.PrintTableCell($"{supervision.ServiceOrderNumber}", tableCellProperties);
                    var dateReq = supervision.DateRequired?.ToShortDateString() ?? "по согл.";
                    docWriter.PrintTableCell(dateReq, tableCellProperties);

                    docWriter.EndTableRow();
                }
            }
            docWriter.EndTable();

            #endregion

            #region Print Text After Table

            docWriter.PrintParagraph($"Оплата стоимости шеф-монтажных работ будет произведена в соответствии с договором {_supervisionContractNumber} от {_supervisionContractDate.ToShortDateString()} г.", paraFormat1);
            var manager = _supervisions.First().SalesUnit.Project.Manager.Employee;
            docWriter.PrintParagraph($"Ответственный менеджер: {manager.Person}, тел.: {manager.PhoneNumber}; e-mail: {manager.Email}", paraFormat1);
            docWriter.PrintParagraph("Приложение: письмо Заказчика.", paraFormat1);

            #endregion
        }
    }

}