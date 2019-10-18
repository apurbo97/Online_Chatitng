using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class home_login : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        cn.ConnectionString = ConfigurationManager.ConnectionStrings["sqlconn"].ToString();
        cn.Open();
    }
    protected void btn_login_Click(object sender, EventArgs e)
    {
        if (txt_email.Text.ToUpper() == "ADMIN")
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from t_admin where admin_id='" + txt_email.Text + "' and pwd = '" + txt_password.Text + "'";
            cmd.Connection = cn;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session.Contents["user_id"] = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                Session.Contents["user_type"] = "admin";
                Response.Redirect("user_list_admin.aspx");
            }
            else
            {
                Response.Write("<script language='javascript'> alert('Wrong user id or password')</script>");
            }
        }
        else
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from user_account where email='" + txt_email.Text + "' and password = '" + txt_password.Text + "' and acc_status='Active'";
            cmd.Connection = cn;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session.Contents["user_id"] = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                Session.Contents["user_type"] = "user";
                Response.Redirect("user_profile.aspx");
            }
            else
            {
                Response.Write("<script language='javascript'> alert('Wrong email id or password')</script>");
            }
        }

    }
    protected void btn_new_Click(object sender, EventArgs e)
    {
        Response.Redirect("new_user.aspx");
    }
}
