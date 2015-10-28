using DNIT.ProjetoEstag.Exercicio2.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNIT.ProjetoEstag.Exercicio2.Negocio.BO
{
    public class UsuarioBO
    {
        private readonly Prova_EstagEntities context;

        public UsuarioBO()
        {
            context = new Prova_EstagEntities();
        }

        public void Salvar(USUARIO usuario)
        {
            context.USUARIO.Add(usuario);
            context.SaveChanges();
        }

        public List<USUARIO> Pesquisar(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {

                return context.USUARIO.ToList();
            }
            else
            {

                return context.USUARIO.Where(n => n.DS_USUARIO.Contains(nome)).ToList();
            }


        }

        public void Deletar(string nome)
        {
            USUARIO usuario = this.Pesquisar(nome).FirstOrDefault();

            if (usuario != null)
            {
                context.USUARIO.Remove(usuario);
                context.SaveChanges();
            }
        }
    }
}
