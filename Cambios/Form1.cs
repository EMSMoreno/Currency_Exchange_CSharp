using Cambios.Modelos;
using Cambios.Servicos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Cambios
{
    public partial class Form1 : Form
    {
        #region Atributos

        private List<Rate> Rates;

        private NetworkService networkService;

        private ApiService apiService;

        private DialogService dialogService;

        private DataService dataService;

        #endregion

        public Form1()
        {
            InitializeComponent();
            networkService = new NetworkService();
            apiService = new ApiService();
            dialogService = new DialogService();
            dataService = new DataService();
            LoadRates();
        }

        private async void LoadRates()
        {
            bool load;

            LabelResultado.Text = "A atualizar taxas...";

            var connection = networkService.CheckConnection();

            if (!connection.IsSuccess) //Consoante a conexao, corre os locais ou da API
            {
                LoadLocalRates();
                load = false;
            }
            else
            {
                await LoadApiRates();
                load = true;
            }

            if (Rates == null || Rates.Count == 0)
            {
                LabelResultado.Text = "Não há ligação à Internet" + Environment.NewLine +
                                      "e não foram previamente carregadas as taxas." +
                                      Environment.NewLine + "Tente mais tarde!";

                LabelStatus.Text = "Primeira inicialização deverá ter ligação à Internet";
                return;
            }

            ComboBoxOrigem.DataSource = Rates;
            ComboBoxOrigem.DisplayMember = "Name";

            //Corrige Bug da Microsoft
            ComboBoxDestino.BindingContext = new BindingContext();

            ComboBoxDestino.DataSource = Rates;
            ComboBoxDestino.DisplayMember = "Name";

            LabelResultado.Text = "Taxas Atualizadas";

            if (load)
            {
                LabelStatus.Text = string.Format("Taxas carregadas da internet em {0:F}", DateTime.Now);
            }
            else
            {
                LabelStatus.Text = "Taxas carregadas da Base de Dados";
            }

            ProgressBar1.Value = 100;

            ButtonConverter.Enabled = true;
            buttonTroca.Enabled = true;
        }

        private void LoadLocalRates()
        {
            Rates = dataService.GetData();
        }

        private async Task LoadApiRates()
        {
            ProgressBar1.Value = 0;

            var response = await apiService.GetRates("http://rates.somee.com", "/api/rates");
            //Passa Endereco base API + Controlador API

            if (response.IsSuccess)
            {
                Rates = (List<Rate>)response.Result;

                dataService.DeleteData();

                dataService.SaveData(Rates);
            }
            else
            {
                Rates = new List<Rate>();
            }
        }

        private void ButtonConverter_Click(object sender, EventArgs e)
        {
            Converter();
        }

        private void Converter()
        {
            if (string.IsNullOrEmpty(TextBoxValor.Text.Trim()))
            {
                dialogService.ShowMessage("Erro", "Insira um valor a converter.");
                return;
            }

            decimal valor;
            if (!decimal.TryParse(TextBoxValor.Text, out valor))
            {
                dialogService.ShowMessage("Erro de conversão", "Valor terá que ser numérico.");
                return;
            }

            if (ComboBoxOrigem.SelectedItem == null)
            {
                dialogService.ShowMessage("Erro", "Tem de escolher uma moeda a converter.");
                return;
            }

            if (ComboBoxDestino.SelectedItem == null)
            {
                dialogService.ShowMessage("Erro", "Tem de escolher uma moeda de destino para converter.");
                return;
            }

            var taxaOrigem = (Rate)ComboBoxOrigem.SelectedItem;

            var taxaDestino = (Rate)ComboBoxDestino.SelectedItem;

            var valorConvertido = valor / (decimal)taxaOrigem.TaxRate * (decimal)taxaDestino.TaxRate;

            LabelResultado.Text = string.Format("{0} {1:C2} = {2} {3:C2}",
                taxaOrigem.Code,
                valor,
                taxaDestino.Code,
                valorConvertido);
        }

        private void buttonTroca_Click(object sender, EventArgs e)
        {
            Troca();
        }

        private void Troca()
        {
            var aux = ComboBoxOrigem.SelectedItem;
            ComboBoxOrigem.SelectedItem = ComboBoxDestino.SelectedItem;
            ComboBoxDestino.SelectedItem = aux;
            Converter();
        }
    }
}