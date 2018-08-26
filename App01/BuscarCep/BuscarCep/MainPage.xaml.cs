using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using BuscarCep.Services.Models;
using BuscarCep.Services;
namespace BuscarCep
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            btnBuscarCep.Clicked += BuscaCEP;
        }

        public void BuscaCEP(Object sender, EventArgs args)
        {

            if (IsValidCEP(txtCEP.Text))
            {
                try
                {
                    Endereco end = ViaCEPServices.BuscarEnderecoViaCEP(txtCEP.Text);

                    if (end!=null)
                    {
                        lblResultado.Text = string.Format("Endereço: {0} - {1} {2}/{3}", end.logradouro, end.bairro, end.localidade, end.uf);
                    }
                    else
                    {
                        DisplayAlert("Erro", "Endereço não encontrado para o CEP informado", "OK");
                    }
                }catch(Exception e)
                {
                    DisplayAlert("Erro", "Não foi possível buscar o CEP, segue:" + e.Message, "OK");
                }
            }
        }

        public bool IsValidCEP(string cep)
        {
            bool Error = true;

            if (txtCEP.Text.Length != 8)
            {
                DisplayAlert("Erro", "CEP inválido! O campo CEP deve conter 8 caracteres", "OK");
                Error = false;
            }
            else
            {
                int Novocep = 0;

                if (!int.TryParse(txtCEP.Text, out Novocep))
                {
                    DisplayAlert("Erro", "CEP inválido! O campo CEP deve conter apenas números", "OK");
                    Error = false;
                }
            }

            return Error;
        }
    }
}
