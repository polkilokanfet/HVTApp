using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using HVTApp.Model;
using HVTApp.Model.POCOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HVTApp.Services.GetProductService.Tests
{
    [TestClass]
    public class ParameterSelectorTests
    {
        private ParameterGroup _groupEqType;

        private Parameter _parameterBreaker, _parameterTransformator;
        private Parameter _parameterV110, _parameterV220, _parameterV500;
        private Parameter _c2500, _c3150;
        private ParameterSelector _parameterSelectorEqType;

        [TestInitialize]
        public void Init()
        {
            _groupEqType = new ParameterGroup();
            _parameterBreaker = new Parameter { ParameterGroup = _groupEqType };
            _parameterTransformator = new Parameter { ParameterGroup = _groupEqType };

            var voltage = new ParameterGroup();
            _parameterV110 = new Parameter {ParameterGroup = voltage}.AddRequiredPreviousParameters(new[] { _parameterBreaker });
            _parameterV220 = new Parameter {ParameterGroup = voltage}.AddRequiredPreviousParameters(new[] { _parameterBreaker });
            _parameterV500 = new Parameter {ParameterGroup = voltage}.AddRequiredPreviousParameters(new[] { _parameterBreaker });

            var current = new ParameterGroup();
            _c2500 = new Parameter {ParameterGroup = current}.
                AddRequiredPreviousParameters(new[] { _parameterBreaker, _parameterV110 }).
                AddRequiredPreviousParameters(new[] { _parameterBreaker, _parameterV220 });
            _c3150 = new Parameter {ParameterGroup = current}.
                AddRequiredPreviousParameters(new[] { _parameterBreaker, _parameterV110 }).
                AddRequiredPreviousParameters(new[] { _parameterBreaker, _parameterV220 }).
                AddRequiredPreviousParameters(new[] { _parameterBreaker, _parameterV500 });

            _parameterSelectorEqType = new ParameterSelector(new []{_parameterBreaker, _parameterTransformator}, _parameterBreaker);
        }

        [TestMethod]
        public void ParameterSelectorHasPreSelectedParameter()
        {
            Assert.IsTrue(_parameterSelectorEqType.SelectedParameterFlaged != null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "¬ыбран параметр не из списка.")]
        public void ParameterSelectorSelectedParameterException()
        {
            Assert.IsFalse(_parameterSelectorEqType.ParametersFlaged.Select(x => x.Parameter).Contains(_parameterV110));
            _parameterSelectorEqType.SelectedParameterFlaged = new ParameterFlaged(_parameterV110, false);
        }

        [TestMethod]
        public void ParameterSelectorSelectedParameterIsNotActual()
        {
            var selectedParameter = _parameterSelectorEqType.SelectedParameterFlaged = _parameterSelectorEqType.ParametersFlaged.Last();
            var parameterWithActualFlag = _parameterSelectorEqType.ParametersFlaged.Single(x => Equals(selectedParameter, x));
            parameterWithActualFlag.IsActual = false;

            //как только выбранный параметр потер€л свою актуальность, мен€ем его на актуальный
            Assert.IsFalse(Equals(_parameterSelectorEqType.SelectedParameterFlaged, selectedParameter));
        }

        [TestMethod]
        public void ParameterSelectorAutoSelectParameter()
        {
            foreach (var parameterWithActualFlag in _parameterSelectorEqType.ParametersFlaged)
                parameterWithActualFlag.IsActual = false;
            Assert.IsTrue(_parameterSelectorEqType.SelectedParameterFlaged == null);

            var pwaf = _parameterSelectorEqType.ParametersFlaged.Last();
            pwaf.IsActual = true;
            Assert.IsTrue(Equals(_parameterSelectorEqType.SelectedParameterFlaged, pwaf));
        }
    }
}