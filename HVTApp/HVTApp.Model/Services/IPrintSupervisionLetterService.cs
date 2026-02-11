using System;
using System.Collections.Generic;
using HVTApp.Model.POCOs;

namespace HVTApp.Model.Services
{
    public interface IPrintSupervisionLetterService
    {
        void PrintSupervisionLetter(
            IEnumerable<Supervision> supervisions, 
            string supervisionContractNumber,
            DateTime supervisionContractDate, 
            Document letter, 
            string path = "");
    }
}