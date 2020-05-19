using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vendas.Models
{
    public class Vendedor
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public double BaseSalarial { get; set; }
        public DateTime Data { get; set; }
        public Departamento Departamento { get; set; } //vendedor possui 1 departamento
        public int DepartamentoId { get; set; } //criando FK
        public ICollection<VendasRecord> Vendas { get; set; } = new List<VendasRecord>(); //permite o acesso a coleção dos objs

        public Vendedor()
        {
        }

        public Vendedor(int iD, string nome, string email, double baseSalarial, DateTime data, Departamento departamento)
        {
            ID = iD;
            Nome = nome;
            Email = email;
            BaseSalarial = baseSalarial;
            Data = data;
            Departamento = departamento;
        }

        public void AddVendas(VendasRecord vr)
        {
            Vendas.Add(vr);
        }

        public void RemoveVendas(VendasRecord vr)
        {
            Vendas.Remove(vr);
        }

        public double TotalVendas(DateTime inicio, DateTime fim)
        {
            return Vendas.Where(vr => vr.Data >= inicio && vr.Data <= fim).Sum(vr => vr.Amount);
        }
    }
}
