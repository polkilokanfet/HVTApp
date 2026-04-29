using System;
using System.Collections.Generic;
using System.Linq;
using HVTApp.Model;
using HVTApp.Model.POCOs;

namespace HVTApp.TestDataGenerator
{
    public partial class TestData
    {
        #region Group

        public ParameterGroup ParameterGroupProductType;
        public ParameterGroup ParameterGroupZip;
        public ParameterGroup ParameterGroupOpornMetHigh;
        public ParameterGroup ParameterGroupEqType;
        public ParameterGroup ParameterGroupBreakerType;
        public ParameterGroup ParameterGroupTransformatorType;
        public ParameterGroup ParameterGroupTransformatorCurrentType;
        public ParameterGroup ParameterGroupTvgType;
        public ParameterGroup ParameterGroupVoltage;
        public ParameterGroup ParameterGroupDrivesVoltage;
        public ParameterGroup ParameterGroupDrivesCurrentDisconnectors;
        public ParameterGroup ParameterGroupIsolation;
        public ParameterGroup ParameterGroupIsolationColor;
        public ParameterGroup ParameterGroupIsolationMaterial;
        public ParameterGroup ParameterGroupAccuracy;
        public ParameterGroup ParameterGroupCurrent;
        public ParameterGroup ParameterGroupCurrentBreaking;
        public ParameterGroup ParameterGroupNewProductDesignation;
        public ParameterGroup ParameterGroupComplectDesignationGroup;
        public ParameterGroup ParameterGroupComplectsGroup;
        public ParameterGroup ParameterGroupDrives;
        public ParameterGroup ParameterGroupClimat;
        public ParameterGroup ParameterGroupPartType;
        public ParameterGroup ParameterGroupTransformersBlockStandartNumber;
        public ParameterGroup ParameterGroupTransformersCurrentBlockType;
        public ParameterGroup ParameterGroupTransformersVoltageBlockType;
        public ParameterGroup ParameterGroupTransformersInBlockAmount;
        public ParameterGroup ParameterGroupTransformersBlockTarget;
        public ParameterGroup ParameterGroupServiceType;
        public ParameterGroup ParameterGroupControlCircuitVoltage;
        public ParameterGroup ParameterGroupTransformerLoad;
        public ParameterGroup ParameterGroupTransformerLimitMultiplicity;
        public ParameterGroup ParameterGroupTransformerSafetyK;
        public ParameterGroup ParameterGroupTransformerPrimaryCurrentRow;
        public ParameterGroup ParameterGroupTransformerSecondaryCurrent;
        public ParameterGroup ParameterGroupBreakerPhases;
        public ParameterGroup ParameterGroupBreakerLiveTankBreaks;
        public ParameterGroup ParameterGroupBreakerHeaterVoltage;
        public ParameterGroup ParameterGroupVgtOtklUstr;
        public ParameterGroup ParameterGroupVgbIspPoRastPrivoda;
        public ParameterGroup ParameterGroupVgbIspPem;
        public ParameterGroup ParameterGroupPemUnomUpr;
        public ParameterGroup ParameterGroupPemUnomVkl;
        public ParameterGroup ParameterGroupPemUnomOtkl;
        public ParameterGroup ParameterGroupPemUnomYav;
        public ParameterGroup ParameterGroupPemInomYaa;
        public ParameterGroup ParameterGroupIterm;
        public ParameterGroup ParameterGroupDisconnectorIspolnenie;
        public ParameterGroup ParameterGroupDisconnectorZazemlPal;
        public ParameterGroup ParameterGroupDisconnectorZazemlKul;
        public ParameterGroup ParameterGroupDriveDisconnectorType;
        public ParameterGroup ParameterGroupDriveDisconnectorTarget;
        public ParameterGroup ParameterGroupDriveDisconnectorU;
        public ParameterGroup ParameterGroupDriveDisconnectorUblock;
        public ParameterGroup ParameterGroupDisconnectorRast;
        public ParameterGroup ParameterGroupTransformerVoltageUisp;
        public ParameterGroup ParameterGroupTransformerVoltageIsolation;
        public ParameterGroup ParameterGroupTrgIsp;
        public ParameterGroup ParameterGroupTransformerCurrentTargetProduct;
        public ParameterGroup ParameterGroupBvptType;
        public ParameterGroup ParameterGroupBvptSeries;
        public ParameterGroup ParameterGroupBvptIspolnenie;
        public ParameterGroup ParameterGroupBvptCurrent;
        public ParameterGroup ParameterGroupBvptVoltage;
        public ParameterGroup ParameterGroupSupervisionTarget;
        public ParameterGroup ParameterGroupSupervisionZone;
        public ParameterGroup ParameterGroupDependentEquipmentType;
        public ParameterGroup ParameterGroupDependentEquipmentTypeMkType;

        private void GenerateParameterGroups()
        {
            ParameterGroupProductType.Clone(new ParameterGroup { Name = "Тип продукта" });
            ParameterGroupEqType.Clone(new ParameterGroup { Name = "Тип оборудования" });
            ParameterGroupZip.Clone(new ParameterGroup { Name = "Тип ЗИП" });
            ParameterGroupOpornMetHigh.Clone(new ParameterGroup { Name = "Высота металлоконструкции" });
            ParameterGroupBreakerType.Clone(new ParameterGroup { Name = "Тип выключателя" });
            ParameterGroupTransformatorType.Clone(new ParameterGroup { Name = "Тип трансформатора" });
            ParameterGroupTransformatorCurrentType.Clone(new ParameterGroup { Name = "Установка ТТ" });
            ParameterGroupVoltage.Clone(new ParameterGroup { Name = "Номинальное напряжение", Measure = MeasureKv });
            ParameterGroupDrivesVoltage.Clone(new ParameterGroup { Name = "Номинальное напряжение двигателя завода пружин", Measure = MeasureKv });
            ParameterGroupIsolation.Clone(new ParameterGroup { Name = "Длина пути утечки" });
            ParameterGroupIsolationColor.Clone(new ParameterGroup { Name = "Цвет изоляции" });
            ParameterGroupIsolationMaterial.Clone(new ParameterGroup { Name = "Тип изоляции" });
            ParameterGroupAccuracy.Clone(new ParameterGroup { Name = "Класс точности" });
            ParameterGroupCurrent.Clone(new ParameterGroup { Name = "Номинальный ток" });
            ParameterGroupCurrentBreaking.Clone(new ParameterGroup { Name = "Номинальный ток отключения" });
            ParameterGroupNewProductDesignation.Clone(new ParameterGroup { Name = "Обозначение" });
            ParameterGroupComplectDesignationGroup.Clone(new ParameterGroup { Name = "Обозначение комплекта или детали" });
            ParameterGroupComplectsGroup.Clone(new ParameterGroup { Name = "Тип комплекта или детали" });
            ParameterGroupDrives.Clone(new ParameterGroup { Name = "Приводы" });
            ParameterGroupClimat.Clone(new ParameterGroup { Name = "Климатическое исполнение" });
            ParameterGroupPartType.Clone(new ParameterGroup { Name = "Тип составной части" });
            ParameterGroupTransformersCurrentBlockType.Clone(new ParameterGroup { Name = "Тип комплекта трансформаторов тока" });
            ParameterGroupTransformersVoltageBlockType.Clone(new ParameterGroup { Name = "Тип комплекта обмоток ТН" });
            ParameterGroupTransformersBlockTarget.Clone(new ParameterGroup { Name = "Назначение комплекта трансформатора" });
            ParameterGroupTransformersBlockStandartNumber.Clone(new ParameterGroup { Name = "Номер стандартного комплекта ТТ" });
            ParameterGroupServiceType.Clone(new ParameterGroup { Name = "Тип услуги" });
            ParameterGroupTvgType.Clone(new ParameterGroup { Name = "Тип встроенного ТТ" });
            ParameterGroupControlCircuitVoltage.Clone(new ParameterGroup { Name = "Напряжение цепей управления" });
            ParameterGroupTransformerLoad.Clone(new ParameterGroup { Name = "Нагрузка, ВА" });
            ParameterGroupTransformerLimitMultiplicity.Clone(new ParameterGroup { Name = "Предельная кратность" });
            ParameterGroupTransformerSafetyK.Clone(new ParameterGroup { Name = "Коэффициент безопасности" });
            ParameterGroupTransformerPrimaryCurrentRow.Clone(new ParameterGroup { Name = "Номинальные токи отпаек" });
            ParameterGroupTransformerSecondaryCurrent.Clone(new ParameterGroup { Name = "Номинальный вторичный ток" });
            ParameterGroupDrivesCurrentDisconnectors.Clone(new ParameterGroup { Name = "Установка двух токовых расцепителей" });
            ParameterGroupBreakerPhases.Clone(new ParameterGroup { Name = "Исполнение выключателя" });
            ParameterGroupBreakerLiveTankBreaks.Clone(new ParameterGroup { Name = "Исполнение по количеству разрывов" });
            ParameterGroupBreakerHeaterVoltage.Clone(new ParameterGroup { Name = "Номинальное напряжение обогрева, В" });
            ParameterGroupVgtOtklUstr.Clone(new ParameterGroup { Name = "Исполнение по конструкции отключающего устройства" });
            ParameterGroupVgbIspPoRastPrivoda.Clone(new ParameterGroup { Name = "Исполнение в зависимости от расстояния между приводом и выключателем" });
            ParameterGroupVgbIspPem.Clone(new ParameterGroup { Name = "Исполнение привода ПЭМ" });
            ParameterGroupTransformersInBlockAmount.Clone(new ParameterGroup { Name = "Количество ТТ на фазу" });
            ParameterGroupPemUnomUpr.Clone(new ParameterGroup { Name = "Uном пост.тока цепей питания эл.магнитов включения, отключения и контакторов, В" });
            ParameterGroupPemUnomVkl.Clone(new ParameterGroup { Name = "Uном пост.тока цепей питания эл.магнитов включения, В" });
            ParameterGroupPemUnomOtkl.Clone(new ParameterGroup { Name = "Uном пост.тока цепей питания эл.магнитов отключения и контакторов, В" });
            ParameterGroupPemUnomYav.Clone(new ParameterGroup { Name = "Uном эл.магнита релейного отключения YAV, В" });
            ParameterGroupPemInomYaa.Clone(new ParameterGroup { Name = "Iном токовых эл.магнитов YAA, A" });
            ParameterGroupIterm.Clone(new ParameterGroup { Name = "Ток термической стойкости разъединителя, кA" });
            ParameterGroupDisconnectorIspolnenie.Clone(new ParameterGroup { Name = "Исполнение разъединителя" });
            ParameterGroupDisconnectorZazemlPal.Clone(new ParameterGroup { Name = "Заземлитель со стороны пальцевого контакта" });
            ParameterGroupDisconnectorZazemlKul.Clone(new ParameterGroup { Name = "Заземлитель со стороны кулачкового контакта" });
            ParameterGroupDriveDisconnectorType.Clone(new ParameterGroup { Name = "Тип привода" });
            ParameterGroupDriveDisconnectorTarget.Clone(new ParameterGroup { Name = "Для управления ножами" });
            ParameterGroupDriveDisconnectorU.Clone(new ParameterGroup { Name = "Номинальное напряжение электродвигателя" });
            ParameterGroupDriveDisconnectorUblock.Clone(new ParameterGroup { Name = "Номинальное напряжение постоянного тока электромагнитной блокировки" });
            ParameterGroupDisconnectorRast.Clone(new ParameterGroup { Name = "Расстояние между полюсами / откл.способность" });
            ParameterGroupTransformerVoltageUisp.Clone(new ParameterGroup { Name = "Уровни напряжений, кВ (пром.част / полн. / срез.гр.имп.)" });
            ParameterGroupTransformerVoltageIsolation.Clone(new ParameterGroup { Name = "Вид внутренней изоляции" });
            ParameterGroupTrgIsp.Clone(new ParameterGroup { Name = "Возможность переключения по первичной стороне (4:2:1)" });
            ParameterGroupTransformerCurrentTargetProduct.Clone(new ParameterGroup { Name = "Продукт для встраивания" });
            ParameterGroupBvptType.Clone(new ParameterGroup { Name = "Тип БВПТ" });
            ParameterGroupBvptSeries.Clone(new ParameterGroup { Name = "Серия БВПТ" });
            ParameterGroupBvptIspolnenie.Clone(new ParameterGroup { Name = "Исполнение БВПТ" });
            ParameterGroupBvptCurrent.Clone(new ParameterGroup { Name = "Номинальный рабочий ток, А" });
            ParameterGroupBvptVoltage.Clone(new ParameterGroup { Name = "Номинальное напряжение, В" });
            ParameterGroupSupervisionTarget.Clone(new ParameterGroup { Name = "Монтируемое изделие" });
            ParameterGroupSupervisionZone.Clone(new ParameterGroup { Name = "Зона проведения монтажа" });
            ParameterGroupDependentEquipmentType.Clone(new ParameterGroup { Name = "Тип дополнительного оборудования" });
            ParameterGroupDependentEquipmentTypeMkType.Clone(new ParameterGroup { Name = "МК к оборудованию" });
        }

        #endregion

        #region Parameter

        #region Параметры

        #region Тип продукта

        public Parameter ParameterNewProduct;
        public Parameter ParameterMainEquipment;
        public Parameter ParameterBvpt;
        public Parameter ParameterDependentEquipment;
        public Parameter ParameterService;
        public Parameter ParameterComplects;

        #endregion

        #region Тип услуги

        public Parameter ParameterSupervision;

        #endregion

        #region Цель шеф-монтажа

        public Parameter ParameterSupervisionDeadTankBreaker;
        public Parameter ParameterSupervisionLiveTankBreaker;
        public Parameter ParameterSupervisionTransformerCurrent;
        public Parameter ParameterSupervisionTransformerVoltage;

        #endregion

        #region Зона шеф-монтажа

        public Parameter ParameterSupervisionZone1;
        public Parameter ParameterSupervisionZone2;
        public Parameter ParameterSupervisionZone3;

        #endregion

        #region Тип дополнительного оборудования

        public Parameter ParameterDependentEquipmentTypeZip;
        public Parameter ParameterDependentEquipmentTypeShkaf;
        public Parameter ParameterDependentEquipmentTypeOpornMet;
        public Parameter ParameterDependentEquipmentTypeOpornMetVeb110;
        public Parameter ParameterDependentEquipmentTypeOpornMetTrg110;

        #endregion

        #region ЗИПы

        public Parameter ParameterZip1;
        public Parameter ParameterZip2;

        #endregion

        #region Металлоконструкции

        public Parameter ParameterOpornMet1000;
        public Parameter ParameterOpornMet2000;

        #endregion

        #region Тип основного оборудования

        public Parameter ParameterBreaker;
        public Parameter ParameterTransformer;
        public Parameter ParameterDisconnector;
        public Parameter ParameterEarthingSwitch;
        public Parameter ParameterProductParts;

        #endregion

        #region Составные части основоного оборудования

        public Parameter ParameterPartDrive;
        public Parameter ParameterPartTransformer;
        public Parameter ParameterPartTransformersCurrentBlock;
        public Parameter ParameterPartTransformersVoltageBlock;

        #endregion

        #region Тип привода

        public Parameter ParameterDrivePPrK;
        public Parameter ParameterDrivePPV;
        public Parameter ParameterDriveDisconnector;
        public Parameter ParameterDrivePem;

        #endregion

        #region Тип выключателя

        public Parameter ParameterBreakerDeadTank;
        public Parameter ParameterBreakerLiveTank;

        #endregion

        #region Тип трансформатора

        public Parameter ParameterTransformerCurrent;
        public Parameter ParameterTransformerVoltage;

        #endregion

        #region Тип трансформатора тока

        public Parameter ParameterTransformerBuiltOut;
        public Parameter ParameterTransformerBuiltIn;

        #endregion

        #region Номинальное напряжение

        public Parameter ParameterVoltage35kV;
        public Parameter ParameterVoltage110kV;
        public Parameter ParameterVoltage220kV;
        public Parameter ParameterVoltage330kV;
        public Parameter ParameterVoltage500kV;

        #endregion

        #region Номинальный ток

        public Parameter ParameterCurrent1250;
        public Parameter ParameterCurrent1600;

        public Parameter ParameterCurrent0630;
        public Parameter ParameterCurrent1000;

        public Parameter ParameterCurrent2500;
        public Parameter ParameterCurrent3150;

        public Parameter ParameterCurrent4000;

        #endregion

        #region Номинальный ток отключения

        public Parameter ParameterCurrentBreaking12kA;
        public Parameter ParameterCurrentBreaking40kA;
        public Parameter ParameterCurrentBreaking50kA;

        #endregion

        #region Ток термической стойкости

        public Parameter ParameterIterm25kA;
        public Parameter ParameterIterm40kA;
        public Parameter ParameterIterm50kA;

        #endregion

        #region Климматическое исполнение

        public Parameter ParameterClimatT1;
        public Parameter ParameterClimatU1Z;
        public Parameter ParameterClimatUhl1Z;
        public Parameter ParameterClimatUhl1;
        public Parameter ParameterClimatU1;
        public Parameter ParameterClimatHl1Z;
        public Parameter ParameterClimatHl1;

        #endregion

        #region Характеристики привода выключателя

        #region Токовые расцепители

        public Parameter ParameterDrivesCurrentDiscNo;
        public Parameter ParameterDrivesCurrentDisc3A;
        public Parameter ParameterDrivesCurrentDisc5A;

        #endregion

        #region Напряжение двигателя завода пружин

        public Parameter ParameterDrivesVoltage400V;
        public Parameter ParameterDrivesVoltage230V;
        public Parameter ParameterDrivesVoltage220V;
        public Parameter ParameterDrivesVoltage110Vpost;
        public Parameter ParameterDrivesVoltage220Vpost;
        public Parameter ParameterDrivesVoltage230Vperem;
        #endregion

        #region Напряжение цепей управления

        public Parameter ParameterControlCircuitVoltage110Vpost;
        public Parameter ParameterControlCircuitVoltage220Vpost;
        public Parameter ParameterControlCircuitVoltage220Vperem;

        #endregion

        #endregion

        #region Изоляция

        #region Тип изоляции

        public Parameter ParameterFarfor;
        public Parameter ParameterPolimer;

        #endregion

        #region Длина пути утечки

        public Parameter ParameterDpu2;
        public Parameter ParameterDpu3;
        public Parameter ParameterDpu4;

        #endregion

        #region Цвет изоляции

        public Parameter ParameterIsolationColorGrey;
        public Parameter ParameterIsolationColorBrown;

        #endregion

        #endregion

        #region Трансформаторы тока

        #region Первичные токи отпаек ТТ

        public Parameter ParameterTransformerPrimaryCurrentRow1;
        public Parameter ParameterTransformerPrimaryCurrentRow2;

        #endregion

        #region Вторичный ток ТТ

        public Parameter ParameterTransformerSecondaryCurrent1;
        public Parameter ParameterTransformerSecondaryCurrent5;

        #endregion

        #region Класс точности ТТ

        public Parameter ParameterAccuracy02;
        public Parameter ParameterAccuracy02S;
        public Parameter ParameterAccuracy05;
        public Parameter ParameterAccuracy05S;
        public Parameter ParameterAccuracy05P;
        public Parameter ParameterAccuracy10P;

        #endregion

        #region Нагрузка ТТ

        public Parameter ParameterTransformerLoad05;
        public Parameter ParameterTransformerLoad10;
        public Parameter ParameterTransformerLoad15;
        public Parameter ParameterTransformerLoad20;
        public Parameter ParameterTransformerLoad25;
        public Parameter ParameterTransformerLoad30;
        public Parameter ParameterTransformerLoad35;
        public Parameter ParameterTransformerLoad40;
        public Parameter ParameterTransformerLoad45;
        public Parameter ParameterTransformerLoad50;
        public Parameter ParameterTransformerLoad55;
        public Parameter ParameterTransformerLoad60;

        #endregion

        #region Коэффициент предельной кратности ТТ

        public Parameter ParameterTransformerLimitMultiplicity05;
        public Parameter ParameterTransformerLimitMultiplicity10;
        public Parameter ParameterTransformerLimitMultiplicity15;
        public Parameter ParameterTransformerLimitMultiplicity20;
        public Parameter ParameterTransformerLimitMultiplicity25;
        public Parameter ParameterTransformerLimitMultiplicity30;
        public Parameter ParameterTransformerLimitMultiplicity35;
        public Parameter ParameterTransformerLimitMultiplicity40;
        public Parameter ParameterTransformerLimitMultiplicity45;
        public Parameter ParameterTransformerLimitMultiplicity50;
        public Parameter ParameterTransformerLimitMultiplicity55;
        public Parameter ParameterTransformerLimitMultiplicity60;

        #endregion

        #region Коэффициент безопасности ТТ

        public Parameter ParameterTransformerSafetyK02;
        public Parameter ParameterTransformerSafetyK04;
        public Parameter ParameterTransformerSafetyK06;
        public Parameter ParameterTransformerSafetyK08;
        public Parameter ParameterTransformerSafetyK10;
        public Parameter ParameterTransformerSafetyK12;
        public Parameter ParameterTransformerSafetyK14;
        public Parameter ParameterTransformerSafetyK16;
        public Parameter ParameterTransformerSafetyK18;
        public Parameter ParameterTransformerSafetyK20;
        public Parameter ParameterTransformerSafetyK22;
        public Parameter ParameterTransformerSafetyK24;

        #endregion

        #region Тип комплекта ТТ

        public Parameter ParameterTransformersCurrentBlockTypeStandart;
        public Parameter ParameterTransformersCurrentBlockTypeCustom;

        #endregion

        #region Тип комплекта ТН

        public Parameter ParameterTransformersVoltageBlockTypeStandart;
        public Parameter ParameterTransformersVoltageBlockTypeCustom;

        #endregion

        #region Количество ТТ в комплекте

        public Parameter ParameterTransformersInBlockAmount0;
        public Parameter ParameterTransformersInBlockAmount1;
        public Parameter ParameterTransformersInBlockAmount2;
        public Parameter ParameterTransformersInBlockAmount3;
        public Parameter ParameterTransformersInBlockAmount4;
        public Parameter ParameterTransformersInBlockAmount5;
        public Parameter ParameterTransformersInBlockAmount6;
        public Parameter ParameterTransformersInBlockAmount7;
        public Parameter ParameterTransformersInBlockAmount8;

        #endregion

        #region Стандартные комплекты ТТ

        public Parameter ParameterTransformersBlockStandartVgb035Num1;
        public Parameter ParameterTransformersBlockStandartVgb035Num2;
        public Parameter ParameterTransformersBlockStandartVeb110Num1;
        public Parameter ParameterTransformersBlockStandartVeb110Num2;
        public Parameter ParameterTransformersBlockStandartVeb220Num1;
        public Parameter ParameterTransformersBlockStandartVeb220Num2;

        public Parameter ParameterTransformersBlockStandartEmpty;

        #endregion

        #region Назначение ТТ

        public Parameter ParameterTransformersBlockTargetVeb110;
        public Parameter ParameterTransformersBlockTargetVeb220;
        public Parameter ParameterTransformersBlockTargetVgb35;
        public Parameter ParameterTransformersBlockTargetTrg35;
        public Parameter ParameterTransformersBlockTargetTrg110;
        public Parameter ParameterTransformersBlockTargetTrg220;
        public Parameter ParameterTransformersBlockTargetZng110;
        public Parameter ParameterTransformersBlockTargetZng220;

        #endregion        

        #endregion

        #region Исполнение выключателя по полюсности

        public Parameter ParameterBreakerPhases3;
        public Parameter ParameterBreakerPhases1;

        #endregion

        #region Исполнение выключателя по количеству разрывов

        public Parameter ParameterBreakerLiveTankBreaks1Razriv;

        #endregion

        #region Напряжение обогрева полюсов

        public Parameter ParameterBreakerHeatingVoltage400Zvezda;
        public Parameter ParameterBreakerHeatingVoltage230Treug;
        public Parameter ParameterBreakerHeatingVoltage230Ff;
        public Parameter ParameterBreakerHeatingVoltage230Fn;

        #endregion

        #region Исполнение по конструкции отключающего устройства ВГТ

        public Parameter ParameterVgtOtklUstrOtkr;
        public Parameter ParameterVgtOtklUstrZakr;

        #endregion

        #region Исполнение ВГБ-35 по расстоянию

        public Parameter ParameterVgbIspPoRastPrivodaStandrt;
        public Parameter ParameterVgbIspPoRastPrivodaSpec;

        #endregion

        #region Исполнение привода ПЭМ

        public Parameter ParameterVgbIspPem1;
        public Parameter ParameterVgbIspPem2;
        public Parameter ParameterVgbIspPem3;
        public Parameter ParameterVgbIspPem4;

        #endregion

        #region ПЭМ цепи управления

        public Parameter ParameterPemUnomUpr110Post;
        public Parameter ParameterPemUnomUpr220Post;
        public Parameter ParameterPemUnomUpr220Perem;

        public Parameter ParameterPemUnomVkl;
        public Parameter ParameterPemUnomOtkl;

        public Parameter ParameterPemUnomYav220Perem;
        public Parameter ParameterPemUnomYav220Post;
        public Parameter ParameterPemUnomYav110Post;

        public Parameter ParameterPemInomYaa3;
        public Parameter ParameterPemInomYaa5;

        #endregion

        #region Исполнение разъединителя

        public Parameter ParameterDisconnectorIspolnenie1Pol;
        public Parameter ParameterDisconnectorIspolnenie3Pol;
        public Parameter ParameterDisconnectorIspolnenieKil;
        public Parameter ParameterDisconnectorIspolnenieStKil;

        #endregion

        #region Заземлители разъединителя

        public Parameter ParameterDisconnectorZazemlPalPos;
        public Parameter ParameterDisconnectorZazemlPalNeg;

        public Parameter ParameterDisconnectorZazemlKulPos;
        public Parameter ParameterDisconnectorZazemlKulNeg;

        #endregion

        #region Тип привода разъединителя

        public Parameter ParameterDriveDisconnectorTypeMotorn;
        public Parameter ParameterDriveDisconnectorTypeRuchn;

        #endregion

        #region Тип привода разъединителя (по ножам)

        public Parameter ParameterDriveDisconnectorTargetMain;
        public Parameter ParameterDriveDisconnectorTargetZazeml;

        #endregion

        #region Напряжение двигателя разъединителя

        public Parameter ParameterDriveDisconnectorU230;
        public Parameter ParameterDriveDisconnectorU220;
        public Parameter ParameterDriveDisconnectorU400;

        #endregion

        #region Напряжение эл.магн. блокировки

        public Parameter ParameterDriveDisconnectorUblock110;
        public Parameter ParameterDriveDisconnectorUblock220;

        #endregion

        #region Расстояние между полюсами

        public Parameter ParameterDisconnectorRast1700;
        public Parameter ParameterDisconnectorRast1800;
        public Parameter ParameterDisconnectorRast2000;

        #endregion

        #region Уровни напряжений

        public Parameter ParameterTransformerVoltageUisp200;
        public Parameter ParameterTransformerVoltageUisp230;

        #endregion

        #region Вид внутренней изоляции

        public Parameter ParameterTransformerVoltageIsolationSf6;
        public Parameter ParameterTransformerVoltageIsolationN2;
        public Parameter ParameterTransformerVoltageIsolationSf6N2;
        public Parameter ParameterTransformerVoltageIsolationSf6Cf4;

        #endregion

        #region Исполнение ТРГ

        public Parameter ParameterTrgIsp1;
        public Parameter ParameterTrgIsp2;

        #endregion

        #region Продукт для встраивания

        public Parameter ParameterTransformerCurrentTargetProductBreaker;
        public Parameter ParameterTransformerCurrentTargetProductTransformer;

        #endregion

        #region БВПТ

        #region Тип БВПТ

        public Parameter ParameterBvptVab;
        public Parameter ParameterBvptVat;

        #endregion

        #region Исполнение БВПТ

        public Parameter ParameterBvptIspolnenieL;
        public Parameter ParameterBvptIspolnenieK;

        #endregion

        #region Серия БВПТ

        public Parameter ParameterBvptSeries42;
        public Parameter ParameterBvptSeries43;
        public Parameter ParameterBvptSeries48;
        public Parameter ParameterBvptSeries49;
        public Parameter ParameterBvptSeries52;
        public Parameter ParameterBvptSeries55;

        #endregion

        #region Ток БВПТ

        public Parameter ParameterBvptCurrent1600;
        public Parameter ParameterBvptCurrent2500;
        public Parameter ParameterBvptCurrent3200;
        public Parameter ParameterBvptCurrent4000;
        public Parameter ParameterBvptCurrent5000;
        public Parameter ParameterBvptCurrent6300;

        #endregion

        #region Напряжение БВПТ

        public Parameter ParameterBvptVoltage0460;
        public Parameter ParameterBvptVoltage0660;
        public Parameter ParameterBvptVoltage1050;
        public Parameter ParameterBvptVoltage1650;
        public Parameter ParameterBvptVoltage3000;
        public Parameter ParameterBvptVoltage3300;

        #endregion       

        #endregion

        #endregion

        private void GenerateParameters()
        {
            #region Тип продукта

            ParameterMainEquipment.Clone(new Parameter { ParameterGroup = ParameterGroupProductType, Value = "Подстанционное оборудование", Rang = 10 });
            ParameterBvpt.Clone(new Parameter { ParameterGroup = ParameterGroupProductType, Value = "Быстродействующие выключатели постоянного тока", Rang = 9 });
            ParameterDependentEquipment.Clone(new Parameter { ParameterGroup = ParameterGroupProductType, Value = "Оборудование дополнительное", Rang = 8 });
            ParameterService.Clone(new Parameter { ParameterGroup = ParameterGroupProductType, Value = "Услуга", Rang = 7 });
            ParameterProductParts.Clone(new Parameter { ParameterGroup = ParameterGroupProductType, Value = "Составные части оборудования", Rang = 6 });
            ParameterNewProduct.Clone(new Parameter { ParameterGroup = ParameterGroupProductType, Value = "Оборудование новое", Rang = 5 });
            ParameterComplects.Clone(new Parameter { ParameterGroup = ParameterGroupProductType, Value = "Комплекты и детали", Rang = 10 });

            #endregion

            #region Тип услуги

            ParameterSupervision.Clone(new Parameter { ParameterGroup = ParameterGroupServiceType, Value = "Шеф-монтаж" });

            ParameterSupervision.AddRequiredPreviousParameters(ParameterService);

            #endregion

            #region Цель шеф-монтажа

            ParameterSupervisionDeadTankBreaker.Clone(new Parameter { ParameterGroup = ParameterGroupSupervisionTarget, Value = "Выключатель баковый" });
            ParameterSupervisionLiveTankBreaker.Clone(new Parameter { ParameterGroup = ParameterGroupSupervisionTarget, Value = "Выключатель колонковый" });
            ParameterSupervisionTransformerCurrent.Clone(new Parameter { ParameterGroup = ParameterGroupSupervisionTarget, Value = "Трансформатор тока" });
            ParameterSupervisionTransformerVoltage.Clone(new Parameter { ParameterGroup = ParameterGroupSupervisionTarget, Value = "Трансформатор напряжения" });

            ParameterSupervisionDeadTankBreaker
                .AddRequiredPreviousParameters(ParameterSupervision);

            ParameterSupervisionLiveTankBreaker
                .AddRequiredPreviousParameters(ParameterSupervision);

            ParameterSupervisionTransformerCurrent
                .AddRequiredPreviousParameters(ParameterSupervision);

            ParameterSupervisionTransformerVoltage
                .AddRequiredPreviousParameters(ParameterSupervision);

            #endregion

            #region Зона шеф-монтажа

            ParameterSupervisionZone1.Clone(new Parameter { ParameterGroup = ParameterGroupSupervisionZone, Value = "1" });
            ParameterSupervisionZone2.Clone(new Parameter { ParameterGroup = ParameterGroupSupervisionZone, Value = "2" });
            ParameterSupervisionZone3.Clone(new Parameter { ParameterGroup = ParameterGroupSupervisionZone, Value = "3" }); ;

            ParameterSupervisionZone1.AddRequiredPreviousParameters(ParameterSupervision);
            ParameterSupervisionZone2.AddRequiredPreviousParameters(ParameterSupervision);
            ParameterSupervisionZone3.AddRequiredPreviousParameters(ParameterSupervision);

            #endregion

            #region Тип дополнительного оборудования

            ParameterDependentEquipmentTypeZip.Clone(new Parameter { ParameterGroup = ParameterGroupDependentEquipmentType, Value = "Групповой комплект ЗИП", Rang = 50 });
            ParameterDependentEquipmentTypeOpornMet.Clone(new Parameter { ParameterGroup = ParameterGroupDependentEquipmentType, Value = "Опорные металлоконструкции", Rang = 40 });
            ParameterDependentEquipmentTypeOpornMetVeb110.Clone(new Parameter { ParameterGroup = ParameterGroupDependentEquipmentTypeMkType, Value = "Опорные металлоконструкции к ВЭБ-110", Rang = 40 });
            ParameterDependentEquipmentTypeOpornMetTrg110.Clone(new Parameter { ParameterGroup = ParameterGroupDependentEquipmentTypeMkType, Value = "Опорные металлоконструкции к ТРГ-110", Rang = 40 });
            ParameterDependentEquipmentTypeShkaf.Clone(new Parameter { ParameterGroup = ParameterGroupDependentEquipmentType, Value = "Шкафы", Rang = 30 });

            ParameterDependentEquipmentTypeZip.AddRequiredPreviousParameters(ParameterDependentEquipment);
            ParameterDependentEquipmentTypeOpornMet.AddRequiredPreviousParameters(ParameterDependentEquipment);
            ParameterDependentEquipmentTypeOpornMetVeb110.AddRequiredPreviousParameters(ParameterDependentEquipmentTypeOpornMet);
            ParameterDependentEquipmentTypeOpornMetTrg110.AddRequiredPreviousParameters(ParameterDependentEquipmentTypeOpornMet);
            ParameterDependentEquipmentTypeShkaf.AddRequiredPreviousParameters(ParameterDependentEquipment);

            #endregion

            #region ЗИПы

            ParameterZip1.Clone(new Parameter { ParameterGroup = ParameterGroupZip, Value = "Групповой комплект ЗИП №1 (газотехнология)" });
            ParameterZip2.Clone(new Parameter { ParameterGroup = ParameterGroupZip, Value = "Групповой комплект ЗИП №2 (элегаз)" });

            ParameterZip1.AddRequiredPreviousParameters(ParameterDependentEquipmentTypeZip);
            ParameterZip2.AddRequiredPreviousParameters(ParameterDependentEquipmentTypeZip);

            #endregion

            #region Высота МК

            ParameterOpornMet1000.Clone(new Parameter { ParameterGroup = ParameterGroupOpornMetHigh, Value = "1000 мм" });
            ParameterOpornMet2000.Clone(new Parameter { ParameterGroup = ParameterGroupOpornMetHigh, Value = "2000 мм" });

            ParameterOpornMet1000.AddRequiredPreviousParameters(ParameterDependentEquipmentTypeOpornMet);
            ParameterOpornMet2000.AddRequiredPreviousParameters(ParameterDependentEquipmentTypeOpornMet);

            #endregion


            #region Тип основного оборудования

            ParameterBreaker.Clone(new Parameter { ParameterGroup = ParameterGroupEqType, Value = "Выключатель", Rang = 10 });
            ParameterTransformer.Clone(new Parameter { ParameterGroup = ParameterGroupEqType, Value = "Трансформатор", Rang = 9 });
            ParameterDisconnector.Clone(new Parameter { ParameterGroup = ParameterGroupEqType, Value = "Разъединитель", Rang = 8 });
            ParameterEarthingSwitch.Clone(new Parameter { ParameterGroup = ParameterGroupEqType, Value = "Заземлитель", Rang = 7 });

            ParameterBreaker
                .AddRequiredPreviousParameters(ParameterMainEquipment);

            ParameterDisconnector
                .AddRequiredPreviousParameters(ParameterMainEquipment);

            ParameterEarthingSwitch
                .AddRequiredPreviousParameters(ParameterMainEquipment);

            ParameterTransformer
                .AddRequiredPreviousParameters(ParameterMainEquipment)
                .AddRequiredPreviousParameters(ParameterPartTransformer);

            #endregion

            #region Составные части основоного оборудования

            ParameterPartDrive.Clone(new Parameter { ParameterGroup = ParameterGroupPartType, Value = "Привод" });
            ParameterPartTransformer.Clone(new Parameter { ParameterGroup = ParameterGroupPartType, Value = "Трансформатор" });
            ParameterPartTransformersCurrentBlock.Clone(new Parameter { ParameterGroup = ParameterGroupPartType, Value = "Блок трансформаторов тока" });
            ParameterPartTransformersVoltageBlock.Clone(new Parameter { ParameterGroup = ParameterGroupPartType, Value = "Блок катушек трансформатора напряжения" });

            ParameterPartDrive.AddRequiredPreviousParameters(ParameterProductParts);
            ParameterPartTransformer.AddRequiredPreviousParameters(ParameterProductParts);
            ParameterPartTransformersCurrentBlock.AddRequiredPreviousParameters(ParameterProductParts);
            ParameterPartTransformersVoltageBlock.AddRequiredPreviousParameters(ParameterProductParts);

            #endregion

            #region Тип привода

            ParameterDrivePem.Clone(new Parameter { ParameterGroup = ParameterGroupDrives, Value = "Привод ПЭМ" });
            ParameterDrivePPrK.Clone(new Parameter { ParameterGroup = ParameterGroupDrives, Value = "Привод ППрК" });
            ParameterDrivePPV.Clone(new Parameter { ParameterGroup = ParameterGroupDrives, Value = "Привод ППВ" });
            ParameterDriveDisconnector.Clone(new Parameter { ParameterGroup = ParameterGroupDrives, Value = "Привод разъединителя/заземлителя" });

            ParameterDrivePem.AddRequiredPreviousParameters(ParameterPartDrive);
            ParameterDrivePPrK.AddRequiredPreviousParameters(ParameterPartDrive);
            ParameterDrivePPV.AddRequiredPreviousParameters(ParameterPartDrive);
            ParameterDriveDisconnector.AddRequiredPreviousParameters(ParameterPartDrive);

            #endregion

            #region Характеристики привода выключателя

            #region Токовые расцепители

            ParameterDrivesCurrentDiscNo.Clone(new Parameter { ParameterGroup = ParameterGroupDrivesCurrentDisconnectors, Value = "нет" });
            ParameterDrivesCurrentDisc3A.Clone(new Parameter { ParameterGroup = ParameterGroupDrivesCurrentDisconnectors, Value = "на 3 А" });
            ParameterDrivesCurrentDisc5A.Clone(new Parameter { ParameterGroup = ParameterGroupDrivesCurrentDisconnectors, Value = "на 5 А" });

            ParameterDrivesCurrentDiscNo.AddRequiredPreviousParameters(ParameterDrivePPrK);
            ParameterDrivesCurrentDisc3A.AddRequiredPreviousParameters(ParameterDrivePPrK);
            ParameterDrivesCurrentDisc5A.AddRequiredPreviousParameters(ParameterDrivePPrK);

            #endregion

            #region Напряжение двигателя завода пружин

            ParameterDrivesVoltage400V.Clone(new Parameter { ParameterGroup = ParameterGroupDrivesVoltage, Value = "~400 В (3ф. звезда)" });
            ParameterDrivesVoltage230V.Clone(new Parameter { ParameterGroup = ParameterGroupDrivesVoltage, Value = "~230 В (3ф. треугольник)" });
            ParameterDrivesVoltage220V.Clone(new Parameter { ParameterGroup = ParameterGroupDrivesVoltage, Value = "~/=220 В (1ф.)" });
            ParameterDrivesVoltage110Vpost.Clone(new Parameter { ParameterGroup = ParameterGroupDrivesVoltage, Value = "=110 В (1ф.)" });
            ParameterDrivesVoltage220Vpost.Clone(new Parameter { ParameterGroup = ParameterGroupDrivesVoltage, Value = "=220 В (1ф.)" });
            ParameterDrivesVoltage230Vperem.Clone(new Parameter { ParameterGroup = ParameterGroupDrivesVoltage, Value = "~230 В (1ф.)" });

            ParameterDrivesVoltage400V.AddRequiredPreviousParameters(ParameterDrivePPrK);
            ParameterDrivesVoltage230V.AddRequiredPreviousParameters(ParameterDrivePPrK);
            ParameterDrivesVoltage220V.AddRequiredPreviousParameters(ParameterDrivePPrK);
            ParameterDrivesVoltage110Vpost.AddRequiredPreviousParameters(ParameterDrivePPrK)
                                          .AddRequiredPreviousParameters(ParameterDrivePPV);
            ParameterDrivesVoltage220Vpost.AddRequiredPreviousParameters(ParameterDrivePPV);
            ParameterDrivesVoltage230Vperem.AddRequiredPreviousParameters(ParameterDrivePPV);

            #endregion

            #region Напряжение цепей управления

            ParameterControlCircuitVoltage110Vpost.Clone(new Parameter { ParameterGroup = ParameterGroupControlCircuitVoltage, Value = "= 110 В" });
            ParameterControlCircuitVoltage220Vpost.Clone(new Parameter { ParameterGroup = ParameterGroupControlCircuitVoltage, Value = "= 220 В" });
            ParameterControlCircuitVoltage220Vperem.Clone(new Parameter { ParameterGroup = ParameterGroupControlCircuitVoltage, Value = "~ 220 В" });

            ParameterControlCircuitVoltage110Vpost
                .AddRequiredPreviousParameters(ParameterDrivePPrK)
                .AddRequiredPreviousParameters(ParameterDrivePPV);

            ParameterControlCircuitVoltage220Vpost
                .AddRequiredPreviousParameters(ParameterDriveDisconnectorTypeMotorn)
                .AddRequiredPreviousParameters(ParameterDrivePPrK)
                .AddRequiredPreviousParameters(ParameterDrivePPV);

            ParameterControlCircuitVoltage220Vperem
                .AddRequiredPreviousParameters(ParameterDriveDisconnectorTypeMotorn);

            #endregion

            #endregion

            #region Тип выключателя

            ParameterBreakerDeadTank.Clone(new Parameter { ParameterGroup = ParameterGroupBreakerType, Value = "Баковый" });
            ParameterBreakerLiveTank.Clone(new Parameter { ParameterGroup = ParameterGroupBreakerType, Value = "Колонковый" });

            ParameterBreakerDeadTank.AddRequiredPreviousParameters(ParameterBreaker);
            ParameterBreakerLiveTank.AddRequiredPreviousParameters(ParameterBreaker);

            #endregion

            #region Тип трансформатора

            ParameterTransformerCurrent.Clone(new Parameter { ParameterGroup = ParameterGroupTransformatorType, Value = "Тока" });
            ParameterTransformerVoltage.Clone(new Parameter { ParameterGroup = ParameterGroupTransformatorType, Value = "Напряжения" });

            ParameterTransformerCurrent.AddRequiredPreviousParameters(ParameterTransformer);
            ParameterTransformerVoltage.AddRequiredPreviousParameters(ParameterTransformer, ParameterMainEquipment);

            #endregion

            #region Тип трансформатора тока

            ParameterTransformerBuiltOut.Clone(new Parameter { ParameterGroup = ParameterGroupTransformatorCurrentType, Value = "Отдельностоящий" });
            ParameterTransformerBuiltIn.Clone(new Parameter { ParameterGroup = ParameterGroupTransformatorCurrentType, Value = "Встроенный" });

            ParameterTransformerBuiltOut.AddRequiredPreviousParameters(ParameterTransformerCurrent, ParameterMainEquipment);
            ParameterTransformerBuiltIn.AddRequiredPreviousParameters(ParameterTransformerCurrent, ParameterPartTransformer);

            #endregion

            #region Номинальное напряжение

            ParameterVoltage35kV.Clone(new Parameter { ParameterGroup = ParameterGroupVoltage, Value = "35 кВ" });
            ParameterVoltage110kV.Clone(new Parameter { ParameterGroup = ParameterGroupVoltage, Value = "110 кВ" });
            ParameterVoltage220kV.Clone(new Parameter { ParameterGroup = ParameterGroupVoltage, Value = "220 кВ" });
            ParameterVoltage330kV.Clone(new Parameter { ParameterGroup = ParameterGroupVoltage, Value = "330 кВ" });
            ParameterVoltage500kV.Clone(new Parameter { ParameterGroup = ParameterGroupVoltage, Value = "500 кВ" });

            #region Шеф-монтаж

            ParameterVoltage35kV
                .AddRequiredPreviousParameters(ParameterSupervisionDeadTankBreaker)
                .AddRequiredPreviousParameters(ParameterSupervisionLiveTankBreaker)
                .AddRequiredPreviousParameters(ParameterSupervisionTransformerCurrent);

            ParameterVoltage110kV
                .AddRequiredPreviousParameters(ParameterSupervisionDeadTankBreaker)
                .AddRequiredPreviousParameters(ParameterSupervisionLiveTankBreaker)
                .AddRequiredPreviousParameters(ParameterSupervisionTransformerVoltage)
                .AddRequiredPreviousParameters(ParameterSupervisionTransformerCurrent);

            ParameterVoltage220kV
                .AddRequiredPreviousParameters(ParameterSupervisionDeadTankBreaker)
                .AddRequiredPreviousParameters(ParameterSupervisionLiveTankBreaker)
                .AddRequiredPreviousParameters(ParameterSupervisionTransformerVoltage)
                .AddRequiredPreviousParameters(ParameterSupervisionTransformerCurrent);

            ParameterVoltage330kV
                .AddRequiredPreviousParameters(ParameterSupervisionLiveTankBreaker);

            ParameterVoltage500kV
                .AddRequiredPreviousParameters(ParameterSupervisionLiveTankBreaker);


            #endregion

            ParameterVoltage35kV
                .AddRequiredPreviousParameters(ParameterBreaker)
                .AddRequiredPreviousParameters(ParameterTransformerCurrent);

            ParameterVoltage110kV
                .AddRequiredPreviousParameters(ParameterBreaker)
                .AddRequiredPreviousParameters(ParameterTransformer)
                .AddRequiredPreviousParameters(ParameterDisconnector)
                .AddRequiredPreviousParameters(ParameterEarthingSwitch);

            ParameterVoltage220kV
                .AddRequiredPreviousParameters(ParameterBreaker)
                .AddRequiredPreviousParameters(ParameterTransformer)
                .AddRequiredPreviousParameters(ParameterDisconnector)
                .AddRequiredPreviousParameters(ParameterEarthingSwitch);

            ParameterVoltage330kV
                .AddRequiredPreviousParameters(ParameterBreakerLiveTank);

            ParameterVoltage500kV
                .AddRequiredPreviousParameters(ParameterBreakerLiveTank);

            #endregion

            #region Номинальный ток

            ParameterCurrent0630.Clone(new Parameter { ParameterGroup = ParameterGroupCurrent, Value = "630 А" });
            ParameterCurrent1000.Clone(new Parameter { ParameterGroup = ParameterGroupCurrent, Value = "1000 А" });
            ParameterCurrent2500.Clone(new Parameter { ParameterGroup = ParameterGroupCurrent, Value = "2500 А" });
            ParameterCurrent3150.Clone(new Parameter { ParameterGroup = ParameterGroupCurrent, Value = "3150 А" });
            ParameterCurrent4000.Clone(new Parameter { ParameterGroup = ParameterGroupCurrent, Value = "4000 А" });
            ParameterCurrent1250.Clone(new Parameter { ParameterGroup = ParameterGroupCurrent, Value = "1250 А" });
            ParameterCurrent1600.Clone(new Parameter { ParameterGroup = ParameterGroupCurrent, Value = "1600 А" });

            ParameterCurrent0630
                .AddRequiredPreviousParameters(ParameterBreakerDeadTank, ParameterVoltage35kV);

            ParameterCurrent1000
                .AddRequiredPreviousParameters(ParameterBreakerDeadTank, ParameterVoltage35kV);

            ParameterCurrent2500
                .AddRequiredPreviousParameters(ParameterDisconnector)
                .AddRequiredPreviousParameters(ParameterBreakerLiveTank, ParameterVoltage110kV, ParameterPolimer)
                .AddRequiredPreviousParameters(ParameterBreakerDeadTank, ParameterVoltage110kV)
                .AddRequiredPreviousParameters(ParameterBreaker, ParameterVoltage220kV, ParameterBreakerDeadTank);

            ParameterCurrent3150
                .AddRequiredPreviousParameters(ParameterBreakerLiveTank, ParameterVoltage35kV)
                .AddRequiredPreviousParameters(ParameterBreaker, ParameterVoltage110kV, ParameterFarfor)
                .AddRequiredPreviousParameters(ParameterBreaker, ParameterVoltage220kV);

            ParameterCurrent4000.AddRequiredPreviousParameters(ParameterBreaker, ParameterVoltage500kV);

            ParameterCurrent1250
                .AddRequiredPreviousParameters(ParameterDisconnector);

            ParameterCurrent1600
                .AddRequiredPreviousParameters(ParameterDisconnector);


            #endregion

            #region Номинальный ток отключения

            ParameterCurrentBreaking12kA.Clone(new Parameter { ParameterGroup = ParameterGroupCurrentBreaking, Value = "12,5 кА" });
            ParameterCurrentBreaking40kA.Clone(new Parameter { ParameterGroup = ParameterGroupCurrentBreaking, Value = "40 кА" });
            ParameterCurrentBreaking50kA.Clone(new Parameter { ParameterGroup = ParameterGroupCurrentBreaking, Value = "50 кА" });

            ParameterCurrentBreaking12kA
                .AddRequiredPreviousParameters(ParameterBreakerDeadTank, ParameterVoltage35kV);

            ParameterCurrentBreaking40kA
                .AddRequiredPreviousParameters(ParameterBreaker, ParameterVoltage110kV)
                .AddRequiredPreviousParameters(ParameterBreakerLiveTank, ParameterVoltage330kV)
                .AddRequiredPreviousParameters(ParameterBreakerLiveTank, ParameterVoltage500kV);

            ParameterCurrentBreaking50kA
                .AddRequiredPreviousParameters(ParameterBreakerDeadTank, ParameterVoltage110kV)
                .AddRequiredPreviousParameters(ParameterBreakerDeadTank, ParameterVoltage220kV)
                .AddRequiredPreviousParameters(ParameterBreakerLiveTank, ParameterVoltage330kV)
                .AddRequiredPreviousParameters(ParameterBreakerLiveTank, ParameterVoltage500kV)
                .AddRequiredPreviousParameters(ParameterBreakerLiveTank, ParameterVoltage35kV);

            #endregion

            #region Ток термической стойкости

            ParameterIterm25kA.Clone(new Parameter { ParameterGroup = ParameterGroupIterm, Value = "25 кА" });
            ParameterIterm40kA.Clone(new Parameter { ParameterGroup = ParameterGroupIterm, Value = "40 кА" });
            ParameterIterm50kA.Clone(new Parameter { ParameterGroup = ParameterGroupIterm, Value = "50 кА" });

            ParameterIterm25kA
                .AddRequiredPreviousParameters(ParameterDisconnector, ParameterCurrent1250);

            ParameterIterm40kA
                .AddRequiredPreviousParameters(ParameterEarthingSwitch)
                .AddRequiredPreviousParameters(ParameterDisconnector, ParameterCurrent1600)
                .AddRequiredPreviousParameters(ParameterDisconnector, ParameterCurrent2500);

            ParameterIterm50kA
                .AddRequiredPreviousParameters(ParameterEarthingSwitch)
                .AddRequiredPreviousParameters(ParameterDisconnector, ParameterCurrent1600)
                .AddRequiredPreviousParameters(ParameterDisconnector, ParameterCurrent2500);

            #endregion

            #region Климматическое исполнение

            ParameterClimatT1.Clone(new Parameter { ParameterGroup = ParameterGroupClimat, Value = "T1 (от +50 до -40)", Rang = -10 });
            ParameterClimatU1Z.Clone(new Parameter { ParameterGroup = ParameterGroupClimat, Value = "У1* (от +40 до -40)" });
            ParameterClimatUhl1Z.Clone(new Parameter { ParameterGroup = ParameterGroupClimat, Value = "УХЛ1* (от +40 до -55)", Rang = 10 });
            ParameterClimatUhl1.Clone(new Parameter { ParameterGroup = ParameterGroupClimat, Value = "УХЛ1 (от +40 до -60)" });
            ParameterClimatU1.Clone(new Parameter { ParameterGroup = ParameterGroupClimat, Value = "У1 (от +40 до -45)", Rang = 8 });
            ParameterClimatHl1Z.Clone(new Parameter { ParameterGroup = ParameterGroupClimat, Value = "ХЛ1* (от +40 до -55)" });
            ParameterClimatHl1.Clone(new Parameter { ParameterGroup = ParameterGroupClimat, Value = "ХЛ1 (от +40 до -60)" });

            ParameterClimatT1
                .AddRequiredPreviousParameters(ParameterTransformerVoltage)
                .AddRequiredPreviousParameters(ParameterBreakerDeadTank, ParameterVoltage35kV)
                .AddRequiredPreviousParameters(ParameterBreakerLiveTank, ParameterVoltage35kV)
                .AddRequiredPreviousParameters(ParameterBreakerLiveTank, ParameterVoltage110kV)
                .AddRequiredPreviousParameters(ParameterBreakerLiveTank, ParameterVoltage220kV)
                .AddRequiredPreviousParameters(ParameterBreakerLiveTank, ParameterVoltage330kV)
                .AddRequiredPreviousParameters(ParameterBreakerLiveTank, ParameterVoltage500kV);

            ParameterClimatU1Z
                .AddRequiredPreviousParameters(ParameterBreakerDeadTank, ParameterVoltage110kV, ParameterCurrentBreaking40kA);

            ParameterClimatUhl1Z
                .AddRequiredPreviousParameters(ParameterBreakerDeadTank, ParameterVoltage110kV, ParameterCurrentBreaking40kA);

            ParameterClimatUhl1
                .AddRequiredPreviousParameters(ParameterTransformerCurrent, ParameterTransformerBuiltOut, ParameterVoltage35kV)
                .AddRequiredPreviousParameters(ParameterTransformerCurrent, ParameterTransformerBuiltOut, ParameterVoltage110kV)
                .AddRequiredPreviousParameters(ParameterTransformerCurrent, ParameterTransformerBuiltOut, ParameterVoltage220kV)
                .AddRequiredPreviousParameters(ParameterBreakerDeadTank, ParameterVoltage35kV)
                .AddRequiredPreviousParameters(ParameterBreakerDeadTank, ParameterVoltage110kV)
                .AddRequiredPreviousParameters(ParameterBreakerDeadTank, ParameterVoltage220kV);

            ParameterClimatU1
                .AddRequiredPreviousParameters(ParameterTransformerVoltage)
                .AddRequiredPreviousParameters(ParameterTransformerCurrent, ParameterTransformerBuiltOut, ParameterVoltage110kV)
                .AddRequiredPreviousParameters(ParameterTransformerCurrent, ParameterTransformerBuiltOut, ParameterVoltage220kV)
                .AddRequiredPreviousParameters(ParameterBreakerLiveTank, ParameterVoltage35kV)
                .AddRequiredPreviousParameters(ParameterBreakerLiveTank, ParameterVoltage110kV)
                .AddRequiredPreviousParameters(ParameterBreakerLiveTank, ParameterVoltage220kV)
                .AddRequiredPreviousParameters(ParameterBreakerLiveTank, ParameterVoltage330kV)
                .AddRequiredPreviousParameters(ParameterBreakerLiveTank, ParameterVoltage500kV);

            ParameterClimatHl1Z
                .AddRequiredPreviousParameters(ParameterTransformerVoltage, ParameterVoltage110kV)
                .AddRequiredPreviousParameters(ParameterBreakerLiveTank, ParameterVoltage35kV)
                .AddRequiredPreviousParameters(ParameterBreakerLiveTank, ParameterVoltage110kV)
                .AddRequiredPreviousParameters(ParameterBreakerLiveTank, ParameterVoltage220kV)
                .AddRequiredPreviousParameters(ParameterBreakerLiveTank, ParameterVoltage330kV)
                .AddRequiredPreviousParameters(ParameterBreakerLiveTank, ParameterVoltage500kV);

            ParameterClimatHl1
                .AddRequiredPreviousParameters(ParameterTransformerCurrent, ParameterTransformerBuiltOut, ParameterVoltage110kV)
                .AddRequiredPreviousParameters(ParameterTransformerCurrent, ParameterTransformerBuiltOut, ParameterVoltage220kV)
                .AddRequiredPreviousParameters(ParameterTransformerVoltage);

            #endregion

            #region Изоляция

            #region Тип изоляции

            ParameterFarfor.Clone(new Parameter { ParameterGroup = ParameterGroupIsolationMaterial, Value = "Фарфор", Rang = 10 });
            ParameterPolimer.Clone(new Parameter { ParameterGroup = ParameterGroupIsolationMaterial, Value = "Полимер", Rang = 9 });

            ParameterFarfor.AddRequiredPreviousParameters(ParameterBreaker)
                           .AddRequiredPreviousParameters(ParameterDisconnector)
                           .AddRequiredPreviousParameters(ParameterEarthingSwitch)
                           .AddRequiredPreviousParameters(ParameterTransformerVoltage)
                           .AddRequiredPreviousParameters(ParameterTransformerCurrent, ParameterTransformerBuiltOut);

            ParameterPolimer.AddRequiredPreviousParameters(ParameterBreaker)
                            .AddRequiredPreviousParameters(ParameterDisconnector)
                            .AddRequiredPreviousParameters(ParameterEarthingSwitch)
                            .AddRequiredPreviousParameters(ParameterTransformerVoltage)
                            .AddRequiredPreviousParameters(ParameterTransformerCurrent, ParameterTransformerBuiltOut);

            #endregion

            #region Длина пути утечки

            ParameterDpu2.Clone(new Parameter { ParameterGroup = ParameterGroupIsolation, Value = "II*" });
            ParameterDpu3.Clone(new Parameter { ParameterGroup = ParameterGroupIsolation, Value = "III" });
            ParameterDpu4.Clone(new Parameter { ParameterGroup = ParameterGroupIsolation, Value = "IV" });

            ParameterDpu2.AddRequiredPreviousParameters(ParameterFarfor);
            ParameterDpu3.AddRequiredPreviousParameters(ParameterFarfor);
            ParameterDpu4.AddRequiredPreviousParameters(ParameterFarfor)
                         .AddRequiredPreviousParameters(ParameterPolimer);

            #endregion

            #region Цвет изоляции

            ParameterIsolationColorGrey.Clone(new Parameter { ParameterGroup = ParameterGroupIsolationColor, Value = "Светло-серый", Rang = 10 });
            ParameterIsolationColorBrown.Clone(new Parameter { ParameterGroup = ParameterGroupIsolationColor, Value = "Коричневый", Rang = 9 });

            ParameterIsolationColorGrey
                .AddRequiredPreviousParameters(ParameterFarfor)
                .AddRequiredPreviousParameters(ParameterPolimer);

            ParameterIsolationColorBrown
                .AddRequiredPreviousParameters(ParameterFarfor);

            #endregion


            #endregion

            #region Трансформаторы тока

            #region Первичные токи отпаек ТТ

            ParameterTransformerPrimaryCurrentRow1.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerPrimaryCurrentRow, Value = "600-400-300-200 А" });
            ParameterTransformerPrimaryCurrentRow2.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerPrimaryCurrentRow, Value = "2000-1500-1000-500 А" });

            ParameterTransformerPrimaryCurrentRow1.AddRequiredPreviousParameters(ParameterTransformerBuiltIn);
            ParameterTransformerPrimaryCurrentRow2.AddRequiredPreviousParameters(ParameterTransformerBuiltIn);

            #endregion

            #region Вторичный ток ТТ

            ParameterTransformerSecondaryCurrent1.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerSecondaryCurrent, Value = "1 А" });
            ParameterTransformerSecondaryCurrent5.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerSecondaryCurrent, Value = "5 А" });

            ParameterTransformerSecondaryCurrent1.AddRequiredPreviousParameters(ParameterTransformerBuiltIn);
            ParameterTransformerSecondaryCurrent5.AddRequiredPreviousParameters(ParameterTransformerBuiltIn);

            #endregion

            #region Класс точности ТТ

            ParameterAccuracy02.Clone(new Parameter { ParameterGroup = ParameterGroupAccuracy, Value = "0,2" });
            ParameterAccuracy02S.Clone(new Parameter { ParameterGroup = ParameterGroupAccuracy, Value = "0,2S" });
            ParameterAccuracy05.Clone(new Parameter { ParameterGroup = ParameterGroupAccuracy, Value = "0,5" });
            ParameterAccuracy05S.Clone(new Parameter { ParameterGroup = ParameterGroupAccuracy, Value = "0,5S" });
            ParameterAccuracy05P.Clone(new Parameter { ParameterGroup = ParameterGroupAccuracy, Value = "5P" });
            ParameterAccuracy10P.Clone(new Parameter { ParameterGroup = ParameterGroupAccuracy, Value = "10P" });

            ParameterAccuracy02.AddRequiredPreviousParameters(ParameterTransformerBuiltIn);
            ParameterAccuracy02S.AddRequiredPreviousParameters(ParameterTransformerBuiltIn);
            ParameterAccuracy05.AddRequiredPreviousParameters(ParameterTransformerBuiltIn);
            ParameterAccuracy05S.AddRequiredPreviousParameters(ParameterTransformerBuiltIn);
            ParameterAccuracy05P.AddRequiredPreviousParameters(ParameterTransformerBuiltIn);
            ParameterAccuracy10P.AddRequiredPreviousParameters(ParameterTransformerBuiltIn);

            #endregion

            #region Нагрузка ТТ

            ParameterTransformerLoad05.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerLoad, Value = "5 ВА" });
            ParameterTransformerLoad10.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerLoad, Value = "10 ВА" });
            ParameterTransformerLoad15.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerLoad, Value = "15 ВА" });
            ParameterTransformerLoad20.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerLoad, Value = "20 ВА" });
            ParameterTransformerLoad25.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerLoad, Value = "25 ВА" });
            ParameterTransformerLoad30.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerLoad, Value = "30 ВА" });
            ParameterTransformerLoad35.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerLoad, Value = "35 ВА" });
            ParameterTransformerLoad40.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerLoad, Value = "40 ВА" });
            ParameterTransformerLoad45.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerLoad, Value = "45 ВА" });
            ParameterTransformerLoad50.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerLoad, Value = "50 ВА" });
            ParameterTransformerLoad55.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerLoad, Value = "55 ВА" });
            ParameterTransformerLoad60.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerLoad, Value = "60 ВА" });

            ParameterTransformerLoad05.AddRequiredPreviousParameters(ParameterTransformerBuiltIn);
            ParameterTransformerLoad10.AddRequiredPreviousParameters(ParameterTransformerBuiltIn);
            ParameterTransformerLoad15.AddRequiredPreviousParameters(ParameterTransformerBuiltIn);
            ParameterTransformerLoad20.AddRequiredPreviousParameters(ParameterTransformerBuiltIn);
            ParameterTransformerLoad25.AddRequiredPreviousParameters(ParameterTransformerBuiltIn);
            ParameterTransformerLoad30.AddRequiredPreviousParameters(ParameterTransformerBuiltIn);
            ParameterTransformerLoad35.AddRequiredPreviousParameters(ParameterTransformerBuiltIn);
            ParameterTransformerLoad40.AddRequiredPreviousParameters(ParameterTransformerBuiltIn);
            ParameterTransformerLoad45.AddRequiredPreviousParameters(ParameterTransformerBuiltIn);
            ParameterTransformerLoad50.AddRequiredPreviousParameters(ParameterTransformerBuiltIn);
            ParameterTransformerLoad55.AddRequiredPreviousParameters(ParameterTransformerBuiltIn);
            ParameterTransformerLoad60.AddRequiredPreviousParameters(ParameterTransformerBuiltIn);

            #endregion

            #region Коэффициент предельной кратности ТТ

            ParameterTransformerLimitMultiplicity05.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerLimitMultiplicity, Value = "5" });
            ParameterTransformerLimitMultiplicity10.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerLimitMultiplicity, Value = "10" });
            ParameterTransformerLimitMultiplicity15.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerLimitMultiplicity, Value = "15" });
            ParameterTransformerLimitMultiplicity20.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerLimitMultiplicity, Value = "20" });
            ParameterTransformerLimitMultiplicity25.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerLimitMultiplicity, Value = "25" });
            ParameterTransformerLimitMultiplicity30.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerLimitMultiplicity, Value = "30" });
            ParameterTransformerLimitMultiplicity35.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerLimitMultiplicity, Value = "35" });
            ParameterTransformerLimitMultiplicity40.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerLimitMultiplicity, Value = "40" });
            ParameterTransformerLimitMultiplicity45.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerLimitMultiplicity, Value = "45" });
            ParameterTransformerLimitMultiplicity50.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerLimitMultiplicity, Value = "50" });
            ParameterTransformerLimitMultiplicity55.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerLimitMultiplicity, Value = "55" });
            ParameterTransformerLimitMultiplicity60.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerLimitMultiplicity, Value = "60" });

            ParameterTransformerLimitMultiplicity05.AddRequiredPreviousParameters(ParameterAccuracy05P).AddRequiredPreviousParameters(ParameterAccuracy10P);
            ParameterTransformerLimitMultiplicity10.AddRequiredPreviousParameters(ParameterAccuracy05P).AddRequiredPreviousParameters(ParameterAccuracy10P);
            ParameterTransformerLimitMultiplicity15.AddRequiredPreviousParameters(ParameterAccuracy05P).AddRequiredPreviousParameters(ParameterAccuracy10P);
            ParameterTransformerLimitMultiplicity20.AddRequiredPreviousParameters(ParameterAccuracy05P).AddRequiredPreviousParameters(ParameterAccuracy10P);
            ParameterTransformerLimitMultiplicity25.AddRequiredPreviousParameters(ParameterAccuracy05P).AddRequiredPreviousParameters(ParameterAccuracy10P);
            ParameterTransformerLimitMultiplicity30.AddRequiredPreviousParameters(ParameterAccuracy05P).AddRequiredPreviousParameters(ParameterAccuracy10P);
            ParameterTransformerLimitMultiplicity35.AddRequiredPreviousParameters(ParameterAccuracy05P).AddRequiredPreviousParameters(ParameterAccuracy10P);
            ParameterTransformerLimitMultiplicity40.AddRequiredPreviousParameters(ParameterAccuracy05P).AddRequiredPreviousParameters(ParameterAccuracy10P);
            ParameterTransformerLimitMultiplicity45.AddRequiredPreviousParameters(ParameterAccuracy05P).AddRequiredPreviousParameters(ParameterAccuracy10P);
            ParameterTransformerLimitMultiplicity50.AddRequiredPreviousParameters(ParameterAccuracy05P).AddRequiredPreviousParameters(ParameterAccuracy10P);
            ParameterTransformerLimitMultiplicity55.AddRequiredPreviousParameters(ParameterAccuracy05P).AddRequiredPreviousParameters(ParameterAccuracy10P);
            ParameterTransformerLimitMultiplicity60.AddRequiredPreviousParameters(ParameterAccuracy05P).AddRequiredPreviousParameters(ParameterAccuracy10P);

            #endregion

            #region Коэффициент безопасности ТТ

            ParameterTransformerSafetyK02.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerSafetyK, Value = "2" });
            ParameterTransformerSafetyK04.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerSafetyK, Value = "4" });
            ParameterTransformerSafetyK06.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerSafetyK, Value = "6" });
            ParameterTransformerSafetyK08.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerSafetyK, Value = "8" });
            ParameterTransformerSafetyK10.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerSafetyK, Value = "10" });
            ParameterTransformerSafetyK12.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerSafetyK, Value = "12" });
            ParameterTransformerSafetyK14.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerSafetyK, Value = "14" });
            ParameterTransformerSafetyK16.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerSafetyK, Value = "16" });
            ParameterTransformerSafetyK18.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerSafetyK, Value = "18" });
            ParameterTransformerSafetyK20.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerSafetyK, Value = "20" });
            ParameterTransformerSafetyK22.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerSafetyK, Value = "22" });
            ParameterTransformerSafetyK24.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerSafetyK, Value = "24" });

            ParameterTransformerSafetyK02.AddRequiredPreviousParameters(ParameterAccuracy02).AddRequiredPreviousParameters(ParameterAccuracy02S).AddRequiredPreviousParameters(ParameterAccuracy05).AddRequiredPreviousParameters(ParameterAccuracy05S);
            ParameterTransformerSafetyK04.AddRequiredPreviousParameters(ParameterAccuracy02).AddRequiredPreviousParameters(ParameterAccuracy02S).AddRequiredPreviousParameters(ParameterAccuracy05).AddRequiredPreviousParameters(ParameterAccuracy05S);
            ParameterTransformerSafetyK06.AddRequiredPreviousParameters(ParameterAccuracy02).AddRequiredPreviousParameters(ParameterAccuracy02S).AddRequiredPreviousParameters(ParameterAccuracy05).AddRequiredPreviousParameters(ParameterAccuracy05S);
            ParameterTransformerSafetyK08.AddRequiredPreviousParameters(ParameterAccuracy02).AddRequiredPreviousParameters(ParameterAccuracy02S).AddRequiredPreviousParameters(ParameterAccuracy05).AddRequiredPreviousParameters(ParameterAccuracy05S);
            ParameterTransformerSafetyK10.AddRequiredPreviousParameters(ParameterAccuracy02).AddRequiredPreviousParameters(ParameterAccuracy02S).AddRequiredPreviousParameters(ParameterAccuracy05).AddRequiredPreviousParameters(ParameterAccuracy05S);
            ParameterTransformerSafetyK12.AddRequiredPreviousParameters(ParameterAccuracy02).AddRequiredPreviousParameters(ParameterAccuracy02S).AddRequiredPreviousParameters(ParameterAccuracy05).AddRequiredPreviousParameters(ParameterAccuracy05S);
            ParameterTransformerSafetyK14.AddRequiredPreviousParameters(ParameterAccuracy02).AddRequiredPreviousParameters(ParameterAccuracy02S).AddRequiredPreviousParameters(ParameterAccuracy05).AddRequiredPreviousParameters(ParameterAccuracy05S);
            ParameterTransformerSafetyK16.AddRequiredPreviousParameters(ParameterAccuracy02).AddRequiredPreviousParameters(ParameterAccuracy02S).AddRequiredPreviousParameters(ParameterAccuracy05).AddRequiredPreviousParameters(ParameterAccuracy05S);
            ParameterTransformerSafetyK18.AddRequiredPreviousParameters(ParameterAccuracy02).AddRequiredPreviousParameters(ParameterAccuracy02S).AddRequiredPreviousParameters(ParameterAccuracy05).AddRequiredPreviousParameters(ParameterAccuracy05S);
            ParameterTransformerSafetyK20.AddRequiredPreviousParameters(ParameterAccuracy02).AddRequiredPreviousParameters(ParameterAccuracy02S).AddRequiredPreviousParameters(ParameterAccuracy05).AddRequiredPreviousParameters(ParameterAccuracy05S);
            ParameterTransformerSafetyK22.AddRequiredPreviousParameters(ParameterAccuracy02).AddRequiredPreviousParameters(ParameterAccuracy02S).AddRequiredPreviousParameters(ParameterAccuracy05).AddRequiredPreviousParameters(ParameterAccuracy05S);
            ParameterTransformerSafetyK24.AddRequiredPreviousParameters(ParameterAccuracy02).AddRequiredPreviousParameters(ParameterAccuracy02S).AddRequiredPreviousParameters(ParameterAccuracy05).AddRequiredPreviousParameters(ParameterAccuracy05S);

            #endregion

            #region Тип комплекта ТТ

            ParameterTransformersCurrentBlockTypeStandart.Clone(new Parameter { ParameterGroup = ParameterGroupTransformersCurrentBlockType, Value = "Стандартный", Rang = 10 });
            ParameterTransformersCurrentBlockTypeCustom.Clone(new Parameter { ParameterGroup = ParameterGroupTransformersCurrentBlockType, Value = "По заказу", Rang = 9 });

            ParameterTransformersCurrentBlockTypeStandart
                .AddRequiredPreviousParameters(ParameterTransformersBlockTargetTrg35)
                .AddRequiredPreviousParameters(ParameterTransformersBlockTargetTrg110)
                .AddRequiredPreviousParameters(ParameterTransformersBlockTargetTrg220)
                .AddRequiredPreviousParameters(ParameterTransformersBlockTargetVeb110)
                .AddRequiredPreviousParameters(ParameterTransformersBlockTargetVeb220)
                .AddRequiredPreviousParameters(ParameterTransformersBlockTargetVgb35);

            ParameterTransformersCurrentBlockTypeCustom
                .AddRequiredPreviousParameters(ParameterTransformersBlockTargetTrg35)
                .AddRequiredPreviousParameters(ParameterTransformersBlockTargetTrg110)
                .AddRequiredPreviousParameters(ParameterTransformersBlockTargetTrg220)
                .AddRequiredPreviousParameters(ParameterTransformersBlockTargetVeb110)
                .AddRequiredPreviousParameters(ParameterTransformersBlockTargetVeb220)
                .AddRequiredPreviousParameters(ParameterTransformersBlockTargetVgb35);

            #endregion

            #region Тип комплекта ТН

            ParameterTransformersVoltageBlockTypeStandart.Clone(new Parameter { ParameterGroup = ParameterGroupTransformersVoltageBlockType, Value = "Стандартный", Rang = 10 });
            ParameterTransformersVoltageBlockTypeCustom.Clone(new Parameter { ParameterGroup = ParameterGroupTransformersVoltageBlockType, Value = "По заказу", Rang = 9 });

            ParameterTransformersVoltageBlockTypeStandart
                .AddRequiredPreviousParameters(ParameterPartTransformersVoltageBlock);

            ParameterTransformersVoltageBlockTypeCustom
                .AddRequiredPreviousParameters(ParameterPartTransformersVoltageBlock);

            #endregion

            #region Количество ТТ в комплекте

            ParameterTransformersInBlockAmount0.Clone(new Parameter { ParameterGroup = ParameterGroupTransformersInBlockAmount, Value = "0" });
            ParameterTransformersInBlockAmount1.Clone(new Parameter { ParameterGroup = ParameterGroupTransformersInBlockAmount, Value = "1" });
            ParameterTransformersInBlockAmount2.Clone(new Parameter { ParameterGroup = ParameterGroupTransformersInBlockAmount, Value = "2" });
            ParameterTransformersInBlockAmount3.Clone(new Parameter { ParameterGroup = ParameterGroupTransformersInBlockAmount, Value = "3" });
            ParameterTransformersInBlockAmount4.Clone(new Parameter { ParameterGroup = ParameterGroupTransformersInBlockAmount, Value = "4" });
            ParameterTransformersInBlockAmount5.Clone(new Parameter { ParameterGroup = ParameterGroupTransformersInBlockAmount, Value = "5" });
            ParameterTransformersInBlockAmount6.Clone(new Parameter { ParameterGroup = ParameterGroupTransformersInBlockAmount, Value = "6" });
            ParameterTransformersInBlockAmount7.Clone(new Parameter { ParameterGroup = ParameterGroupTransformersInBlockAmount, Value = "7" });
            ParameterTransformersInBlockAmount8.Clone(new Parameter { ParameterGroup = ParameterGroupTransformersInBlockAmount, Value = "8" });

            ParameterTransformersInBlockAmount0
                .AddRequiredPreviousParameters(ParameterTransformersCurrentBlockTypeCustom);

            ParameterTransformersInBlockAmount1
                .AddRequiredPreviousParameters(ParameterTransformersCurrentBlockTypeCustom);

            ParameterTransformersInBlockAmount2
                .AddRequiredPreviousParameters(ParameterTransformersCurrentBlockTypeCustom);

            ParameterTransformersInBlockAmount3
                .AddRequiredPreviousParameters(ParameterTransformersCurrentBlockTypeCustom);

            ParameterTransformersInBlockAmount4
                .AddRequiredPreviousParameters(ParameterTransformersCurrentBlockTypeCustom);

            ParameterTransformersInBlockAmount5
                .AddRequiredPreviousParameters(ParameterTransformersCurrentBlockTypeCustom);

            ParameterTransformersInBlockAmount6
                .AddRequiredPreviousParameters(ParameterTransformersCurrentBlockTypeCustom);

            ParameterTransformersInBlockAmount7
                .AddRequiredPreviousParameters(ParameterTransformersCurrentBlockTypeCustom);

            ParameterTransformersInBlockAmount8
                .AddRequiredPreviousParameters(ParameterTransformersCurrentBlockTypeCustom);

            #endregion


            #region Стандартные комплекты ТТ

            ParameterTransformersBlockStandartVgb035Num1.Clone(new Parameter { ParameterGroup = ParameterGroupTransformersBlockStandartNumber, Value = "776-49 (300-200-150-100/5) (фарф.)" });
            ParameterTransformersBlockStandartVgb035Num2.Clone(new Parameter { ParameterGroup = ParameterGroupTransformersBlockStandartNumber, Value = "776-91 (600-400-300-200/5) (фарф.)" });
            ParameterTransformersBlockStandartVeb110Num1.Clone(new Parameter { ParameterGroup = ParameterGroupTransformersBlockStandartNumber, Value = "602-231 (300-200-150-100/5)" });
            ParameterTransformersBlockStandartVeb110Num2.Clone(new Parameter { ParameterGroup = ParameterGroupTransformersBlockStandartNumber, Value = "602-112 (600-400-300-200/5)" });
            ParameterTransformersBlockStandartVeb220Num1.Clone(new Parameter { ParameterGroup = ParameterGroupTransformersBlockStandartNumber, Value = "623-192 (2000-1500-1000-500/5)" });
            ParameterTransformersBlockStandartVeb220Num2.Clone(new Parameter { ParameterGroup = ParameterGroupTransformersBlockStandartNumber, Value = "623-194 (2000-1500-1000-500/1)" });
            ParameterTransformersBlockStandartEmpty.Clone(new Parameter { ParameterGroup = ParameterGroupTransformersBlockStandartNumber, Value = "пустой" });

            ParameterTransformersBlockStandartVgb035Num1
                .AddRequiredPreviousParameters(ParameterTransformersBlockTargetVgb35, ParameterTransformersCurrentBlockTypeStandart);
            ParameterTransformersBlockStandartVgb035Num2
                .AddRequiredPreviousParameters(ParameterTransformersBlockTargetVgb35, ParameterTransformersCurrentBlockTypeStandart);

            ParameterTransformersBlockStandartVeb110Num1
                .AddRequiredPreviousParameters(ParameterTransformersBlockTargetVeb110, ParameterTransformersCurrentBlockTypeStandart);
            ParameterTransformersBlockStandartVeb110Num2
                .AddRequiredPreviousParameters(ParameterTransformersBlockTargetVeb110, ParameterTransformersCurrentBlockTypeStandart);

            ParameterTransformersBlockStandartVeb220Num1
                .AddRequiredPreviousParameters(ParameterTransformersBlockTargetVeb220, ParameterTransformersCurrentBlockTypeStandart);
            ParameterTransformersBlockStandartVeb220Num2
                .AddRequiredPreviousParameters(ParameterTransformersBlockTargetVeb220, ParameterTransformersCurrentBlockTypeStandart);

            ParameterTransformersBlockStandartEmpty
                .AddRequiredPreviousParameters(ParameterTransformersBlockTargetVeb110, ParameterTransformersCurrentBlockTypeStandart);

            #endregion

            #region Назначение KТТ

            ParameterTransformersBlockTargetVgb35.Clone(new Parameter { ParameterGroup = ParameterGroupTransformersBlockTarget, Value = "Для ВГБ-35 (3 фазы)" });
            ParameterTransformersBlockTargetVeb110.Clone(new Parameter { ParameterGroup = ParameterGroupTransformersBlockTarget, Value = "Для ВЭБ-110 (3 фазы)" });
            ParameterTransformersBlockTargetVeb220.Clone(new Parameter { ParameterGroup = ParameterGroupTransformersBlockTarget, Value = "Для ВЭБ-220 (3 фазы)" });
            ParameterTransformersBlockTargetZng110.Clone(new Parameter { ParameterGroup = ParameterGroupTransformersBlockTarget, Value = "Для ЗНГ-110" });
            ParameterTransformersBlockTargetZng220.Clone(new Parameter { ParameterGroup = ParameterGroupTransformersBlockTarget, Value = "Для ЗНГ-220" });
            ParameterTransformersBlockTargetTrg35.Clone(new Parameter { ParameterGroup = ParameterGroupTransformersBlockTarget, Value = "Для ТРГ-35" });
            ParameterTransformersBlockTargetTrg110.Clone(new Parameter { ParameterGroup = ParameterGroupTransformersBlockTarget, Value = "Для ТРГ-110" });
            ParameterTransformersBlockTargetTrg220.Clone(new Parameter { ParameterGroup = ParameterGroupTransformersBlockTarget, Value = "Для ТРГ-220" });

            ParameterTransformersBlockTargetVgb35
                .AddRequiredPreviousParameters(ParameterPartTransformersCurrentBlock);

            ParameterTransformersBlockTargetVeb110
                .AddRequiredPreviousParameters(ParameterPartTransformersCurrentBlock);

            ParameterTransformersBlockTargetVeb220
                .AddRequiredPreviousParameters(ParameterPartTransformersCurrentBlock);

            ParameterTransformersBlockTargetTrg35
                .AddRequiredPreviousParameters(ParameterPartTransformersCurrentBlock);

            ParameterTransformersBlockTargetTrg110
                .AddRequiredPreviousParameters(ParameterPartTransformersCurrentBlock);

            ParameterTransformersBlockTargetTrg220
                .AddRequiredPreviousParameters(ParameterPartTransformersCurrentBlock);



            ParameterTransformersBlockTargetZng110
                .AddRequiredPreviousParameters(ParameterPartTransformersVoltageBlock);

            ParameterTransformersBlockTargetZng220
                .AddRequiredPreviousParameters(ParameterPartTransformersVoltageBlock);

            #endregion        

            #endregion

            #region Исполнение выключателя по полюсности

            ParameterBreakerPhases3.Clone(new Parameter { ParameterGroup = ParameterGroupBreakerPhases, Value = "Трехфазное", Rang = 10 });
            ParameterBreakerPhases1.Clone(new Parameter { ParameterGroup = ParameterGroupBreakerPhases, Value = "Однофазное" });

            ParameterBreakerPhases3.AddRequiredPreviousParameters(ParameterBreaker, ParameterVoltage110kV).AddRequiredPreviousParameters(ParameterBreaker, ParameterVoltage220kV);
            ParameterBreakerPhases1.AddRequiredPreviousParameters(ParameterBreaker, ParameterVoltage110kV).AddRequiredPreviousParameters(ParameterBreaker, ParameterVoltage220kV);

            #endregion

            #region Исполнение выключателя по количеству разрывов

            ParameterBreakerLiveTankBreaks1Razriv.Clone(new Parameter { ParameterGroup = ParameterGroupBreakerLiveTankBreaks, Value = "Одноразрывный" });

            ParameterBreakerLiveTankBreaks1Razriv.AddRequiredPreviousParameters(ParameterBreakerLiveTank, ParameterVoltage220kV);

            #endregion

            #region Напряжение обогрева полюсов

            ParameterBreakerHeatingVoltage400Zvezda.Clone(new Parameter { ParameterGroup = ParameterGroupBreakerHeaterVoltage, Value = "230/400 (3ф. звезда)" });
            ParameterBreakerHeatingVoltage230Treug.Clone(new Parameter { ParameterGroup = ParameterGroupBreakerHeaterVoltage, Value = "230 (3ф. треугольник)" });
            ParameterBreakerHeatingVoltage230Ff.Clone(new Parameter { ParameterGroup = ParameterGroupBreakerHeaterVoltage, Value = "230 (1ф. фаза-фаза)" });
            ParameterBreakerHeatingVoltage230Fn.Clone(new Parameter { ParameterGroup = ParameterGroupBreakerHeaterVoltage, Value = "230 (1ф. фаза-нейтраль)" });

            ParameterBreakerHeatingVoltage400Zvezda
                .AddRequiredPreviousParameters(ParameterBreakerDeadTank, ParameterVoltage110kV, ParameterClimatUhl1)
                .AddRequiredPreviousParameters(ParameterBreakerDeadTank, ParameterVoltage110kV, ParameterClimatUhl1Z)
                .AddRequiredPreviousParameters(ParameterBreakerDeadTank, ParameterVoltage220kV);

            ParameterBreakerHeatingVoltage230Treug
                .AddRequiredPreviousParameters(ParameterBreakerDeadTank, ParameterVoltage110kV, ParameterClimatUhl1)
                .AddRequiredPreviousParameters(ParameterBreakerDeadTank, ParameterVoltage110kV, ParameterClimatUhl1Z)
                .AddRequiredPreviousParameters(ParameterBreakerDeadTank, ParameterVoltage220kV);

            ParameterBreakerHeatingVoltage230Ff
                .AddRequiredPreviousParameters(ParameterBreakerDeadTank, ParameterVoltage110kV, ParameterClimatUhl1Z)
                .AddRequiredPreviousParameters(ParameterBreakerDeadTank, ParameterVoltage220kV);

            ParameterBreakerHeatingVoltage230Fn
                .AddRequiredPreviousParameters(ParameterBreakerDeadTank, ParameterVoltage110kV, ParameterClimatUhl1Z)
                .AddRequiredPreviousParameters(ParameterBreakerDeadTank, ParameterVoltage220kV);

            #endregion

            #region Исполнение по конструкции отключающего устройства ВГТ

            ParameterVgtOtklUstrOtkr.Clone(new Parameter { ParameterGroup = ParameterGroupVgtOtklUstr, Value = "Стандартное", Rang = 10 });
            ParameterVgtOtklUstrZakr.Clone(new Parameter { ParameterGroup = ParameterGroupVgtOtklUstr, Value = "Закрытое", Rang = 9 });

            ParameterVgtOtklUstrOtkr.AddRequiredPreviousParameters(ParameterBreakerLiveTank);
            ParameterVgtOtklUstrZakr.AddRequiredPreviousParameters(ParameterBreakerLiveTank, ParameterVoltage110kV);


            #endregion

            #region Исполнение ВГБ-35 по расстоянию

            ParameterVgbIspPoRastPrivodaStandrt.Clone(new Parameter { ParameterGroup = ParameterGroupVgbIspPoRastPrivoda, Value = "Стандартное", Rang = 10 }); ;
            ParameterVgbIspPoRastPrivodaSpec.Clone(new Parameter { ParameterGroup = ParameterGroupVgbIspPoRastPrivoda, Value = "Специальное", Rang = 9 }); ;

            ParameterVgbIspPoRastPrivodaStandrt.AddRequiredPreviousParameters(ParameterBreakerDeadTank, ParameterVoltage35kV);
            ParameterVgbIspPoRastPrivodaSpec.AddRequiredPreviousParameters(ParameterBreakerDeadTank, ParameterVoltage35kV);

            #endregion

            #region Исполнение привода ПЭМ

            ParameterVgbIspPem1.Clone(new Parameter { ParameterGroup = ParameterGroupVgbIspPem, Value = "1" });
            ParameterVgbIspPem2.Clone(new Parameter { ParameterGroup = ParameterGroupVgbIspPem, Value = "2" });
            ParameterVgbIspPem3.Clone(new Parameter { ParameterGroup = ParameterGroupVgbIspPem, Value = "3" });
            ParameterVgbIspPem4.Clone(new Parameter { ParameterGroup = ParameterGroupVgbIspPem, Value = "4" });

            ParameterVgbIspPem1.AddRequiredPreviousParameters(ParameterDrivePem);
            ParameterVgbIspPem2.AddRequiredPreviousParameters(ParameterDrivePem);
            ParameterVgbIspPem3.AddRequiredPreviousParameters(ParameterDrivePem);
            ParameterVgbIspPem4.AddRequiredPreviousParameters(ParameterDrivePem);

            #endregion

            #region ПЭМ цепи управления

            ParameterPemUnomUpr110Post.Clone(new Parameter { ParameterGroup = ParameterGroupPemUnomUpr, Value = "= 110 В" });
            ParameterPemUnomUpr220Post.Clone(new Parameter { ParameterGroup = ParameterGroupPemUnomUpr, Value = "= 220 В" });
            ParameterPemUnomUpr220Perem.Clone(new Parameter { ParameterGroup = ParameterGroupPemUnomUpr, Value = "~ 220 В" });

            ParameterPemUnomVkl.Clone(new Parameter { ParameterGroup = ParameterGroupPemUnomVkl, Value = "~ 220 В" });
            ParameterPemUnomOtkl.Clone(new Parameter { ParameterGroup = ParameterGroupPemUnomOtkl, Value = "= 220 В" });

            ParameterPemUnomYav220Perem.Clone(new Parameter { ParameterGroup = ParameterGroupPemUnomYav, Value = "~ 220 В" });
            ParameterPemUnomYav220Post.Clone(new Parameter { ParameterGroup = ParameterGroupPemUnomYav, Value = "= 220 В" });
            ParameterPemUnomYav110Post.Clone(new Parameter { ParameterGroup = ParameterGroupPemUnomYav, Value = "= 110 В" }); ;

            ParameterPemInomYaa3.Clone(new Parameter { ParameterGroup = ParameterGroupPemInomYaa, Value = "3 А" });
            ParameterPemInomYaa5.Clone(new Parameter { ParameterGroup = ParameterGroupPemInomYaa, Value = "5 А" });


            ParameterPemUnomUpr110Post
                .AddRequiredPreviousParameters(ParameterVgbIspPem1)
                .AddRequiredPreviousParameters(ParameterVgbIspPem4);

            ParameterPemUnomUpr220Post
                .AddRequiredPreviousParameters(ParameterVgbIspPem1)
                .AddRequiredPreviousParameters(ParameterVgbIspPem4);

            ParameterPemUnomUpr220Perem
                .AddRequiredPreviousParameters(ParameterVgbIspPem3);

            ParameterPemUnomVkl
                .AddRequiredPreviousParameters(ParameterVgbIspPem2);

            ParameterPemUnomOtkl
                .AddRequiredPreviousParameters(ParameterVgbIspPem2);

            ParameterPemUnomYav220Perem.AddRequiredPreviousParameters(ParameterVgbIspPem3);
            ParameterPemUnomYav220Post.AddRequiredPreviousParameters(ParameterVgbIspPem3);
            ParameterPemUnomYav110Post.AddRequiredPreviousParameters(ParameterVgbIspPem3);

            ParameterPemInomYaa3.AddRequiredPreviousParameters(ParameterVgbIspPem3);
            ParameterPemInomYaa5.AddRequiredPreviousParameters(ParameterVgbIspPem3);

            #endregion

            #region Исполнение разъединителя

            ParameterDisconnectorIspolnenie1Pol.Clone(new Parameter { ParameterGroup = ParameterGroupDisconnectorIspolnenie, Value = "Однополюсное", Rang = 9 });
            ParameterDisconnectorIspolnenie3Pol.Clone(new Parameter { ParameterGroup = ParameterGroupDisconnectorIspolnenie, Value = "Трехполюсное", Rang = 10 });
            ParameterDisconnectorIspolnenieKil.Clone(new Parameter { ParameterGroup = ParameterGroupDisconnectorIspolnenie, Value = "Килевое", Rang = 8 });
            ParameterDisconnectorIspolnenieStKil.Clone(new Parameter { ParameterGroup = ParameterGroupDisconnectorIspolnenie, Value = "Ступенчато-килевое", Rang = 7 });

            ParameterDisconnectorIspolnenie1Pol
                .AddRequiredPreviousParameters(ParameterDisconnector);

            ParameterDisconnectorIspolnenie3Pol
                .AddRequiredPreviousParameters(ParameterDisconnector);

            ParameterDisconnectorIspolnenieKil
                .AddRequiredPreviousParameters(ParameterDisconnector, ParameterVoltage110kV);

            ParameterDisconnectorIspolnenieStKil
                .AddRequiredPreviousParameters(ParameterDisconnector, ParameterVoltage110kV);

            #endregion

            #region Заземлители разъединителя

            ParameterDisconnectorZazemlPalPos.Clone(new Parameter { ParameterGroup = ParameterGroupDisconnectorZazemlPal, Value = "Есть" });
            ParameterDisconnectorZazemlPalNeg.Clone(new Parameter { ParameterGroup = ParameterGroupDisconnectorZazemlPal, Value = "Отсутствует" });

            ParameterDisconnectorZazemlKulPos.Clone(new Parameter { ParameterGroup = ParameterGroupDisconnectorZazemlKul, Value = "Есть" });
            ParameterDisconnectorZazemlKulNeg.Clone(new Parameter { ParameterGroup = ParameterGroupDisconnectorZazemlKul, Value = "Отсутствует" });

            ParameterDisconnectorZazemlPalPos.AddRequiredPreviousParameters(ParameterDisconnector);
            ParameterDisconnectorZazemlPalNeg.AddRequiredPreviousParameters(ParameterDisconnector);

            ParameterDisconnectorZazemlKulPos.AddRequiredPreviousParameters(ParameterDisconnector);
            ParameterDisconnectorZazemlKulNeg.AddRequiredPreviousParameters(ParameterDisconnector);

            #endregion

            #region Тип привода разъединителя

            ParameterDriveDisconnectorTypeMotorn.Clone(new Parameter { ParameterGroup = ParameterGroupDriveDisconnectorType, Value = "Моторный" });
            ParameterDriveDisconnectorTypeRuchn.Clone(new Parameter { ParameterGroup = ParameterGroupDriveDisconnectorType, Value = "Ручной" });

            ParameterDriveDisconnectorTypeMotorn.AddRequiredPreviousParameters(ParameterDriveDisconnector);
            ParameterDriveDisconnectorTypeRuchn.AddRequiredPreviousParameters(ParameterDriveDisconnector);

            #endregion

            #region Тип привода разъединителя (по ножам)

            ParameterDriveDisconnectorTargetMain.Clone(new Parameter { ParameterGroup = ParameterGroupDriveDisconnectorTarget, Value = "Главными" });
            ParameterDriveDisconnectorTargetZazeml.Clone(new Parameter { ParameterGroup = ParameterGroupDriveDisconnectorTarget, Value = "Заземляющими" });

            ParameterDriveDisconnectorTargetMain.AddRequiredPreviousParameters(ParameterDriveDisconnector);
            ParameterDriveDisconnectorTargetZazeml.AddRequiredPreviousParameters(ParameterDriveDisconnector);

            #endregion

            #region Напряжение двигателя разъединителя

            ParameterDriveDisconnectorU230.Clone(new Parameter { ParameterGroup = ParameterGroupDriveDisconnectorU, Value = "~ 230 В" });
            ParameterDriveDisconnectorU220.Clone(new Parameter { ParameterGroup = ParameterGroupDriveDisconnectorU, Value = "= 220 В" });
            ParameterDriveDisconnectorU400.Clone(new Parameter { ParameterGroup = ParameterGroupDriveDisconnectorU, Value = "~ 400 В" }); ;

            ParameterDriveDisconnectorU230.AddRequiredPreviousParameters(ParameterDriveDisconnectorTypeMotorn);
            ParameterDriveDisconnectorU220.AddRequiredPreviousParameters(ParameterDriveDisconnectorTypeMotorn);
            ParameterDriveDisconnectorU400.AddRequiredPreviousParameters(ParameterDriveDisconnectorTypeMotorn);

            #endregion

            #region Напряжение эл.магн. блокировки

            ParameterDriveDisconnectorUblock110.Clone(new Parameter { ParameterGroup = ParameterGroupDriveDisconnectorUblock, Value = "= 110 В" });
            ParameterDriveDisconnectorUblock220.Clone(new Parameter { ParameterGroup = ParameterGroupDriveDisconnectorUblock, Value = "= 220 В" });

            ParameterDriveDisconnectorUblock110
                .AddRequiredPreviousParameters(ParameterDriveDisconnectorTargetZazeml, ParameterDriveDisconnectorTypeRuchn);

            ParameterDriveDisconnectorUblock220
                .AddRequiredPreviousParameters(ParameterDriveDisconnectorTargetZazeml, ParameterDriveDisconnectorTypeMotorn)
                .AddRequiredPreviousParameters(ParameterDriveDisconnectorTargetZazeml, ParameterDriveDisconnectorTypeRuchn);

            #endregion

            #region Расстояние между полюсами

            ParameterDisconnectorRast1700.Clone(new Parameter { ParameterGroup = ParameterGroupDisconnectorRast, Value = "1700 мм / 1 А" });
            ParameterDisconnectorRast1800.Clone(new Parameter { ParameterGroup = ParameterGroupDisconnectorRast, Value = "1800 мм / 1 А" });
            ParameterDisconnectorRast2000.Clone(new Parameter { ParameterGroup = ParameterGroupDisconnectorRast, Value = "2000 мм / 2 А" });

            ParameterDisconnectorRast1700.AddRequiredPreviousParameters(ParameterDisconnector, ParameterVoltage110kV);
            ParameterDisconnectorRast1800.AddRequiredPreviousParameters(ParameterDisconnector, ParameterVoltage110kV);
            ParameterDisconnectorRast2000.AddRequiredPreviousParameters(ParameterDisconnector, ParameterVoltage110kV);


            #endregion

            #region Уровни напряжений

            ParameterTransformerVoltageUisp200.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerVoltageUisp, Value = "200/480/550" });
            ParameterTransformerVoltageUisp230.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerVoltageUisp, Value = "230/550/550" });

            ParameterTransformerVoltageUisp200
                .AddRequiredPreviousParameters(ParameterTransformerVoltage, ParameterVoltage110kV, ParameterClimatT1)
                .AddRequiredPreviousParameters(ParameterTransformerVoltage, ParameterVoltage110kV, ParameterClimatU1)
                .AddRequiredPreviousParameters(ParameterTransformerVoltage, ParameterVoltage110kV, ParameterClimatHl1Z);

            ParameterTransformerVoltageUisp230
                .AddRequiredPreviousParameters(ParameterTransformerVoltage, ParameterVoltage110kV);

            #endregion

            #region Вид внутренней изоляции

            ParameterTransformerVoltageIsolationSf6.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerVoltageIsolation, Value = "SF6" });
            ParameterTransformerVoltageIsolationN2.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerVoltageIsolation, Value = "N2" });
            ParameterTransformerVoltageIsolationSf6N2.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerVoltageIsolation, Value = "SF6 + N2" });
            ParameterTransformerVoltageIsolationSf6Cf4.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerVoltageIsolation, Value = "SF6 + CF4" });

            ParameterTransformerVoltageIsolationSf6
                .AddRequiredPreviousParameters(ParameterTransformerCurrent, ParameterTransformerBuiltOut, ParameterVoltage35kV)
                .AddRequiredPreviousParameters(ParameterTransformerCurrent, ParameterTransformerBuiltOut, ParameterVoltage110kV, ParameterClimatU1)
                .AddRequiredPreviousParameters(ParameterTransformerCurrent, ParameterTransformerBuiltOut, ParameterVoltage220kV, ParameterClimatU1)
                .AddRequiredPreviousParameters(ParameterTransformerVoltage, ParameterVoltage110kV, ParameterClimatT1)
                .AddRequiredPreviousParameters(ParameterTransformerVoltage, ParameterVoltage110kV, ParameterClimatU1);

            ParameterTransformerVoltageIsolationN2
                .AddRequiredPreviousParameters(ParameterTransformerCurrent, ParameterTransformerBuiltOut, ParameterVoltage35kV);

            ParameterTransformerVoltageIsolationSf6N2
                .AddRequiredPreviousParameters(ParameterTransformerCurrent, ParameterTransformerBuiltOut, ParameterVoltage110kV, ParameterClimatUhl1)
                .AddRequiredPreviousParameters(ParameterTransformerCurrent, ParameterTransformerBuiltOut, ParameterVoltage220kV, ParameterClimatUhl1)
                .AddRequiredPreviousParameters(ParameterTransformerCurrent, ParameterTransformerBuiltOut, ParameterVoltage110kV, ParameterClimatHl1)
                .AddRequiredPreviousParameters(ParameterTransformerCurrent, ParameterTransformerBuiltOut, ParameterVoltage220kV, ParameterClimatHl1)
                .AddRequiredPreviousParameters(ParameterTransformerVoltage, ParameterVoltage110kV, ParameterClimatHl1Z)
                .AddRequiredPreviousParameters(ParameterTransformerVoltage, ParameterVoltage110kV, ParameterClimatHl1);

            ParameterTransformerVoltageIsolationSf6Cf4
                .AddRequiredPreviousParameters(ParameterTransformerVoltage, ParameterVoltage110kV, ParameterClimatHl1Z);

            #endregion

            #region Исполнение ТРГ

            ParameterTrgIsp1.Clone(new Parameter { ParameterGroup = ParameterGroupTrgIsp, Value = "Да" });
            ParameterTrgIsp2.Clone(new Parameter { ParameterGroup = ParameterGroupTrgIsp, Value = "Нет" });

            ParameterTrgIsp1
                .AddRequiredPreviousParameters(ParameterTransformerCurrent, ParameterTransformerBuiltOut);

            ParameterTrgIsp2
                .AddRequiredPreviousParameters(ParameterTransformerCurrent, ParameterTransformerBuiltOut);

            #endregion

            #region Продукт для встраивания

            ParameterTransformerCurrentTargetProductBreaker.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerCurrentTargetProduct, Value = "Выключатель" });
            ParameterTransformerCurrentTargetProductTransformer.Clone(new Parameter { ParameterGroup = ParameterGroupTransformerCurrentTargetProduct, Value = "Трансформатор" });

            ParameterTransformerCurrentTargetProductBreaker.AddRequiredPreviousParameters(ParameterTransformerBuiltIn);
            ParameterTransformerCurrentTargetProductTransformer.AddRequiredPreviousParameters(ParameterTransformerBuiltIn);

            #endregion

            #region Тип БВПТ

            ParameterBvptVab.Clone(new Parameter { ParameterGroup = ParameterGroupBvptType, Value = "Быстродействующий" });
            ParameterBvptVat.Clone(new Parameter { ParameterGroup = ParameterGroupBvptType, Value = "Токоограничивающий" });

            ParameterBvptVab
                .AddRequiredPreviousParameters(ParameterBvpt);

            ParameterBvptVat
                .AddRequiredPreviousParameters(ParameterBvpt);

            #endregion

            #region Серия БВПТ

            ParameterBvptSeries42.Clone(new Parameter { ParameterGroup = ParameterGroupBvptSeries, Value = "42" });
            ParameterBvptSeries43.Clone(new Parameter { ParameterGroup = ParameterGroupBvptSeries, Value = "43" });
            ParameterBvptSeries48.Clone(new Parameter { ParameterGroup = ParameterGroupBvptSeries, Value = "48" });
            ParameterBvptSeries49.Clone(new Parameter { ParameterGroup = ParameterGroupBvptSeries, Value = "49" });
            ParameterBvptSeries52.Clone(new Parameter { ParameterGroup = ParameterGroupBvptSeries, Value = "52" });
            ParameterBvptSeries55.Clone(new Parameter { ParameterGroup = ParameterGroupBvptSeries, Value = "55" });

            ParameterBvptSeries42
                .AddRequiredPreviousParameters(ParameterBvptVat);

            ParameterBvptSeries43
                .AddRequiredPreviousParameters(ParameterBvptVab)
                .AddRequiredPreviousParameters(ParameterBvptVat);

            ParameterBvptSeries48
                .AddRequiredPreviousParameters(ParameterBvptVat);

            ParameterBvptSeries49
                .AddRequiredPreviousParameters(ParameterBvptVab)
                .AddRequiredPreviousParameters(ParameterBvptVat);

            ParameterBvptSeries52
                .AddRequiredPreviousParameters(ParameterBvptVab);

            ParameterBvptSeries55
                .AddRequiredPreviousParameters(ParameterBvptVab);

            #endregion

            #region Исполнение БВПТ

            ParameterBvptIspolnenieL.Clone(new Parameter { ParameterGroup = ParameterGroupBvptIspolnenie, Value = "Линейный" });
            ParameterBvptIspolnenieK.Clone(new Parameter { ParameterGroup = ParameterGroupBvptIspolnenie, Value = "Катодный" });

            ParameterBvptIspolnenieL
                .AddRequiredPreviousParameters(ParameterBvptSeries49);

            ParameterBvptIspolnenieK
                .AddRequiredPreviousParameters(ParameterBvptSeries49);

            #endregion

            #region Ток БВПТ

            ParameterBvptCurrent1600.Clone(new Parameter { ParameterGroup = ParameterGroupBvptCurrent, Value = "1600 А" });
            ParameterBvptCurrent2500.Clone(new Parameter { ParameterGroup = ParameterGroupBvptCurrent, Value = "2500 А" });
            ParameterBvptCurrent3200.Clone(new Parameter { ParameterGroup = ParameterGroupBvptCurrent, Value = "3200 А" });
            ParameterBvptCurrent4000.Clone(new Parameter { ParameterGroup = ParameterGroupBvptCurrent, Value = "4000 А" });
            ParameterBvptCurrent5000.Clone(new Parameter { ParameterGroup = ParameterGroupBvptCurrent, Value = "5000 А" });
            ParameterBvptCurrent6300.Clone(new Parameter { ParameterGroup = ParameterGroupBvptCurrent, Value = "6300 А" });

            ParameterBvptCurrent1600
                .AddRequiredPreviousParameters(ParameterBvptSeries55);

            ParameterBvptCurrent2500
                .AddRequiredPreviousParameters(ParameterBvptSeries55);

            ParameterBvptCurrent3200
                .AddRequiredPreviousParameters(ParameterBvptSeries49, ParameterBvptIspolnenieL);

            ParameterBvptCurrent4000
                .AddRequiredPreviousParameters(ParameterBvptSeries49, ParameterBvptIspolnenieK);

            ParameterBvptCurrent5000
                .AddRequiredPreviousParameters(ParameterBvptSeries49);

            ParameterBvptCurrent6300
                .AddRequiredPreviousParameters(ParameterBvptSeries49, ParameterBvptIspolnenieL);

            #endregion

            #region Напряжение БВПТ

            ParameterBvptVoltage0460.Clone(new Parameter { ParameterGroup = ParameterGroupBvptVoltage, Value = "460 В" });
            ParameterBvptVoltage0660.Clone(new Parameter { ParameterGroup = ParameterGroupBvptVoltage, Value = "660 В" });
            ParameterBvptVoltage1050.Clone(new Parameter { ParameterGroup = ParameterGroupBvptVoltage, Value = "1050 В" });
            ParameterBvptVoltage1650.Clone(new Parameter { ParameterGroup = ParameterGroupBvptVoltage, Value = "1650 В" });
            ParameterBvptVoltage3000.Clone(new Parameter { ParameterGroup = ParameterGroupBvptVoltage, Value = "3000 В" });
            ParameterBvptVoltage3300.Clone(new Parameter { ParameterGroup = ParameterGroupBvptVoltage, Value = "3300 В" });

            ParameterBvptVoltage0460
                .AddRequiredPreviousParameters(ParameterBvptSeries48);

            ParameterBvptVoltage0660
                .AddRequiredPreviousParameters(ParameterBvptSeries48);

            ParameterBvptVoltage1050
                .AddRequiredPreviousParameters(ParameterBvptSeries52)
                .AddRequiredPreviousParameters(ParameterBvptSeries48)
                .AddRequiredPreviousParameters(ParameterBvptSeries43)
                .AddRequiredPreviousParameters(ParameterBvptSeries49);

            ParameterBvptVoltage1650
                .AddRequiredPreviousParameters(ParameterBvptSeries49);


            ParameterBvptVoltage3000
                .AddRequiredPreviousParameters(ParameterBvptSeries55);

            ParameterBvptVoltage3300
                .AddRequiredPreviousParameters(ParameterBvptSeries49);

            #endregion

        }

        #endregion

        #region ProductRelations

        #region Fields

        public ProductRelation RequiredChildProductRelationDrivePem;

        public ProductRelation RequiredChildProductRelationDrivePprKVgt35;
        public ProductRelation RequiredChildProductRelationDrivePprKVgt110;
        public ProductRelation RequiredChildProductRelationDrivePprKVeb110;

        public ProductRelation RequiredChildProductRelationDriveDisconnectorMain;
        public ProductRelation RequiredChildProductRelationDriveDisconnectorPal;
        public ProductRelation RequiredChildProductRelationDriveDisconnectorKul;
        public ProductRelation RequiredChildProductRelationDriveDisconnectorBoth;

        public ProductRelation RequiredChildProductRelationDriveEarthingSwitch;

        public ProductRelation RequiredChildProductRelationDrivePpvVeb110;
        public ProductRelation RequiredChildProductRelationDrivePpv220;
        public ProductRelation RequiredChildProductRelationDrivePpv330;
        public ProductRelation RequiredChildProductRelationDrivePpv500;

        public ProductRelation RequiredChildProductRelationTransfBlockForVeb110;
        public ProductRelation RequiredChildProductRelationTransfBlockForVeb220;
        public ProductRelation RequiredChildProductRelationTransfBlockForVgb35;
        public ProductRelation RequiredChildProductRelationTransfBlockForTrg35;
        public ProductRelation RequiredChildProductRelationTransfBlockForTrg110;
        public ProductRelation RequiredChildProductRelationTransfBlockForTrg220;



        public ProductRelation RequiredChildProductRelationTvg110ForBlock1;
        public ProductRelation RequiredChildProductRelationTvg220ForBlock1;
        public ProductRelation RequiredChildProductRelationTvg35ForBlock1;
        public ProductRelation RequiredChildProductRelationTrg35ForBlock1;
        public ProductRelation RequiredChildProductRelationTrg110ForBlock1;
        public ProductRelation RequiredChildProductRelationTrg220ForBlock1;

        public ProductRelation RequiredChildProductRelationTvg110ForBlock2;
        public ProductRelation RequiredChildProductRelationTvg220ForBlock2;
        public ProductRelation RequiredChildProductRelationTvg35ForBlock2;
        public ProductRelation RequiredChildProductRelationTrg35ForBlock2;
        public ProductRelation RequiredChildProductRelationTrg110ForBlock2;
        public ProductRelation RequiredChildProductRelationTrg220ForBlock2;

        public ProductRelation RequiredChildProductRelationTvg110ForBlock3;
        public ProductRelation RequiredChildProductRelationTvg220ForBlock3;
        public ProductRelation RequiredChildProductRelationTvg35ForBlock3;
        public ProductRelation RequiredChildProductRelationTrg35ForBlock3;
        public ProductRelation RequiredChildProductRelationTrg110ForBlock3;
        public ProductRelation RequiredChildProductRelationTrg220ForBlock3;

        public ProductRelation RequiredChildProductRelationTvg110ForBlock4;
        public ProductRelation RequiredChildProductRelationTvg220ForBlock4;
        public ProductRelation RequiredChildProductRelationTvg35ForBlock4;
        public ProductRelation RequiredChildProductRelationTrg35ForBlock4;
        public ProductRelation RequiredChildProductRelationTrg110ForBlock4;
        public ProductRelation RequiredChildProductRelationTrg220ForBlock4;

        public ProductRelation RequiredChildProductRelationTvg110ForBlock5;
        public ProductRelation RequiredChildProductRelationTvg220ForBlock5;
        public ProductRelation RequiredChildProductRelationTvg35ForBlock5;
        public ProductRelation RequiredChildProductRelationTrg35ForBlock5;
        public ProductRelation RequiredChildProductRelationTrg110ForBlock5;
        public ProductRelation RequiredChildProductRelationTrg220ForBlock5;

        public ProductRelation RequiredChildProductRelationTvg110ForBlock6;
        public ProductRelation RequiredChildProductRelationTvg220ForBlock6;
        public ProductRelation RequiredChildProductRelationTvg35ForBlock6;
        public ProductRelation RequiredChildProductRelationTrg35ForBlock6;
        public ProductRelation RequiredChildProductRelationTrg110ForBlock6;
        public ProductRelation RequiredChildProductRelationTrg220ForBlock6;

        public ProductRelation RequiredChildProductRelationTvg110ForBlock7;
        public ProductRelation RequiredChildProductRelationTvg220ForBlock7;
        public ProductRelation RequiredChildProductRelationTvg35ForBlock7;
        public ProductRelation RequiredChildProductRelationTrg35ForBlock7;
        public ProductRelation RequiredChildProductRelationTrg110ForBlock7;
        public ProductRelation RequiredChildProductRelationTrg220ForBlock7;

        public ProductRelation RequiredChildProductRelationTvg110ForBlock8;
        public ProductRelation RequiredChildProductRelationTvg220ForBlock8;
        public ProductRelation RequiredChildProductRelationTvg35ForBlock8;
        public ProductRelation RequiredChildProductRelationTrg35ForBlock8;
        public ProductRelation RequiredChildProductRelationTrg110ForBlock8;
        public ProductRelation RequiredChildProductRelationTrg220ForBlock8;



        public ProductRelation RequiredChildProductRelationZng110Block;
        public ProductRelation RequiredChildProductRelationZng220Block;

        #endregion

        private void GenerateProductRelations()
        {
            #region Приводы

            RequiredChildProductRelationDrivePem.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterBreaker, ParameterVoltage35kV, ParameterBreakerDeadTank },
                ChildProductParameters = new List<Parameter> { ParameterDrivePem },
                ChildProductsAmount = 1,
                IsUnique = false
            });

            RequiredChildProductRelationDrivePprKVgt35.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterBreakerLiveTank, ParameterVoltage35kV },
                ChildProductParameters = new List<Parameter> { ParameterDrivePPrK },
                ChildProductsAmount = 1,
                IsUnique = false
            });

            RequiredChildProductRelationDrivePprKVgt110.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterBreakerLiveTank, ParameterVoltage110kV },
                ChildProductParameters = new List<Parameter> { ParameterDrivePPrK },
                ChildProductsAmount = 1,
                IsUnique = false
            });

            RequiredChildProductRelationDrivePprKVeb110.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterBreakerDeadTank, ParameterVoltage110kV, ParameterCurrentBreaking40kA },
                ChildProductParameters = new List<Parameter> { ParameterDrivePPrK },
                ChildProductsAmount = 1,
                IsUnique = false
            });

            RequiredChildProductRelationDrivePpvVeb110.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterBreakerDeadTank, ParameterVoltage110kV, ParameterCurrentBreaking50kA },
                ChildProductParameters = new List<Parameter> { ParameterDrivePPV },
                ChildProductsAmount = 1,
                IsUnique = false
            });

            RequiredChildProductRelationDrivePpv220.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterBreaker, ParameterVoltage220kV },
                ChildProductParameters = new List<Parameter> { ParameterDrivePPV },
                ChildProductsAmount = 1,
                IsUnique = false
            });

            RequiredChildProductRelationDrivePpv330.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterBreaker, ParameterVoltage330kV },
                ChildProductParameters = new List<Parameter> { ParameterDrivePPV },
                ChildProductsAmount = 3,
                IsUnique = false
            });

            RequiredChildProductRelationDrivePpv500.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterBreaker, ParameterVoltage500kV },
                ChildProductParameters = new List<Parameter> { ParameterDrivePPV },
                ChildProductsAmount = 3,
                IsUnique = false
            });

            RequiredChildProductRelationDriveDisconnectorMain.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterDisconnector },
                ChildProductParameters = new List<Parameter> { ParameterDriveDisconnector, ParameterDriveDisconnectorTargetMain },
                ChildProductsAmount = 1,
                IsUnique = false
            });

            RequiredChildProductRelationDriveDisconnectorKul.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterDisconnectorZazemlKulPos, ParameterDisconnectorZazemlPalNeg },
                ChildProductParameters = new List<Parameter> { ParameterDriveDisconnector, ParameterDriveDisconnectorTargetZazeml },
                ChildProductsAmount = 1,
                IsUnique = false
            });

            RequiredChildProductRelationDriveDisconnectorPal.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterDisconnectorZazemlKulNeg, ParameterDisconnectorZazemlPalPos },
                ChildProductParameters = new List<Parameter> { ParameterDriveDisconnector, ParameterDriveDisconnectorTargetZazeml },
                ChildProductsAmount = 1,
                IsUnique = false
            });

            RequiredChildProductRelationDriveDisconnectorBoth.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterDisconnectorZazemlKulPos, ParameterDisconnectorZazemlPalPos },
                ChildProductParameters = new List<Parameter> { ParameterDriveDisconnector, ParameterDriveDisconnectorTargetZazeml },
                ChildProductsAmount = 2,
                IsUnique = false
            });

            #endregion

            RequiredChildProductRelationDriveEarthingSwitch.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterEarthingSwitch },
                ChildProductParameters = new List<Parameter> { ParameterDriveDisconnector, ParameterDriveDisconnectorTargetZazeml },
                ChildProductsAmount = 1,
                IsUnique = false
            });



            #region Блоки трансформаторов тока

            RequiredChildProductRelationTransfBlockForVeb110.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterBreakerDeadTank, ParameterVoltage110kV, ParameterBreakerPhases3 },
                ChildProductParameters = new List<Parameter> { ParameterTransformersBlockTargetVeb110 },
                ChildProductsAmount = 1,
                IsUnique = false
            });

            RequiredChildProductRelationTransfBlockForVeb220.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterBreakerDeadTank, ParameterVoltage220kV, ParameterBreakerPhases3 },
                ChildProductParameters = new List<Parameter> { ParameterTransformersBlockTargetVeb220 },
                ChildProductsAmount = 1,
                IsUnique = false
            });

            RequiredChildProductRelationTransfBlockForVgb35.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterBreakerDeadTank, ParameterVoltage35kV },
                ChildProductParameters = new List<Parameter> { ParameterTransformersBlockTargetVgb35 },
                ChildProductsAmount = 1,
                IsUnique = false
            });

            RequiredChildProductRelationTransfBlockForTrg35.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformerCurrent, ParameterTransformerBuiltOut, ParameterVoltage35kV },
                ChildProductParameters = new List<Parameter> { ParameterTransformersBlockTargetTrg35 },
                ChildProductsAmount = 1,
                IsUnique = false
            });

            RequiredChildProductRelationTransfBlockForTrg110.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformerCurrent, ParameterTransformerBuiltOut, ParameterVoltage110kV },
                ChildProductParameters = new List<Parameter> { ParameterTransformersBlockTargetTrg110 },
                ChildProductsAmount = 1,
                IsUnique = false
            });

            RequiredChildProductRelationTransfBlockForTrg220.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformerCurrent, ParameterTransformerBuiltOut, ParameterVoltage220kV },
                ChildProductParameters = new List<Parameter> { ParameterTransformersBlockTargetTrg220 },
                ChildProductsAmount = 1,
                IsUnique = false
            });

            #endregion

            #region Блоки трансформаторов напряжения

            RequiredChildProductRelationZng110Block.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformerVoltage, ParameterVoltage110kV },
                ChildProductParameters = new List<Parameter> { ParameterPartTransformersVoltageBlock, ParameterTransformersBlockTargetZng110 },
                ChildProductsAmount = 1,
                IsUnique = false
            });

            RequiredChildProductRelationZng220Block.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformerVoltage, ParameterVoltage220kV },
                ChildProductParameters = new List<Parameter> { ParameterPartTransformersVoltageBlock, ParameterTransformersBlockTargetZng220 },
                ChildProductsAmount = 1,
                IsUnique = false
            });

            #endregion

            #region Трансформаторы в блоке

            #region 1 трансформатора в блоке

            RequiredChildProductRelationTvg110ForBlock1.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetVeb110, ParameterTransformersInBlockAmount1 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage110kV, ParameterTransformerCurrentTargetProductBreaker },
                ChildProductsAmount = 1,
                IsUnique = false
            });

            RequiredChildProductRelationTvg220ForBlock1.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetVeb220, ParameterTransformersInBlockAmount1 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage220kV, ParameterTransformerCurrentTargetProductBreaker },
                ChildProductsAmount = 1,
                IsUnique = false
            });

            RequiredChildProductRelationTvg35ForBlock1.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetVgb35, ParameterTransformersInBlockAmount1 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage35kV, ParameterTransformerCurrentTargetProductBreaker },
                ChildProductsAmount = 1,
                IsUnique = false
            });

            RequiredChildProductRelationTrg35ForBlock1.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetTrg35, ParameterTransformersInBlockAmount1 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage35kV, ParameterTransformerCurrentTargetProductTransformer },
                ChildProductsAmount = 1,
                IsUnique = false
            });

            RequiredChildProductRelationTrg110ForBlock1.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetTrg110, ParameterTransformersInBlockAmount1 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage110kV, ParameterTransformerCurrentTargetProductTransformer },
                ChildProductsAmount = 1,
                IsUnique = false
            });

            RequiredChildProductRelationTrg220ForBlock1.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetTrg220, ParameterTransformersInBlockAmount1 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage220kV, ParameterTransformerCurrentTargetProductTransformer },
                ChildProductsAmount = 1,
                IsUnique = false
            });

            #endregion

            #region 2 трансформатора в блоке

            RequiredChildProductRelationTvg110ForBlock2.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetVeb110, ParameterTransformersInBlockAmount2 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage110kV, ParameterTransformerCurrentTargetProductBreaker },
                ChildProductsAmount = 2,
                IsUnique = false
            });

            RequiredChildProductRelationTvg220ForBlock2.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetVeb220, ParameterTransformersInBlockAmount2 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage220kV, ParameterTransformerCurrentTargetProductBreaker },
                ChildProductsAmount = 2,
                IsUnique = false
            });

            RequiredChildProductRelationTvg35ForBlock2.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetVgb35, ParameterTransformersInBlockAmount2 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage35kV, ParameterTransformerCurrentTargetProductBreaker },
                ChildProductsAmount = 2,
                IsUnique = false
            });

            RequiredChildProductRelationTrg35ForBlock2.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetTrg35, ParameterTransformersInBlockAmount2 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage35kV, ParameterTransformerCurrentTargetProductTransformer },
                ChildProductsAmount = 2,
                IsUnique = false
            });

            RequiredChildProductRelationTrg110ForBlock2.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetTrg110, ParameterTransformersInBlockAmount2 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage110kV, ParameterTransformerCurrentTargetProductTransformer },
                ChildProductsAmount = 2,
                IsUnique = false
            });

            RequiredChildProductRelationTrg220ForBlock2.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetTrg220, ParameterTransformersInBlockAmount2 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage220kV, ParameterTransformerCurrentTargetProductTransformer },
                ChildProductsAmount = 2,
                IsUnique = false
            });

            #endregion

            #region 3 трансформатора в блоке

            RequiredChildProductRelationTvg110ForBlock3.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetVeb110, ParameterTransformersInBlockAmount3 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage110kV, ParameterTransformerCurrentTargetProductBreaker },
                ChildProductsAmount = 3,
                IsUnique = false
            });

            RequiredChildProductRelationTvg220ForBlock3.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetVeb220, ParameterTransformersInBlockAmount3 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage220kV, ParameterTransformerCurrentTargetProductBreaker },
                ChildProductsAmount = 3,
                IsUnique = false
            });

            RequiredChildProductRelationTvg35ForBlock3.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetVgb35, ParameterTransformersInBlockAmount3 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage35kV, ParameterTransformerCurrentTargetProductBreaker },
                ChildProductsAmount = 3,
                IsUnique = false
            });

            RequiredChildProductRelationTrg35ForBlock3.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetTrg35, ParameterTransformersInBlockAmount3 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage35kV, ParameterTransformerCurrentTargetProductTransformer },
                ChildProductsAmount = 3,
                IsUnique = false
            });

            RequiredChildProductRelationTrg110ForBlock3.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetTrg110, ParameterTransformersInBlockAmount3 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage110kV, ParameterTransformerCurrentTargetProductTransformer },
                ChildProductsAmount = 3,
                IsUnique = false
            });

            RequiredChildProductRelationTrg220ForBlock3.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetTrg220, ParameterTransformersInBlockAmount3 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage220kV, ParameterTransformerCurrentTargetProductTransformer },
                ChildProductsAmount = 3,
                IsUnique = false
            });

            #endregion

            #region 4 трансформатора в блоке

            RequiredChildProductRelationTvg110ForBlock4.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetVeb110, ParameterTransformersInBlockAmount4 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage110kV, ParameterTransformerCurrentTargetProductBreaker },
                ChildProductsAmount = 4,
                IsUnique = false
            });

            RequiredChildProductRelationTvg220ForBlock4.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetVeb220, ParameterTransformersInBlockAmount4 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage220kV, ParameterTransformerCurrentTargetProductBreaker },
                ChildProductsAmount = 4,
                IsUnique = false
            });

            RequiredChildProductRelationTvg35ForBlock4.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetVgb35, ParameterTransformersInBlockAmount4 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage35kV, ParameterTransformerCurrentTargetProductBreaker },
                ChildProductsAmount = 4,
                IsUnique = false
            });

            RequiredChildProductRelationTrg35ForBlock4.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetTrg35, ParameterTransformersInBlockAmount4 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage35kV, ParameterTransformerCurrentTargetProductTransformer },
                ChildProductsAmount = 4,
                IsUnique = false
            });

            RequiredChildProductRelationTrg110ForBlock4.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetTrg110, ParameterTransformersInBlockAmount4 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage110kV, ParameterTransformerCurrentTargetProductTransformer },
                ChildProductsAmount = 4,
                IsUnique = false
            });

            RequiredChildProductRelationTrg220ForBlock4.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetTrg220, ParameterTransformersInBlockAmount4 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage220kV, ParameterTransformerCurrentTargetProductTransformer },
                ChildProductsAmount = 4,
                IsUnique = false
            });

            #endregion

            #region 5 трансформатора в блоке

            RequiredChildProductRelationTvg110ForBlock5.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetVeb110, ParameterTransformersInBlockAmount5 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage110kV, ParameterTransformerCurrentTargetProductBreaker },
                ChildProductsAmount = 5,
                IsUnique = false
            });

            RequiredChildProductRelationTvg220ForBlock5.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetVeb220, ParameterTransformersInBlockAmount5 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage220kV, ParameterTransformerCurrentTargetProductBreaker },
                ChildProductsAmount = 5,
                IsUnique = false
            });

            RequiredChildProductRelationTvg35ForBlock5.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetVgb35, ParameterTransformersInBlockAmount5 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage35kV, ParameterTransformerCurrentTargetProductBreaker },
                ChildProductsAmount = 5,
                IsUnique = false
            });

            RequiredChildProductRelationTrg35ForBlock5.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetTrg35, ParameterTransformersInBlockAmount5 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage35kV, ParameterTransformerCurrentTargetProductTransformer },
                ChildProductsAmount = 5,
                IsUnique = false
            });

            RequiredChildProductRelationTrg110ForBlock5.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetTrg110, ParameterTransformersInBlockAmount5 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage110kV, ParameterTransformerCurrentTargetProductTransformer },
                ChildProductsAmount = 5,
                IsUnique = false
            });

            RequiredChildProductRelationTrg220ForBlock5.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetTrg220, ParameterTransformersInBlockAmount5 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage220kV, ParameterTransformerCurrentTargetProductTransformer },
                ChildProductsAmount = 5,
                IsUnique = false
            });

            #endregion

            #region 6 трансформатора в блоке

            RequiredChildProductRelationTvg110ForBlock6.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetVeb110, ParameterTransformersInBlockAmount6 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage110kV, ParameterTransformerCurrentTargetProductBreaker },
                ChildProductsAmount = 6,
                IsUnique = false
            });

            RequiredChildProductRelationTvg220ForBlock6.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetVeb220, ParameterTransformersInBlockAmount6 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage220kV, ParameterTransformerCurrentTargetProductBreaker },
                ChildProductsAmount = 6,
                IsUnique = false
            });

            RequiredChildProductRelationTvg35ForBlock6.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetVgb35, ParameterTransformersInBlockAmount6 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage35kV, ParameterTransformerCurrentTargetProductBreaker },
                ChildProductsAmount = 6,
                IsUnique = false
            });

            RequiredChildProductRelationTrg35ForBlock6.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetTrg35, ParameterTransformersInBlockAmount6 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage35kV, ParameterTransformerCurrentTargetProductTransformer },
                ChildProductsAmount = 6,
                IsUnique = false
            });

            RequiredChildProductRelationTrg110ForBlock6.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetTrg110, ParameterTransformersInBlockAmount6 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage110kV, ParameterTransformerCurrentTargetProductTransformer },
                ChildProductsAmount = 6,
                IsUnique = false
            });

            RequiredChildProductRelationTrg220ForBlock6.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetTrg220, ParameterTransformersInBlockAmount6 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage220kV, ParameterTransformerCurrentTargetProductTransformer },
                ChildProductsAmount = 6,
                IsUnique = false
            });

            #endregion

            #region 7 трансформатора в блоке

            RequiredChildProductRelationTvg110ForBlock7.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetVeb110, ParameterTransformersInBlockAmount7 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage110kV, ParameterTransformerCurrentTargetProductBreaker },
                ChildProductsAmount = 7,
                IsUnique = false
            });

            RequiredChildProductRelationTvg220ForBlock7.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetVeb220, ParameterTransformersInBlockAmount7 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage220kV, ParameterTransformerCurrentTargetProductBreaker },
                ChildProductsAmount = 7,
                IsUnique = false
            });

            RequiredChildProductRelationTvg35ForBlock7.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetVgb35, ParameterTransformersInBlockAmount7 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage35kV, ParameterTransformerCurrentTargetProductBreaker },
                ChildProductsAmount = 7,
                IsUnique = false
            });

            RequiredChildProductRelationTrg35ForBlock7.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetTrg35, ParameterTransformersInBlockAmount7 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage35kV, ParameterTransformerCurrentTargetProductTransformer },
                ChildProductsAmount = 7,
                IsUnique = false
            });

            RequiredChildProductRelationTrg110ForBlock7.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetTrg110, ParameterTransformersInBlockAmount7 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage110kV, ParameterTransformerCurrentTargetProductTransformer },
                ChildProductsAmount = 7,
                IsUnique = false
            });

            RequiredChildProductRelationTrg220ForBlock7.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetTrg220, ParameterTransformersInBlockAmount7 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage220kV, ParameterTransformerCurrentTargetProductTransformer },
                ChildProductsAmount = 7,
                IsUnique = false
            });

            #endregion

            #region 8 трансформатора в блоке

            RequiredChildProductRelationTvg110ForBlock8.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetVeb110, ParameterTransformersInBlockAmount8 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage110kV, ParameterTransformerCurrentTargetProductBreaker },
                ChildProductsAmount = 8,
                IsUnique = false
            });

            RequiredChildProductRelationTvg220ForBlock8.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetVeb220, ParameterTransformersInBlockAmount8 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage220kV, ParameterTransformerCurrentTargetProductBreaker },
                ChildProductsAmount = 8,
                IsUnique = false
            });

            RequiredChildProductRelationTvg35ForBlock8.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetVgb35, ParameterTransformersInBlockAmount8 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage35kV, ParameterTransformerCurrentTargetProductBreaker },
                ChildProductsAmount = 8,
                IsUnique = false
            });

            RequiredChildProductRelationTrg35ForBlock8.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetTrg35, ParameterTransformersInBlockAmount8 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage35kV, ParameterTransformerCurrentTargetProductTransformer },
                ChildProductsAmount = 8,
                IsUnique = false
            });

            RequiredChildProductRelationTrg110ForBlock8.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetTrg110, ParameterTransformersInBlockAmount8 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage110kV, ParameterTransformerCurrentTargetProductTransformer },
                ChildProductsAmount = 8,
                IsUnique = false
            });

            RequiredChildProductRelationTrg220ForBlock8.Clone(new ProductRelation
            {
                ParentProductParameters = new List<Parameter> { ParameterTransformersCurrentBlockTypeCustom, ParameterTransformersBlockTargetTrg220, ParameterTransformersInBlockAmount8 },
                ChildProductParameters = new List<Parameter> { ParameterTransformerBuiltIn, ParameterVoltage220kV, ParameterTransformerCurrentTargetProductTransformer },
                ChildProductsAmount = 8,
                IsUnique = false
            });

            #endregion

            #endregion

        }

        #endregion

        #region ProductType

        public ProductType ProductTypeDeadTankBreaker;
        public ProductType ProductTypeLiveTankBreaker;
        public ProductType ProductTypeCurrentTransformer;
        public ProductType ProductTypeVoltageTransformer;
        public ProductType ProductTypeDisconnector;
        public ProductType ProductTypeEarthingSwitch;
        public ProductType ProductTypeBvpt;
        public ProductType ProductTypeDrive;
        public ProductType ProductTypeKtt;
        public ProductType ProductTypeTvg;
        public ProductType ProductTypeService;

        private void GenerateProductTypes()
        {
            ProductTypeDeadTankBreaker.Clone(new ProductType { Name = "Выключатель баковый" });
            ProductTypeLiveTankBreaker.Clone(new ProductType { Name = "Выключатель колонковый" });
            ProductTypeCurrentTransformer.Clone(new ProductType { Name = "Трансформатор тока" });
            ProductTypeVoltageTransformer.Clone(new ProductType { Name = "Трансформатор напряжения" });
            ProductTypeDisconnector.Clone(new ProductType { Name = "Разъединитель" });
            ProductTypeEarthingSwitch.Clone(new ProductType { Name = "Заземлитель" });
            ProductTypeBvpt.Clone(new ProductType { Name = "Выключатель постоянного тока" });
            ProductTypeDrive.Clone(new ProductType { Name = "Привод" });
            ProductTypeKtt.Clone(new ProductType { Name = "Комплект трансформаторов тока" });
            ProductTypeTvg.Clone(new ProductType { Name = "Трансформатор тока встроенный" });
            ProductTypeService.Clone(new ProductType { Name = "Услуга" });
        }

        public ProductTypeDesignation ProductTypeDesignationDeadTankBreaker;
        public ProductTypeDesignation ProductTypeDesignationLiveTankBreaker;
        public ProductTypeDesignation ProductTypeDesignationCurrentTransformer;
        public ProductTypeDesignation ProductTypeDesignationVoltageTransformer;
        public ProductTypeDesignation ProductTypeDesignationDisconnector;
        public ProductTypeDesignation ProductTypeDesignationEarthingSwitch;
        public ProductTypeDesignation ProductTypeDesignationBvpt;
        public ProductTypeDesignation ProductTypeDesignationDrive;
        public ProductTypeDesignation ProductTypeDesignationKtt;
        public ProductTypeDesignation ProductTypeDesignationTvg;
        public ProductTypeDesignation ProductTypeDesignationService;

        private void GenerateProductTypeDesignations()
        {
            ProductTypeDesignationDeadTankBreaker.Clone(new ProductTypeDesignation { ProductType = ProductTypeDeadTankBreaker, Parameters = new List<Parameter> { ParameterBreaker, ParameterBreakerDeadTank } });
            ProductTypeDesignationLiveTankBreaker.Clone(new ProductTypeDesignation { ProductType = ProductTypeLiveTankBreaker, Parameters = new List<Parameter> { ParameterBreaker, ParameterBreakerLiveTank } });
            ProductTypeDesignationCurrentTransformer.Clone(new ProductTypeDesignation { ProductType = ProductTypeCurrentTransformer, Parameters = new List<Parameter> { ParameterTransformer, ParameterTransformerCurrent, ParameterTransformerBuiltOut } });
            ProductTypeDesignationVoltageTransformer.Clone(new ProductTypeDesignation { ProductType = ProductTypeVoltageTransformer, Parameters = new List<Parameter> { ParameterTransformer, ParameterTransformerVoltage } });
            ProductTypeDesignationDisconnector.Clone(new ProductTypeDesignation { ProductType = ProductTypeDisconnector, Parameters = new List<Parameter> { ParameterDisconnector } });
            ProductTypeDesignationEarthingSwitch.Clone(new ProductTypeDesignation { ProductType = ProductTypeEarthingSwitch, Parameters = new List<Parameter> { ParameterEarthingSwitch } });
            ProductTypeDesignationBvpt.Clone(new ProductTypeDesignation { ProductType = ProductTypeBvpt, Parameters = new List<Parameter> { ParameterBvpt } });
            ProductTypeDesignationDrive.Clone(new ProductTypeDesignation { ProductType = ProductTypeDrive, Parameters = new List<Parameter> { ParameterPartDrive } });
            ProductTypeDesignationKtt.Clone(new ProductTypeDesignation { ProductType = ProductTypeKtt, Parameters = new List<Parameter> { ParameterPartTransformersCurrentBlock } });
            ProductTypeDesignationTvg.Clone(new ProductTypeDesignation { ProductType = ProductTypeTvg, Parameters = new List<Parameter> { ParameterTransformerCurrent, ParameterTransformerBuiltIn } });
            ProductTypeDesignationService.Clone(new ProductTypeDesignation { ProductType = ProductTypeService, Parameters = new List<Parameter> { ParameterService } });
        }

        #endregion

        #region ProductDesignation

        public ProductDesignation ProductDesignationVgb35;

        public ProductDesignation ProductDesignationVgt35;
        public ProductDesignation ProductDesignationVgt110;
        public ProductDesignation ProductDesignationVgt330;
        public ProductDesignation ProductDesignationVgt500;
        public ProductDesignation ProductDesignationVgt2201A1;

        public ProductDesignation ProductDesignationVeb110;

        public ProductDesignation ProductDesignationVeb220;

        public ProductDesignation ProductDesignationDpu2;
        public ProductDesignation ProductDesignationDpu3;
        public ProductDesignation ProductDesignationDpu4;

        public ProductDesignation ProductDesignationZng110;
        public ProductDesignation ProductDesignationZng220;

        public ProductDesignation ProductDesignationTvg35;
        public ProductDesignation ProductDesignationTvg110;
        public ProductDesignation ProductDesignationTvg220;

        public ProductDesignation ProductDesignationTrg35;
        public ProductDesignation ProductDesignationTrg110;
        public ProductDesignation ProductDesignationTrg220;

        public ProductDesignation ProductDesignationPem;
        public ProductDesignation ProductDesignationPprK;
        public ProductDesignation ProductDesignationPpv;
        public ProductDesignation ProductDesignationDriveDisconnector;

        public ProductDesignation ProductDesignationTransfBlockVgb35;
        public ProductDesignation ProductDesignationTransfBlockVeb110;
        public ProductDesignation ProductDesignationTransfBlockVeb220;

        public ProductDesignation ProductDesignationZip1;
        public ProductDesignation ProductDesignationZip2;

        public ProductDesignation ProductDesignationRpd;
        public ProductDesignation ProductDesignationRpdo;


        public ProductDesignation ProductDesignationRpd1P;
        public ProductDesignation ProductDesignationRpd1K;
        public ProductDesignation ProductDesignationRpd2;

        public ProductDesignation ProductDesignationRpdVoltage110;
        public ProductDesignation ProductDesignationRpdVoltage220;

        public ProductDesignation ProductDesignationZro110;
        public ProductDesignation ProductDesignationZro220;

        public ProductDesignation ProductDesignationVab;
        public ProductDesignation ProductDesignationVab43;
        public ProductDesignation ProductDesignationVab49;
        public ProductDesignation ProductDesignationVab52;
        public ProductDesignation ProductDesignationVab55;




        public ProductDesignation ProductDesignationVat;
        public ProductDesignation ProductDesignationVat42;
        public ProductDesignation ProductDesignationVat43;
        public ProductDesignation ProductDesignationVat48;
        public ProductDesignation ProductDesignationVat49;

        public ProductDesignation ProductDesignationClimatT1;
        public ProductDesignation ProductDesignationClimatU1Z;
        public ProductDesignation ProductDesignationClimatUhl1Z;
        public ProductDesignation ProductDesignationClimatUhl1;
        public ProductDesignation ProductDesignationClimatU1;
        public ProductDesignation ProductDesignationClimatHl1Z;
        public ProductDesignation ProductDesignationClimatHl1;

        public ProductDesignation ProductDesignationCurrentBreaking12;
        public ProductDesignation ProductDesignationCurrentBreaking40;
        public ProductDesignation ProductDesignationCurrentBreaking50;

        public ProductDesignation ProductDesignationCurrentTerm25;
        public ProductDesignation ProductDesignationCurrentTerm40;
        public ProductDesignation ProductDesignationCurrentTerm50;

        public ProductDesignation ProductDesignationCurrent0630;
        public ProductDesignation ProductDesignationCurrent1000;
        public ProductDesignation ProductDesignationCurrent1250;
        public ProductDesignation ProductDesignationCurrent1600;
        public ProductDesignation ProductDesignationCurrent2500;
        public ProductDesignation ProductDesignationCurrent3150;
        public ProductDesignation ProductDesignationCurrent4000;

        public ProductDesignation ProductDesignationSupervision;

        public ProductDesignation ParameterDesignationSupervisionDeadTankBreaker;
        public ProductDesignation ParameterDesignationSupervisionLiveTankBreaker;
        public ProductDesignation ParameterDesignationSupervisionTransformerCurrent;
        public ProductDesignation ParameterDesignationSupervisionTransformerVoltage;

        public ProductDesignation ProductDesignationSupervision035kV;
        public ProductDesignation ProductDesignationSupervision110kV;
        public ProductDesignation ProductDesignationSupervision220kV;
        public ProductDesignation ProductDesignationSupervision330kV;
        public ProductDesignation ProductDesignationSupervision500kV;

        public ProductDesignation ProductDesignationSupervisionZone1;
        public ProductDesignation ProductDesignationSupervisionZone2;
        public ProductDesignation ProductDesignationSupervisionZone3;



        private void GenerateProductDesignations()
        {
            ProductDesignationVgb35.Clone(new ProductDesignation { Designation = "ВГБ-УЭТМ-35", Parameters = new List<Parameter> { ParameterBreakerDeadTank, ParameterVoltage35kV } });

            ProductDesignationVgt35.Clone(new ProductDesignation { Designation = "ВГТ-УЭТМ-35", Parameters = new List<Parameter> { ParameterBreakerLiveTank, ParameterVoltage35kV } });
            ProductDesignationVgt110.Clone(new ProductDesignation { Designation = "ВГТ-УЭТМ-110", Parameters = new List<Parameter> { ParameterBreakerLiveTank, ParameterVoltage110kV } });
            ProductDesignationVgt330.Clone(new ProductDesignation { Designation = "ВГТ-УЭТМ-330", Parameters = new List<Parameter> { ParameterBreakerLiveTank, ParameterVoltage330kV } });
            ProductDesignationVgt500.Clone(new ProductDesignation { Designation = "ВГТ-УЭТМ-500", Parameters = new List<Parameter> { ParameterBreakerLiveTank, ParameterVoltage500kV } });

            ProductDesignationVgt2201A1.Clone(new ProductDesignation { Designation = "ВГТ-УЭТМ-1А1-220", Parameters = new List<Parameter> { ParameterBreakerLiveTank, ParameterVoltage220kV, ParameterBreakerLiveTankBreaks1Razriv } });

            ProductDesignationVeb110.Clone(new ProductDesignation { Designation = "ВЭБ-УЭТМ-110", Parameters = new List<Parameter> { ParameterBreakerDeadTank, ParameterVoltage110kV } });
            ProductDesignationVeb220.Clone(new ProductDesignation { Designation = "ВЭБ-УЭТМ-220", Parameters = new List<Parameter> { ParameterBreakerDeadTank, ParameterVoltage220kV } });

            ProductDesignationZng110.Clone(new ProductDesignation { Designation = "ЗНГ-УЭТМ-110", Parameters = new List<Parameter> { ParameterTransformerVoltage, ParameterVoltage110kV } });
            ProductDesignationZng220.Clone(new ProductDesignation { Designation = "ЗНГ-УЭТМ-220", Parameters = new List<Parameter> { ParameterTransformerVoltage, ParameterVoltage220kV } });

            ProductDesignationTvg35.Clone(new ProductDesignation { Designation = "ТВГ-УЭТМ-35", Parameters = new List<Parameter> { ParameterTransformerCurrent, ParameterTransformerBuiltIn, ParameterVoltage35kV } });
            ProductDesignationTvg110.Clone(new ProductDesignation { Designation = "ТВГ-УЭТМ-110", Parameters = new List<Parameter> { ParameterTransformerCurrent, ParameterTransformerBuiltIn, ParameterVoltage110kV } });
            ProductDesignationTvg220.Clone(new ProductDesignation { Designation = "ТВГ-УЭТМ-220", Parameters = new List<Parameter> { ParameterTransformerCurrent, ParameterTransformerBuiltIn, ParameterVoltage220kV } });

            ProductDesignationTrg35.Clone(new ProductDesignation { Designation = "ТРГ-УЭТМ-35", Parameters = new List<Parameter> { ParameterTransformerCurrent, ParameterTransformerBuiltOut, ParameterVoltage35kV } });
            ProductDesignationTrg110.Clone(new ProductDesignation { Designation = "ТРГ-УЭТМ-110", Parameters = new List<Parameter> { ParameterTransformerCurrent, ParameterTransformerBuiltOut, ParameterVoltage110kV } });
            ProductDesignationTrg220.Clone(new ProductDesignation { Designation = "ТРГ-УЭТМ-220", Parameters = new List<Parameter> { ParameterTransformerCurrent, ParameterTransformerBuiltOut, ParameterVoltage220kV } });

            ProductDesignationPem.Clone(new ProductDesignation { Designation = "ПЭМ", Parameters = new List<Parameter> { ParameterDrivePem } });
            ProductDesignationPprK.Clone(new ProductDesignation { Designation = "ППрК", Parameters = new List<Parameter> { ParameterDrivePPrK } });
            ProductDesignationPpv.Clone(new ProductDesignation { Designation = "ППВ", Parameters = new List<Parameter> { ParameterDrivePPV } });
            ProductDesignationDriveDisconnector.Clone(new ProductDesignation { Designation = "Привод разъединителя/заземлителя", Parameters = new List<Parameter> { ParameterDriveDisconnector } });

            ProductDesignationTransfBlockVgb35.Clone(new ProductDesignation { Designation = "Комплект трансформаторов тока для ВГБ-35 (3 фазы)", Parameters = new List<Parameter> { ParameterTransformersBlockTargetVgb35 } });
            ProductDesignationTransfBlockVeb110.Clone(new ProductDesignation { Designation = "Комплект трансформаторов тока для ВЭБ-110 (3 фазы)", Parameters = new List<Parameter> { ParameterTransformersBlockTargetVeb110 } });
            ProductDesignationTransfBlockVeb220.Clone(new ProductDesignation { Designation = "Комплект трансформаторов тока для ВЭБ-220 (3 фазы)", Parameters = new List<Parameter> { ParameterTransformersBlockTargetVeb220 } });

            ProductDesignationZip1.Clone(new ProductDesignation { Designation = "Групповой комплект ЗИП №1", Parameters = new List<Parameter> { ParameterZip1 } });
            ProductDesignationZip2.Clone(new ProductDesignation { Designation = "Групповой комплект ЗИП №2", Parameters = new List<Parameter> { ParameterZip2 } });

            ProductDesignationRpd.Clone(new ProductDesignation { Designation = "РПД-УЭТМ", Parameters = new List<Parameter> { ParameterDisconnector, ParameterDisconnectorIspolnenie3Pol } });
            ProductDesignationRpdo.Clone(new ProductDesignation { Designation = "РПДО-УЭТМ", Parameters = new List<Parameter> { ParameterDisconnector, ParameterDisconnectorIspolnenie1Pol } });

            var rpd1 = new List<ProductDesignation>
            {
                ProductDesignationRpd,
                ProductDesignationRpdo
            };

            ProductDesignationRpd1P.Clone(new ProductDesignation { Designation = "-1п", Parameters = new List<Parameter> { ParameterDisconnectorZazemlPalPos, ParameterDisconnectorZazemlKulNeg }, Parents = rpd1.ToList() });
            ProductDesignationRpd1K.Clone(new ProductDesignation { Designation = "-1к", Parameters = new List<Parameter> { ParameterDisconnectorZazemlPalNeg, ParameterDisconnectorZazemlKulPos }, Parents = rpd1.ToList() });
            ProductDesignationRpd2.Clone(new ProductDesignation { Designation = "-2", Parameters = new List<Parameter> { ParameterDisconnectorZazemlPalPos, ParameterDisconnectorZazemlKulPos }, Parents = rpd1.ToList() });

            var rpd = new List<ProductDesignation>
            {
                ProductDesignationRpd,
                ProductDesignationRpdo,
                ProductDesignationRpd1P,
                ProductDesignationRpd1K,
                ProductDesignationRpd2
            };

            ProductDesignationRpdVoltage110.Clone(new ProductDesignation { Designation = "-110", Parameters = new List<Parameter> { ParameterVoltage110kV }, Parents = rpd.ToList() });
            ProductDesignationRpdVoltage220.Clone(new ProductDesignation { Designation = "-220", Parameters = new List<Parameter> { ParameterVoltage220kV }, Parents = rpd.ToList() });

            var rpdVol = new List<ProductDesignation>
            {
                ProductDesignationRpdVoltage110,
                ProductDesignationRpdVoltage220
            };

            ProductDesignationCurrentTerm25.Clone(new ProductDesignation { Designation = "-25", Parameters = new List<Parameter> { ParameterIterm25kA }, Parents = rpdVol.ToList() });
            ProductDesignationCurrentTerm40.Clone(new ProductDesignation { Designation = "-40", Parameters = new List<Parameter> { ParameterIterm40kA }, Parents = rpdVol.ToList() });
            ProductDesignationCurrentTerm50.Clone(new ProductDesignation { Designation = "-50", Parameters = new List<Parameter> { ParameterIterm50kA }, Parents = rpdVol.ToList() });


            ProductDesignationZro110.Clone(new ProductDesignation { Designation = "ЗРО-УЭТМ-110", Parameters = new List<Parameter> { ParameterEarthingSwitch, ParameterVoltage110kV } });
            ProductDesignationZro220.Clone(new ProductDesignation { Designation = "ЗРО-УЭТМ-220", Parameters = new List<Parameter> { ParameterEarthingSwitch, ParameterVoltage220kV } });

            ProductDesignationVab.Clone(new ProductDesignation { Designation = "ВАБ-УЭТМ", Parameters = new List<Parameter> { ParameterBvptVab } });
            ProductDesignationVab43.Clone(new ProductDesignation { Designation = "ВАБ-УЭТМ-43", Parameters = new List<Parameter> { ParameterBvptVab, ParameterBvptSeries43 } });
            ProductDesignationVab49.Clone(new ProductDesignation { Designation = "ВАБ-УЭТМ-49", Parameters = new List<Parameter> { ParameterBvptVab, ParameterBvptSeries49 } });
            ProductDesignationVab52.Clone(new ProductDesignation { Designation = "ВАБ-УЭТМ-52", Parameters = new List<Parameter> { ParameterBvptVab, ParameterBvptSeries52 } });
            ProductDesignationVab55.Clone(new ProductDesignation { Designation = "ВАБ-УЭТМ-55", Parameters = new List<Parameter> { ParameterBvptVab, ParameterBvptSeries55 } });

            ProductDesignationVat.Clone(new ProductDesignation { Designation = "ВАТ-УЭТМ", Parameters = new List<Parameter> { ParameterBvptVat } });
            ProductDesignationVat42.Clone(new ProductDesignation { Designation = "ВАТ-УЭТМ-42", Parameters = new List<Parameter> { ParameterBvptVat, ParameterBvptSeries42 } });
            ProductDesignationVat43.Clone(new ProductDesignation { Designation = "ВАТ-УЭТМ-43", Parameters = new List<Parameter> { ParameterBvptVat, ParameterBvptSeries43 } });
            ProductDesignationVat48.Clone(new ProductDesignation { Designation = "ВАТ-УЭТМ-48", Parameters = new List<Parameter> { ParameterBvptVat, ParameterBvptSeries48 } });
            ProductDesignationVat49.Clone(new ProductDesignation { Designation = "ВАТ-УЭТМ-49", Parameters = new List<Parameter> { ParameterBvptVat, ParameterBvptSeries49 } });

            var dpu = new List<ProductDesignation>
            {
                ProductDesignationVgt35,
                ProductDesignationVgt110,
                ProductDesignationVgt330,
                ProductDesignationVgt500,
                ProductDesignationVgt2201A1,
                ProductDesignationVeb110,
                ProductDesignationVeb220,
                ProductDesignationTrg35,
                ProductDesignationTrg110,
                ProductDesignationTrg220,
                ProductDesignationZng110,
                ProductDesignationZng220
            };

            ProductDesignationDpu2.Clone(new ProductDesignation { Designation = "II*", Parameters = new List<Parameter> { ParameterDpu2 }, Parents = dpu.ToList() });
            ProductDesignationDpu3.Clone(new ProductDesignation { Designation = "III", Parameters = new List<Parameter> { ParameterDpu3 }, Parents = dpu.ToList() });
            ProductDesignationDpu4.Clone(new ProductDesignation { Designation = "IV", Parameters = new List<Parameter> { ParameterDpu4 }, Parents = dpu.ToList() });

            var climat = new List<ProductDesignation>()
            {
                ProductDesignationCurrent0630,
                ProductDesignationCurrent1000,
                ProductDesignationCurrent1250,
                ProductDesignationCurrent1600,
                ProductDesignationCurrent2500,
                ProductDesignationCurrent3150,
                ProductDesignationCurrent4000,
                ProductDesignationDpu2,
                ProductDesignationDpu3,
                ProductDesignationDpu4
            };

            ProductDesignationClimatT1.Clone(new ProductDesignation { Designation = " Т1", Parameters = new List<Parameter> { ParameterClimatT1 }, Parents = climat.ToList() });
            ProductDesignationClimatU1Z.Clone(new ProductDesignation { Designation = " У1*", Parameters = new List<Parameter> { ParameterClimatU1Z }, Parents = climat.ToList() });
            ProductDesignationClimatUhl1Z.Clone(new ProductDesignation { Designation = " УХЛ1*", Parameters = new List<Parameter> { ParameterClimatUhl1Z }, Parents = climat.ToList() });
            ProductDesignationClimatUhl1.Clone(new ProductDesignation { Designation = " УХЛ1", Parameters = new List<Parameter> { ParameterClimatUhl1 }, Parents = climat.ToList() });
            ProductDesignationClimatU1.Clone(new ProductDesignation { Designation = " У1", Parameters = new List<Parameter> { ParameterClimatU1 }, Parents = climat.ToList() });
            ProductDesignationClimatHl1Z.Clone(new ProductDesignation { Designation = " ХЛ1*", Parameters = new List<Parameter> { ParameterClimatHl1Z }, Parents = climat.ToList() });
            ProductDesignationClimatHl1.Clone(new ProductDesignation { Designation = " ХЛ1", Parameters = new List<Parameter> { ParameterClimatHl1 }, Parents = climat.ToList() });

            var dpu2 = new List<ProductDesignation>
            {
                ProductDesignationDpu2,
                ProductDesignationDpu3,
                ProductDesignationDpu4
            };

            ProductDesignationCurrentBreaking12.Clone(new ProductDesignation { Designation = "-12,5", Parameters = new List<Parameter> { ParameterCurrentBreaking12kA }, Parents = new List<ProductDesignation> { ProductDesignationVgb35 } });
            ProductDesignationCurrentBreaking40.Clone(new ProductDesignation { Designation = "-40", Parameters = new List<Parameter> { ParameterCurrentBreaking40kA }, Parents = dpu2.ToList() });
            ProductDesignationCurrentBreaking50.Clone(new ProductDesignation { Designation = "-50", Parameters = new List<Parameter> { ParameterCurrentBreaking50kA }, Parents = dpu2.ToList() });

            var current = new List<ProductDesignation>
            {
                ProductDesignationCurrentBreaking12,
                ProductDesignationCurrentBreaking40,
                ProductDesignationCurrentBreaking50,
                ProductDesignationCurrentTerm25,
                ProductDesignationCurrentTerm40,
                ProductDesignationCurrentTerm50
            };

            ProductDesignationCurrent0630.Clone(new ProductDesignation { Designation = "/630", Parameters = new List<Parameter> { ParameterCurrent0630 }, Parents = current.ToList() });
            ProductDesignationCurrent1000.Clone(new ProductDesignation { Designation = "/1000", Parameters = new List<Parameter> { ParameterCurrent1000 }, Parents = current.ToList() });
            ProductDesignationCurrent1250.Clone(new ProductDesignation { Designation = "/1250", Parameters = new List<Parameter> { ParameterCurrent1250 }, Parents = current.ToList() });
            ProductDesignationCurrent1600.Clone(new ProductDesignation { Designation = "/1600", Parameters = new List<Parameter> { ParameterCurrent1600 }, Parents = current.ToList() });
            ProductDesignationCurrent2500.Clone(new ProductDesignation { Designation = "/2500", Parameters = new List<Parameter> { ParameterCurrent2500 }, Parents = current.ToList() });
            ProductDesignationCurrent3150.Clone(new ProductDesignation { Designation = "/3150", Parameters = new List<Parameter> { ParameterCurrent3150 }, Parents = current.ToList() });
            ProductDesignationCurrent4000.Clone(new ProductDesignation { Designation = "/4000", Parameters = new List<Parameter> { ParameterCurrent4000 }, Parents = current.ToList() });

            ProductDesignationSupervision.Clone(new ProductDesignation { Designation = "Шеф-монтаж", Parameters = new List<Parameter> { ParameterSupervision } });

            ParameterDesignationSupervisionDeadTankBreaker.Clone(new ProductDesignation { Designation = " бакового выключателя", Parameters = new List<Parameter> { ParameterSupervisionDeadTankBreaker }, Parents = new List<ProductDesignation> { ProductDesignationSupervision } });
            ParameterDesignationSupervisionLiveTankBreaker.Clone(new ProductDesignation { Designation = " колонкового выключателя", Parameters = new List<Parameter> { ParameterSupervisionLiveTankBreaker }, Parents = new List<ProductDesignation> { ProductDesignationSupervision } });
            ParameterDesignationSupervisionTransformerCurrent.Clone(new ProductDesignation { Designation = " трансформатора тока", Parameters = new List<Parameter> { ParameterSupervisionTransformerCurrent }, Parents = new List<ProductDesignation> { ProductDesignationSupervision } });
            ParameterDesignationSupervisionTransformerVoltage.Clone(new ProductDesignation { Designation = " трансформатора напряжения", Parameters = new List<Parameter> { ParameterSupervisionTransformerVoltage }, Parents = new List<ProductDesignation> { ProductDesignationSupervision } });

            var supervisionVoltage = new List<ProductDesignation>
            {
                ParameterDesignationSupervisionDeadTankBreaker,
                ParameterDesignationSupervisionLiveTankBreaker,
                ParameterDesignationSupervisionTransformerCurrent,
                ParameterDesignationSupervisionTransformerVoltage
            };

            ProductDesignationSupervision035kV.Clone(new ProductDesignation { Designation = " на 35 кВ", Parameters = new List<Parameter> { ParameterVoltage35kV }, Parents = supervisionVoltage.ToList() });
            ProductDesignationSupervision110kV.Clone(new ProductDesignation { Designation = " на 110 кВ", Parameters = new List<Parameter> { ParameterVoltage110kV }, Parents = supervisionVoltage.ToList() });
            ProductDesignationSupervision220kV.Clone(new ProductDesignation { Designation = " на 220 кВ", Parameters = new List<Parameter> { ParameterVoltage220kV }, Parents = supervisionVoltage.ToList() });
            ProductDesignationSupervision330kV.Clone(new ProductDesignation { Designation = " на 330 кВ", Parameters = new List<Parameter> { ParameterVoltage330kV }, Parents = supervisionVoltage.ToList() });
            ProductDesignationSupervision500kV.Clone(new ProductDesignation { Designation = " на 500 кВ", Parameters = new List<Parameter> { ParameterVoltage500kV }, Parents = supervisionVoltage.ToList() });

            var supervisionZone = new List<ProductDesignation>
            {
                ProductDesignationSupervision035kV,
                ProductDesignationSupervision110kV,
                ProductDesignationSupervision220kV,
                ProductDesignationSupervision330kV,
                ProductDesignationSupervision500kV
            };

            ProductDesignationSupervisionZone1.Clone(new ProductDesignation { Designation = " (зона 1)", Parameters = new List<Parameter> { ParameterSupervisionZone1 }, Parents = supervisionZone.ToList() });
            ProductDesignationSupervisionZone2.Clone(new ProductDesignation { Designation = " (зона 2)", Parameters = new List<Parameter> { ParameterSupervisionZone2 }, Parents = supervisionZone.ToList() });
            ProductDesignationSupervisionZone3.Clone(new ProductDesignation { Designation = " (зона 3)", Parameters = new List<Parameter> { ParameterSupervisionZone3 }, Parents = supervisionZone.ToList() });
        }

        #endregion

        #region Products

        public ProductBlock ProductBlockZip1;
        public Product ProductZip1;

        #if DEBUG

        public ProductBlock ProductBlockVgb35;
        public ProductBlock ProductBlockVeb110;
        public ProductBlock ProductBlockZng110;
        public ProductBlock ProductBlockDrivePprK;
        public ProductBlock ProductBlockSupervision;

        public Product ProductVeb110;
        public Product ProductZng110;
        public Product ProductBreakersDrivePprk;
        public Product ProductSupervision;

        #endif

        private void GenerateProductBlocs()
        {

            ProductBlockZip1.Clone(new ProductBlock
            {
                //DesignationSpecial = "Блок Групповой комплект ЗИП №1",
                Parameters = new List<Parameter> { ParameterDependentEquipment, ParameterDependentEquipmentTypeZip, ParameterZip1 },
                Prices = new List<SumOnDate> { new SumOnDate { Sum = 14050, Date = DateTime.Today } },
                StructureCostNumber = "???"
            });

            #if DEBUG

            ProductBlockVgb35.Clone(new ProductBlock
            {
                //DesignationSpecial = "Блок Выключатель баковый ВГБ-35",
                Parameters = new List<Parameter> { ParameterMainEquipment, ParameterBreaker, ParameterBreakerDeadTank, ParameterVoltage35kV },
                Prices = new List<SumOnDate> { new SumOnDate { Sum = 450000, Date = DateTime.Today } },
                StructureCostNumber = "123",
            });

            ProductBlockVeb110.Clone(new ProductBlock
            {
                //DesignationSpecial = "Блок Выключатель баковый ВЭБ-110",
                Parameters = new List<Parameter> { ParameterMainEquipment, ParameterBreaker, ParameterBreakerDeadTank, ParameterVoltage110kV, ParameterCurrent2500, ParameterCurrentBreaking40kA },
                Prices = new List<SumOnDate> { new SumOnDate { Sum = 2000000, Date = DateTime.Today } },
                StructureCostNumber = "321",
            });

            ProductBlockZng110.Clone(new ProductBlock
            {
                //DesignationSpecial = "Блок Трансформатор напряжения ЗНГ-110",
                Parameters = new List<Parameter> { ParameterMainEquipment, ParameterTransformer, ParameterTransformerVoltage, ParameterVoltage110kV },
                Prices = new List<SumOnDate> { new SumOnDate { Sum = 250000, Date = DateTime.Today.AddDays(-95) } },
                StructureCostNumber = "456"
            });

            ProductBlockDrivePprK.Clone(new ProductBlock
            {
                DesignationSpecial = "ППрК",
                Parameters = new List<Parameter> { ParameterProductParts, ParameterPartDrive, ParameterDrivePPrK, ParameterDrivesVoltage220V },
                Prices = new List<SumOnDate> { new SumOnDate { Sum = 200000, Date = DateTime.Today } },
                StructureCostNumber = "654"
            });

            ProductBlockSupervision.Clone(new ProductBlock
            {
                //DesignationSpecial = "Шеф-монтаж ВЭБ-110 (2 зона)",
                Parameters = new List<Parameter> { ParameterService, ParameterSupervision, ParameterSupervisionZone2, ParameterSupervisionDeadTankBreaker, ParameterVoltage110kV },
                Prices = new List<SumOnDate> { new SumOnDate { Sum = 60000, Date = DateTime.Today } },
                FixedCosts = new List<SumOnDate> { new SumOnDate { Sum = 120000, Date = DateTime.Today } },
                StructureCostNumber = "---"
            });

#endif
        }

        private void GenerateProducts()
        {
            ProductZip1.Clone(new Product
            {
                //DesignationSpecial = "ЗиП №1",
                ProductBlock = ProductBlockZip1
            });

#if DEBUG

            ProductVeb110.Clone(new Product
            {
                //DesignationSpecial = "ВЭБ-110",
                ProductBlock = ProductBlockVeb110,
                DependentProducts = new List<ProductDependent> { new ProductDependent { Product = ProductBreakersDrivePprk } }
            });

            ProductZng110.Clone(new Product
            {
                //DesignationSpecial = "Трансформатор напряжения ЗНГ-110",
                ProductBlock = ProductBlockZng110
            });

            ProductBreakersDrivePprk.Clone(new Product
            {
                //DesignationSpecial = "Привод выключателя",
                ProductBlock = ProductBlockDrivePprK
            });

            ProductSupervision.Clone(new Product
            {
                ProductBlock = ProductBlockSupervision
            });

#endif
        }

        #endregion
    }
}
