using System.Collections.Generic;
using System.Linq;
using HVTApp.Infrastructure;
using HVTApp.Model.POCOs;

namespace HVTApp.TestDataGenerator
{
    public partial class TestData
    {
        public EmployeesPosition EmployeesPositionDirector;
        public EmployeesPosition EmployeesPositionManager;
        public EmployeesPosition EmployeesPositionEconomist;
        public EmployeesPosition EmployeesPositionConstructor;

        public Person PersonBrehov;
        public Person PersonBuzikin;
        public Person PersonVinogradova;
        public Person PersonZaytsev;
        public Person PersonKolesnik;
        public Person PersonKopitin;
        public Person PersonPostnikova;
        public Person PersonKosolapov;
        public Person PersonKoreshkov;
        public Person PersonEmelyanov;
        public Person PersonRybin;
        public Person PersonGazizov;
        public Person PersonTekin;
        public Person PersonDeev;
        public Person PersonGuseinov;

        public Person PersonIgnatenko;
        public Person PersonEgorova;
        public Person PersonSharapova;
        public Person PersonNikiforova;
        public Person PersonRozhkova;

        public Person PersonDavidov;
        public Person PersonBaranova;

        public Person PersonPalferov;
        public Person PersonBukrin;

        public Person PersonVedernikov;
        public Person PersonSivkov;

        public Employee EmployeeBrehov;
        public Employee EmployeeBuzikin;
        public Employee EmployeeVinogradova;
        public Employee EmployeeZaytsev;
        public Employee EmployeeKolesnik;
        public Employee EmployeeKopitin;
        public Employee EmployeePostnikova;
        public Employee EmployeeKosolapov;
        public Employee EmployeeKoreshkov;
        public Employee EmployeeEmelyanov;
        public Employee EmployeeRybin;
        public Employee EmployeeGazizov;
        public Employee EmployeeTekin;
        public Employee EmployeeDeev;
        public Employee EmployeeGuseinov;

        public Employee EmployeeIgnatenko;
        public Employee EmployeeEgorova;
        public Employee EmployeeSharapova;
        public Employee EmployeeNikiforova;
        public Employee EmployeeRozhkova;

        public Employee EmployeeDavidov;
        public Employee EmployeeBaranova;

        public Employee EmployeePalferov;
        public Employee EmployeeBukrin;

        public Employee EmployeeVedernikov;
        public Employee EmployeeSivkov;

        public User UserBrehov;
        public User UserBuzikin;
        public User UserVinogradova;
        public User UserZaytsev;
        public User UserKolesnik;
        public User UserKopitin;
        public User UserPostnikova;
        public User UserKosolapov;
        public User UserKoreshkov;
        public User UserEmelyanov;
        public User UserRybin;
        public User UserGazizov;
        public User UserTekin;
        public User UserDeev;

        public User UserIgnatenko;
        public User UserEgorova;
        public User UserSharapova;
        public User UserNikiforova;
        public User UserRozhkova;

        public User UserDavidov;
        public User UserBaranova;
        public User UserPalferov;
        public User UserBukrin;

        public User UserVedernikov;
        public User UserSivkov;

        public UserRole UserRoleDataBaseFiller;
        public UserRole UserRoleAdmin;
        public UserRole UserRoleSalesManager;
        public UserRole UserRoleEconomist;
        public UserRole UserRolePricer;
        public UserRole UserRoleDirector;
        public UserRole UserRolePlanMaker;
        public UserRole UserRoleConstructor;
        public UserRole UserRoleReportMaker;
        public UserRole UserRoleSupplier;
        public UserRole UserRoleBackManager;
        public UserRole UserRoleBackManagerBoss;
        public UserRole UserRoleDesignDepartmentHead;

        #if DEBUG

        public Person PersonIvanov;
        public Person PersonPetrov;
        public Person PersonSidorov;

        public User UserIvanov;
        public User UserPetrov;

        public Employee EmployeeIvanov;
        public Employee EmployeePetrov;
        public Employee EmployeeSidorov;

        #endif

        private void GenerateUserRoles()
        {
            UserRoleDataBaseFiller.Clone(new UserRole { Role = Role.DataBaseFiller, Name = "DataBaseFiller" });
            UserRoleAdmin.Clone(new UserRole { Role = Role.Admin, Name = "Администратор" });
            UserRoleSalesManager.Clone(new UserRole { Role = Role.SalesManager, Name = "Менеджер" });
            UserRoleEconomist.Clone(new UserRole { Role = Role.Economist, Name = "Экономист" });
            UserRolePricer.Clone(new UserRole { Role = Role.Pricer, Name = "Расчетчик" });
            UserRoleDirector.Clone(new UserRole { Role = Role.Director, Name = "Директор" });
            UserRolePlanMaker.Clone(new UserRole { Role = Role.PlanMaker, Name = "Плановик" });
            UserRoleConstructor.Clone(new UserRole { Role = Role.Constructor, Name = "Конструктор" });
            UserRoleReportMaker.Clone(new UserRole { Role = Role.ReportMaker, Name = "Отчетчик" });
            UserRoleSupplier.Clone(new UserRole { Role = Role.Supplier, Name = "Снабженец" });
            UserRoleBackManager.Clone(new UserRole { Role = Role.BackManager, Name = "BackManager" });
            UserRoleBackManagerBoss.Clone(new UserRole { Role = Role.BackManagerBoss, Name = "BackManagerBoss" });
            UserRoleDesignDepartmentHead.Clone(new UserRole { Role = Role.DesignDepartmentHead, Name = "DepartmentHead" });
        }

        private void GenerateEmployeesPositions()
        {
            EmployeesPositionDirector.Clone(new EmployeesPosition { Name = "Директор по продажам ВВА" });
            EmployeesPositionManager.Clone(new EmployeesPosition { Name = "Менеджер" });
            EmployeesPositionEconomist.Clone(new EmployeesPosition { Name = "Экономист" });
            EmployeesPositionConstructor.Clone(new EmployeesPosition { Name = "Инженер-конструктор" });
        }

        private void GeneratePersons()
        {
            #if DEBUG

            PersonIvanov.Clone(new Person { Surname = "Иванов", Name = "Иван", Patronymic = "Иванович", IsMan = true });
            PersonPetrov.Clone(new Person { Surname = "Петров", Name = "Петр", Patronymic = "Петрович", IsMan = true });
            PersonSidorov.Clone(new Person { Surname = "Сидоров", Name = "Сидор", Patronymic = "Сидорович", IsMan = true });

            #endif

            PersonBrehov.Clone(new Person { Surname = "Брехов", Name = "Евгений", Patronymic = "Владимирович", IsMan = true });
            PersonBuzikin.Clone(new Person { Surname = "Бузыкин", Name = "Валерий", Patronymic = "Владимирович", IsMan = true });
            PersonVinogradova.Clone(new Person { Surname = "Виноградова", Name = "Лидия", Patronymic = "Александровна", IsMan = false });
            PersonZaytsev.Clone(new Person { Surname = "Зайцев", Name = "Сергей", Patronymic = "Николвевич", IsMan = true });
            PersonKolesnik.Clone(new Person { Surname = "Колесник", Name = "Андрей", Patronymic = "Павлович", IsMan = true });
            PersonKopitin.Clone(new Person { Surname = "Копытин", Name = "Павел", Patronymic = "Андреевич", IsMan = true });
            PersonPostnikova.Clone(new Person { Surname = "Постникова", Name = "Елена", Patronymic = "Владимировна", IsMan = false });
            PersonKosolapov.Clone(new Person { Surname = "Косолапов", Name = "Александр", Patronymic = "Геннадьевич", IsMan = true });
            PersonKoreshkov.Clone(new Person { Surname = "Корешков", Name = "Николя", Patronymic = "Батькович", IsMan = true });
            PersonEmelyanov.Clone(new Person { Surname = "Емельянов", Name = "Тимофей", Patronymic = "Викторович", IsMan = true });
            PersonRybin.Clone(new Person { Surname = "Рыбин", Name = "Андрей", Patronymic = "Юрьевич", IsMan = true });
            PersonGazizov.Clone(new Person { Surname = "Газизов", Name = "Евгений", Patronymic = "Рафаильевич", IsMan = true });
            PersonTekin.Clone(new Person { Surname = "Текин", Name = "Вадим", Patronymic = "Владимирович", IsMan = true });
            PersonDeev.Clone(new Person { Surname = "Деев", Name = "Дмитрий", Patronymic = "Геннадьевич", IsMan = true });
            PersonGuseinov.Clone(new Person { Surname = "Гусейнов", Name = "Анатолий", Patronymic = "Рассулович", IsMan = true });

            PersonIgnatenko.Clone(new Person { Surname = "Игнатенко", Name = "Светлана", Patronymic = "Викторовна", IsMan = false });
            PersonEgorova.Clone(new Person { Surname = "Егорова", Name = "Татьяна", Patronymic = "Евгеньевна", IsMan = false });
            PersonSharapova.Clone(new Person { Surname = "Шарапова", Name = "Екатерина", Patronymic = "Анатольевна", IsMan = false });
            PersonNikiforova.Clone(new Person { Surname = "Никифорова", Name = "Ольга", Patronymic = "Викторовна", IsMan = false });
            PersonRozhkova.Clone(new Person { Surname = "Рожкова", Name = "Елена", Patronymic = "Николаевна", IsMan = false });

            PersonDavidov.Clone(new Person { Surname = "Давыдов", Name = "Николай", Patronymic = "Владимирович", IsMan = true });
            PersonBaranova.Clone(new Person { Surname = "Баранова", Name = "Татьяна", Patronymic = "Юрьевна", IsMan = false });

            PersonPalferov.Clone(new Person { Surname = "Палферов", Name = "Дмитрий", Patronymic = "Александрович", IsMan = true });
            PersonBukrin.Clone(new Person { Surname = "Букрин", Name = "Олег", Patronymic = "Олегович", IsMan = true });

            PersonVedernikov.Clone(new Person { Surname = "Ведерников", Name = "Олег", Patronymic = "Олегович", IsMan = true });
            PersonSivkov.Clone(new Person { Surname = "Сивков", Name = "Олег", Patronymic = "Олегович", IsMan = true });

        }

        private void GenerateEmployees()
        {
            #if DEBUG

            EmployeeIvanov.Clone(new Employee { Person = PersonIvanov, Position = EmployeesPositionManager, Company = CompanyUetm, PersonalNumber = "7111", Email = "iii@uetm.ru", PhoneNumber = "326-36-36" });
            EmployeePetrov.Clone(new Employee { Person = PersonPetrov, Position = EmployeesPositionDirector, Company = CompanyFsk, PersonalNumber = "7112", Email = "pii@uetm.ru", PhoneNumber = "326-36-37" });
            EmployeeSidorov.Clone(new Employee { Person = PersonSidorov, Position = EmployeesPositionDirector, Company = CompanyEnel, Email = "sii@uetm.ru", PhoneNumber = "326-36-38" });

            #endif

            EmployeeBrehov.Clone(new Employee { Person = PersonBrehov, Position = EmployeesPositionManager, Company = CompanyUetm, PersonalNumber = "74??", Email = "hz@uetm.ru", PhoneNumber = "326-36-36" });
            EmployeeBuzikin.Clone(new Employee { Person = PersonBuzikin, Position = EmployeesPositionManager, Company = CompanyUetm, PersonalNumber = "74??", Email = "hz@uetm.ru", PhoneNumber = "326-36-36" });
            EmployeeVinogradova.Clone(new Employee { Person = PersonVinogradova, Position = EmployeesPositionManager, Company = CompanyUetm, PersonalNumber = "74??", Email = "hz@uetm.ru", PhoneNumber = "326-36-36" });
            EmployeeZaytsev.Clone(new Employee { Person = PersonZaytsev, Position = EmployeesPositionManager, Company = CompanyUetm, PersonalNumber = "74??", Email = "hz@uetm.ru", PhoneNumber = "326-36-36" });
            EmployeeKolesnik.Clone(new Employee { Person = PersonKolesnik, Position = EmployeesPositionManager, Company = CompanyUetm, PersonalNumber = "74??", Email = "hz@uetm.ru", PhoneNumber = "326-36-36" });
            EmployeeKopitin.Clone(new Employee { Person = PersonKopitin, Position = EmployeesPositionManager, Company = CompanyUetm, PersonalNumber = "74??", Email = "hz@uetm.ru", PhoneNumber = "326-36-36" });
            EmployeePostnikova.Clone(new Employee { Person = PersonPostnikova, Position = EmployeesPositionManager, Company = CompanyUetm, PersonalNumber = "74??", Email = "hz@uetm.ru", PhoneNumber = "326-36-36" });
            EmployeeKosolapov.Clone(new Employee { Person = PersonKosolapov, Position = EmployeesPositionManager, Company = CompanyUetm, PersonalNumber = "7412", Email = "kos@uetm.ru", PhoneNumber = "326-36-36" });
            EmployeeKoreshkov.Clone(new Employee { Person = PersonKoreshkov, Position = EmployeesPositionManager, Company = CompanyUetm, PersonalNumber = "74??", Email = "hz@uetm.ru", PhoneNumber = "326-36-36" });
            EmployeeEmelyanov.Clone(new Employee { Person = PersonEmelyanov, Position = EmployeesPositionManager, Company = CompanyUetm, PersonalNumber = "7406", Email = "em@uetm.ru", PhoneNumber = "326-36-36" });
            EmployeeRybin.Clone(new Employee { Person = PersonRybin, Position = EmployeesPositionManager, Company = CompanyUetm, PersonalNumber = "7403", Email = "rbn@uetm.ru", PhoneNumber = "326-36-36" });
            EmployeeGazizov.Clone(new Employee { Person = PersonGazizov, Position = EmployeesPositionManager, Company = CompanyUetm, PersonalNumber = "7410", Email = "gaz@uetm.ru", PhoneNumber = "326-36-36" });
            EmployeeTekin.Clone(new Employee { Person = PersonTekin, Position = EmployeesPositionManager, Company = CompanyUetm, PersonalNumber = "7478", Email = "tkn@uetm.ru", PhoneNumber = "326-36-36" });
            EmployeeDeev.Clone(new Employee { Person = PersonDeev, Position = EmployeesPositionDirector, Company = CompanyUetm, PersonalNumber = "7401", Email = "deev@uetm.ru", PhoneNumber = "326-36-36" });
            EmployeeGuseinov.Clone(new Employee { Person = PersonGuseinov, Position = EmployeesPositionDirector, Company = CompanyUetm, PersonalNumber = "74", Email = "ggg@uetm.ru", PhoneNumber = "326-36-36" });

            EmployeeIgnatenko.Clone(new Employee { Person = PersonIgnatenko, Position = EmployeesPositionEconomist, Company = CompanyUetm, PersonalNumber = "74??", Email = "hz@uetm.ru", PhoneNumber = "326-36-36" });
            EmployeeEgorova.Clone(new Employee { Person = PersonEgorova, Position = EmployeesPositionEconomist, Company = CompanyUetm, PersonalNumber = "74??", Email = "hz@uetm.ru", PhoneNumber = "326-36-36" });
            EmployeeSharapova.Clone(new Employee { Person = PersonSharapova, Position = EmployeesPositionEconomist, Company = CompanyUetm, PersonalNumber = "74??", Email = "hz@uetm.ru", PhoneNumber = "326-36-36" });
            EmployeeNikiforova.Clone(new Employee { Person = PersonNikiforova, Position = EmployeesPositionEconomist, Company = CompanyUetm, PersonalNumber = "74??", Email = "hz@uetm.ru", PhoneNumber = "326-36-36" });
            EmployeeRozhkova.Clone(new Employee { Person = PersonRozhkova, Position = EmployeesPositionEconomist, Company = CompanyUetm, PersonalNumber = "74??", Email = "hz@uetm.ru", PhoneNumber = "326-36-36" });

            EmployeeBaranova.Clone(new Employee { Person = PersonBaranova, Position = EmployeesPositionConstructor, Company = CompanyUetm, PersonalNumber = "74??", Email = "hz@uetm.ru", PhoneNumber = "326-36-36" });
            EmployeeDavidov.Clone(new Employee { Person = PersonDavidov, Position = EmployeesPositionConstructor, Company = CompanyUetm, PersonalNumber = "74??", Email = "hz@uetm.ru", PhoneNumber = "326-36-36" });
            EmployeePalferov.Clone(new Employee { Person = PersonPalferov, Position = EmployeesPositionConstructor, Company = CompanyUetm, PersonalNumber = "74??", Email = "hz@uetm.ru", PhoneNumber = "326-36-36" });
            EmployeeBukrin.Clone(new Employee { Person = PersonBukrin, Position = EmployeesPositionConstructor, Company = CompanyUetm, PersonalNumber = "74??", Email = "hz@uetm.ru", PhoneNumber = "326-36-36" });

            EmployeeVedernikov.Clone(new Employee { Person = PersonVedernikov, Position = EmployeesPositionConstructor, Company = CompanyUetm, PersonalNumber = "74??", Email = "hz@uetm.ru", PhoneNumber = "326-36-36" });
            EmployeeSivkov.Clone(new Employee { Person = PersonSivkov, Position = EmployeesPositionConstructor, Company = CompanyUetm, PersonalNumber = "74??", Email = "hz@uetm.ru", PhoneNumber = "326-36-36" });

        }

        private void GenerateUsers()
        {
            var pas1 = StringToGuid.GetHashString("1");
            var pas2 = StringToGuid.GetHashString("2");

            var allRoles = new List<UserRole>
            {
                UserRoleAdmin,
                UserRoleDataBaseFiller,
                UserRoleSalesManager,
                UserRolePlanMaker,
                UserRoleDirector,
                UserRoleEconomist,
                UserRolePricer,
                UserRoleConstructor,
                UserRoleSupplier,
                UserRoleBackManager,
                UserRoleBackManagerBoss,
                UserRoleDesignDepartmentHead
            };

            #if DEBUG

            UserIvanov.Clone(new User { Login = "1", Password = pas1, Employee = EmployeeIvanov, Roles = allRoles.ToList()});
            UserPetrov.Clone(new User { Login = "2", Password = pas2, Employee = EmployeePetrov, Roles = new List<UserRole> { UserRoleDataBaseFiller } });

            #endif

            UserBrehov.Clone(new User { Login = "brehov", Password = pas1, Employee = EmployeeBrehov, Roles = new List<UserRole> { UserRoleSalesManager } });
            UserBuzikin.Clone(new User { Login = "buzikin", Password = pas1, Employee = EmployeeBuzikin, Roles = new List<UserRole> { UserRoleSalesManager } }); ;
            UserVinogradova.Clone(new User { Login = "vinogradova", Password = pas1, Employee = EmployeeVinogradova, Roles = new List<UserRole> { UserRoleSalesManager } });
            UserZaytsev.Clone(new User { Login = "zaytsev", Password = pas1, Employee = EmployeeZaytsev, Roles = new List<UserRole> { UserRoleSalesManager } });
            UserKolesnik.Clone(new User { Login = "kolesnik", Password = pas1, Employee = EmployeeKolesnik, Roles = new List<UserRole> { UserRoleSalesManager } });
            UserKopitin.Clone(new User { Login = "kopitin", Password = pas1, Employee = EmployeeKopitin, Roles = new List<UserRole> { UserRoleSalesManager } });
            UserPostnikova.Clone(new User { Login = "postnikova", Password = pas1, Employee = EmployeePostnikova, Roles = new List<UserRole> { UserRoleSalesManager } });
            UserKosolapov.Clone(new User { Login = "kos", Password = pas1, Employee = EmployeeKosolapov, Roles = allRoles.ToList() });
            UserKoreshkov.Clone(new User { Login = "koreshkov", Password = pas1, Employee = EmployeeKoreshkov, Roles = new List<UserRole> { UserRoleSalesManager } });
            UserEmelyanov.Clone(new User { Login = "emelianov", Password = pas1, Employee = EmployeeEmelyanov, Roles = new List<UserRole> { UserRoleSalesManager } });
            UserRybin.Clone(new User { Login = "rybin", Password = pas1, Employee = EmployeeRybin, Roles = new List<UserRole> { UserRoleSalesManager } });
            UserGazizov.Clone(new User { Login = "gazizov", Password = pas1, Employee = EmployeeGazizov, Roles = new List<UserRole> { UserRoleSalesManager } });
            UserTekin.Clone(new User { Login = "tekin", Password = pas1, Employee = EmployeeTekin, Roles = new List<UserRole> { UserRoleSalesManager } });
            UserDeev.Clone(new User { Login = "deev", Password = pas1, Employee = EmployeeDeev, Roles = new List<UserRole> { UserRoleDirector } });

            UserIgnatenko.Clone(new User { Login = "ignatenko", Password = pas1, Employee = EmployeeIgnatenko, Roles = new List<UserRole> { UserRolePlanMaker, UserRoleReportMaker } });
            UserEgorova.Clone(new User { Login = "egorova", Password = pas1, Employee = EmployeeEgorova, Roles = new List<UserRole> { UserRoleEconomist, UserRolePricer } });
            UserSharapova.Clone(new User { Login = "sharapova", Password = pas1, Employee = EmployeeSharapova, Roles = new List<UserRole> { UserRoleEconomist, UserRolePricer } });
            UserNikiforova.Clone(new User { Login = "nikiforova", Password = pas1, Employee = EmployeeNikiforova, Roles = new List<UserRole> { UserRoleEconomist, UserRolePlanMaker } });
            UserRozhkova.Clone(new User { Login = "rozhkova", Password = pas1, Employee = EmployeeRozhkova, Roles = new List<UserRole> { UserRoleEconomist, UserRolePlanMaker } });

            UserDavidov.Clone(new User { Login = "davidov", Password = pas1, Employee = EmployeeDavidov, Roles = new List<UserRole> { UserRoleDesignDepartmentHead} });
            UserBaranova.Clone(new User { Login = "baranova", Password = pas1, Employee = EmployeeBaranova, Roles = new List<UserRole> { UserRoleConstructor } });
            UserPalferov.Clone(new User { Login = "palferov", Password = pas1, Employee = EmployeePalferov, Roles = new List<UserRole> { UserRoleDesignDepartmentHead } });
            UserBukrin.Clone(new User { Login = "bukrin", Password = pas1, Employee = EmployeeBukrin, Roles = new List<UserRole> { UserRoleConstructor } });

            UserVedernikov.Clone(new User { Login = "vedernikov", Password = pas1, Employee = EmployeeVedernikov, Roles = new List<UserRole> { UserRoleDesignDepartmentHead } });
            UserSivkov.Clone(new User { Login = "sivkov", Password = pas1, Employee = EmployeeSivkov, Roles = new List<UserRole> { UserRoleConstructor } });
        }

        #region DesignDepartment

        public DesignDepartment DesignDepartmentDeadTanks;
        public DesignDepartment DesignDepartmentLiveTanks;
        public DesignDepartment DesignDepartmentDrives;
        public DesignDepartment DesignDepartmentCurrentTransformers;
        public DesignDepartment DesignDepartmentVoltageTransformers;
        public DesignDepartment DesignDepartmentVoltageTransformersCoil;

        private void GenerateDesignDepartments()
        {
            DesignDepartmentDeadTanks.Clone(new DesignDepartment
            {
                Name = "Выключатели баковые",
                Head = UserDavidov,
                Staff = new List<User> { UserDavidov, UserBaranova },
                ParameterSets = new List<DesignDepartmentParameters>()
                {
                    new DesignDepartmentParameters
                    {
                        Name = "ВЭБ-110",
                        Parameters = new List<Parameter>
                        {
                            ParameterBreaker, ParameterBreakerDeadTank, ParameterVoltage110kV
                        }
                    }
                },
                ParameterSetsAddedBlocks = new List<DesignDepartmentParametersAddedBlocks>()
                {
                    new DesignDepartmentParametersAddedBlocks()
                    {
                        Name = "ЗИП",
                        Parameters = new List<Parameter>
                        {
                            ParameterDependentEquipmentTypeZip
                        }
                    },
                    new DesignDepartmentParametersAddedBlocks()
                    {
                        Name = "МК",
                        Parameters = new List<Parameter>
                        {
                            ParameterDependentEquipmentTypeOpornMetVeb110
                        }
                    }

                }
            });

            DesignDepartmentLiveTanks.Clone(new DesignDepartment
            {
                Name = "Выключатели колонковые",
                Head = UserDavidov,
                Staff = new List<User> { UserDavidov, UserBaranova },
                ParameterSets = new List<DesignDepartmentParameters>()
                {
                    new DesignDepartmentParameters
                    {
                        Name = "ВГТ",
                        Parameters = new List<Parameter>
                        {
                            ParameterBreaker, ParameterBreakerLiveTank
                        }
                    }
                },
                ParameterSetsAddedBlocks = new List<DesignDepartmentParametersAddedBlocks>()
                {
                    new DesignDepartmentParametersAddedBlocks()
                    {
                        Name = "ЗИП",
                        Parameters = new List<Parameter>
                        {
                            ParameterDependentEquipmentTypeZip
                        }
                    }
                }
            });

            DesignDepartmentDrives.Clone(new DesignDepartment
            {
                Name = "Приводы",
                Head = UserPalferov,
                Staff = new List<User> { UserPalferov, UserBukrin },
                ParameterSets = new List<DesignDepartmentParameters>()
                {
                    new DesignDepartmentParameters
                    {
                        Name = "Привод ППрК",
                        Parameters = new List<Parameter>
                        {
                            ParameterDrivePPrK
                        }
                    },
                    new DesignDepartmentParameters
                    {
                        Name = "Привод ППВ",
                        Parameters = new List<Parameter>
                        {
                            ParameterDrivePPV
                        }
                    }
                },
                ParameterSetsAddedBlocks = new List<DesignDepartmentParametersAddedBlocks>()
                {
                    new DesignDepartmentParametersAddedBlocks()
                    {
                        Name = "ЗИП",
                        Parameters = new List<Parameter>
                        {
                            ParameterDependentEquipmentTypeZip
                        }
                    },
                    new DesignDepartmentParametersAddedBlocks()
                    {
                        Name = "МК",
                        Parameters = new List<Parameter>
                        {
                            ParameterDependentEquipmentTypeOpornMet
                        }
                    }
                }
            });

            DesignDepartmentCurrentTransformers.Clone(new DesignDepartment
            {
                Name = "КТТ",
                Head = UserVedernikov,
                Staff = new List<User> { UserSivkov, UserBaranova },
                ParameterSets = new List<DesignDepartmentParameters>()
                {
                    new DesignDepartmentParameters
                    {
                        Name = "КТТ ВЭБ-110",
                        Parameters = new List<Parameter>
                        {
                            ParameterTransformersBlockTargetVeb110, ParameterPartTransformersCurrentBlock, ParameterProductParts
                        }
                    }
                },
                ParameterSetsAddedBlocks = new List<DesignDepartmentParametersAddedBlocks>()
                {
                    new DesignDepartmentParametersAddedBlocks()
                    {
                        Name = "ЗИП",
                        Parameters = new List<Parameter>
                        {
                            ParameterDependentEquipmentTypeZip
                        }
                    }
                },
                IsPriceIncreaseFactor = true
            });

            DesignDepartmentVoltageTransformers.Clone(new DesignDepartment
            {
                Name = "ТН",
                Head = UserVedernikov,
                Staff = new List<User> { UserSivkov, UserBaranova },
                ParameterSets = new List<DesignDepartmentParameters>()
                {
                    new DesignDepartmentParameters
                    {
                        Name = "ЗНГ-110",
                        Parameters = new List<Parameter>
                        {
                            ParameterVoltage110kV, ParameterTransformerVoltage
                        }
                    }
                },
                ParameterSetsAddedBlocks = new List<DesignDepartmentParametersAddedBlocks>()
                {
                    new DesignDepartmentParametersAddedBlocks()
                    {
                        Name = "ЗИП",
                        Parameters = new List<Parameter>
                        {
                            ParameterDependentEquipmentTypeZip
                        }
                    }
                }
            });

            DesignDepartmentVoltageTransformersCoil.Clone(new DesignDepartment
            {
                Name = "ТН (катушка)",
                Head = UserVedernikov,
                Staff = new List<User> { UserSivkov, UserBaranova },
                ParameterSets = new List<DesignDepartmentParameters>()
                {
                    new DesignDepartmentParameters
                    {
                        Name = "ЗНГ-110 (катушка)",
                        Parameters = new List<Parameter>
                        {
                            ParameterTransformersVoltageBlockTypeStandart
                        }
                    }
                }, 
                IsPriceIncreaseFactor = true
            });


        }

        #endregion
    }
}