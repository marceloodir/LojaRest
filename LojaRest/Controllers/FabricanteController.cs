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
            string create_string = create_table(entrada);
            if (create_string != null)
            {
                strings.Add(create_string);
                String string_insert = insert_table(entrada);
                foreach (var f in fabricantes)
                {
                    strings.Add(String.Format(string_insert, f.Id, f.Descricao));
                }
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


        private string create_table(string nomedobanco)
        {
            Models.DBStringsDataContext dc = new Models.DBStringsDataContext();
            try
            {
                Models.database banco = (from f in dc.database where f.name == nomedobanco select f).Single();
                Models.table tabela = banco.table.Single();
                return tabela.create_string;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private string insert_table(string nomedobanco)
        {
            Models.DBStringsDataContext dc = new Models.DBStringsDataContext();
            try
            {
                Models.database banco = (from f in dc.database where f.name == nomedobanco select f).Single();
                Models.table tabela = banco.table.Single();
                return tabela.insert_string;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
