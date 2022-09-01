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

namespace storyGraphs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //whether the mouse is being dragged
        bool mouseDragging;

        Brush StandardBrush;
        Random r = new Random();

        //for incrementing the ID we give in the dictionary
        //int nextRectangleId = 0;




        //dictionary for storing all the rectangles, so they can be called and deleted later on
        Dictionary<Rectangle,Node> rectanglesOnCanvas = new Dictionary<Rectangle,Node>();
        Dictionary<Line, Edge> linesOnCanvas = new Dictionary<Line, Edge>();

        


        /*
        LinkedList<Node> nodesOnCanvas = new LinkedList<Node>();
        LinkedList<Edge> edgesOnCanvas = new LinkedList<Edge>();
        */






        //WPF EVENTS

        //when the user clicks with the RIGHT mousebutton on the Graph/Node canvas
        private void MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            
                // If we're clicking on a rectangle
                if (e.OriginalSource is Rectangle)
                {
                    //deleting the rectangle
                    Rectangle activeRec = (Rectangle)e.OriginalSource;
                    NodesEdgesCanvas.Children.Remove(activeRec); // find the rectangle and remove it from the canvas
                    rectanglesOnCanvas.Remove(activeRec);
                    


                }

                // If we clicked on the canvas 
                else
                {
                    
                    StandardBrush = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255),
                    (byte)r.Next(1, 255), (byte)r.Next(1, 233)));

                    //creating new rectangle
                    Rectangle newRec = new Rectangle
                    {
                        Width = 50,
                        Height = 50,
                        StrokeThickness = 3,
                        Fill = StandardBrush,
                        Stroke = Brushes.Black
                    };

                    rectanglesOnCanvas.Add(newRec,new Node());
                    

                    //getting mouse x and y for rectangle placement
                    Canvas.SetLeft(newRec, Mouse.GetPosition(NodesEdgesCanvas).X); // set the left position of rectangle to mouse X
                    Canvas.SetTop(newRec, Mouse.GetPosition(NodesEdgesCanvas).Y); // set the top position of rectangle to mouse Y

                    NodesEdgesCanvas.Children.Add(newRec); // add the new rectangle to the canvas


            }

        }

        //when the user clicks with the LEFT mousebutton on the GRAPHNode canvas
        private void MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            // If we're clicking on a rectangle
            if (e.OriginalSource is Rectangle)
            {
                //deleting the rectangle
                Rectangle activeRec = (Rectangle)e.OriginalSource;
                mouseDragging = true;
                activeRec.CaptureMouse();


            }


        }

        //when the user clicks with the LEFT mousebutton on the GRAPHNode canvas
        private void MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // If we're clicking on a rectangle
            if (e.OriginalSource is Rectangle)
            {
                //deleting the rectangle
                Rectangle activeRec = (Rectangle)e.OriginalSource;
                mouseDragging = false;
                activeRec.ReleaseMouseCapture();


            }

        }

        //when the users mouse moves
        private void MouseMove(object sender, MouseEventArgs e)
        {
            //if we're moving a rectangle
            if (e.OriginalSource is Rectangle)
            {
               
                //if the mouse has a rectangle in its grasp
                if (!mouseDragging) return;
                {
                    Rectangle activeRec = (Rectangle)e.OriginalSource;

                    // get the position of the mouse relative to the Canvas
                    var mousePos = e.GetPosition(NodesEdgesCanvas);

                    // put the rectangle on the mouse
                    double left = mousePos.X - (activeRec.ActualWidth / 2);
                    double top = mousePos.Y - (activeRec.ActualHeight / 2);
                    Canvas.SetLeft(activeRec, left);
                    Canvas.SetTop(activeRec, top);

                }
            }
        }


    }

    public class Node
    {
        int nodeDegree;
        


    }

    public class Edge
    {
        int edgeDegree;
    }


}
