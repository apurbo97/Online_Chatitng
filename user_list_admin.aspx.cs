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

public partial class user_list_admin : System.Web.UI.Page
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
                load_data();
            }
        }
        else
        {
            Response.Redirect("home_login.aspx");
        }

    }
    private void load_data()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select * from user_account where name like '%" + txt_search.Text + "%' or phone like '%" + txt_search + "%' or email like '%" + txt_search.Text + "%'";
        cmd.Connection = cn;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);

        if (ds.Tables[0].Rows.Count > 0)
        {

            grd_data.DataSource = ds;
            grd_data.DataBind();

            grd_hide.DataSource = ds;
            grd_hide.DataBind();
            grd_data.HeaderRow.Visible = false;

            int i;
            for (i = 0; i < grd_data.Rows.Count; i++)
            {
                LinkButton lnk = (LinkButton)grd_data.Rows[i].Cells[0].Controls[0];
                lnk.Text = "Change(" + grd_hide.Rows[i].Cells[11].Text + ")";
            }
        }
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        load_data();
    }
    protected void grd_data_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int idx = int.Parse(e.CommandArgument.ToString());

        if (e.CommandName == "status")
        {
            string str;
            if (grd_hide.Rows[idx].Cells[11].Text == "Active")
            {
                str = "update user_account set acc_status='Inactive' where account_id='" + grd_hide.Rows[idx].Cells[0].Text + "'";
            }
            else
            {
                str = "update user_account set acc_status='Active' where account_id='" + grd_hide.Rows[idx].Cells[0].Text + "'";
            }

            SqlCommand cmd = new SqlCommand(str, cn);
            cmd.ExecuteNonQuery();
            load_data();
            
        }
        if (e.CommandName == "details")
        {
            string sndr = grd_hide.Rows[idx].Cells[0].Text;
            Session.Contents["pg"] = "list";
            Response.Redirect("user_details_admin.aspx?person=" + sndr);
        }
    }
}
