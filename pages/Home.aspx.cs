using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.IO;
namespace onlineShop
{
    public partial class Home : System.Web.UI.Page
    {
         loginClass obj = new loginClass();
        string cameFromCompany;    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Application["logOut"] != null)
            {
                if (Application["logOut"].ToString() == "1")
                {
                    account.Style["display"] = "none";
                    userNameStored.InnerHtml = "Login";
                    login.Style["display"] = "block";
                    rege.Style["display"] = "block";
                    cart.Style["display"] = "none";
                    Application["name"] = null;
                    Application["logOut"] = null;

                }
            }

            cart.Style.Add("display", "none");
            account.Style.Add("display", "none");
            if (Application["value"] != null)
                cameFromCompany = Application["value"].ToString();
            // open Register Drob Down
            if (Session["openRegisterMenue"] != null)
            {
                if ((int)Session["openRegisterMenue"] == 1)
                {
                    showArea.Attributes["class"] = showArea.Attributes["class"].ToString() + " show";
                    rege.Attributes["class"] = rege.Attributes["class"].ToString() + " show";
                    navbarDropdownMenuLink.Attributes["aria-expanded"] = "true";
                    Session["openRegisterMenue"] = null;
                }
            }
            if (Application["name"] != null)
            {//check com or user to remove home and open mange page of company :)
                string name = Application["name"].ToString();
                if (name != null)
                {
                    rege.Style.Add("display", "none");
                    login.Style.Add("display", "none");
                    cart.Style.Remove("display");
                    account.Style.Remove("display");
                    accountName.InnerHtml = name;

                }
            }
            else if (Application["please"] != null || cameFromCompany == "1")
            {
                log.Attributes["class"] = log.Attributes["class"].ToString() + " show";

                login.Attributes["class"] = login.Attributes["class"].ToString() + " show";
                logs.Attributes["aria-expanded"] = "true";
                Application["please"] = null;
                Application["value"] = null;
               if (cameFromCompany!="1")
                lo.InnerHtml = " <h6 style='color:red;'>please login first to see your cart</h6> ";
                cameFromCompany = "0";

            }
       
 
        }

        protected void signinButton_ServerClick(object sender, EventArgs e)
        {
           
                string email = enterEmail.Value;
                string password = enterPassword.Value;
                obj.login(email,password);                
                if(Application["name"]!=null)
                        userNameStored.InnerHtml = "Welcome "+Application["name"].ToString();
          }
        

       
        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            if (obj.getCount() == 0)
                Response.Redirect("company.aspx");
            else
            {
               
                Response.Redirect("user.aspx"); 
            }
        }

        protected void Unnamed_ServerClick1(object sender, EventArgs e)
        {
            account.Style["display"] = "none";
            userNameStored.InnerHtml = "Login";
            login.Style["display"] = "block";
            rege.Style["display"] = "block";
            cart.Style["display"] = "none";
            Application["name"] = null;
          //  Response.Redirect("Home.aspx");
        }

        protected void showRegisterMenue_ServerClick(object sender, EventArgs e)
        {
            Session["openRegisterMenue"] = 1;
            Response.Redirect("Home.aspx");   

        }

        protected void gotoMobile_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("mobile.aspx");
        }

        protected void gotoLaptop_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("laptops.aspx");
        }

        protected void searchProduct_ServerClick(object sender, EventArgs e)
        {
            searchClass findProducts = new searchClass();
            string value = searchText.Value;
            findProducts.searchButton(value);
        }
    }
}
