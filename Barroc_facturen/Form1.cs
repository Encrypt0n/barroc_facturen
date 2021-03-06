﻿using RESTfulAPIConsume.Constants;
using RESTfulAPIConsume.RequestHandlers;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RESTfulAPIConsume.Model;
using System.Net.Mail;
using Newtonsoft.Json.Linq;
using Flurl.Http;
using System.Net;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.xml;
using System.Web;
using System.Reflection;

namespace Barroc_facturen
{
    public partial class Form1 : Form
    {
        public Form1()
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

            var githubReleases = JsonConvert.DeserializeObject <List<GitHubRelease>>(response);

          


            






            foreach (var release in githubReleases)
    
            {
             


                CustomerEmaillbl.Text = customerCombobox.Text;
               

                customerCombobox.Items.Add(release);

                


            }

         




            }

        public static string GetReleases(IRequestHandler requestHandler)
        {
            return requestHandler.GetReleases(RequestConstants.Url);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
            dateTimePicker1.Value = DateTime.Now;

          
            



        }

        private void emailButton_Click(object sender, EventArgs e)
        {
            string path;
            path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

            MailMessage mail = new MailMessage("laraveltestbas@gmail.com", "basrights19@gmail.com");
            mail.Subject = "Factuur Barroc Intense";
            mail.Body = "Hierbij uw facuur voor voor de contractperiode waarvoor u heeft gekozen.                                              Met vriendelijke groet,                                              Barroc Intense";
            mail.Attachments.Add(new Attachment(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Factuur.pdf")));

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "laraveltestbas@gmail.com",
                Password = "Welkom12!"
            };

            smtpClient.EnableSsl = true;
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object s,
                    System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                    System.Security.Cryptography.X509Certificates.X509Chain chain,
                    System.Net.Security.SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };

            smtpClient.Send(mail);
        }

        private void customerCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GitHubRelease customer = (GitHubRelease)customerCombobox.SelectedItem;
           

            
        }

        public int customer_id;
     
        public int lease_id;
        public int price;
        
        

        private void showcustomerdata(GitHubRelease customer)
        {
            
            CustomerEmaillbl.Text = customer.companydetail.email;
            CustomerNamelbl.Text = customer.companydetail.name;

            

        }

    
        private void PDFbutton_Click(object sender, EventArgs e)
        {
            string path;
          
            
            Document document = new Document();
            path = Path.Combine("/", "Factuur.pdf");
            using (FileStream fileStream = new FileStream("Factuur.pdf", FileMode.Create))
            {
                PdfWriter writer = PdfWriter.GetInstance(document, fileStream);
                document.Open();
                PdfContentByte canvas = writer.DirectContent;
                BaseFont baseFont = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
                canvas.SetFontAndSize(baseFont, 8f);
                ColumnText column = new ColumnText(canvas);
                column.SetSimpleColumn(300, 500, 60, 800); //width, height, xPos, yPos
                if (CustomerEmaillbl.Text != null)
                {
                    Chunk c1 = new Chunk("Email:" + CustomerEmaillbl.Text + "                                     ");
                    column.AddText(c1);
                }
                if (CustomerNamelbl.Text != null)
                {
                    Chunk c2 = new Chunk("Name:" + CustomerNamelbl.Text + "                                              ");
                    column.AddText(c2);
                }
                if (italian_lightlbl.Text != null)
                {
                    Chunk c3 = new Chunk(italian_lightlbl.Text + "                                     ");
                    column.AddText(c3);
                }
                if (italianlbl.Text != null)
                {
                    Chunk c4 = new Chunk(italianlbl.Text + "                                                         ");
                    column.AddText(c4);
                }
                if (italiandeluxelbl != null)
                {
                    Chunk c5 = new Chunk(italiandeluxelbl.Text + "                                                        ");
                    column.AddText(c5);
                }
                if (italiandeluxespeciallbl.Text != null)
                {
                    Chunk c6 = new Chunk(italiandeluxespeciallbl.Text + "                                             ");
                    column.AddText(c6);
                }
                if (espressobeneficiolbl.Text != null)
                {
                    Chunk c7 = new Chunk(espressobeneficiolbl.Text + "                                     ");
                    column.AddText(c7);
                }
                if (yellowbourbonbrasillbl.Text != null)
                {
                    Chunk c8 = new Chunk(yellowbourbonbrasillbl.Text + "                                     ");
                    column.AddText(c8);
                }
                if (espressoromalbl.Text != null)
                {
                    Chunk c9 = new Chunk(espressoromalbl.Text + "                                     ");
                    column.AddText(c9);
                }
                if (redhoneyhonduraslbl.Text != null)
                {
                    Chunk c10 = new Chunk(redhoneyhonduraslbl.Text + "                                                                                                                                                           ");
                    column.AddText(c10);
                }
                Chunk c11 = new Chunk("Totaal: " + "€" + price + "                                                   ");
                column.AddText(c11);
                


                column.Go();
                document.Close();
            }

            /* de Chunk stukjes bevatten de informatie van alle labels en dat wordt
               als een kolom in een pdf gestopt */





        }

        private void databaseUpdateButton_Click(object sender, EventArgs e)
        {
            var request = (HttpWebRequest)WebRequest.Create("http://localhost:8000/api/post");

            var postData = "thing0=" + lease_id;
            postData += "&thing1=" + dateTimePicker1.Value.ToString("yyyy/MM/dd");
            
            postData += "&thing3=" + price;  // 
            

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

        private void customerCombobox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
          
            GitHubRelease customer = (GitHubRelease)customerCombobox.SelectedItem;

            
            showcustomerdata(customer);

            quotationComboBox.Items.Clear();
            quotationComboBox.Text = "";

            foreach (var item in customer.companydetail.quotations)
            {
                quotationComboBox.Items.Add(item);
            }
            // aan de hand van de gekozen klant worden de bijbehorende offertes in de quotation combobox gestopt

        }

        private void overviewButton_Click(object sender, EventArgs e)
        {
            Form2 overview = new Form2();
            overview.ShowDialog();
        }

        public void showquotationdata(GitHubRelease customer)
        {
            if (customer.companydetail != null)
            {

                if (customer.companydetail.quotations != null)
                {
                    // de labels worden gevuld met het de bestelde producten + prijs en de klantgegevens

                    if (customer.companydetail.quotations[quotationComboBox.SelectedIndex].italian_light != null)
                    {
                        
                        italian_lightlbl.Text = customer.companydetail.quotations[quotationComboBox.SelectedIndex].italian_light + " x " + "Italian Light: " + "€" + int.Parse(customer.companydetail.quotations[quotationComboBox.SelectedIndex].italian_light) * 280;
                    }
                    if (customer.companydetail.quotations[quotationComboBox.SelectedIndex].italian != null)
                    {
                      
                        italianlbl.Text = customer.companydetail.quotations[quotationComboBox.SelectedIndex].italian + " x " + "Italian: " + "€" + int.Parse(customer.companydetail.quotations[quotationComboBox.SelectedIndex].italian) * 290;
                    }
                    if (customer.companydetail.quotations[quotationComboBox.SelectedIndex].italian_deluxe != null)
                    {
                       
                        italiandeluxelbl.Text = customer.companydetail.quotations[quotationComboBox.SelectedIndex].italian_deluxe + " x " + "Italian Deluxe: " + "€" + int.Parse(customer.companydetail.quotations[quotationComboBox.SelectedIndex].italian_deluxe) * 350;
                    }
                    if (customer.companydetail.quotations[quotationComboBox.SelectedIndex].italian_deluxe_special != null)
                    {
                       
                        italiandeluxespeciallbl.Text = customer.companydetail.quotations[quotationComboBox.SelectedIndex].italian_deluxe_special + " x " + "Italian Deluxe Special: " + "€" + int.Parse(customer.companydetail.quotations[quotationComboBox.SelectedIndex].italian_deluxe_special) * 375;
                    }
                    if (customer.companydetail.quotations[quotationComboBox.SelectedIndex].espresso_beneficio != null)
                    {
                       
                        espressobeneficiolbl.Text = customer.companydetail.quotations[quotationComboBox.SelectedIndex].espresso_beneficio + " x " + "Espresso Beneficio: " + "€" + int.Parse(customer.companydetail.quotations[quotationComboBox.SelectedIndex].espresso_beneficio) * 21.60;
                    }
                    if (customer.companydetail.quotations[quotationComboBox.SelectedIndex].yellow_bourbon_brasil != null)
                    {
                        
                        yellowbourbonbrasillbl.Text = customer.companydetail.quotations[quotationComboBox.SelectedIndex].yellow_bourbon_brasil + " x " + "Yellow Bourbon Brasil: " + "€" + int.Parse(customer.companydetail.quotations[quotationComboBox.SelectedIndex].yellow_bourbon_brasil) * 23.20;
                    }
                    if (customer.companydetail.quotations[quotationComboBox.SelectedIndex].espresso_roma != null)
                    {
                       
                        espressoromalbl.Text = customer.companydetail.quotations[quotationComboBox.SelectedIndex].espresso_roma + " x " + "Espresso Roma: " + "€" + int.Parse(customer.companydetail.quotations[quotationComboBox.SelectedIndex].espresso_roma) * 20.80;
                    }
                    if (customer.companydetail.quotations[quotationComboBox.SelectedIndex].red_honey_honduras != null)
                    {
                       
                        redhoneyhonduraslbl.Text = customer.companydetail.quotations[quotationComboBox.SelectedIndex].red_honey_honduras + " x " + "Red Honey Honduras: " + "€" + int.Parse(customer.companydetail.quotations[quotationComboBox.SelectedIndex].red_honey_honduras) * 27.80;
                    }
                    
                    lease_id = customer.companydetail.lease[quotationComboBox.SelectedIndex].id;
                    price = int.Parse(customer.companydetail.lease[quotationComboBox.SelectedIndex].monthly_costs);




                }
            }
        }

        private void quotationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GitHubRelease customer = (GitHubRelease)customerCombobox.SelectedItem;


            showquotationdata(customer);


        }
    }

}
