using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LojaRest.Controllers
{
    public class FabricanteController : ApiController
    {

        public List<string> Get(string entrada)
        {
            List<string> strings = new List<string>();
            IEnumerable<Models.Fabricante> fabricantes = this.lendobanco();

            strings.Add(create_table(entrada));
            String string_insert = insert_table(entrada);
            foreach (var f in fabricantes)
            {
               strings.Add(String.Format(string_insert, f.Id, f.Descricao));
            }
            return strings;
        }

        public string teste()
        {
            return "testando com a testa....";
        }

        private IEnumerable<Models.Fabricante> lendobanco()
        {
            Models.LojaDataContext dc = new Models.LojaDataContext();
            var r = from f in dc.Fabricante select f;
            return r.ToList();
        }

        private Boolean selecionandoBanco(string nomedobanco)
        {
            Models.StringsBancoDataContext dc = new Models.StringsBancoDataContext();
            var r = from f in dc.databases select f.name == nomedobanco;
            
            if (r != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string create_table(string nomedobanco)
        {
            Models.StringsBancoDataContext dc = new Models.StringsBancoDataContext();
            try
            {
                Models.databases banco = (from f in dc.databases where f.name == nomedobanco select f).Single();
                Models.create_table tabela = banco.create_table.Single();
                return tabela.@string;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private string insert_table(string nomedobanco)
        {
            Models.StringsBancoDataContext dc = new Models.StringsBancoDataContext();
            try
            {
                Models.databases banco = (from f in dc.databases where f.name == nomedobanco select f).Single();
                Models.create_table tabela = banco.create_table.Single();
                return tabela.insert_table.@string;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
