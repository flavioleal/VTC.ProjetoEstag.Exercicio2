using DNIT.ProjetoEstag.Exercicio2.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNIT.ProjetoEstag.Exercicio2.Negocio.BO
{
    public class SexoBO
    {
        Prova_EstagEntities context = new Prova_EstagEntities();

        // Método que carrega o Sexo

        public List<SEXO> CarregarSexo()
        {
            List<SEXO> sexos = context.SEXO.ToList();
            return sexos;
        }

        /// <summary>
        /// Buscar Id por nome Sexo
        /// </summary>
        public int BuscarIdSexo(string descricaoSexo)
        {
            SEXO sexo = context.SEXO.FirstOrDefault(n => n.DS_SEXO.Equals(descricaoSexo));
            if (sexo != null)
            {
                return sexo.ID_SEXO;
            }
            return 0;
        }

        public SEXO ObterSexoPorId(int? id)
        {
            var result = context.SEXO.Find(id);
            return result;
        }
    }
}
