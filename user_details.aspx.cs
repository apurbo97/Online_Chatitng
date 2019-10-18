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

public partial class user_details : System.Web.UI.Page
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
        string str = "select account_id,name,address+', '+city +', '+state,left(convert(varchar,dob,113),11) [DOB],email,phone from user_account where account_id='" + pr+"'";
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
        if (Session.Contents["friend"].ToString() == "no")
        {
            btn_friend.Text = "SEND REQUEST";
        }
        if (Session.Contents["friend"].ToString() == "req")
        {
            btn_friend.Text = "ACCEPT";
        }
        if (Session.Contents["friend"].ToString() == "yes")
        {
            btn_friend.Text = "UNFREND";
        }

    }

    protected void btn_block_Click(object sender, EventArgs e)
    {
        string str = "delete from friend_request where sender_id='" + Request.QueryString["person"].ToString() + "' and friend_id='" + Session.Contents["user_id"].ToString() +"'";
        SqlCommand cmd = new SqlCommand();
        cmd.Connection=cn;
        cmd.CommandText = str;
        cmd.ExecuteNonQuery();

        str = "delete from friend_list where (account_id='" + Session.Contents["user_id"].ToString() + "' and friend_id='" + Request.QueryString["person"].ToString() + "') or (friend_id='" + Session.Contents["user_id"].ToString() + "' and account_id='" + Request.QueryString["person"].ToString() + "')";
        cmd.CommandText = str;
        cmd.ExecuteNonQuery();

        string sl_no = "";
        SqlCommand cmd_id = new SqlCommand();
        cmd_id.CommandText = "select max(sl_no) from block_list";
        cmd_id.Connection = cn;

        SqlDataAdapter da_id = new SqlDataAdapter(cmd_id);
        DataSet ds_id = new DataSet();
        da_id.Fill(ds_id);

        if (ds_id.Tables[0].Rows[0].ItemArray[0].ToString() == "")
        {
            sl_no = "B00001";
        }
        else
        {
            string old_id = ds_id.Tables[0].Rows[0].ItemArray[0].ToString();
            int d = int.Parse(old_id.Substring(1)) + 1;
            sl_no = "B" + d.ToString().PadLeft(5, '0');

        }

        str = "insert into block_list values('" + sl_no + "','" + Session.Contents["user_id"].ToString() + "','" + Request.QueryString["person"].ToString() + "')";
        cmd.CommandText = str;
        cmd.ExecuteNonQuery();

        Response.Redirect("friend_list.aspx");


    }
    protected void btn_report_Click(object sender, EventArgs e)
    {
        Response.Redirect("report_page.aspx?person=" + Request.QueryString["person"].ToString());
    }
    protected void btn_friend_Click(object sender, EventArgs e)
    {
        if (btn_friend.Text == "UNFREND")
        {
            string str = "delete from friend_list where (account_id='" + Session.Contents["user_id"].ToString() + "' and friend_id='" + Request.QueryString["person"].ToString() + "') or (friend_id='" + Session.Contents["user_id"].ToString() + "' and account_id='" + Request.QueryString["person"].ToString() + "')";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = str;
            cmd.ExecuteNonQuery();
            Response.Redirect("friend_list.aspx");
        }
        if (btn_friend.Text == "SEND REQUEST")
        {
            string str = "insert into friend_request values(";
            str = str + "'" + Session.Contents["user_id"].ToString() + "',";
            str = str + "'" + Request.QueryString["person"].ToString() + "',";
            str = str + "'" + DateTime.Now.ToString() + "')";

            SqlCommand cmd = new SqlCommand(str, cn);
            cmd.ExecuteNonQuery();
        }
        if (btn_friend.Text == "ACCEPT")
        {
            string str = "insert into friend_list values('" + Request.QueryString["person"].ToString() + "','" + Session.Contents["user_id"].ToString() + "')";
            SqlCommand cmd = new SqlCommand(str, cn);
            cmd.ExecuteNonQuery();

            str = "insert into friend_list values('" + Session.Contents["user_id"].ToString() + "','" + Request.QueryString["person"].ToString() + "')";
            cmd.CommandText = str;
            cmd.ExecuteNonQuery();


            str = "delete from friend_request where sender_id='" + Request.QueryString["person"].ToString() + "' and friend_id='" + Session.Contents["user_id"].ToString() + "'";
            cmd.CommandText = str;
            cmd.ExecuteNonQuery();
        }
    }
}
