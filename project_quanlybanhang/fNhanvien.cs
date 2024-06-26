﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using app = Microsoft.Office.Interop.Excel.Application;

namespace project_quanlybanhang
{
    public partial class fNhanvien : Form
    {
        
        Nhanvien nhanvien;

        public fNhanvien()
        {

            InitializeComponent();
            nhanvien = new Nhanvien();
        }

        private void fNhanvien_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "Mã nhân viên";
            // TODO: This line of code loads data into the 'qUANLY_CUAHANGMAYTINHDataSet.NHANVIEN' table. You can move, or remove it, as needed.
            this.nHANVIENTableAdapter.Fill(this.qUANLY_CUAHANGMAYTINHDataSet.NHANVIEN);
            // TODO: This line of code loads data into the 'qUANLY_CUAHANGMAYTINHDataSet.NHANVIEN' table. You can move, or remove it, as needed.
            this.nHANVIENTableAdapter.Fill(this.qUANLY_CUAHANGMAYTINHDataSet.NHANVIEN);

        }

        private void nHANVIENBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.nHANVIENBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.qUANLY_CUAHANGMAYTINHDataSet);

        }

        private void nHANVIENBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.nHANVIENBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.qUANLY_CUAHANGMAYTINHDataSet);

        }

        private void hinhAnhPictureBox_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                hinhAnhPictureBox.Image = Image.FromFile(open.FileName);
                this.Text = open.FileName;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            DataColumn col1 = new DataColumn("MaNV");
            DataColumn col2 = new DataColumn("TenNV");
            DataColumn col3 = new DataColumn("Diachi");
            DataColumn col4 = new DataColumn("Sdt");
            DataColumn col5 = new DataColumn("Chucvu");
            DataColumn col6 = new DataColumn("Ngayvaolam");
            DataColumn col7 = new DataColumn("Gioitinh");
            DataColumn col8 = new DataColumn("Hinhanh");

            dataTable.Columns.Add(col1);
            dataTable.Columns.Add(col2);
            dataTable.Columns.Add(col3);
            dataTable.Columns.Add(col4);
            dataTable.Columns.Add(col5);
            dataTable.Columns.Add(col6);
            dataTable.Columns.Add(col7);
            dataTable.Columns.Add(col8);

            foreach (DataGridViewRow dtgvRow in nHANVIENDataGridView.Rows)
            {
                DataRow dtrow = dataTable.NewRow();
                dtrow[0] = dtgvRow.Cells[0].Value;
                dtrow[1] = dtgvRow.Cells[1].Value;
                dtrow[2] = dtgvRow.Cells[2].Value;
                dtrow[3] = dtgvRow.Cells[3].Value;
                dtrow[4] = dtgvRow.Cells[4].Value;
                dtrow[5] = dtgvRow.Cells[5].Value;
                dtrow[6] = dtgvRow.Cells[6].Value;
                dtrow[7] = dtgvRow.Cells[7].Value;

                dataTable.Rows.Add(dtrow);
            }
            ExportFile(dataTable, "Danh sach", "Danh sách nhân viên");
        }
        public void ExportFile(DataTable dataTable, string sheetName, string title)
        {
            //Tạo các đối tượng Excel

            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel.Workbooks oBooks;

            Microsoft.Office.Interop.Excel.Sheets oSheets;

            Microsoft.Office.Interop.Excel.Workbook oBook;

            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            //Tạo mới một Excel WorkBook 

            oExcel.Visible = true;

            oExcel.DisplayAlerts = false;

            oExcel.Application.SheetsInNewWorkbook = 1;

            oBooks = oExcel.Workbooks;

            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));

            oSheets = oBook.Worksheets;

            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

            oSheet.Name = sheetName;

            // Tạo phần Tiêu đề
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "H1");

            head.MergeCells = true;

            head.Value2 = title;

            head.Font.Bold = true;

            head.Font.Name = "Times New Roman";

            head.Font.Size = "20";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");

            cl1.Value2 = "Mã nhân viên";

            cl1.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

            cl2.Value2 = "Tên nhân viên";

            cl2.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");

            cl3.Value2 = "Địa chỉ";
            cl3.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");

            cl4.Value2 = "Số điện thoại";

            cl4.ColumnWidth = 10.5;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");

            cl5.Value2 = "Chức vụ";

            cl5.ColumnWidth = 20.5;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");

            cl6.Value2 = "Ngày vào làm";

            cl6.ColumnWidth = 18.5;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");

            cl7.Value2 = "Giới tính";

            cl7.ColumnWidth = 10.5;
            Microsoft.Office.Interop.Excel.Range cl8= oSheet.get_Range("H3", "H3");

            cl8.Value2 = "Hình ảnh";

            cl8.ColumnWidth = 10.5;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "H3");

            rowHead.Font.Bold = true;

            // Kẻ viền

            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Thiết lập màu nền

            rowHead.Interior.ColorIndex = 6;

            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo mảng theo datatable

            object[,] arr = new object[dataTable.Rows.Count, dataTable.Columns.Count];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng

            for (int row = 0; row < dataTable.Rows.Count; row++)
            {
                DataRow dataRow = dataTable.Rows[row];

                for (int col = 0; col < dataTable.Columns.Count; col++)
                {
                    arr[row, col] = dataRow[col];
                }
            }

            //Thiết lập vùng điền dữ liệu

            int rowStart = 4;

            int columnStart = 1;

            int rowEnd = rowStart + dataTable.Rows.Count - 2;

            int columnEnd = dataTable.Columns.Count;

            // Ô bắt đầu điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

            // Ô kết thúc điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

            // Lấy về vùng điền dữ liệu

            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            //Điền dữ liệu vào vùng đã thiết lập

            range.Value2 = arr;

            // Kẻ viền

            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Căn giữa cột mã nhân viên

            //Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];

            //Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);

            //Căn giữa cả bảng 
            oSheet.get_Range(c1, c2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            maNVTextBox.Text = "";
            tenNVTextBox.Text = "";
            diaChiNVTextBox.Text = "";
            sDT_NVTextBox.Text = "";
            chucVuComboBox.Text = "";
            ngayVaoLamDateTimePicker.Text = "";
            gioiTinhComboBox.Text = "";
            hinhAnhPictureBox.Text = "";        
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public SqlConnection cn = new SqlConnection();
        public void Ketnoi()
        {
            try
            {
                if (cn.State == 0)
                {
                    cn.ConnectionString = "Data Source = LAPTOP-KNCJTSN8; Initial Catalog = QUANLY_CUAHANGMAYTINH; Integrated Security = True";
                    cn.Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Ngatketnoi()
        {
            if (cn.State != 0)
            {
                cn.Close();
            }
        }
        public DataTable HienDL(string sql)
        {
            Ketnoi();
            Ngatketnoi();
            SqlDataAdapter adap = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Mã nhân viên")
            {
                nHANVIENDataGridView.DataSource = HienDL("select * from NHANVIEN where Manv like '%" + textBox1.Text.Trim() + "%'");
            }
            if (comboBox1.Text == "Tên nhân viên")
            {
                nHANVIENDataGridView.DataSource = HienDL("select * from NHANVIEN where Tennv like '%" + textBox1.Text.Trim() + "%'");
            }
         } 
    }
}
