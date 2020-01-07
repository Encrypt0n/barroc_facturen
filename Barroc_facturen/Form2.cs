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



                //CustomerEmaillbl.Text = customerCombobox.Text;
                //customerCombobox.Items.Add(customeridCombobox.Text);


                //customeridCombobox.Text = release.i

                invoiceComboBox.Items.Add(release);








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
            LeaseIDlbl.Text = "Lease ID: " + invoices.companydetail.lease[contractComboBox.SelectedIndex].invoice.lease_id.ToString();

            Pricelbl.Text = "Prijs " + invoices.companydetail.lease[contractComboBox.SelectedIndex].invoice.prijs.ToString();

            FinalPayDatelbl.Text = "Uiterlijke betaaldatum " + invoices.companydetail.lease[contractComboBox.SelectedIndex].invoice.uiterlijke_betaaldatum.ToString();

            if (invoices.companydetail.lease[contractComboBox.SelectedIndex].invoice.betaald_op != null)
            {
                PaymentFinishedlbl.Text = "Datum voltooide betaling " + invoices.companydetail.lease[contractComboBox.SelectedIndex].invoice.betaald_op.ToString();
            }
            else
            {
                PaymentFinishedlbl.Text = "";
            }
            lease_id = invoices.companydetail.lease[contractComboBox.SelectedIndex].invoice.lease_id;
            invoice_id = invoices.companydetail.lease[contractComboBox.SelectedIndex].invoice.id;

        }

      
        
      

        private void invoiceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GitHubRelease invoices = (GitHubRelease)invoiceComboBox.SelectedItem;

            contractComboBox.Items.Clear();
            contractComboBox.Text = "";


            foreach (var item in invoices.companydetail.lease)
            {
                contractComboBox.Items.Add(item);
            }
        }

        private void contractComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {


            GitHubRelease invoices = (GitHubRelease)invoiceComboBox.SelectedItem;

            showinvoicedata(invoices);
        }

        private void updatePayDateButton_Click(object sender, EventArgs e)
        {
            var request = (HttpWebRequest)WebRequest.Create("http://localhost:8000/api/post2");

            var postData = "thing0=" + invoice_id;
            postData += "&thing1=" + dateTimePicker1.Value.ToString("yyyy/MM/dd");


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
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }
    }
}
