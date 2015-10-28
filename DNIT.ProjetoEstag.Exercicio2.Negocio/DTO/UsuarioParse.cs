using DNIT.ProjetoEstag.Exercicio2.Dados;
using DNIT.ProjetoEstag.Exercicio2.Negocio.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNIT.ProjetoEstag.Exercicio2.Negocio.DTO
{
    public class UsuarioParse
    {
        private readonly EstadoCivilBO _estadoCivilBO;
        private readonly SexoBO _sexoBo;
        public UsuarioParse()
        {
            _estadoCivilBO = new EstadoCivilBO();
            _sexoBo = new SexoBO();

        }

        public UsuarioDTO Parse(USUARIO usuario)
        {
            var estadoCivil = _estadoCivilBO.ObterEstadoCivilPorId(usuario.ID_ESTADO_CIVIL);
            var sexo = _sexoBo.ObterSexoPorId(usuario.ID_SEXO);
            var usuarioDTO = new UsuarioDTO(usuario.DS_USUARIO, ParseSexo(sexo.DS_SEXO), estadoCivil.DS_ESTADO_CIVIL);
            usuarioDTO.Id = usuario.ID_USUARIO;
            
            return usuarioDTO;
        }

        public USUARIO Parse(UsuarioDTO usuario)
        {
            USUARIO usuarioLocal = new USUARIO();

            usuarioLocal.DS_USUARIO = usuario.Nome;
            usuarioLocal.ID_SEXO = _sexoBo.BuscarIdSexo(usuario.Sexo);
            usuarioLocal.ID_ESTADO_CIVIL = _estadoCivilBO.BuscaIdEstado(usuario.EstadoCivil);

           
            return usuarioLocal;
        }

        public List<UsuarioDTO> Parse(List<USUARIO> usuarios)
        {

            
            return usuarios.Select(x => Parse(x)).ToList();
            
        }

        private string ParseSexo(string sexo)
        {
            switch (sexo.ToUpper())
            {
                case "M":
                    return "Masculino";
                case "F":
                    return "Feminino";
                default:
                    return "Outro";

            }

        }

        public List<USUARIO> Parse(List<UsuarioDTO> usuarios)
        {
            return usuarios.Select(x => Parse(x)).ToList();
        }
    }
 }

