using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LojaRest.Controllers
{
    //Controlador pensado apenas para tratar os INSERTS (locais e remotos)
    public class InsertController : ApiController
    {
        private Models.DBStringsDataContext dc = new Models.DBStringsDataContext();
        private Models.database banco;

        public string Get(string strbanco, string strtabela = null, string strinsert = null)
        {
            setBanco(strbanco);

            if (banco == null)
            {
                //parâmetro necessário
                return null;
            }
            else
            {
                //parâmetro necessário para inserção no banco, string SQL INSERT pronta.
                if (strinsert != null)
                {
                    InsertRemote(strinsert);
                    return null;
                }

                //parâmetro necessário para gerar uma string SQL INSERT no banco local do dispositivo móvel.
                if (strtabela != null)
                {
                    return GerarInsertString();
                }
            }
            return null;
        }

        private string GerarInsertString()
        {
            //Nome fixado, ainda não buscando do banco de configurações
            Models.table tabela = (from t in banco.table where t.name == "fabricante" select t).Single();
            return tabela.insert_string;
        }

        private void InsertRemote(string cmd)
        {
            // Executando diretamente sem tratamento, pode ser MUITO perigoso, pensar nesse problema depois.
            SqlConnection connection = new SqlConnection(banco.connection);
            connection.Open();
            SqlCommand sqlCmd = new SqlCommand(cmd, connection);
            sqlCmd.ExecuteNonQuery();
            connection.Close();
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
