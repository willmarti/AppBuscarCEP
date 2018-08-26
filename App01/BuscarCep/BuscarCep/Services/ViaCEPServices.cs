using BuscarCep.Services.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace BuscarCep.Services
{
    public class ViaCEPServices
    {
        private static string EnderecoUrlCEP = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            WebClient wc = new WebClient();

            string Conteudo = wc.DownloadString(string.Format(EnderecoUrlCEP, cep));

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            //if (end == null) return null;

            return end;
        }
    }
}
