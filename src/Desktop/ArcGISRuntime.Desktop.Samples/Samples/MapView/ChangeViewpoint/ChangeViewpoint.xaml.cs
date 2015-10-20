﻿//Copyright 2015 Esri.
//
//Licensed under the Apache License, Version 2.0 (the "License");
//you may not use this file except in compliance with the License.
//You may obtain a copy of the License at
//
//http://www.apache.org/licenses/LICENSE-2.0
//
//Unless required by applicable law or agreed to in writing, software
//distributed under the License is distributed on an "AS IS" BASIS,
//WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//See the License for the specific language governing permissions and
//limitations under the License.

using Esri.ArcGISRuntime.Geometry;
using System.Collections.Generic;
using System.Windows;

namespace ArcGISRuntime.Desktop.Samples.ChangeViewpoint
{
    public partial class ChangeViewpoint
    {    
        static MapPoint LondonCoords = new MapPoint(-13881.7678417696, 6710726.57374296, SpatialReference.Create(102100));
        static double LondonScale = 8762.7156655228955;
        static Polygon EdinburghEnvelope = new Polygon(new List<MapPoint> {
            (new MapPoint(-13049785.1566222, 4032064.6003424)),
            (new MapPoint(-13049785.1566222, 4040202.42595729)),
            (new MapPoint(-13037033.5780234, 4032064.6003424)),
            (new MapPoint(-13037033.5780234, 4040202.42595729))},
            SpatialReference.Create(102100));
        static Polygon RedlandsEnvelope = new Polygon(new List<MapPoint> {
            (new MapPoint(-354262.156621384, 7548092.94093301)),
            (new MapPoint(-354262.156621384, 7548901.50684376)),
            (new MapPoint(-353039.164455303, 7548092.94093301)),
            (new MapPoint(-353039.164455303, 7548901.50684376))},
            SpatialReference.Create(102100));

        public ChangeViewpoint()
        {
            InitializeComponent(); 
        }

        private void Animate_Button_Click(object sender, RoutedEventArgs e)
        {
            var viewpoint = new Esri.ArcGISRuntime.Viewpoint(EdinburghEnvelope);
            //Animates the changing of the viewpoints givng a smooth trasistion from old to new view
            MyMapView.SetViewpointAsync(viewpoint, System.TimeSpan.FromSeconds(5));
        }

        private void Geomtry_Button_Click(object sender, RoutedEventArgs e)
        {
            //Sets the viewpoint extent to the proviede bounding geometry   
            MyMapView.SetViewpointGeometryAsync(RedlandsEnvelope);
        }

        private void Centre_Scale_Button_Click(object sender, RoutedEventArgs e)
        {
            //Centers the viewpoint on the provided map point 
            MyMapView.SetViewpointCenterAsync(LondonCoords);
            //Sets the viewpoint's zoom scale to the provided double value  
            MyMapView.SetViewpointScaleAsync(LondonScale);
        }

        private async void Rotate_Button_Click(object sender, RoutedEventArgs e)
        {
            var currentRotation = MyMapView.Rotation;
            //Rotates the viewpoint by the given number of degrees 
            await MyMapView.SetViewpointRotationAsync(currentRotation + 90.00);
        }
    }
}