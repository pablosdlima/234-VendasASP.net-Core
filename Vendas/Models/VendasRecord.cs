using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vendas.Models.Enum;

namespace Vendas.Models
{
    public class VendasRecord
    {
        public int ID { get; set; }
        public DateTime Data { get; set; }
        public double Amount { get; set; }
        public VendasStatus Status { get; set; }
        public Vendedor Vendedor { get; set; }

        public VendasRecord()
        {

        }

        public VendasRecord(int iD, DateTime data, double amount, VendasStatus status, Vendedor vendedor)
        {
            ID = iD;
            Data = data;
            Amount = amount;
            Status = status;
            Vendedor = vendedor;
        }
    }
}
