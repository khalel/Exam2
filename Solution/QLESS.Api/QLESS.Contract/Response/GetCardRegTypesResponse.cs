using QLESS.Contract.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLESS.Contract.Response
{
    public class GetCardRegTypesResponse
    {
        public IEnumerable<CardRegType> CardRegTypes { get; set; }
    }
}
