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

public partial class friend_list : System.Web.UI.Page
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
                load_request();
                load_request_hide();

                load_friend();
            }
        }
        else
        {
            Response.Redirect("home_login.aspx");
        }
    }

    private void load_request()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select sender_id,name,send_date from friend_request f, user_account u where f.sender_id=u.account_id and f.friend_id='" + Session.Contents["user_id"].ToString() + "'";
        cmd.Connection = cn;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        grd_request.DataSource = ds;
        grd_request.DataBind();
        if (ds.Tables[0].Rows.Count > 0)
        {
            grd_request.HeaderRow.Visible = false;
        }
    }
    protected void grd_request_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int idx=int.Parse(e.CommandArgument.ToString());
        string sndr=grd_hide_request.Rows[idx].Cells[0].Text;

        if (e.CommandName == "acpt")
        {
            string str = "insert into friend_list values('" + sndr + "','" + Session.Contents["user_id"].ToString() + "')";
            SqlCommand cmd = new SqlCommand(str, cn);
            cmd.ExecuteNonQuery();

            str = "insert into friend_list values('" + Session.Contents["user_id"].ToString() + "','" + sndr + "')";
            cmd.CommandText = str;
            cmd.ExecuteNonQuery();
            
            
            str = "delete from friend_request where sender_id='" + sndr + "' and friend_id='" + Session.Contents["user_id"].ToString() + "'";
            cmd.CommandText = str;
            cmd.ExecuteNonQuery();
            load_request();
            load_request_hide();


        }
        if (e.CommandName == "rjct")
        {
            string str = "delete from friend_request where sender_id='" + sndr + "' and friend_id='" + Session.Contents["user_id"].ToString() + "'";
            SqlCommand cmd = new SqlCommand(str, cn);
            cmd.ExecuteNonQuery();
            load_request();
            load_request_hide();
        }
        if (e.CommandName == "details")
        {
            Session.Contents["friend"] = "req";
            Response.Redirect("user_details.aspx?person=" + sndr);
        }
        load_friend();
    }
    private void load_request_hide()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select sender_id,name,send_date from friend_request f, user_account u where f.sender_id=u.account_id and f.friend_id='" + Session.Contents["user_id"].ToString() + "'";
        cmd.Connection = cn;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);

        grd_hide_request.DataSource = ds;
        grd_hide_request.DataBind();
        
    }

    private void load_friend()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select f.friend_id,name from friend_list f,user_account u where f.friend_id=u.account_id and f.account_id='" + Session.Contents["user_id"].ToString() + "'";
        cmd.Connection = cn;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);

        grd_friends.DataSource = ds;
        grd_friends.DataBind();

        grd_hide_friend.DataSource = ds;
        grd_hide_friend.DataBind();
    }
    protected void grd_friends_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int idx = int.Parse(e.CommandArgument.ToString());
        string sndr = grd_hide_friend.Rows[idx].Cells[0].Text;
        if (e.CommandName == "chat")
        {
            Session.Contents["person"] = grd_hide_friend.Rows[idx].Cells[0].Text;
            Session.Contents["name"] = grd_hide_friend.Rows[idx].Cells[1].Text;
            Response.Redirect("chat_screen.aspx");
        }
        if (e.CommandName == "details")
        {
            Session.Contents["friend"] = "yes";
            Response.Redirect("user_details.aspx?person=" + sndr);
        }
    }
}
