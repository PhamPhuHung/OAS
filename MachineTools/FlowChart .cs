using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MachineTools
{
    [DefaultEvent("FlowRun")]

    public partial class FlowChart : Label
    {
        //流程回傳類別
        public enum FCResultType
        {
            NEXT,
            CASE1,
            CASE2,
            CASE3,
            IDLE,
        };

        public delegate FCResultType FlowRunEvent(object sender, EventArgs e);
        public event FlowRunEvent FlowRun = null;
        private FlowChart WorkFlow = null;

        public FlowChart()
            : base()
        {
            InitializeComponent();

            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.BackColor = Color.White;
            this.AutoSize = false;
            this.Size = new System.Drawing.Size(180, 30);
            this.Margin = new Padding(8);
        }

        public override bool AutoSize
        {
            get
            {
                return false;
            }
        }

        #region 指出下一個流程
        //NEXT
        [Browsable(true), Category("#Parameter"), Description("Next")]
        public FlowChart NEXT { get; set; }

        //CASE1
        [Browsable(true), Category("#Parameter"), Description("CASE1")]
        public FlowChart CASE1 { get; set; }

        //CASE2
        [Browsable(true), Category("#Parameter"), Description("CASE2")]
        public FlowChart CASE2 { get; set; }

        //CASE3
        [Browsable(true), Category("#Parameter"), Description("CASE3")]
        public FlowChart CASE3 { get; set; }
        #endregion

        /// <summary>
        /// 流程重置
        /// </summary>
        public void TaskReset()
        {
            if (WorkFlow != null)
                WorkFlow.BackColor = Color.White;
            WorkFlow = this;
            WorkFlow.BackColor = Color.Lime;
        }

        /// <summary>
        /// 執行流程
        /// </summary>
        public void TaskRun()
        {
            if (WorkFlow.FlowRun != null)
            {
                FCResultType FC_Result = WorkFlow.FlowRun(WorkFlow, null);
                FlowChart OldWorkFlow = WorkFlow;
                switch (FC_Result)
                {
                    case FCResultType.NEXT:
                        if (WorkFlow.NEXT != null)
                            WorkFlow = WorkFlow.NEXT;
                        break;
                    case FCResultType.CASE1:
                        if (WorkFlow.CASE1 != null)
                            WorkFlow = WorkFlow.CASE1;
                        break;
                    case FCResultType.CASE2:
                        if (WorkFlow.CASE2 != null)
                            WorkFlow = WorkFlow.CASE2;
                        break;
                    case FCResultType.CASE3:
                        if (WorkFlow.CASE3 != null)
                            WorkFlow = WorkFlow.CASE3;
                        break;
                }
                if (WorkFlow != null && FC_Result != FCResultType.IDLE)
                {
                    OldWorkFlow.BackColor = Color.White;
                    WorkFlow.BackColor = Color.Lime;
                }
            }
            else
            {
                FlowChart OldWorkFlow = WorkFlow;
                if(WorkFlow .NEXT !=null )
                WorkFlow = WorkFlow.NEXT;
                if (WorkFlow != null)
                {
                    OldWorkFlow.BackColor = Color.White;
                    WorkFlow.BackColor = Color.Lime;
                }
            }
        }

        public void FlowPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Point DrawStartPos = new Point();
            Point DrawEndPos = new Point();
            System.Drawing.Drawing2D.AdjustableArrowCap lineArrow = new System.Drawing.Drawing2D.AdjustableArrowCap(4, 4, true);
            if (this.NEXT != null && this.Parent == this.NEXT.Parent)
            {
                Pen p = new Pen(Color.Black, 1);
                p.CustomEndCap = lineArrow;
                CalculateLineStartEndPos(this, this.NEXT, ref DrawStartPos, ref DrawEndPos);
                g.DrawLine(p, DrawStartPos, DrawEndPos);
            }
            if (this.CASE1 != null && this.Parent == this.CASE1.Parent)
            {
                Pen p = new Pen(Color.LimeGreen, 1);
                p.CustomEndCap = lineArrow;
                CalculateLineStartEndPos(this, this.CASE1, ref DrawStartPos, ref DrawEndPos);
                g.DrawLine(p, DrawStartPos, DrawEndPos);
            }
            if (this.CASE2 != null && this.Parent == this.CASE2.Parent)
            {
                Pen p = new Pen(Color.Red, 1);
                p.CustomEndCap = lineArrow;
                CalculateLineStartEndPos(this, this.CASE2, ref DrawStartPos, ref DrawEndPos);
                g.DrawLine(p, DrawStartPos, DrawEndPos);
            }
            if (this.CASE3 != null && this.Parent == this.CASE3.Parent)
            {
                Pen p = new Pen(Color.Blue, 1);
                p.CustomEndCap = lineArrow;
                CalculateLineStartEndPos(this, this.CASE3, ref DrawStartPos, ref DrawEndPos);
                g.DrawLine(p, DrawStartPos, DrawEndPos);
            }
        }

        private class PPDistance
        {
            public Point P1;
            public Point P2;
            public double Distance;

            //計算兩點距離
            public void CalculatePPDistance()
            {
                Distance = Math.Sqrt(Math.Pow(P1.X - P2.X, 2) + Math.Pow(P1.Y - P2.Y, 2));
            }
        }

        private void CalculateLineStartEndPos(FlowChart fc1, FlowChart fc2, ref Point p1, ref Point p2)
        {
            List<PPDistance> PPData = new List<PPDistance>();
            #region 取出各元件四點位置
            Point FC1_p1 = new Point(fc1.Location.X + fc1.Width / 2, fc1.Location.Y);
            Point FC1_p2 = new Point(fc1.Location.X, fc1.Location.Y + fc1.Height / 2);
            Point FC1_p3 = new Point(fc1.Location.X + fc1.Width, fc1.Location.Y + fc1.Height / 2);
            Point FC1_p4 = new Point(fc1.Location.X + fc1.Width / 2, fc1.Location.Y + fc1.Height);
            Point FC2_p1 = new Point(fc2.Location.X + fc2.Width / 2, fc2.Location.Y);
            Point FC2_p2 = new Point(fc2.Location.X, fc2.Location.Y + fc2.Height / 2);
            Point FC2_p3 = new Point(fc2.Location.X + fc2.Width, fc2.Location.Y + fc2.Height / 2);
            Point FC2_p4 = new Point(fc2.Location.X + fc2.Width / 2, fc2.Location.Y + fc2.Height);
            #endregion
            #region 添加比較點訊息
            PPDistance pp_Case1 = new PPDistance();
            pp_Case1.P1 = FC1_p1; pp_Case1.P2 = FC2_p1; pp_Case1.CalculatePPDistance(); PPData.Add(pp_Case1);
            PPDistance pp_Case2 = new PPDistance();
            pp_Case2.P1 = FC1_p1; pp_Case2.P2 = FC2_p2; pp_Case2.CalculatePPDistance(); PPData.Add(pp_Case2);
            PPDistance pp_Case3 = new PPDistance();
            pp_Case3.P1 = FC1_p1; pp_Case3.P2 = FC2_p3; pp_Case3.CalculatePPDistance(); PPData.Add(pp_Case3);
            PPDistance pp_Case4 = new PPDistance();
            pp_Case4.P1 = FC1_p1; pp_Case4.P2 = FC2_p4; pp_Case4.CalculatePPDistance(); PPData.Add(pp_Case4);
            PPDistance pp_Case5 = new PPDistance();
            pp_Case5.P1 = FC1_p2; pp_Case5.P2 = FC2_p1; pp_Case5.CalculatePPDistance(); PPData.Add(pp_Case5);
            PPDistance pp_Case6 = new PPDistance();
            pp_Case6.P1 = FC1_p2; pp_Case6.P2 = FC2_p2; pp_Case6.CalculatePPDistance(); PPData.Add(pp_Case6);
            PPDistance pp_Case7 = new PPDistance();
            pp_Case7.P1 = FC1_p2; pp_Case7.P2 = FC2_p3; pp_Case7.CalculatePPDistance(); PPData.Add(pp_Case7);
            PPDistance pp_Case8 = new PPDistance();
            pp_Case8.P1 = FC1_p2; pp_Case8.P2 = FC2_p4; pp_Case8.CalculatePPDistance(); PPData.Add(pp_Case8);
            PPDistance pp_Case9 = new PPDistance();
            pp_Case9.P1 = FC1_p3; pp_Case9.P2 = FC2_p1; pp_Case9.CalculatePPDistance(); PPData.Add(pp_Case9);
            PPDistance pp_Case10 = new PPDistance();
            pp_Case10.P1 = FC1_p3; pp_Case10.P2 = FC2_p2; pp_Case10.CalculatePPDistance(); PPData.Add(pp_Case10);
            PPDistance pp_Case11 = new PPDistance();
            pp_Case11.P1 = FC1_p3; pp_Case11.P2 = FC2_p3; pp_Case11.CalculatePPDistance(); PPData.Add(pp_Case11);
            PPDistance pp_Case12 = new PPDistance();
            pp_Case12.P1 = FC1_p3; pp_Case12.P2 = FC2_p4; pp_Case12.CalculatePPDistance(); PPData.Add(pp_Case12);
            PPDistance pp_Case13 = new PPDistance();
            pp_Case13.P1 = FC1_p4; pp_Case13.P2 = FC2_p1; pp_Case13.CalculatePPDistance(); PPData.Add(pp_Case13);
            PPDistance pp_Case14 = new PPDistance();
            pp_Case14.P1 = FC1_p4; pp_Case14.P2 = FC2_p2; pp_Case14.CalculatePPDistance(); PPData.Add(pp_Case14);
            PPDistance pp_Case15 = new PPDistance();
            pp_Case15.P1 = FC1_p4; pp_Case15.P2 = FC2_p3; pp_Case15.CalculatePPDistance(); PPData.Add(pp_Case15);
            PPDistance pp_Case16 = new PPDistance();
            pp_Case16.P1 = FC1_p4; pp_Case16.P2 = FC2_p4; pp_Case16.CalculatePPDistance(); PPData.Add(pp_Case16);
            #endregion
            PPData.Sort((x, y) => { return x.Distance.CompareTo(y.Distance); });
            p1 = PPData[0].P1;
            p2 = PPData[0].P2;
        }

        private void FlowChart_ParentChanged(object sender, EventArgs e)
        {
            if (this.Parent != null)
                this.Parent.Paint += new PaintEventHandler(FlowPaint);
        }
    }
}
