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

public partial class report_page : System.Web.UI.Page
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
    protected void btn_report_Click(object sender, EventArgs e)
    {
        string sl_no = "";
        SqlCommand cmd_id = new SqlCommand();
        cmd_id.CommandText = "select max(sl_no) from mal_acc_report";
        cmd_id.Connection = cn;

        SqlDataAdapter da_id = new SqlDataAdapter(cmd_id);
        DataSet ds_id = new DataSet();
        da_id.Fill(ds_id);

        if (ds_id.Tables[0].Rows[0].ItemArray[0].ToString() == "")
        {
            sl_no = "R00001";
        }
        else
        {
            string old_id = ds_id.Tables[0].Rows[0].ItemArray[0].ToString();
            int d = int.Parse(old_id.Substring(1)) + 1;
            sl_no = "R" + d.ToString().PadLeft(5, '0');

        }

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = cn;
        string str = "insert into mal_acc_report values('" + sl_no + "','" + Session.Contents["user_id"].ToString() + "','" + Request.QueryString["person"].ToString() + "','" + txt_report.Text + "')";
        cmd.CommandText = str;
        cmd.ExecuteNonQuery();

        Response.Redirect("friend_list.aspx");
    }
}
