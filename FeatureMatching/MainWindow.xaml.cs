﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FeatureMatching
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Variables

        private Tracker tracker;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// intitialize objects and camera.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Initialize();
        }

        /// <summary>
        /// Flip horizontal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckboxFlipHorizontal_Click(object sender, RoutedEventArgs e)
        {
            tracker.InvertHorizontal = (bool)checkboxFlipHorizontal.IsChecked;
        }

        /// <summary>
        /// Flip vertical.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckboxFlipVertical_Click(object sender, RoutedEventArgs e)
        {
            tracker.InvertVertical = (bool)checkboxFlipVertical.IsChecked;
        }

        /// <summary>
        /// Apply grayscale.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckboxGrayScale_Click(object sender, RoutedEventArgs e)
        {
            tracker.IsGrayScale = (bool)checkboxGrayScale.IsChecked;
        }

        /// <summary>
        /// Apply falt-and-pepper noise.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckboxNoise_Click(object sender, RoutedEventArgs e)
        {
            tracker.IsNoise = (bool)checkboxNoise.IsChecked;
        }

        /// <summary>
        /// Apply GoodMatching.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckboxGoodMatching_Click(object sender, RoutedEventArgs e)
        {
            tracker.IsGoodMatching = (bool)checkboxGoodMaching.IsChecked;
        }

        /// <summary>
        /// Apply Homography.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckboxHomography_Click(object sender, RoutedEventArgs e)
        {
            tracker.IsHomography = (bool)checkboxHomography.IsChecked;
        }

        /// <summary>
        /// Change stereo mode/type to image.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButtonImage_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Change stereo mode/type to camera.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButtonCamera_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Change feature extractor to Sift.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButtonSift_Click(object sender, RoutedEventArgs e)
        {
            tracker.FeatureExtractor = Tracker.FeatureType.Sift;
        }

        /// <summary>
        /// Change feature extractor to Surf.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButtonSurf_Click(object sender, RoutedEventArgs e)
        {
            tracker.FeatureExtractor = Tracker.FeatureType.Surf;
        }

        /// <summary>
        /// Change feature matcher to BruteForce.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButtonBruteForce_Click(object sender, RoutedEventArgs e)
        {
            tracker.FeatureMatcher = Tracker.MatcherType.BruteForce;
        }

        /// <summary>
        /// Change feature matcher to FlannedBased.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButtonFlannedBased_Click(object sender, RoutedEventArgs e)
        {
            tracker.FeatureMatcher = Tracker.MatcherType.FlannBased;
        }

        /// <summary>
        /// Change the value of the Brightness.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SliderBrightness_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (tracker != null)
            {
                tracker.Brightness = (int)sliderBrightness.Value;
            }
        }

        /// <summary>
        /// Change the value of GuassianSmoothing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SliderGuassianSmooth_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (tracker != null)
            {
                tracker.GaussianSmooth = (int)sliderGuassianSmooth.Value;
            }
        }

        /// <summary>
        /// Change value of GoodMatchingThreshold.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SliderGoodMatchingThreshold_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (tracker != null)
            {
                tracker.GoodMatchingThreshold = sliderGoodMatchingThreshold.Value;
            }
        }

        /// <summary>
        /// Button snapshot is clicked.
        /// </summary>
        private void ButtonSnapShot_Click(object sender, RoutedEventArgs e)
        {
            tracker.TakeSnapshot();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// intitialize objects and camera.
        /// </summary>
        private void Initialize()
        {
            tracker = new Tracker(labelFrameCounter);
            tracker.StartProcessing();
            sliderBrightness.Value = tracker.DefaultBrightness;
        }

        #endregion
    }
}
