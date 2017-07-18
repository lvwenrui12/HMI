using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace hmitype
{
    public partial class fenlei : UserControl
    {

        private JObject fenleijo;

        private List<string> fenleiid1 = new List<string>();

        private List<string> fenleiid2 = new List<string>();

        private List<string> fenleiid3 = new List<string>();

        private List<string> fenleiid4 = new List<string>();

      
        private ComboBox comboBox1;

        private ComboBox comboBox2;

        private Label label2;

        private Label label3;

        private ComboBox comboBox3;

        private Label label4;

        private ComboBox comboBox4;

        private Label label1;

        private Panel panel1;
        public fenlei()
        {
            InitializeComponent();
        }
        public string getid()
        {
            string result = "";
            if (this.comboBox4.Visible)
            {
                result = this.fenleiid4[this.comboBox4.SelectedIndex];
            }
            else if (this.comboBox3.Visible)
            {
                result = this.fenleiid3[this.comboBox3.SelectedIndex];
            }
            else if (this.comboBox2.Visible)
            {
                result = this.fenleiid2[this.comboBox2.SelectedIndex];
            }
            else if (this.comboBox1.Items.Count > 0)
            {
                result = this.fenleiid1[this.comboBox1.SelectedIndex];
            }
            return result;
        }

        public void setid(string id)
        {
            try
            {
                List<string> list = new List<string>();
                list.Add(id);
                string text = this.getparentid(id);
                while (text != "0")
                {
                    list.Add(text);
                    text = this.getparentid(text);
                }
                switch (list.Count)
                {
                    case 1:
                        this.setidcombox(this.comboBox1, this.fenleiid1, list[0]);
                        break;
                    case 2:
                        this.setidcombox(this.comboBox1, this.fenleiid1, list[1]);
                        this.setidcombox(this.comboBox2, this.fenleiid2, list[0]);
                        break;
                    case 3:
                        this.setidcombox(this.comboBox1, this.fenleiid1, list[2]);
                        this.setidcombox(this.comboBox2, this.fenleiid2, list[1]);
                        this.setidcombox(this.comboBox3, this.fenleiid3, list[0]);
                        break;
                    case 4:
                        this.setidcombox(this.comboBox1, this.fenleiid1, list[3]);
                        this.setidcombox(this.comboBox2, this.fenleiid2, list[2]);
                        this.setidcombox(this.comboBox3, this.fenleiid3, list[1]);
                        this.setidcombox(this.comboBox4, this.fenleiid3, list[0]);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
            }
        }

        private void setidcombox(ComboBox combbox, List<string> fenleiid, string id)
        {
            try
            {
                for (int i = 0; i < fenleiid.Count; i++)
                {
                    if (fenleiid[i] == id)
                    {
                        combbox.SelectedIndex = i;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageOpen.Show(ex.Message);
            }
        }

        private void refcomboxvis()
        {
            if (!this.comboBox2.Visible)
            {
                this.comboBox3.Visible = false;
            }
            if (!this.comboBox3.Visible)
            {
                this.comboBox4.Visible = false;
            }
            this.label2.Visible = this.comboBox2.Visible;
            this.label3.Visible = this.comboBox3.Visible;
            this.label4.Visible = this.comboBox4.Visible;
        }

        public bool Reffenlei()
        {
            this.panel1.Visible = true;
            this.fenleiid1.Clear();
            this.fenleiid2.Clear();
            this.fenleiid3.Clear();
            this.fenleiid4.Clear();
            this.fenleijo = php.getfenlei();
            bool result;
            if (this.fenleijo == null)
            {
                result = false;
            }
            else
            {
                this.setnextcombox("0", this.comboBox1, this.fenleiid1);
                this.panel1.Visible = false;
                result = true;
            }
            return result;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex >= 0 && this.comboBox1.Items.Count > this.comboBox1.SelectedIndex)
            {
                this.setnextcombox(this.fenleiid1[this.comboBox1.SelectedIndex], this.comboBox2, this.fenleiid2);
            }
        }

        private string getparentid(string id)
        {
            JToken jToken = this.fenleijo.First;
            JProperty jProperty = this.fenleijo.Property(jToken.Path);
            string result;
            for (int i = 0; i < this.fenleijo.Count; i++)
            {
                if (jProperty.Name == id)
                {
                    result = this.fenleijo[jProperty.Path]["parent_id"].ToString();
                    return result;
                }
                jToken = jToken.Next;
                if (jToken != null)
                {
                    jProperty = this.fenleijo.Property(jToken.Path);
                }
            }
            result = "-1";
            return result;
        }

        private void setnextcombox(string pid, ComboBox combbox, List<string> fenleiid)
        {
            combbox.Items.Clear();
            fenleiid.Clear();
            JToken jToken = this.fenleijo.First;
            JProperty jProperty = this.fenleijo.Property(jToken.Path);
            for (int i = 0; i < this.fenleijo.Count; i++)
            {
                if (this.fenleijo[jProperty.Path]["parent_id"].ToString() == pid)
                {
                    if (this.fenleijo[jProperty.Path]["name"].ToString() != "官方样例".Language() || php.Username == "wygabc414" || php.Username == "fmzhangpei241")
                    {
                        combbox.Items.Add(this.fenleijo[jProperty.Path]["name"].ToString());
                        fenleiid.Add(jProperty.Name);
                    }
                }
                jToken = jToken.Next;
                if (jToken != null)
                {
                    jProperty = this.fenleijo.Property(jToken.Path);
                }
            }
            if (combbox.Items.Count > 0)
            {
                combbox.SelectedIndex = 0;
                combbox.Visible = true;
            }
            else
            {
                combbox.Visible = false;
                this.refcomboxvis();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox3.SelectedIndex >= 0 && this.comboBox3.Items.Count > this.comboBox3.SelectedIndex)
            {
                this.setnextcombox(this.fenleiid3[this.comboBox3.SelectedIndex], this.comboBox4, this.fenleiid4);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox2.SelectedIndex >= 0 && this.comboBox2.Items.Count > this.comboBox2.SelectedIndex)
            {
                this.setnextcombox(this.fenleiid2[this.comboBox2.SelectedIndex], this.comboBox3, this.fenleiid3);
            }
        }
    }
}
