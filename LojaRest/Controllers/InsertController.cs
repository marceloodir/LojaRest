using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LojaRest.Controllers
{
    public class InsertController : ApiController
    {
        private Models.DBStringsDataContext dc = new Models.DBStringsDataContext();
        private Models.database banco;

        public string Get(string strbanco, string strtabela = null, string strinsert = null)
        {
            setBanco(strbanco);

            if (banco == null)
            {
                return null;
            }
            else
            {
                if (strinsert != null)
                {
                    InsertRemote(strinsert);
                    return null;
                }

                if (strtabela != null)
                {
                    return GerarInsertString();
                }
            }
            return null;
        }

        private string GerarInsertString()
        {
            Models.table tabela = (from t in banco.table where t.name == "fabricante" select t).Single();
            return tabela.insert_string;
        }

        private void InsertRemote(string cmd)
        {
            try
            {
                SqlConnection connection = new SqlConnection(banco.connection);
                connection.Open();
                SqlCommand sqlCmd = new SqlCommand(cmd, connection);
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception)
            {                
                throw;
            }
        }

        private void setBanco(string entrada)
        {
            try
            {
                banco = (from f in dc.database where f.name == entrada select f).Single();
            }
            catch (Exception)
            {
                banco = null;
            }
        }

    }
}
