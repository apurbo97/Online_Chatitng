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

public partial class user_details_admin : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        cn.ConnectionString = ConfigurationManager.ConnectionStrings["sqlconn"].ToString();
        cn.Open();
        if (Session.Contents["user_id"] != null)
        {
            if (Session.Contents["user_type"] == "admin")
            {

                string pr = Request.QueryString["person"].ToString();
                load_details(pr);
            }
        }
        else
        {
            Response.Redirect("home_login.aspx");
        }
    }
    private void load_details(string pr)
    {
        string str = "select account_id,name,address+', '+city +', '+state,left(convert(varchar,dob,113),11) [DOB],email,phone from user_account where account_id='" + pr + "'";
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = str;
        cmd.Connection = cn;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            img_person.ImageUrl = "image_view.aspx?id=" + ds.Tables[0].Rows[0].ItemArray[0].ToString();
            lbl_person_name.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString().ToUpper();
            lbl_address.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString().ToUpper();
            lbl_date.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
            lbl_email.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
            lbl_phone.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        }
    }
    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("malicious_acc_report.aspx");
    }
}
