using System;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;


namespace Excels
{
    /// <summary>
    /// Main class for working with xlsx file.
    /// </summary>
    internal class ExcelMain : IDisposable
    {
        /// <summary>
        /// Excel application.
        /// </summary>
        private Excel.Application _excel;

        /// <summary>
        /// Path to file.
        /// </summary>
        private string _path;

        /// <summary>
        /// Excel workbook.
        /// </summary>
        private Excel.Workbook _workbook;

        /// <summary>
        /// Create new excal.
        /// </summary>
        /// <param name="path">Path to file.</param>
        public ExcelMain()
        {
            this._excel = new Excel.Application();

        }

        /// <summary>
        /// Open or create excel file.
        /// </summary>
        /// <returns>True if this file was open.</returns>
        internal bool Open(string path)
        {
            this._path = path;
            try
            {
                if (File.Exists(_path))
                {
                    _workbook = _excel.Workbooks.Open(_path);
                }
                else
                {
                    _workbook = _excel.Workbooks.Add();
                }

                return true;
            }
            catch
            {
                Console.WriteLine("Cannot open file.");
            }

            return false;
        }

        /// <summary>
        /// Set information in cell.
        /// </summary>
        /// <param name="row">Row's number.</param>
        /// <param name="column">Column's symbol.</param>
        /// <param name="data">Data too add in cell.</param>
        /// <returns>True if data was add in cell.</returns>
        internal bool Set(int row, string column, object data)
        {
            try
            {
                ((Excel.Worksheet)_excel.ActiveSheet).Cells[row, column] = data;
                return true;
            }
            catch
            {
                Console.WriteLine("Cannot set data in cell.");
            }

            return false;
        }

        /// <summary>
        /// Save changws in file.
        /// </summary>
        internal void Save()
        {
            _workbook.SaveAs(_path);
        }

        /// <summary>
        /// Dispose connection with Excel file.
        /// </summary>
        public void Dispose()
        {
            _workbook.Close();
        }
    }
}
