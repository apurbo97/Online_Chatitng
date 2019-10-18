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
using System.IO;

public partial class new_user : System.Web.UI.Page
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
                txt_user_id.Text = Session.Contents["user_id"].ToString();
                load_details();
            }
        }
        else
        {
            //Response.Redirect("home_login.aspx");
        }
    }
    private void load_details()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select * from user_account where account_id='" + txt_user_id.Text + "'";
        cmd.Connection = cn;
        
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txt_name.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            txt_address.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            txt_city.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
            txt_state.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
            txt_phone.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
            txt_email.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
            drp_gender.SelectedValue = ds.Tables[0].Rows[0].ItemArray[7].ToString();
            txt_dob.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();

        }
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select * from user_account where account_id='" + txt_user_id.Text + "'";
        cmd.Connection = cn;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            SqlCommand cmd_save = new SqlCommand();
            cmd_save.Connection = cn;
            string str = "update user_account set ";
            str += "name='" + txt_name.Text + "',";
            str += "address='" + txt_address.Text + "',";
            str += "city='" + txt_city.Text + "',";
            str += "state='" + txt_state.Text + "',";
            str += "phone='" + txt_phone.Text + "',";
            str += "email='" + txt_email.Text + "',";
            str += "gender='" + drp_gender.SelectedValue + "',";
            str += "dob='" + txt_dob.Text + "'";
            if(txt_password.Text!="")
            str += ",password='" + txt_password.Text + "'";
            if (FileUpload1.FileName != "")
            {
                Stream fs = FileUpload1.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                str += ",prof_pic=@imgitem ";
                cmd_save.Parameters.Add("@imgitem", SqlDbType.Binary).Value = bytes;

            }
            
            str += " where account_id='" + txt_user_id.Text + "'";

            cmd_save.CommandText = str;
            cmd_save.ExecuteNonQuery();
            Response.Write("<script language='javascript'> alert('profile updated....')</script>");
            

        }
        else
        {
            string acc_id = "";
            SqlCommand cmd_id = new SqlCommand();
            cmd_id.CommandText = "select max(account_id) from user_account";
            cmd_id.Connection = cn;

            SqlDataAdapter da_id = new SqlDataAdapter(cmd_id);
            DataSet ds_id = new DataSet();
            da_id.Fill(ds_id);

            if (ds_id.Tables[0].Rows[0].ItemArray[0].ToString() == "")
            {
                acc_id = "USER0001";
            }
            else
            {
                string old_id = ds_id.Tables[0].Rows[0].ItemArray[0].ToString();
                int d = int.Parse(old_id.Substring(4)) + 1;
                acc_id = "USER" + d.ToString().PadLeft(4, '0');

            }
            txt_user_id.Text = acc_id;


            SqlCommand cmd_save = new SqlCommand();
            cmd_save.Connection = cn;
            string str = "insert into user_account values(";
            str += "'" + txt_user_id.Text + "',";
            str += "'" + txt_name.Text + "',";
            str += "'" + txt_address.Text + "',";
            str += "'" + txt_city.Text + "',";
            str += "'" + txt_state.Text + "',";
            str += "'" + txt_phone.Text + "',";
            str += "'" + txt_email.Text + "',";
            str += "'" + drp_gender.SelectedValue + "',";
            str += "'" + txt_dob.Text + "',";
            str += "'" + txt_password.Text + "',";
            str += "'in',";
            str += "'Active',";
            str += "'"+DateTime.Today.ToString()+"',";
            
            if (FileUpload1.FileName != "")
            {
                Stream fs = FileUpload1.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                str += "@imgitem)";

                cmd_save.Parameters.Add("@imgitem", SqlDbType.Binary).Value = bytes;

            }
            else
            {
                str += "null)";
            }

            cmd_save.CommandText = str;
            cmd_save.ExecuteNonQuery();
            Response.Write("<script language='javascript'> alert('Date saved....')</script>");
            Session.Contents["user_id"] = txt_user_id.Text;
            Session.Contents["user_type"] = "user";
            Response.Redirect("user_profile.aspx");

        }
    }
    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("user_profile.aspx");
    }
}
