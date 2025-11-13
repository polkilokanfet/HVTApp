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
    public class PrintContractService : PrintUnitsServiceBase, IPrintContract
    {
        public PrintContractService(IUnityContainer container) : base(container)
        {
        }

        public void PrintContract(Guid specificationId)
        {
            var specification = Container.Resolve<IUnitOfWork>().Repository<Specification>().GetById(specificationId);

            //полный путь к файлу (с именем файла)
            var fullPath = GetPath($"{specification.Contract.Number}_{specification.Number}");

            var docWriter = GetWordDocumentWriter(fullPath);
            if (docWriter == null) return;

            docWriter.StartDocument();

            this.PrintContract(specification.Contract, docWriter);
 
            var addSupervisionAttachment = MessageService.ConfirmationDialog("Вы хотите прикрепить приложения о шеф-монтаже к договору?");
            if (addSupervisionAttachment == true) 
                this.PrintSupervision(docWriter, 1, specification.Contract, null);
            
            docWriter.PrintPageBreak();
            this.PrintSpecification(specification, docWriter, false, !addSupervisionAttachment);

            docWriter.EndDocument();
            docWriter.Close();

            OpenDocument(fullPath);
        }

        private void PrintContract(Contract contract, WordDocumentWriter docWriter)
        {
            #region Print Text

            var paraFormat = docWriter.CreateParagraphProperties();
            paraFormat.Alignment = ParagraphAlignment.Center;

            docWriter.PrintParagraph("ДОГОВОР ПОСТАВКИ", paraFormat);
            docWriter.PrintParagraph("ЭЛЕКТРОТЕХНИЧЕСКОГО ОБОРУДОВАНИЯ", paraFormat);
            docWriter.PrintParagraph($"№{contract.Number} от {contract.Date.ToShortDateString()} г.", paraFormat);

            var paraFormat1 = docWriter.CreateParagraphProperties();
            paraFormat1.Alignment = ParagraphAlignment.Left;
            Company c1 = GlobalAppProperties.Actual.OurCompany;
            Company c2 = contract.Contragent;
            var contragentEmployee = contract.ContragentEmployee;
            docWriter.PrintParagraph($"{PrintCompany(c1)}, именуемое в дальнейшем Поставщик, в лице генерального директора Калаущенко  Владимира Николаевича, действующего на основании Устава, с одной стороны, и {PrintCompany(c2)}, именуемое в дальнейшем Покупатель, в лице в лице {contragentEmployee?.Position} {contragentEmployee?.Person}, действующего на основании Устава, с другой стороны, вместе именуемые Стороны, а по отдельности Сторона, заключили настоящий договор поставки электротехнического оборудования (далее – договор поставки) о нижеследующем:", paraFormat1);

            var contractBody = ContractPrintHelper.GetContractBody(contract.Date).Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var s in contractBody)
            {
                if(s.Contains("СТАТЬЯ"))
                    docWriter.PrintParagraph(string.Empty, paraFormat1);
                docWriter.PrintParagraph(s, paraFormat1);
            }

            #endregion

            #region R

            docWriter.PrintParagraph("СТАТЬЯ 13");
            docWriter.PrintParagraph("АДРЕСА, БАНКОВСКИЕ РЕКВИЗИТЫ И ПОДПИСИ СТОРОН");

            var noBordersTableBorderProperties = docWriter.CreateTableBorderProperties();
            noBordersTableBorderProperties.Style = TableBorderStyle.None;
            noBordersTableBorderProperties.Sides = TableBorderSides.None;

            TableProperties tableProperties2 = GetTableProperties(docWriter, noBordersTableBorderProperties);
            //tableProperties2.PreferredWidthAsPercentage = 100;
            docWriter.StartTable(3, tableProperties2);

            TableCellProperties tableCellProperties2 = docWriter.CreateTableCellProperties();
            tableCellProperties2.PreferredWidthAsPercentage = 33;

            docWriter.StartTableRow();

            var part1 = "Поставщик" + Environment.NewLine + c1.ToShortName() + Environment.NewLine + c1.GetFullDetails();
            docWriter.PrintTableCell(part1, tableCellProperties2);

            docWriter.PrintTableCell(" ");

            var part3 = "Покупатель" + Environment.NewLine + c2.ToShortName() + Environment.NewLine + c2.GetFullDetails();
            docWriter.PrintTableCell(part3, tableCellProperties2);

            docWriter.EndTableRow();

            docWriter.EndTable();


            #endregion

            this.PrintSign(docWriter, contragentEmployee);

            #region Author Footer

            var writerSet = docWriter.AddSectionHeaderFooter(SectionHeaderFooterParts.FooterAllPages);
            writerSet.FooterWriterAllPages.Open();

            writerSet.FooterWriterAllPages.StartParagraph();
            writerSet.FooterWriterAllPages.AddTextRun($"Договор {contract.Number} стр. ");
            writerSet.FooterWriterAllPages.AddPageNumberField(PageNumberFieldFormat.Decimal);
            writerSet.FooterWriterAllPages.EndParagraph();

            writerSet.FooterWriterAllPages.Close();

            #endregion
        }

        private void PrintSupervision(WordDocumentWriter docWriter, int attachmentNumber, Contract contract, Specification specification)
        {
            string header = contract is null
                ? $"спецификации №{specification.Number} от {specification.Date.ToShortDateString()} г. к договору {specification.Contract.Number}"
                : $"договору {contract.Number} от {contract.Date.ToShortDateString()} г.";

            docWriter.StartAttachment(attachmentNumber++, header);
            docWriter.PrintParagraph(ContractPrintHelper.GetSupervision1());

            docWriter.StartAttachment(attachmentNumber, header);
            docWriter.PrintParagraph(ContractPrintHelper.GetSupervision2());
            
            var borderProperties = docWriter.CreateTableBorderProperties();
            borderProperties.Style = TableBorderStyle.Single;
            borderProperties.Sides = TableBorderSides.All;
            TableProperties tableProperties = GetTableProperties(docWriter, borderProperties);
            docWriter.StartTable(5, tableProperties);
            docWriter.PrintTableRow("№", "Приборы и инструмент", "Назначение", "Рекомендации", "Тип");
            docWriter.PrintTableRow("1", "Вольтметр средних значений с диапазоном измерений от 5 В до 2000 В с основной погрешностью не более ±1%", "Для определения характеристик намагничивания трансформаторов тока", "1. Допускается применение комбинированных или специальных приборов внесенных в реестр средств измерений и обеспечивающих заданную точность. 2. Рекомендуется применять амперметр (миллиамперметр)  с коэффициентом искажения амплитуды 3 и более", "ВЭБ");
            docWriter.PrintTableRow("2", "Амперметр (миллиамперметр) с диапазоном измерений от 0,1 А до 10 А класса точности не ниже 1  ", "Для определения характеристик намагничивания трансформаторов тока", "1. Допускается применение комбинированных или специальных приборов внесенных в реестр средств измерений и обеспечивающих заданную точность. 2. Рекомендуется применять амперметр (миллиамперметр)  с коэффициентом искажения амплитуды 3 и более", "ВЭБ");
            docWriter.PrintTableRow("3", "Регулируемый источник переменного напряжения до 2 кВ", "Для определения характеристик намагничивания трансформаторов тока", "", "ВЭБ");
            docWriter.PrintTableRow("4", "Микроомметр с пределом измерения 0-200 мкОм", "для измерения переходного сопротивления", "Рабочий ток от 100 А", "ВЭБ, ВГТ");
            docWriter.PrintTableRow("5", "Слесарный инструмент: рожковые ключи с зевом 8 – 46 мм, пассатижи, отвертки", "", "", "ВЭБ, ВГТ");
            docWriter.EndTable();

            docWriter.PrintParagraph(ContractPrintHelper.GetSupervision3());
        }

        public void PrintSpecification(Guid specificationId)
        {
            var specification = Container.Resolve<IUnitOfWork>().Repository<Specification>().GetById(specificationId);

            //полный путь к файлу (с именем файла)
            var fullPath = GetPath($"{specification.Contract.Number}_{specification.Number}");

            var docWriter = GetWordDocumentWriter(fullPath);
            if (docWriter == null) return;

            var addSupervisionAttachment = MessageService.ConfirmationDialog("Вы хотите прикрепить приложения о шеф-монтаже к спецификации?");

            docWriter.StartDocument();

            this.PrintSpecification(specification, docWriter, true, addSupervisionAttachment);

            docWriter.EndDocument();
            docWriter.Close();

            OpenDocument(fullPath);
        }

        private void PrintSpecification(
            Specification specification, 
            WordDocumentWriter docWriter, 
            bool printFooter,
            bool addSupervisionAttachment)
        {
            var unitsGroups = GetUnitsGroups(specification.SalesUnits);
            var unitsGroupsByFacilities = unitsGroups.GroupBy(unitsGroup => unitsGroup.Facility).ToList();

            #region Print Text Above Table

            docWriter.PrintParagraph(string.Empty);

            var paraFormat = docWriter.CreateParagraphProperties();
            paraFormat.Alignment = ParagraphAlignment.Center;
            docWriter.PrintParagraph($"Спецификация №{specification.Number} от {specification.Date.ToShortDateString()} г.", paraFormat);

            var paraFormat1 = docWriter.CreateParagraphProperties();
            paraFormat1.Alignment = ParagraphAlignment.Both;
            Company c1 = GlobalAppProperties.Actual.OurCompany;
            Company c2 = specification.Contract.Contragent;
            var contragentEmployee = specification.Contract.ContragentEmployee;
            docWriter.PrintParagraph($"{PrintCompany(c1)}, именуемое в дальнейшем Поставщик, в лице Генерального директора Калаущенко Владимира Николаевича, действующего на основании устава, с одной стороны, и {PrintCompany(c2)}, именуемое в дальнейшем Покупатель, в лице {contragentEmployee?.Position} {contragentEmployee?.Person}, действующего на основании устава, с другой стороны, вместе именуемые Стороны, по отдельности Сторона, заключили настоящую спецификацию к договору поставки от {specification.Contract.Date.ToLongDateString()} {specification.Contract.Number} (далее - спецификация) о нижеследующем:", paraFormat1);

            #endregion

            #region Print Main Table

            Font fontBold = docWriter.CreateFont();
            fontBold.Bold = true;

            PrintUnitsTable(unitsGroups, docWriter, fontBold, unitsGroupsByFacilities, specification);

            //Сумма прописью
            var sum = unitsGroups.Sum(x => x.Total);
            var vatSum = sum * specification.Vat / 100;
            var totalSum = sum + vatSum;
            var paragraphPropertiesCenter = docWriter.CreateParagraphProperties();
            paragraphPropertiesCenter.Alignment = ParagraphAlignment.Center;
            docWriter.PrintParagraph($"Всего по настоящей спецификации: {totalSum.ToSumWordCurrency()}, в том числе НДС {vatSum.ToSumWordCurrency()}", paragraphPropertiesCenter);

            #endregion

            #region Print Conditions

            var c = new Dictionary<string, string>
            {
                { "Упаковка, маркировка и консервация", "Согласно ГОСТ Р 52565-2006, ГОСТ 14192-96, ГОСТ 23216-78, ГОСТ 15150-69" },
                { "Технические и иные требования", "Согласно технической спецификации, являющейся приложением №1 к настоящей спецификации" },
                { "Перечень документов, относящихся к товару, передаваемых Поставщиком", "Нет" },
                { "Условия хранения", "согласно статье 3(17) договора поставки" },
                { "Условия отгрузки", GetShipmentConditions(unitsGroups) },
                { "Грузополучатель", $"{specification.Contract.Contragent}, ИНН {specification.Contract.Contragent.Inn}. {specification.Contract.Contragent.AddressLegal}" },
                { "Срок поставки", PrintConditions("Срок поставки (календарных дней при соблюдении Покупателем условий оплаты):", unitsGroups.GroupBy(unitsGroup => unitsGroup.ProductionTerm)) },
                { "Момент поставки, перехода права собственности, рисков случайной гибели или случайного повреждения", "Согласно статье 3(4), 3(5) договора поставки" },
                { "Оплата", PrintPaymentConditions("Условия оплаты:", unitsGroups.GroupBy(x => x.PaymentConditionSet), specification.Date.AddDays(14)) },
                { "Гарантийный срок", "Составляет 60 (шестьдесят) месяцев с даты ввода в эксплуатацию, но не более 66 (шестидесяти шести) месяцев с момента поставки.\nВ течение установленного гарантийного срока поставщик не гарантирует надежную работу и не отвечает за недостатки сданного в эксплуатацию оборудования, предусмотренного настоящей спецификацией, монтаж которого выполнен без специалиста завода-изготовителя (шеф-инженера), когда предусмотрен шефмонтаж." },
                { "Шеф-монтаж", GetSupervisionConditionsForSpecification(unitsGroups, addSupervisionAttachment) },
                { "Изготовитель", "ООО \"Эльмаш (УЭТМ)\" (ИНН 6686007865)" },
                { "Адреса электронной почты", $"Согласно статье 12(2) договора поставки для направления уведомлений, сообщений, писем Стороны определяют следующие адреса: {c1.Email} (Поставщик), {c2.Email} (Покупатель)" },
                { "Иные условия", "Нет" }
            };

            docWriter.StartTable(2, GetTableProperties(docWriter, docWriter.CreateTableBorderProperties()));

            var nn = 1;
            foreach (var condition in c)
            {
                docWriter.PrintTableRow(
                    docWriter.CreateTableCellProperties(), 
                    docWriter.CreateTableRowProperties(), 
                    docWriter.CreateParagraphProperties(), 
                    docWriter.CreateFont(),
                    $"{nn++}.", condition.Key, condition.Value);
            }

            docWriter.EndTable();

            #endregion

            PrintSign(docWriter, contragentEmployee);

            #region Print Technical Details

            docWriter.StartAttachment(1, $"спецификации №{specification.Number} от {specification.Date.ToShortDateString()} г. к договору {specification.Contract.Number}");
            PrintTechnicalDetails(docWriter, unitsGroupsByFacilities);
            PrintSign(docWriter, contragentEmployee);

            #endregion

            if (addSupervisionAttachment == true)
                this.PrintSupervision(docWriter, 2, null, specification);

            #region Footer

            if (printFooter)
            {
                var writerSet = docWriter.AddSectionHeaderFooter(SectionHeaderFooterParts.FooterAllPages);
                writerSet.FooterWriterAllPages.Open();

                writerSet.FooterWriterAllPages.StartParagraph();
                writerSet.FooterWriterAllPages.AddTextRun($"Спецификация №{specification.Number} к договору {specification.Contract.Number}" + Environment.NewLine + "стр. ");
                writerSet.FooterWriterAllPages.AddPageNumberField(PageNumberFieldFormat.Decimal);
                writerSet.FooterWriterAllPages.EndParagraph();

                writerSet.FooterWriterAllPages.Close();
            }

            #endregion
        }

        private string PrintCompany(Company company)
        {
            return $"{company.ToFullName()} (сокращенное наименование {company.ToShortName()})";
        }
        
        private void PrintSign(WordDocumentWriter docWriter, Employee contragentEmployee)
        {
            docWriter.PrintParagraph(string.Empty);

            var noBordersTableBorderProperties = docWriter.CreateTableBorderProperties();
            noBordersTableBorderProperties.Style = TableBorderStyle.None;
            noBordersTableBorderProperties.Sides = TableBorderSides.None;

            TableProperties tableProperties2 = GetTableProperties(docWriter, noBordersTableBorderProperties);
            docWriter.StartTable(2, tableProperties2);

            TableCellProperties tableCellProperties2 = docWriter.CreateTableCellProperties();
            tableCellProperties2.PreferredWidthAsPercentage = 33;

            docWriter.StartTableRow();

            var part1 = "Поставщик" + Environment.NewLine + Environment.NewLine + Environment.NewLine + "________________ В.Н.Калаущенко";
            docWriter.PrintTableCell(part1, tableCellProperties2);

            var part3 = "Покупатель" + Environment.NewLine + Environment.NewLine + Environment.NewLine + $"________________ {contragentEmployee?.Person.Name[0]}.{contragentEmployee?.Person.Patronymic?[0]}.{contragentEmployee?.Person.Surname}";
            docWriter.PrintTableCell(part3, tableCellProperties2);

            docWriter.EndTableRow();

            docWriter.EndTable();
        }

        private static string GetPath(string fileName)
        {
            //удаляем некорректные символы
            fileName = fileName.ReplaceUncorrectSimbols("-").Replace('.', '-').Replace(' ', '_') + ".docx";

            //возвращаем путь
            return Path.GetTempPath() + $"\\{fileName}";
        }
    }
}