using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;
namespace WindowsFormsApp1.othercs
{
    public partial class calculaterectangle : Form
    {
        public calculaterectangle()
        {
            InitializeComponent();
            Test();
        }

        private static void Test()
        {
            var src = Cv2.ImRead(Properties.Settings.Default.检测点位置, ImreadModes.Color);
            var dst = new Mat();
            Cv2.CvtColor(src, dst, ColorConversionCodes.RGB2GRAY);
            Cv2.FindContours(dst, out var contours, out var hierarchy, RetrievalModes.External,
                ContourApproximationModes.ApproxSimple);
            List<List<Point>> approxContours = new List<List<Point>>();
            for (int i = 0; i < contours.Length; i++)
            {
                //先求出多边形的近似轮廓，减少轮廓数量，方便后面计算
                var approxContour = Cv2.ApproxPolyDP(contours[i], 20, true);
                approxContours.Add(approxContour.ToList());
                DrawContour(src, approxContour, Scalar.White, 1);
            }

            foreach (var contour in approxContours)
            {
                GetMaxInscribedRect(src, contour);
            }

            Cv2.ImShow("src", src);
        }

        private static Rect GetMaxInscribedRect(Mat src, List<Point> contour)
        {
            //根据轮廓让点与下一个点之间形成一个矩形，然后让每个矩形都与当前所有矩形相交，求出相交的矩形，
            //再把这些矩形所有的角放到一个集合里，筛选出在轮廓内并且非重复的点，
            //最后让这些点两两组合成一个矩形，判断是否为内部矩形，算出面积，找出最大内接矩形。
            //比如一共4个点，第1个与第2个形成矩形（矩形1），第1与第3（矩形2），
            //第1与第4（矩形3），第2与第3（矩形4），第2与第4（矩形5），第3与第4（矩形6），
            //由于矩形1为第一个元素，没有相交矩形，所以直接放入allPoint中，
            //接着把矩形2的四个角，以及矩形2和矩形1相交矩形的四个角，放入allPoint中，
            //矩形3以此类推，其本身四个角，以及和矩形1相交矩形的四个角，以及和矩形2相交矩形的四个角
            Rect maxInscribedRect = new Rect();
            Rect EmptyRect = new Rect();
            List<Rect> allRect = new List<Rect>();
            List<Point> allPoint = new List<Point>(contour);

            //根据轮廓让点与下一个点之间形成一个矩形
            for (int i = 0; i < contour.Count; i++)
            {
                for (int j = i + 1; j < contour.Count; j++)
                {
                    var p1 = contour[i];
                    var p2 = contour[j];
                    if (p1.Y == p2.Y || p1.X == p2.X)
                        continue;
                    var tempRect = FromTowPoint(p1, p2);
                    allPoint.AddRange(GetAllCorner(tempRect));
                    //让每个矩形都与当前所有矩形相交，求出相交的矩形，再把这些矩形所有的角放到一个集合里
                    foreach (var rect in allRect)
                    {
                        var intersectR = tempRect.Intersect(rect);
                        if (intersectR != EmptyRect)
                            allPoint.AddRange(GetAllCorner(intersectR));
                    }

                    allRect.Add(tempRect);
                }
            }

            //去除重复的点，再让这些点两两组合成一个矩形，判断是否为内部矩形，算出面积，找出最大内接矩形
            List<Point> distinctPoints = allPoint.Distinct().ToList();
            for (int i = 0; i < distinctPoints.Count; i++)
            {
                for (int j = i + 1; j < distinctPoints.Count; j++)
                {
                    var tempRect = FromTowPoint(distinctPoints[i], distinctPoints[j]);
                    //只要矩形包含一个轮廓内的点，就不算多边形的内部矩形；只要轮廓不包含该矩形，该矩形就不算多边形的内部矩形
                    if (!ContainPoints(contour, GetAllCorner(tempRect)) || ContainsAnyPt(tempRect, contour))
                        continue;
                    src.Rectangle(tempRect, Scalar.RandomColor(), 2);
                    if (tempRect.Width * tempRect.Height > maxInscribedRect.Width * maxInscribedRect.Height)
                        maxInscribedRect = tempRect;
                }
            }

            src.Rectangle(maxInscribedRect, Scalar.Yellow, 2);
            return maxInscribedRect == EmptyRect ? Cv2.BoundingRect(contour) : maxInscribedRect;
        }

        public static Point[] GetAllCorner(Rect rect)
        {
            Point[] result = new Point[4];
            result[0] = rect.Location;
            result[1] = new Point(rect.X + rect.Width, rect.Y);
            result[2] = rect.BottomRight;
            result[3] = new Point(rect.X, rect.Y + rect.Height);
            return result;
        }

        public static bool ContainPoint(List<Point> contour, Point p1)
        {
            return Cv2.PointPolygonTest(contour, p1, false) > 0;
        }

        public static bool ContainPoints(List<Point> contour, IEnumerable<Point> points)
        {
            foreach (var point in points)
            {
                if (Cv2.PointPolygonTest(contour, point, false) < 0)
                    return false;
            }
            return true;
        }

        private static void DrawContour(Mat mat, Point[] contour, Scalar color, int thickness)
        {
            for (int i = 0; i < contour.Length; i++)
            {
                if (i + 1 < contour.Length)
                    Cv2.Line(mat, contour[i], contour[i + 1], color, thickness);
            }
        }

        /// <summary>
        /// 是否有任意一个点集合中的点包含在矩形内，在矩形边界上不算包含
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="points"></param>
        /// <returns></returns>
        private static bool ContainsAnyPt(Rect rect, IEnumerable<Point> points)
        {
            foreach (var point in points)
            {
                if (point.X > rect.X && point.X < rect.X + rect.Width && point.Y < rect.BottomRight.Y && point.Y > rect.Y)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 用任意两点组成一个矩形
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static Rect FromTowPoint(Point p1, Point p2)
        {
            Rect EmptyRect = new Rect();
            if (p1.X == p2.X || p1.Y == p2.Y)
                return EmptyRect;

            if (p1.X > p2.X && p1.Y < p2.Y)
            {
                (p1, p2) = (p2, p1);
            }
            else if (p1.X > p2.X && p1.Y > p2.Y)
            {
                (p1.X, p2.X) = (p2.X, p1.X);
            }
            else if (p1.X < p2.X && p1.Y < p2.Y)
            {
                (p1.Y, p2.Y) = (p2.Y, p1.Y);
            }
            return Rect.FromLTRB(p1.X, p2.Y, p2.X, p1.Y);
        }

        private void calculaterectangle_Load(object sender, EventArgs e)
        {

        }
    }
}
