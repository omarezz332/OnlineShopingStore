﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace onlineShop.pages
{
    public partial class hello : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7Q14GL7\SQLEXPRESS;Initial Catalog=OnlineShopStore;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void signinButton_ServerClick(object sender, EventArgs e)
        {
            string user_name = enterEmail.Value;
            string pass = enterPassword.Value;
            SqlCommand cmd = new SqlCommand("loginAccess", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramU = new SqlParameter()
            {
                ParameterName = "@adminVal",
                Value = user_name
            };
            cmd.Parameters.Add(paramU);

            SqlParameter paramP = new SqlParameter()
            {
                ParameterName = "@passVal",
                Value = pass
            };
            cmd.Parameters.Add(paramP);
            con.Open();
            int cnt = (int)cmd.ExecuteScalar();
            con.Close();
            if (cnt == 1){Response.Redirect("adminpage.aspx");}
            else 
            {


            }

        }



    }
}