﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace LojaRest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Remova a codificação de comentário da seguinte linha de código para habilitar o suporte a consultas de ações com um tipo de retorno IQueryable ou IQueryable<T>.
            // Para evitar o processamento de consultas inesperadas ou mal-intencionadas, use as configurações de validação em QueryableAttribute para validar as consultas de entrada.
            // Para obter mais informações, acesse http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // Para desativar o rastreamento no seu aplicativo, remova a seguinte linha de código ou a transforme em comentários
            // Para obter mais informações, consulte: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }
    }
}
