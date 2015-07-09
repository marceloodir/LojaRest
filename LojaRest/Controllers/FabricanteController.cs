using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LojaRest.Controllers
{
    public class FabricanteController : ApiController
    {

        public string Get(string entrada)
        {
            string saida = "";
            IEnumerable<Models.Fabricante> fabricantes = this.lendobanco();

            System.Diagnostics.Debug.WriteLine("#####################################Retorno## " + entrada);
            if (entrada == "tabela")
            {
                saida = "CREATE TABLE fabricante(id INTEGER PRIMARY KEY, descricao VARCHAR(50));#";
                foreach (var f in fabricantes)
                {
                    saida += "INSERT INTO fabricante (id,descricao) VALUES (" + f.Id + ",'" + f.Descricao + "');#";
                }
            }
            return saida;
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

    }
}
