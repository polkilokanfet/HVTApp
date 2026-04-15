using System;
using HVTApp.Model.POCOs;
using Microsoft.Practices.Unity;
using System.IO;
using System.Linq;
using System.Text;
using HVTApp.Infrastructure;
using HVTApp.Services.PrintService.Extensions;
using System.Collections.Generic;
using HVTApp.Model;
using HVTApp.Model.Services;
using Infragistics.Documents.Word;

namespace HVTApp.Services.PrintService
{
    public class PrintPriceCalculationInformationCardService : PrintServiceBase, IPrintPriceCalculationInformationCardService
    {
        public PrintPriceCalculationInformationCardService(IUnityContainer container) : base(container)
        {
        }

        public void Print(PriceCalculation calculation)
        {
            //полный путь к файлу (с именем файла)
            var fullPath = Path.GetTempPath() + $"Карточка";

            var docWriter = GetWordDocumentWriter(fullPath);
            if (docWriter == null) return;
            docWriter.StartDocument();

            docWriter.PrintParagraph($"Проект: {calculation.PriceCalculationItems.First().SalesUnits.First().Project}");
            docWriter.PrintParagraph($"Менеджер: {GlobalAppProperties.User.Employee.Person}");

            foreach (var priceCalculationItem in calculation.PriceCalculationItems.OrderBy(x => x.PositionInTeamCenter))
            {
                var salesUnit = priceCalculationItem.SalesUnits.First();

                docWriter.PrintParagraph("");
                docWriter.PrintParagraph($"поз.{priceCalculationItem.PositionInTeamCenter} {salesUnit.Product.ToString()}");
                
                var c = new Dictionary<string, string>
                {
                    { "Тип", salesUnit.Product.ProductType.ToString() },
                    { "Обозначение", salesUnit.Product.Designation },
                    { "Количество (шт.)", priceCalculationItem.SalesUnits.Count.ToString() },
                    { "Объект", salesUnit.Facility.ToString() },
                    { "Владелец объекта", salesUnit.Facility.OwnerCompany.ToString() },
                    { "Местоположение", salesUnit.Facility.Address.ToString() },
                    { "Головная компания", salesUnit.Facility.OwnerCompany.ParentCompanies().FirstOrDefault(x => x.ParentCompany == null)?.ToString() },
                    { "Заключение ОГК", GetDesignerInformation(priceCalculationItem) }
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
            }

            docWriter.EndDocument();
            docWriter.Close();

            OpenDocument(fullPath);
        }

        private string GetDesignerInformation(PriceCalculationItem calculationItem)
        {
            if (calculationItem.PriceEngineeringTaskId.HasValue == false)
                return "Эта строка расчёта не связана с какой-либо задачей ТСП";

            var sb = new StringBuilder();
            using (var unitOfWork = this.Container.Resolve<IUnitOfWork>())
            {
                var task = unitOfWork.Repository<PriceEngineeringTask>()
                    .GetById(calculationItem.PriceEngineeringTaskId.Value);

                var tasks = unitOfWork.Repository<PriceEngineeringTasks>()
                    .GetById(task.ParentPriceEngineeringTasksId.Value);

                var allTasks = task.GetAllPriceEngineeringTasks().ToList();

                var tasksNotFinished = allTasks.Where(x => x.IsFinishedByConstructor == false).ToList();
                var tasksWithNoInfo = allTasks.Except(tasksNotFinished).Where(x => x.HasDesignDocumentationInfo == false).ToList();
                var tasksNeedDoc = allTasks.Except(tasksNotFinished).Except(tasksWithNoInfo).Where(x => x.NeedDesignDocumentationDevelopment).ToList();

                if (tasksNotFinished.Any() || tasksWithNoInfo.Any() || tasksNeedDoc.Any())
                {
                    sb.AppendLine();

                    foreach (var t in tasksNotFinished)
                        sb.AppendLine($"{GetBlockInfo(t)} окончательно не проработан исполнителем ОГК ВВА.");

                    foreach (var t in tasksWithNoInfo)
                        sb.AppendLine($"{GetBlockInfo(t)} не имеет актуальной информации о КД (проработан до внедрения соответствующего модуля).");

                    foreach (var t in tasksNeedDoc)
                        sb.AppendLine($"{GetBlockInfo(t)}. Заключение по КД (исп. {t.UserConstructor?.Employee.Person}): {t.GetDesignDocumentationAvailabilityInfo()}");
                }

                var result = sb.ToString();
                sb.Clear();
                sb.AppendLine($"Заключение ОГК ВВА по наличию КД (ID в УП ВВА: {tasks.NumberFull}; ID в TeamCenter: {tasks.TceNumber}):");
                sb.AppendLine(string.IsNullOrWhiteSpace(result)
                    ? "Документация в наличии (не потребуется времени на её разработку)"
                    : result);

            }
            return sb.ToString().TrimEnd('\n', '\r');

        }

        private string GetBlockInfo(PriceEngineeringTask task)
        {
            return $"   Блок ({task.ProductBlock.Designation} (ID в УП ВВА: {task.Number}))";
        }

        protected override string GetFullPath(Document document, string path)
        {
            return Path.GetTempPath() + $"Карточка запроса";
        }

        protected override void PrintBody(Document document, WordDocumentWriter docWriter)
        {
            throw new NotImplementedException();
        }
    }
}