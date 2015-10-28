using DNIT.ProjetoEstag.Exercicio2.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNIT.ProjetoEstag.Exercicio2.Negocio.BO
{
    /// <summary>
    /// 
    /// </summary>
    public class EstadoCivilBO
    {
        Prova_EstagEntities context = new Prova_EstagEntities();

        public List<ESTADO_CIVIL> Carregar()
        {
            List<ESTADO_CIVIL> estados = context.ESTADO_CIVIL.ToList();
            return estados;
        }

        public int BuscaIdEstado(string descricaoEstado)
        {
            ESTADO_CIVIL estado_civil = context.ESTADO_CIVIL.FirstOrDefault(n => n.DS_ESTADO_CIVIL.Equals(descricaoEstado));
            if (estado_civil != null)
            {
                return estado_civil.ID_ESTADO_CIVIL;
                
            }
            return 0;
    
        }

        public ESTADO_CIVIL ObterEstadoCivilPorId(int? id)
        {
            var result = context.ESTADO_CIVIL.Find(id);
            return result;
        }
    }
}
