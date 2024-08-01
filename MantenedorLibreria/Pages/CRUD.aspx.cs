using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MantenedorLibreria.Pages
{
    public partial class CRUD : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public static string sId = "-1";
        public static string sOpc = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //obtener el ID
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"]!=null)
                {
                    sId = Request.QueryString["id"].ToString();
                    CargarDatos();
                    txtfecha.TextMode = TextBoxMode.DateTime;
                }
                if (Request.QueryString["op"] != null)
                {
                    sOpc = Request.QueryString["op"].ToString();
                    switch (sOpc)
                    {
                        case "C":
                            this.lbltitulo.Text = "Ingresar nuevo producto";
                            this.btncreate.Visible = true;
                            break;
                        case "R":
                            this.lbltitulo.Text = "Ver el producto";
                            this.txtnombre.Enabled = false;
                            this.txtcantidad.Enabled = false;
                            this.txtfecha.Enabled = false;
                            this.txtprecio.Enabled = false;
                            break;
                        case "U":
                            this.lbltitulo.Text = "Actualizar el producto";
                            this.btnupdate.Visible = true;
                            break;
                        case "D":
                            this.lbltitulo.Text = "Eliminar el producto";
                            this.btndelete.Visible = true;
                            this.txtnombre.Enabled = false;
                            this.txtcantidad.Enabled = false;
                            this.txtfecha.Enabled = false;
                            this.txtprecio.Enabled = false;
                            break;
                    }
                }
            }
        }
        void CargarDatos()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("sp_read", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = sId;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            txtnombre.Text = row[1].ToString();
            txtcantidad.Text = row[2].ToString();
            txtprecio.Text = row[3].ToString();
            DateTime d = (DateTime)row[4];
            txtfecha.Text = d.ToString("d/M/yyyy");
            con.Close();
         
        }

        protected void btncreate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_create", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre",SqlDbType.VarChar).Value = txtnombre.Text;
            cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = txtcantidad.Text;
            cmd.Parameters.Add("@precio", SqlDbType.Int).Value = txtprecio.Text;
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = txtfecha.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Index.aspx");
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_update", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = sId;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = txtnombre.Text;
            cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = int.Parse(txtcantidad.Text);
            cmd.Parameters.Add("@precio", SqlDbType.Int).Value = int.Parse(txtprecio.Text);
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = txtfecha.Text;

            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Index.aspx");
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_delete", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = sId;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Index.aspx");
        }

        protected void btnvolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}