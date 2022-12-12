﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backEnd
{
    public class BackEndCanvas
    {

        int nextID;

        List<MyEdge> canvasEdges;
        List<MyNode> canvasNodes;
        
        public BackEndCanvas()
        {
            nextID = 0;
        }

        public void addNode(MyNode node)
        {
            canvasNodes.Add(node);
        }

        public void addEdge(MyEdge edge)
        {
            canvasEdges.Add(edge);
        }

        public void deleteNode(MyNode node)
        {
            canvasNodes.Remove(node);
        }

        public void deleteEdge(MyEdge edge)
        {
            edge.deleteSelfFromNodes();
            canvasEdges.Remove(edge);
        }

        public void incrementID()
        {
            nextID++;
        }
    }
}
