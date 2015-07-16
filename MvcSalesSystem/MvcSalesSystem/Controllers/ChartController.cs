using DataLayer;
using MvcSalesSystem.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.DataVisualization.Charting;

namespace MvcSalesSystem.Controllers
{
    [Authorize]
    public class ChartController : Controller
    {
        private DALContext _dalContext;

        private IProductRepository _productRepository;
        private ICustomerRepository _customerRepository;
        private IManagerRepository _managerRepository;
        private IInputFilesRepository _inputFileRepository;
        private ISaleItemRepository _saleItemRepository;

        public ChartController()
        {
            _dalContext = new DALContext();
            _customerRepository = _dalContext.Customers;
            _inputFileRepository = _dalContext.InputFiles;
            _managerRepository = _dalContext.Managers;
            _productRepository = _dalContext.Products;
            _saleItemRepository = _dalContext.SaleItems;

        }

        //
        // GET: /Chart/

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(SalesChartFormModel item)
        {
            if (ModelState.IsValid)
            {
                View(item);
            }

            return View();
        }


        public ActionResult GetChart(string GetDateStart,string GetDateFinish)
        {
            DateTime dateStart = Convert.ToDateTime(GetDateStart);
            DateTime dateFinish = Convert.ToDateTime(GetDateFinish);
            if (dateStart != null && dateFinish != null)
            {
                IList<Tuple<double, string>> dates = _saleItemRepository.GetAll()
                    .Where(x=> x.SaleDate > dateStart && x.SaleDate < dateFinish)
                    .OrderBy(x => x.SaleDate)
                    .GroupBy(x => new { Year = x.SaleDate.Year, Month = x.SaleDate.Month })
                    .Select(x => new Tuple<double, string>(x.Sum(y => y.SaleSum), x.Key.Year + " - " + x.Key.Month))
                    .ToList<Tuple<double, string>>();

                var chart = new Chart();
                chart.Width = 700;
                chart.Height = 300;
                chart.BackColor = Color.FromArgb(211, 223, 240);
                chart.BorderlineDashStyle = ChartDashStyle.Solid;
                chart.BackSecondaryColor = Color.White;
                chart.BackGradientStyle = GradientStyle.TopBottom;
                chart.BorderlineWidth = 1;
                chart.Palette = ChartColorPalette.BrightPastel;
                chart.BorderlineColor = Color.FromArgb(26, 59, 105);
                chart.RenderType = RenderType.BinaryStreaming;
                chart.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
                chart.AntiAliasing = AntiAliasingStyles.All;
                chart.TextAntiAliasingQuality = TextAntiAliasingQuality.Normal;
                chart.Titles.Add(CreateTitle());
                chart.Legends.Add(CreateLegend());
                chart.Series.Add(CreateSeries(dates, SeriesChartType.Line, Color.Red));
                chart.ChartAreas.Add(CreateChartArea());

                var ms = new MemoryStream();
                chart.SaveImage(ms);
                return File(ms.GetBuffer(), @"image/png");
            }
            return View();
        }

        [NonAction]
        public Title CreateTitle()
        {
            Title title = new Title();
            title.Text = "Sales chart";
            title.Font = new Font("Trebuchet MS", 14F, FontStyle.Bold);
            title.ForeColor = Color.Gray;

            return title;
        }
        

        [NonAction]
        public Legend CreateLegend()
        {
            var legend = new Legend();
            legend.Name = "Sales sum";
            legend.Docking = Docking.Bottom;
            legend.Alignment = StringAlignment.Center;
            legend.BackColor = Color.Transparent;
            legend.Font = new Font(new FontFamily("Trebuchet MS"), 9);
            legend.LegendStyle = LegendStyle.Row;

            return legend;
        }


        [NonAction]
        public Series CreateSeries(IList<Tuple<double, string>> results,
               SeriesChartType chartType,
               Color color)
        {
            var seriesDetail = new Series();
            seriesDetail.Name = "Sales sum";
            seriesDetail.IsValueShownAsLabel = true;
            seriesDetail.Color = color;
            seriesDetail.ChartType = chartType;
            seriesDetail.BorderWidth = 2;
            seriesDetail["DrawingStyle"] = "Cylinder";
            seriesDetail["PieDrawingStyle"] = "SoftEdge";
            DataPoint point;

            foreach (var result in results)
            {
                point = new DataPoint();
                point.AxisLabel = result.Item2;
                point.YValues = new double[] { result.Item1 };
                seriesDetail.Points.Add(point);
            }
            seriesDetail.ChartArea = "Sales Chart";

            return seriesDetail;
        }

        

        [NonAction]
        public ChartArea CreateChartArea()
        {
            var chartArea = new ChartArea();
            chartArea.Name = "Sales Chart";
            chartArea.BackColor = Color.Transparent;
            chartArea.AxisX.IsLabelAutoFit = false;
            chartArea.AxisY.IsLabelAutoFit = false;
            chartArea.AxisX.LabelStyle.Font = new Font("Verdana,Arial,Helvetica,sans-serif", 8F, FontStyle.Regular);
            chartArea.AxisY.LabelStyle.Font = new Font("Verdana,Arial,Helvetica,sans-serif", 8F, FontStyle.Regular);
            chartArea.AxisY.LineColor = Color.FromArgb(64, 64, 64, 64);
            chartArea.AxisX.LineColor = Color.FromArgb(64, 64, 64, 64);
            chartArea.AxisY.MajorGrid.LineColor = Color.FromArgb(64, 64, 64, 64);
            chartArea.AxisX.MajorGrid.LineColor = Color.FromArgb(64, 64, 64, 64);
            chartArea.AxisX.Interval = 1;
            return chartArea;
        }

    }
}
