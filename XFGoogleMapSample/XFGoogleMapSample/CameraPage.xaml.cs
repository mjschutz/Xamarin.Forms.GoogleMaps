﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace XFGoogleMapSample
{
    public partial class CameraPage : ContentPage
    {
        public CameraPage()
        {
            InitializeComponent();

            var pinMelbourne = new Pin() { Label = "Melbourne", Position = new Position(-37.971237, 144.492697) };
            var pinNewyork = new Pin() { Label = "New york", Position = new Position(40.705311, -74.2581874) };
            var pinLisboa = new Pin() { Label = "Lisboa", Position = new Position(38.7436057, -13.6426275) };
            var pinParis = new Pin() { Label = "Paris", Position = new Position(48.8588377, 2.2775173) };
            var pinTokyo = new Pin() { Label = "Tokyo", Position = new Position(35.7104, 139.8093) };
            map.Pins.Add(pinMelbourne);
            map.Pins.Add(pinNewyork);
            map.Pins.Add(pinLisboa);
            map.Pins.Add(pinParis);
            map.Pins.Add(pinTokyo);

            map.CameraChanged += (sender, e) => 
            {
                var p = e.Position;
                labelStatus.Text = $"Lat={p.Target.Latitude:0.00}, Long={p.Target.Longitude:0.00}, Zoom={p.Zoom:0.00}, Bearing={p.Bearing:0.00}, Tilt={p.Tilt:0.00}";
            };

            // MoveToCamera with Position
            buttonMoveToPosition.Clicked += async (sender, e) =>
            {
                await map.MoveCamera(CameraUpdateFactory.NewPosition(
                    pinMelbourne.Position)); // Melbourne
            };

            // MoveToCamera with Position and Zoom
            buttonMoveToPositionZoom.Clicked += async (sender, e) =>
            {
                await map.MoveCamera(CameraUpdateFactory.NewPositionZoom(
                    pinNewyork.Position, 16d)); // New york
            };

            // MoveToCamera with Bounds
            buttonMoveToBounds.Clicked += async (sender, e) =>
            {
                await map.MoveCamera(CameraUpdateFactory.NewBounds(
                    new Bounds(pinLisboa.Position,  // Lisboa
                               pinParis.Position),  // Paris
                   50)); // 50px
            };

            // MoveToCamera with Bounds
            buttonMoveToCameraPosition.Clicked += async (sender, e) =>
            {
                await map.MoveCamera(CameraUpdateFactory.NewCameraPosition(
                    new CameraPosition(
                        pinTokyo.Position, // Tokyo
                        45d, // bearing(rotation)
                        60d, // tilt
                        17d)));
            };

            // AnimateToCamera with Position
            buttonAnimateToPosition.Clicked += async (sender, e) =>
            {
                var animState = await map.AnimateCamera(CameraUpdateFactory.NewPosition(
                    pinMelbourne.Position)); // Melbourne
                Debug.WriteLine($"Animate result = {animState}");
            };

            // MoveToCamera with Position and Zoom
            buttonAnimateToPositionZoom.Clicked += async (sender, e) =>
            {
                var animState = await map.AnimateCamera(CameraUpdateFactory.NewPositionZoom(
                    pinNewyork.Position, 16d)); // New york
                Debug.WriteLine($"Animate result = {animState}");
            };

            // MoveToCamera with Bounds
            buttonAnimateToBounds.Clicked += async (sender, e) =>
            {
                var animState = await map.AnimateCamera(CameraUpdateFactory.NewBounds(
                    new Bounds(pinLisboa.Position,  // Lisboa
                               pinParis.Position),  // Paris
                   50)); // 50px
                Debug.WriteLine($"Animate result = {animState}");
            };

            // MoveToCamera with Bounds
            buttonAnimateToCameraPosition.Clicked += async (sender, e) =>
            {
                var animState = await map.AnimateCamera(CameraUpdateFactory.NewCameraPosition(
                    new CameraPosition(
                        pinTokyo.Position, // Tokyo
                        45d, // bearing(rotation)
                        60d, // tilt
                        17d)));
                Debug.WriteLine($"Animate result = {animState}");
            };
        }
    }
}
