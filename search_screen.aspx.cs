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

public partial class search_screen : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection();

    protected void Page_Load(object sender, EventArgs e)
    {
        cn.ConnectionString = ConfigurationManager.ConnectionStrings["sqlconn"].ToString();
        cn.Open();
        if (Session.Contents["user_id"] != null)
        {
            if (Session.Contents["user_type"] == "user")
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from user_account where account_id='" + Session.Contents["user_id"].ToString() + "'";
                cmd.Connection = cn;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    img_profPic.ImageUrl = "image_view.aspx?id=" + ds.Tables[0].Rows[0].ItemArray[0].ToString();
                    lbl_name.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                    
                }
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
        //cmd.CommandText = "select account_id,name from user_account where name like '%" + txt_search.Text + "%' or phone like '" + txt_search.Text + "%'";
        cmd.CommandText = "select account_id,name from user_account where account_id  not in (select friend_id from friend_list where account_id='" + Session.Contents["user_id"].ToString() + "') and account_id not in (select friend_id from friend_request where sender_id='" + Session.Contents["user_id"].ToString() + "') and account_id not in(select sender_id from friend_request where friend_id='" + Session.Contents["user_id"].ToString() + "') and account_id not in(select block_id from block_list where acc_id='" + Session.Contents["user_id"].ToString() + "') and account_id <> '" + Session.Contents["user_id"].ToString() + "' and (name like '%" + txt_search.Text + "%' or phone like '" + txt_search.Text + "%')";
        //cmd.CommandText = "select account_id,name from user_account where  name like '%"+txt_search.Text +"%' or phone like '"+ txt_search.Text +"%'";
        cmd.Connection = cn;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);

        if (ds.Tables[0].Rows.Count > 0)
        {

            grd_data.DataSource = ds;
            grd_data.DataBind();
            grd_data.HeaderRow.Visible = false;
        }
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        load_data();
        load_hidden();
    }
    protected void grd_data_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int idx = int.Parse(e.CommandArgument.ToString());

        if (e.CommandName == "req")
        {
            string str = "insert into friend_request values(";
            str = str + "'" + Session.Contents["user_id"].ToString() + "',";
            str = str + "'" + grd_hide.Rows[idx].Cells[0].Text + "',";
            str = str + "'" + DateTime.Now.ToString() + "')";

            SqlCommand cmd = new SqlCommand(str, cn);
            cmd.ExecuteNonQuery();
            load_data();
            load_hidden();
        }
        if (e.CommandName == "details")
        {
            string sndr = grd_hide.Rows[idx].Cells[0].Text;
            Session.Contents["friend"] = "no";
            Response.Redirect("user_details.aspx?person=" + sndr);
        }
    }
    private void load_hidden()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select account_id,name from user_account where account_id  not in (select friend_id from friend_list where account_id='" + Session.Contents["user_id"].ToString() + "') and account_id not in (select friend_id from friend_request where sender_id='" + Session.Contents["user_id"].ToString() + "') and account_id not in(select sender_id from friend_request where friend_id='" + Session.Contents["user_id"].ToString() + "') and account_id not in(select block_id from block_list where acc_id='" + Session.Contents["user_id"].ToString() + "') and account_id <> '" + Session.Contents["user_id"].ToString() + "' and (name like '%" + txt_search.Text + "%' or phone like '" + txt_search.Text + "%')";
        //cmd.CommandText = "select account_id,name from user_account where name like '%" + txt_search.Text + "%' or phone like '" + txt_search.Text + "%'";
        cmd.Connection = cn;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);

        if (ds.Tables[0].Rows.Count > 0)
        {

            grd_hide.DataSource = ds;
            grd_hide.DataBind();
            
        }
    }
}
