using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNIT.ProjetoEstag.Exercicio2.Negocio.DTO
{
    public class UsuarioDTO
    {
        public string Nome { get; private set; }
        public string Sexo { get; private set; }
        public string EstadoCivil { get; private set; }
        public int? Id { get; set; }
        public UsuarioDTO(string nome, string sexo, string estadoCivil)
        {
            Nome = nome;
            Sexo = sexo;
            EstadoCivil = estadoCivil;
        }
    }
}
