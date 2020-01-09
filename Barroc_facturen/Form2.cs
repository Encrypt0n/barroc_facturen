using Newtonsoft.Json;
using RESTfulAPIConsume.Constants;
using RESTfulAPIConsume.Model;
using RESTfulAPIConsume.RequestHandlers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barroc_facturen
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();


            IRequestHandler httpWebRequestHandler = new HttpWebRequestHandler();
            IRequestHandler webClientRequestHandler = new WebClientRequestHandler();
            IRequestHandler httpClientRequestHandler = new HttpClientRequestHandler();
            IRequestHandler restSharpRequestHandler = new RestSharpRequestHandler();
            IRequestHandler serviceStackRequestHandler = new ServiceStackRequestHandler();
            IRequestHandler flurlRequestHandler = new FlurlRequestHandler();
            IRequestHandler dalSoftRequestHandler = new DalSoftRequestHandler();


            var response = GetReleases(httpWebRequestHandler);

            var githubReleases = JsonConvert.DeserializeObject<List<GitHubRelease>>(response);








            foreach (var release in githubReleases)
            {



               

                customerComboBox.Items.Add(release);








            }

        }

        public static string GetReleases(IRequestHandler requestHandler)
        {
            return requestHandler.GetReleases(RequestConstants.Url);
        }

        public int lease_id;
        public int invoice_id;

        private void showinvoicedata(GitHubRelease invoices)
        {
            /* de labels worden gevuld met het Leasenummer, prijs, uiterlijke betaaldatum
               en eventueel de datum van daadwerkelijke betaling. 
               Om te kijken welke facturen bij welk contract horen kijken we naar de SelectedIndex van de combobox */


            LeaseIDlbl.Text = "Lease ID: " + invoices.companydetail.lease[contractComboBox.SelectedIndex].invoice[invoiceComboBox.SelectedIndex].lease_id.ToString();

            Pricelbl.Text = "Prijs " + invoices.companydetail.lease[contractComboBox.SelectedIndex].invoice[invoiceComboBox.SelectedIndex].prijs.ToString();

            FinalPayDatelbl.Text = "Uiterlijke betaaldatum " + invoices.companydetail.lease[contractComboBox.SelectedIndex].invoice[invoiceComboBox.SelectedIndex].uiterlijke_betaaldatum.ToString();

            if (invoices.companydetail.lease[contractComboBox.SelectedIndex].invoice[invoiceComboBox.SelectedIndex].betaald_op != null)
            {
                PaymentFinishedlbl.Text = "Datum voltooide betaling " + invoices.companydetail.lease[contractComboBox.SelectedIndex].invoice[invoiceComboBox.SelectedIndex].betaald_op.ToString();
            }
            else
            {
                PaymentFinishedlbl.Text = "";
            }
            lease_id = invoices.companydetail.lease[contractComboBox.SelectedIndex].invoice[invoiceComboBox.SelectedIndex].lease_id;
            invoice_id = invoices.companydetail.lease[contractComboBox.SelectedIndex].invoice[invoiceComboBox.SelectedIndex].id;

        }

      
        
      

       

        private void contractComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            GitHubRelease invoices = (GitHubRelease)customerComboBox.SelectedItem;


            invoiceComboBox.Items.Clear();
            invoiceComboBox.Text = "";

            /* aan de hand van de gekozen waarde in de contract combobox worden de bijbehorende 
             facturen in de facturen combobox gestopt */
            foreach (var item in invoices.companydetail.lease[contractComboBox.SelectedIndex].invoice)
            {
                invoiceComboBox.Items.Add("Invoice: " + item.id);
            }
        }

        private void updatePayDateButton_Click(object sender, EventArgs e)
        {
            var request = (HttpWebRequest)WebRequest.Create("http://localhost:8000/api/post2");

            var postData = "thing0=" + invoice_id;
            postData += "&thing1=" + dateTimePicker1.Value.ToString("yyyy/MM/dd"); //thing1 bevat de betaaldatum wat doorgegeven wordt naar Laravel 


            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            // data word met een post request naar Laravel verzonden
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }

        private void customerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GitHubRelease contracts = (GitHubRelease)customerComboBox.SelectedItem;

            contractComboBox.Items.Clear();
            contractComboBox.Text = "";

            foreach (var item in contracts.companydetail.lease)
            {
                contractComboBox.Items.Add("Contract: " + item.id);
            }

           
        }

        private void invoiceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GitHubRelease invoices = (GitHubRelease)customerComboBox.SelectedItem;

            showinvoicedata(invoices);
        }
    }
}
