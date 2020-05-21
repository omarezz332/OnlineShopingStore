using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public struct cartproduct
{
    public string namme;
    public byte[] pic;
    public double price;
    public string des;
}
namespace onlineShop.pages
{
    public partial class Cart : System.Web.UI.Page
    {
        static List<cartproduct> cart_pro = new List<cartproduct>();
        
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7Q14GL7\SQLEXPRESS;Initial Catalog=OnlineShopStore;Integrated Security=True");
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string get = (string)Application["name"];
            cart.Style.Add("display", "none");
            account.Style.Add("display", "none");
           
           
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
                    Fill_Data();
                    showProducts();
                } 

            }
            else
            {
                Application["please"] = "please login first";
                Response.Redirect("home.aspx");

            }

        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            

        }

        protected void Unnamed_ServerClick1(object sender, EventArgs e)
        {
            Response.Redirect("user.aspx");

        }

        protected void Unnamed_ServerClick2(object sender, EventArgs e)
        {

        }
       protected void Fill_Data()
        {
            if (Application["name"] == null) return;
            string namee = Application["name"].ToString();
            SqlCommand com = new SqlCommand("getIdOfUser", con);
            com.CommandType=CommandType.StoredProcedure;
            SqlParameter paramN = new SqlParameter()
            {
                ParameterName = "@user_N",
                Value=namee

            };
            com.Parameters.Add(paramN);
           con.Open();
           int idOfUser = (int)com.ExecuteScalar();
           con.Close();

           SqlCommand cmd = new SqlCommand("getCartProducts", con);
           cmd.CommandType = CommandType.StoredProcedure;
           SqlParameter paramQ = new SqlParameter() {
               ParameterName = "@userIDN",
               Value=idOfUser
           };
           cmd.Parameters.Add(paramQ);
           con.Open();
           SqlDataReader rdr = cmd.ExecuteReader();
           cartproduct pro = new cartproduct();
           while(rdr.Read())
           {
               pro.namme = (string)rdr["Product_Name"];
               pro.pic = (byte[])rdr["Product_Pic"];
               pro.des = (string)rdr["Descriptions"];
               pro.price = Convert.ToDouble(rdr["Product_Price"]);
               cart_pro.Add(pro);
           }
           rdr.Close();
           con.Close();
        }
        protected void showProducts()
       {

           string add = "";
           int i = 0;
           for(int q=0;q<cart_pro.Count;q++)
           {

               add += @" <div id='divv" + i + "' class='d-inline-block bg-white bo-2 'data-toggle='tooltip'  data-placement='top'  title='price:" + cart_pro[q].price + @"'>
                        <img src='data:image/png;base64," + Convert.ToBase64String(cart_pro[q].pic) +
                               @"'  class='d-block ' /> <div class='d-block'>
                         <h6 class='d-inline-block align-top'>" +cart_pro[q].namme+ @"</h6>
                       </div><a class='btn btn-primary' href='getValueOfProduct.aspx?id=" + i + "&key=" + cart_pro[q].namme + "&page=mobile' value='" + cart_pro[q].namme + "'>Add To Cart</a ></div>";
               i++;

           }
           adds.InnerHtml = add;
       }
    }
}