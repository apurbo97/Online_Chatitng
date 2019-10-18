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

public partial class malicious_acc_report : System.Web.UI.Page
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

                load_details();
            }
        }
        else
        {
            Response.Redirect("home_login.aspx");
        }
    }
    private void load_details()
    {
        string str = "select * from mal_acc_report";
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = str;
        cmd.Connection = cn;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grd_data.DataSource = ds;
        grd_data.DataBind();

    }
    protected void grd_data_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int idx = int.Parse(e.CommandArgument.ToString());
        if (e.CommandName == "r_by")
        {
            Session.Contents["pg"] = "msc";
            LinkButton lnk = (LinkButton)grd_data.Rows[idx].Cells[2].Controls[0];
            Response.Redirect("user_details_admin.aspx?person=" + lnk.Text);
        }
        if (e.CommandName == "r_to")
        {
            Session.Contents["pg"] = "msc";
            LinkButton lnk = (LinkButton)grd_data.Rows[idx].Cells[3].Controls[0];
            Response.Redirect("user_details_admin.aspx?person=" + lnk.Text);
        }
        if (e.CommandName == "de")
        {
            LinkButton lnk = (LinkButton)grd_data.Rows[idx].Cells[3].Controls[0];
            string str = "update user_account set acc_status='Inactive' where account_id='" + lnk.Text + "'";
            SqlCommand cmd = new SqlCommand(str, cn);
            cmd.ExecuteNonQuery();
            load_details();
        }
    }
}
