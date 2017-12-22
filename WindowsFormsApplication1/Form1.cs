using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO;
using BUS;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            HidePanels();
            chontaomoi.Show();
           
                listcuahang();
           
        }
   
        private void HidePanels()
        {
            foreach (Control c in this.Controls)
            {
                if (c is Panel)
                {
                    c.Visible = false;
                }
            }
        }

        private int machinhanh;
        private string tenchinhanh;
        private string madonnhap;

        #region menu
        private void trangchinh_Click(object sender, EventArgs e)
        {
            menuStrip1.Visible = false;
            menu.Visible = true;
            trchinh.Visible = true;
            qlnhapkho.Visible = false;
            tketimk.Visible = false;
            qlxuatkho.Visible = false;
            danhsachsanpham.Visible = false;
        }
        private void xuatkho_Click(object sender, EventArgs e)
        {
            trchinh.Visible = false;
            qlnhapkho.Visible = false;
            tketimk.Visible = false;
            danhsachsanpham.Visible = false;
            qlxuatkho.Visible = true;
        }

        private void nhapkho_Click(object sender, EventArgs e)
        {
            trchinh.Visible = false;
            tketimk.Visible = false;
            qlxuatkho.Visible = false;
            danhsachsanpham.Visible = false;
            qlnhapkho.Visible = true;
        }

        private void thongketimkiem_Click(object sender, EventArgs e)
        {
            trchinh.Visible = false;
            qlnhapkho.Visible = false;
            qlxuatkho.Visible = false;
            danhsachsanpham.Visible = false;
            tketimk.Visible = true;
        }

        private void dsvatpham_Click(object sender, EventArgs e)
        {
            trchinh.Visible = false;
            qlnhapkho.Visible = false;
            qlxuatkho.Visible = false;
            tketimk.Visible = false;
            danhsachsanpham.Visible = true;
        }

        private void trove_Click(object sender, EventArgs e)
        {
            HidePanels();
            chontaomoi.Visible = true;
            menuStrip1.Visible = false;
        }

        private void thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void taodonnhapkho_Click(object sender, EventArgs e)
        {
            HidePanels();
            menuStrip1.Visible = true;
            taodonnhap.Visible = true;
            nhapchitietdon.Visible = false;
            nhapdon.Visible = true;
            xacdinhkholbl.Text = "Nhập vào kho số " + machinhanh + " của cửa hàng (chi nhánh) " + tenchinhanh;
        }

        private void suathongtindonnhap_Click(object sender, EventArgs e)
        {
            HidePanels();
            menuStrip1.Visible = true;
            danhsachdonnhappn.Visible = true;
            nhaphangbus nhbus= new nhaphangbus();
            danhsachdonnhapdgv.DataSource = nhbus.listnhaphang();
        }


        private void themsanphambtn_Click(object sender, EventArgs e)
        {
            HidePanels();
            menuStrip1.Visible = true;
            themsanpham.Visible = true;
        }

        private void danhsachvasuaspbtn_Click(object sender, EventArgs e)
        {
            HidePanels();
            menuStrip1.Visible = true;
            danhsachsanphampn.Visible = true;
            vatphambus vpbus = new vatphambus();
            danhsachsanphamdgv.DataSource = vpbus.listvatpham();
            DataGridViewImageColumn ic = new DataGridViewImageColumn();
            ic.HeaderText = "Hình ảnh";
            ic.Image = null;
            ic.Name = "cImg";
            ic.Width = 100;
            danhsachsanphamdgv.Columns.Insert(0, ic);
            danhsachsanphamdgv.Columns[2].Visible = false;
            foreach (DataGridViewRow row in danhsachsanphamdgv.Rows)
            {
                DataGridViewImageCell cell = row.Cells[0] as DataGridViewImageCell;
                string path = row.Cells[2].Value.ToString();
                path = appPath + path;
                Console.WriteLine(path);
                cell.Value = Bitmap.FromFile(path);
                row.Height = 100;
            }
        }

        private void loadtrchinh(string tenchinhanh)
        {
            cuahangbus chb = new cuahangbus();
            DataTable listch = chb.listcuahang(tenchinhanh);
            foreach (DataRow row in listch.Rows)
            {
                trchinhlbl.Text =  "Quản lí kho số " + row["MACHINHANH"].ToString();
                machinhanh = (int)row["MACHINHANH"];
                tencuahanglbl.Text = "Tên cửa hàng (chi nhánh): " + row["TENCHINHANH"].ToString();
                tenchinhanh = row["TENCHINHANH"].ToString();
                diachilbl.Text = "Địa chỉ: " + row["DIACHI"].ToString();
                tinhtplbl.Text = "Mã thành phố: " + row["MATP"].ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            HidePanels();
            menuStrip1.Visible = true;
            capnhatsoluong.Visible = true;

            tonkhobus tkbus = new tonkhobus();

            danhsachtonkhodgv.DataSource = tkbus.listtonkho();

            DataGridViewImageColumn ic = new DataGridViewImageColumn();
            ic.HeaderText = "Hình ảnh";
            ic.Image = null;
            ic.Name = "cImg";
            ic.Width = 100;
            danhsachtonkhodgv.Columns.Insert(0, ic);
            danhsachtonkhodgv.Columns[1].Visible = false;
            foreach (DataGridViewRow row in danhsachtonkhodgv.Rows)
            {
                DataGridViewImageCell cell = row.Cells[0] as DataGridViewImageCell;
                string path = "default-product-image.jpg";
                try
                {
                    path = row.Cells[1].Value.ToString();
                }
                catch(Exception)
                {
                }
                path = appPath + path;
                Console.WriteLine(path);
                cell.Value = Bitmap.FromFile(path);
                row.Height = 100;
            }
        }

        #endregion

        #region chontaomoi

        public void BindAutoCompleteList(DataTable myDataTable)
        {
            AutoCompleteStringCollection acDataSource = new AutoCompleteStringCollection();

            foreach (DataRow row in myDataTable.Rows)
            {
                acDataSource.Add(row["MATP"].ToString() + "-" + row["TENTP"].ToString());
            }
            tinhtp.Clear();
            tinhtp.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tinhtp.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tinhtp.AutoCompleteCustomSource = acDataSource;
        }

        private void listcuahang()
        {
            List<string> cuahang = new List<string>();
            cuahangbus chb = new cuahangbus();
            DataTable listch = chb.listcuahang();
            foreach (DataRow row in listch.Rows)
            {
                cuahang.Add(row["TENCHINHANH"].ToString());
            }
            listBox1.DataSource = cuahang;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HidePanels();
            taokho.Visible = true;
            thanhphobus tpb = new thanhphobus();
            BindAutoCompleteList(tpb.listthanhpho());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HidePanels();
            menu.Visible = true;
            loadtrchinh(listBox1.SelectedItem.ToString());
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string tencn = tencuahang.Text.Trim();
            string dc = diachi.Text.Trim();
            string ttp = tinhtp.Text.Trim();

            int index = ttp.IndexOf('-');
            if(index > 0) 
            {
                ttp = ttp.Substring(0, index).ToUpper();
            }
            cuahangdto cuahang = new cuahangdto();

            cuahang.Tenchinhanh = tencn;
            cuahang.Diachi = dc;
            cuahang.Matp = ttp;

            cuahangbus chb = new cuahangbus();
            chb.add(cuahang);

            HidePanels();
            menu.Visible = true;
            loadtrchinh(tencn);
        }
        #endregion

        #region taodonnhap

        private void taodonnhapluu_Click(object sender, EventArgs e)
        {
            nhaphangdto nhdto = new nhaphangdto();
            nhdto.Manhaphang = manhapkhotxt.Text;
            nhdto.Ngaynhaphang= ngaynhapkho.Value.Date.ToShortDateString();
            nhdto.Machinhanh = machinhanh;
            nhaphangbus nhb = new nhaphangbus();
            nhb.add(nhdto);

            madonnhap = nhdto.Manhaphang;
            madonnhaplbl.Text = madonnhap;

            nhapdon.Visible = false;
            nhapchitietdon.Visible = true;

            vatphambus vpbus = new vatphambus();
            danhsachsanpham1dgv.DataSource = vpbus.listvatpham();
            DataGridViewImageColumn ic = new DataGridViewImageColumn();
            ic.HeaderText = "Hình ảnh";
            ic.Image = null;
            ic.Name = "cImg";
            ic.Width = 100;
            danhsachsanpham1dgv.Columns.Insert(0, ic);
            danhsachsanpham1dgv.Columns[2].Visible = false;
            foreach (DataGridViewRow row in danhsachsanpham1dgv.Rows)
            {
                DataGridViewImageCell cell = row.Cells[0] as DataGridViewImageCell;
                string path = row.Cells[2].Value.ToString();
                path = appPath + path;
                Console.WriteLine(path);
                cell.Value = Bitmap.FromFile(path);
                row.Height = 100;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            (danhsachsanpham1dgv.DataSource as DataTable).DefaultView.RowFilter = string.Format("TENVP LIKE '%{0}%' or TUKHOA LIKE '%{0}%' ", textBox2.Text);
            foreach (DataGridViewRow row in danhsachsanphamdgv.Rows)
            {
                DataGridViewImageCell cell = row.Cells[0] as DataGridViewImageCell;
                string path = row.Cells[2].Value.ToString();
                path = appPath + path;
                cell.Value = Bitmap.FromFile(path);
                row.Height = 100;
            }
        }
        private void luutonkhobtn_Click(object sender, EventArgs e)
        {
            tonkhodto tkdto = new tonkhodto();
            tkdto.Manhaphang = madonnhaplbl.Text;
            tkdto.Mavp = masplbl.Text;
            tkdto.Ngayhethan = ngayhethan.Value.Date.ToShortDateString();
            tkdto.Soluongnhap = Convert.ToInt32(soluongnhap.Value);
            tkdto.Soluongton = tkdto.Soluongnhap;
            tonkhobus tkbus = new tonkhobus();
            tkbus.add(tkdto);
            thongtindonnhapdgv.DataSource = tkbus.listtonkho(tkdto.Manhaphang);
        }

        private void danhsachsanpham1dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.danhsachsanpham1dgv.Rows[e.RowIndex];
                masplbl.Text = row.Cells["MAVP"].Value.ToString();
            }
        }

        #endregion
       
        #region giaodien
        private void danhMụcToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            danhMụcToolStripMenuItem.ForeColor = Color.Black;
        }

        private void danhMụcToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            danhMụcToolStripMenuItem.ForeColor = Color.White;
        }
        
        #endregion

        #region themsanpham

        private string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\Images\";

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            ;
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = false;

            openFileDialog1.Title = "chon anh dai dien";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = ResizeImage(Image.FromFile(openFileDialog1.FileName), 100, 100); ;
            }
        }


        private void luusanpham_Click(object sender, EventArgs e)
        {
            string tenanh = tensanphamtxt.Text.Replace(" ", "") + DateTime.Now.ToString("ddmmyyyyhhmmss") +".jpeg";
            
            if (Directory.Exists(appPath) == false)
            {
                Directory.CreateDirectory(appPath);
            }
            if (pictureBox1 == null || pictureBox1.Image == null)
            {
                MessageBox.Show("khong co hinh");
                tenanh = "default-product-image.jpg";
            }
            else
                pictureBox1.Image.Save(appPath + tenanh, ImageFormat.Jpeg);

            vatphamdto vpdto = new vatphamdto();
            vpdto.Tenvatpham = tensanphamtxt.Text;
            vpdto.Loaivatpham = loaisptxt.Text;
            vpdto.Hinhanh = tenanh;
            vpdto.Tukhoa = mieutatxt.Text;
            vpdto.Gia = Convert.ToDecimal(giatxt.Text);
            vatphambus vpbus = new vatphambus();
            vpbus.add(vpdto);

            danhsachsanphamnhapdgv.DataSource = vpbus.listvatpham(vpdto.Tenvatpham);
            DataGridViewImageColumn ic = new DataGridViewImageColumn();
            ic.HeaderText = "Hình ảnh";
            ic.Image = null;
            ic.Name = "cImg";
            ic.Width = 100;
            danhsachsanphamnhapdgv.Columns.Insert(0, ic);
            danhsachsanphamnhapdgv.Columns[2].Visible = false;
            foreach (DataGridViewRow row in danhsachsanphamnhapdgv.Rows)
            {
                DataGridViewImageCell cell = row.Cells[0] as DataGridViewImageCell;
                string path = "default-product-image.jpg";
                try
                {
                    path = row.Cells[2].Value.ToString();
                }
                catch (Exception)
                {
                }
                path = appPath + path;
                Console.WriteLine(path);
                cell.Value = Bitmap.FromFile(path);
                row.Height = 100;
            }
        }

        #endregion

        #region danhsachvatpham
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            (danhsachsanphamdgv.DataSource as DataTable).DefaultView.RowFilter = string.Format("TENVP LIKE '%{0}%' or TUKHOA LIKE '%{0}%' ", textBox2.Text);
            foreach (DataGridViewRow row in danhsachsanphamdgv.Rows)
            {
                DataGridViewImageCell cell = row.Cells[0] as DataGridViewImageCell;
                string path = row.Cells[2].Value.ToString();
                path = appPath + path;
                cell.Value = Bitmap.FromFile(path);
                row.Height = 100;
            }
        }

        #endregion

        #region xuatkho
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            (danhsachtonkhodgv.DataSource as DataTable).DefaultView.RowFilter = string.Format("TENVP LIKE '%{0}%' or TUKHOA LIKE '%{0}%' or MANHAPHANG like '%{0}%' ", textBox7.Text);
            foreach (DataGridViewRow row in danhsachtonkhodgv.Rows)
            {
                DataGridViewImageCell cell = row.Cells[0] as DataGridViewImageCell;
                string path = row.Cells[1].Value.ToString();
                path = appPath + path;
                cell.Value = Bitmap.FromFile(path);
                row.Height = 100;
            }
        }

        #endregion

        #region danhsachdonnhap
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            (danhsachdonnhapdgv.DataSource as DataTable).DefaultView.RowFilter = string.Format("MANHAPHANG like '%{0}%' ", textBox8.Text);
        }

        #endregion

    }
}
