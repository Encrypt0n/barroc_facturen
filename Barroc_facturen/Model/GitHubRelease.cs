using Newtonsoft.Json;
using ServiceStack.DataAnnotations;
using System.Collections.Generic;

namespace RESTfulAPIConsume.Model
{
    //public class company { }
    public class Companydetail
    {
        public override string ToString()
        {
            return name;
        }


        public int id { get; set; }
        public int user_id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string postcode { get; set; }
        public string telefoonnummer { get; set; }

        public string email { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }

        //public Quotation quotations { get; set; }


        public List<Quotation> quotations { get; set; }

        public List<Lease> lease { get; set; }

        //public List<Invoice> invoice { get; set; }


    }

    public class Lease
    {
        public override string ToString()
        {
            return "Invoice: " + invoice;
        }
        public int id { get; set; }
        public int lease_type_id { get; set; }
        public int customer_id { get; set; }
        public int finance_id { get; set; }
        public string monthly_costs { get; set; }
        //public string start_date { get; set; }
        //public string end_date { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }

        public List<Invoice> invoice { get; set; }

        //public List<Invoice> invoice_id { get; set; }

        //public List<Lease> lease { get; set; }
    }

    public class Invoice
    {
        public override string ToString()
        {
            return "Invoice " + id.ToString();
        }

        public int id { get; set; }
        public int lease_id { get; set; }
        public int prijs { get; set; }
        public string betaald_op { get; set; }
        public string uiterlijke_betaaldatum { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }

    public class Quotation
    {

        public override string ToString()
        {
            return "Quotation: " + id;
        }
        public int id { get; set; }
        public string companyname { get; set; }

        public string contactpersonname { get; set; }

        public string contactpersonemail { get; set; }

        public string contactpersonphone { get; set; }

        public string companyaddress { get; set; }

        public string italian_light { get; set; }

        public string italian { get; set; }

        public string italian_deluxe { get; set; }

        public string italian_deluxe_special { get; set; }

        public string espresso_beneficio { get; set; }

        public string yellow_bourbon_brasil { get; set; }

        public string espresso_roma { get; set; }

        public string red_honey_honduras { get; set; }




    }

    public class GitHubRelease
    {
        public override string ToString()
        {
            return "Company: " + companydetail;
        }
        public int id { get; set; }
        public int role_id { get; set; }

        //public List<string> name { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public object email_verified_at { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public Companydetail companydetail { get; set; }
        //public Lease lease { get; set; }
        //public Invoice invoice { get; set; }

        //public Quotation quotation { get; set; }
    }






}
