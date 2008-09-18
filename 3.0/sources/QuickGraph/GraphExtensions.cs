﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickGraph
{
    public static class GraphExtensions
    {
        public static BidirectionalGraph<TVertex, TEdge> ToBidirectionalGraph<TVertex, TEdge>(
            this IEnumerable<TEdge> edges,
            bool allowParallelEdges
            )
            where TEdge : IEdge<TVertex>
        {
            if (edges == null)
                throw new ArgumentNullException("edges");

            var g = new BidirectionalGraph<TVertex, TEdge>(allowParallelEdges);
            foreach (var edge in edges)
                g.AddVerticesAndEdge(edge);

            return g;
        }

        public static BidirectionalGraph<TVertex, TEdge> ToBidirectionalGraph<TVertex, TEdge>(
            this IEnumerable<TEdge> edges
            )
            where TEdge : IEdge<TVertex>
        {
            return ToBidirectionalGraph<TVertex, TEdge>(edges, true);
        }

        public static AdjacencyGraph<TVertex, TEdge> ToAdjacencyGraph<TVertex, TEdge>(
            this IEnumerable<TEdge> edges,
            bool allowParallelEdges
            )
            where TEdge : IEdge<TVertex>
        {
            if (edges == null)
                throw new ArgumentNullException("edges");

            var g = new AdjacencyGraph<TVertex, TEdge>(allowParallelEdges);
            foreach (var edge in edges)
                g.AddVerticesAndEdge(edge);

            return g;
        }

        public static AdjacencyGraph<TVertex, TEdge> ToAdjacencyGraph<TVertex, TEdge>(
            this IEnumerable<TEdge> edges
            )
            where TEdge : IEdge<TVertex>
        {
            return ToAdjacencyGraph<TVertex, TEdge>(edges, true);
        }

        public static AdjacencyGraph<TVertex, TEdge> ToAdjacencyGraph<TVertex, TEdge>(
            this IEnumerable<TVertex> vertices,
            Func<TVertex, IEnumerable<TEdge>> outEdgesFactory,
            bool allowParallelEdges
            )
            where TEdge : IEdge<TVertex>
        {
            if (vertices == null)
                throw new ArgumentNullException("vertices");
            if (outEdgesFactory == null)
                throw new ArgumentNullException("outEdgesFactory");

            var g = new AdjacencyGraph<TVertex, TEdge>(allowParallelEdges);
            g.AddVertexRange(vertices);
            foreach (var vertex in g.Vertices)
                g.AddEdgeRange(outEdgesFactory(vertex));

            return g;
        }

        public static AdjacencyGraph<TVertex, TEdge> ToAdjacencyGraph<TVertex, TEdge>(
            this IEnumerable<TVertex> vertices,
            Func<TVertex, IEnumerable<TEdge>> outEdgesFactory
            )
            where TEdge : IEdge<TVertex>
        {
            return ToAdjacencyGraph(vertices, outEdgesFactory, true);
        }

        public static BidirectionalGraph<TVertex, TEdge> ToBidirectionalGraph<TVertex, TEdge>(
            this IEnumerable<TVertex> vertices,
            Func<TVertex, IEnumerable<TEdge>> outEdgesFactory,
            bool allowParallelEdges
            ) 
            where TEdge : IEdge<TVertex>
        {
            if(vertices == null)
                throw new ArgumentNullException("vertices");
            if(outEdgesFactory == null)
                throw new ArgumentNullException("outEdgesFactory");

            var g = new BidirectionalGraph<TVertex, TEdge>(allowParallelEdges);
            g.AddVertexRange(vertices);
            foreach (var vertex in g.Vertices)
                g.AddEdgeRange(outEdgesFactory(vertex));

            return g;
        }

        public static BidirectionalGraph<TVertex, TEdge> ToBidirectionalGraph<TVertex, TEdge>(
            this IEnumerable<TVertex> vertices,
            Func<TVertex, IEnumerable<TEdge>> outEdgesFactory
            )
            where TEdge : IEdge<TVertex>
        {
            return ToBidirectionalGraph(vertices, outEdgesFactory, true);
        }
    }
}
