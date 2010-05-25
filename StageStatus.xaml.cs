﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace Soylent
{
    /// <summary>
    /// Interaction logic for StageStatus.xaml
    /// </summary>
    public partial class StageStatus : UserControl
    {
        private int totalTurkers;
        private double totalCost;

        public StageStatus(int stageNum, string stageType, int totalTurkers, double totalCost)
        {
            InitializeComponent();

            this.totalTurkers = totalTurkers;
            this.totalCost = totalCost;

            stageName.Content = String.Format("Stage {0}: {1:c}", stageNum, stageType);

            updateProgress(0, 0);
        }

        public void updateProgress(int curTurkers, double curCost)
        {
            numTurkers.Content = curTurkers + " of " + totalTurkers + " workers";
            cost.Content = String.Format("{0:c}", curCost);

            double percentDone = ((double)curTurkers) / totalTurkers;
            Duration duration = new Duration(TimeSpan.FromSeconds(1));
            DoubleAnimation doubleanimation = new DoubleAnimation(100 * percentDone, duration);
            hitProgress.BeginAnimation(ProgressBar.ValueProperty, doubleanimation);
        }

    }
}