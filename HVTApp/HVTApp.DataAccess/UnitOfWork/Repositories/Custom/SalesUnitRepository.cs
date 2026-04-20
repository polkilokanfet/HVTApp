using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using HVTApp.Model;
using HVTApp.Model.POCOs;

namespace HVTApp.DataAccess
{
    public partial class SalesUnitRepository : ISalesUnitRepository
    {
        protected override IQueryable<SalesUnit> GetQuery()
        {
            return Context.Set<SalesUnit>().AsQueryable()
                .Include(salesUnit => salesUnit.Specification)
                .Include(salesUnit => salesUnit.Facility.Type)
                .Include(salesUnit => salesUnit.Product.ProductBlock.Parameters)
                .Include(salesUnit => salesUnit.Product.DependentProducts.Select(productDependent => productDependent.Product.ProductBlock.Parameters))
                .Include(salesUnit => salesUnit.ProductsIncluded.Select(productIncluded => productIncluded.Product.ProductBlock.Parameters))
                .Include(salesUnit => salesUnit.PaymentConditionSet.PaymentConditions.Select(paymentCondition => paymentCondition.PaymentConditionPoint))
                .Include(salesUnit => salesUnit.PaymentsActual)
                .Include(salesUnit => salesUnit.PaymentsPlanned);
        }

        //protected override IQueryable<SalesUnit> GetQuary()
        //{
        //    return Context.Set<SalesUnit>().AsQueryable()
        //        .Include(x => x.Facility)
        //        .Include(x => x.Facility.Type)
        //        .Include(x => x.Facility.Address.Locality.Region.District.Country)
        //        .Include(x => x.Facility.OwnerCompany)
        //        .Include(x => x.Facility.OwnerCompany.AddressLegal.Locality.Region.District.Country)
        //        .Include(x => x.Project)
        //        .Include(x => x.Project.Manager)
        //        .Include(x => x.Product.ProductBlock.Parameters)
        //        .Include(x => x.Product.DependentProducts.Select(dp => dp.Product.ProductBlock.Parameters))
        //        .Include(x => x.ProductsIncluded.Select(dp => dp.Product.ProductBlock.Parameters))
        //        .Include(x => x.PaymentsActual)
        //        .Include(x => x.PaymentsPlanned)
        //        .Include(x => x.PaymentConditionSet)
        //        .Include(x => x.PaymentConditionSet.PaymentConditions)
        //        .Include(x => x.Order)
        //        .Include(x => x.Penalty)
        //        .Include(x => x.Producer)
        //        .Include(x => x.AddressDelivery);
        //}

        public IEnumerable<SalesUnit> GetAllOfCurrentUser()
        {
            Loging(System.Reflection.MethodBase.GetCurrentMethod().Name);
            return this.GetQuery().Where(salesUnit => salesUnit.Project.Manager.Id == GlobalAppProperties.User.Id).ToList();
        }

        public IEnumerable<SalesUnit> GetAllOfCurrentUserForMarketView()
        {
            Loging(System.Reflection.MethodBase.GetCurrentMethod().Name);
            return this.GetQuery()
                .Include(salesUnit => salesUnit.Specification)
                .Include(salesUnit => salesUnit.Project.Manager)
                .Include(salesUnit => salesUnit.Facility.OwnerCompany)
                .Include(salesUnit => salesUnit.Producer)
                .Where(salesUnit => !salesUnit.IsRemoved && salesUnit.Project.Manager.Id == GlobalAppProperties.User.Id)
                .ToList();
        }

        public IEnumerable<SalesUnit> GetAllForProductionPlanView()
        {
            Loging(System.Reflection.MethodBase.GetCurrentMethod().Name);

            return Context.Set<SalesUnit>().AsQueryable()
                .Include(salesUnit => salesUnit.Specification)
                .Include(salesUnit => salesUnit.Order)
                .Include(salesUnit => salesUnit.Facility.Type)
                .Include(salesUnit => salesUnit.Product.ProductBlock.Parameters)
                .Include(salesUnit => salesUnit.Project.Manager.Employee.Person)
                .Where(salesUnit => salesUnit.EndProductionPlanDate != null)
                .Where(salesUnit => salesUnit.Order != null);
        }

        public IEnumerable<SalesUnit> GetAllForOrderView()
        {
            Loging(System.Reflection.MethodBase.GetCurrentMethod().Name);

            return Context.Set<SalesUnit>().AsQueryable()
                .Include(salesUnit => salesUnit.Order)
                .Include(salesUnit => salesUnit.Specification.Contract.Contragent)
                .Include(salesUnit => salesUnit.Facility.Type)
                .Include(salesUnit => salesUnit.Product.ProductBlock.Parameters)
                .Where(
                    salesUnit =>
                        !salesUnit.IsRemoved &&
                        salesUnit.SignalToStartProduction.HasValue &&
                        salesUnit.Order == null);
        }

        public IEnumerable<SalesUnit> GetByProject(Guid projectId)
        {
            Loging(System.Reflection.MethodBase.GetCurrentMethod().Name);

            var salesUnitsIds = this.Context.Set<SalesUnit>().AsNoTracking()
                .Where(salesUnit => salesUnit.Project.Id == projectId)
                .Select(salesUnit => salesUnit.Id)
                .ToList();

            foreach (var id in salesUnitsIds)
            {
                yield return this.GetById(id);
            }
        }

        public IEnumerable<SalesUnit> GetByOrder(Guid orderId)
        {
            Loging(System.Reflection.MethodBase.GetCurrentMethod().Name);

            var salesUnitsIds = this.Context.Set<SalesUnit>().AsNoTracking()
                .Where(salesUnit => salesUnit.Order != null)
                .Where(salesUnit => salesUnit.Order.Id == orderId)
                .Select(salesUnit => salesUnit.Id)
                .ToList();

            foreach (var id in salesUnitsIds)
            {
                yield return this.GetById(id);
            }
        }

        public IEnumerable<SalesUnit> GetBySpecification(Guid specificationId)
        {
            Loging(System.Reflection.MethodBase.GetCurrentMethod().Name);

            var salesUnitsIds = this.Context.Set<SalesUnit>().AsNoTracking()
                .Where(salesUnit => salesUnit.Specification != null)
                .Where(salesUnit => salesUnit.Specification.Id == specificationId)
                .Select(salesUnit => salesUnit.Id)
                .ToList();

            foreach (var id in salesUnitsIds)
            {
                yield return this.GetById(id);
            }
        }

        public IEnumerable<SalesUnit> GetAllWithActualPayments()
        {
            Loging(System.Reflection.MethodBase.GetCurrentMethod().Name);

            return this.GetQuery()
                //.Include(salesUnit => salesUnit.PaymentsActual)
                .Include(salesUnit => salesUnit.Order)
                .Where(salesUnit => salesUnit.PaymentsActual.Any())
                .ToList();
        }

        public IEnumerable<SalesUnit> GetAllWithActualPaymentsOfCurrentUser()
        {
            Loging(System.Reflection.MethodBase.GetCurrentMethod().Name);

            return this.GetQuery()
                //.Include(salesUnit => salesUnit.PaymentsActual)
                .Include(salesUnit => salesUnit.Specification)
                .Include(salesUnit => salesUnit.Order)
                .Include(salesUnit => salesUnit.Project.Manager)
                .Where(salesUnit => salesUnit.Project.Manager.Id == GlobalAppProperties.User.Id)
                .Where(salesUnit => salesUnit.PaymentsActual.Any())
                .ToList();
        }

        public IEnumerable<SalesUnit> GetAllIncludeActualPayments()
        {
            Loging(System.Reflection.MethodBase.GetCurrentMethod().Name);

            return Context.Set<SalesUnit>().AsQueryable()
                .Include(salesUnit => salesUnit.Specification)
                .Include(salesUnit => salesUnit.Facility.Type)
                .Include(salesUnit => salesUnit.Product.ProductBlock.Parameters)
                //.Include(salesUnit => salesUnit.PaymentConditionSet.PaymentConditions.Select(paymentCondition => paymentCondition.PaymentConditionPoint))
                .Include(salesUnit => salesUnit.PaymentsActual)
                .ToList();
        }

        public IEnumerable<SalesUnit> GetAllForPaymentDocument(string orderNumber)
        {
            Loging(System.Reflection.MethodBase.GetCurrentMethod().Name);

            IQueryable<SalesUnit> query;

            if (string.IsNullOrWhiteSpace(orderNumber))
            {
                query = Context.Set<SalesUnit>().AsQueryable()
                    .Where(salesUnit => salesUnit.IsRemoved == false);
            }
            else
            {
                query = Context.Set<SalesUnit>().AsQueryable()
                    .Where(salesUnit => 
                        salesUnit.IsRemoved == false && 
                        salesUnit.Order != null && 
                        salesUnit.Order.Number.Contains(orderNumber.Trim()));
            }

            query = query
                .Include(salesUnit => salesUnit.Order)
                .Include(salesUnit => salesUnit.Specification)
                .Include(salesUnit => salesUnit.Facility.Type)
                .Include(salesUnit => salesUnit.Product.ProductBlock.Parameters)
                .Include(salesUnit => salesUnit.PaymentsActual);

            return query.ToList().Where(x => x.IsLoosen == false).ToList();
        }

        public IEnumerable<SalesUnit> GetAllNotRemovedNotLoosen()
        {
            Loging(System.Reflection.MethodBase.GetCurrentMethod().Name);

            return this.GetQuery()
                .Include(salesUnit => salesUnit.Producer)
                .Where(salesUnit => !salesUnit.IsRemoved && (salesUnit.Producer == null || salesUnit.Producer.Id == GlobalAppProperties.Actual.OurCompany.Id))
                .ToList();
        }

        public IEnumerable<SalesUnit> GetForDatesView()
        {
            Loging(System.Reflection.MethodBase.GetCurrentMethod().Name);

            return this.GetQuery()
                .Include(salesUnit => salesUnit.Order)
                .Include(salesUnit => salesUnit.Specification.Contract.Contragent.Form)
                .Include(salesUnit => salesUnit.Producer)
                .Where(salesUnit => !salesUnit.IsRemoved && (salesUnit.Producer == null || salesUnit.Producer.Id == GlobalAppProperties.Actual.OurCompany.Id))
                .ToList();
        }

        public IEnumerable<SalesUnit> GetForFlatReportView(bool onlyReportUnits)
        {
            Loging(System.Reflection.MethodBase.GetCurrentMethod().Name);

            if (onlyReportUnits)
            {
                return this.GetQuery()
                    .Include(salesUnit => salesUnit.Project.Manager.Employee.Person)
                    .Include(salesUnit => salesUnit.Facility.Address.Locality)
                    .Include(salesUnit => salesUnit.Facility.OwnerCompany.AddressLegal.Locality)
                    .Include(salesUnit => salesUnit.Order)
                    .Include(salesUnit => salesUnit.Specification.Contract.Contragent.Form)
                    .Include(salesUnit => salesUnit.Producer)
                    .Where(salesUnit => !salesUnit.IsRemoved && salesUnit.Project.ForReport)
                    .ToList();
            }
            else
            {
                return this.GetQuery()
                    .Include(salesUnit => salesUnit.Project.Manager.Employee.Person)
                    .Include(salesUnit => salesUnit.Facility.Address.Locality)
                    .Include(salesUnit => salesUnit.Facility.OwnerCompany.AddressLegal.Locality)
                    .Include(salesUnit => salesUnit.Order)
                    .Include(salesUnit => salesUnit.Specification.Contract.Contragent.Form)
                    .Include(salesUnit => salesUnit.Producer)
                    .Where(salesUnit => !salesUnit.IsRemoved)
                    .ToList();
            }

        }

        public IEnumerable<SalesUnit> GetForFlatReportView(IEnumerable<Guid> salesUnitsIds)
        {
            Loging(System.Reflection.MethodBase.GetCurrentMethod().Name);

            return Context.Set<SalesUnit>().AsQueryable()

                .Include(salesUnit => salesUnit.Facility.Type)
                .Include(salesUnit => salesUnit.Product.ProductBlock.Parameters)
                .Include(salesUnit => salesUnit.Product.DependentProducts.Select(productDependent => productDependent.Product.ProductBlock.Parameters))
                .Include(salesUnit => salesUnit.ProductsIncluded.Select(productIncluded => productIncluded.Product.ProductBlock.Parameters))
                .Include(salesUnit => salesUnit.PaymentConditionSet.PaymentConditions.Select(paymentCondition => paymentCondition.PaymentConditionPoint))
                .Include(salesUnit => salesUnit.PaymentsActual)
                .Include(salesUnit => salesUnit.PaymentsPlanned)
                .Include(salesUnit => salesUnit.Project.Manager.Employee.Person)
                .Include(salesUnit => salesUnit.Facility.Address.Locality)
                .Include(salesUnit => salesUnit.Facility.OwnerCompany.AddressLegal.Locality)
                .Include(salesUnit => salesUnit.Order)
                .Include(salesUnit => salesUnit.Specification.Contract.Contragent.Form)
                .Include(salesUnit => salesUnit.Producer)
                .AsEnumerable()
                .Where(salesUnit => salesUnitsIds.Contains(salesUnit.Id))
                .ToList();
        }

        public IEnumerable<SalesUnit> GetForCommonInfo(IEnumerable<Facility> facilities)
        {
            Loging(System.Reflection.MethodBase.GetCurrentMethod().Name);

            return Context.Set<SalesUnit>().AsQueryable()
                .Include(salesUnit => salesUnit.Facility)
                .AsEnumerable()
                .Where(salesUnit => salesUnit.IsRemoved == false && facilities.Contains(salesUnit.Facility))
                .ToList();
        }

        //public async Task<IEnumerable<SalesUnit>> GetUsersSalesUnitsAsync()
        //{
        //    var su = await this.GetAllAsync();
        //    return su.Where(x => x.Project.Manager.IsAppCurrentUser());
        //}
    }
}