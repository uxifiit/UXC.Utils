using UXI.GazeToolkit;

namespace UXC.Utils.CorrectGazeDataPositions
{
    public class Hexahedron
    {
        public Hexahedron(
            Point3 vertex000, Point3 vertex100, Point3 vertex110, Point3 vertex010, 
            Point3 vertex001, Point3 vertex101, Point3 vertex111, Point3 vertex011
        )
        {
            Vertex000 = vertex000;
            Vertex100 = vertex100;
            Vertex110 = vertex110;
            Vertex010 = vertex010;
            Vertex001 = vertex001;
            Vertex101 = vertex101;
            Vertex111 = vertex111;
            Vertex011 = vertex011;
        }


        public Hexahedron(Point3[][][] vertices) 
            : this
              (
                  vertices[0][0][0], vertices[1][0][0], vertices[1][1][0], vertices[0][1][0], 
                  vertices[0][0][1], vertices[1][0][1], vertices[1][1][1], vertices[0][1][1]
              )
        {
        }

        public Point3 Vertex000 { get; }
        public Point3 Vertex100 { get; }
        public Point3 Vertex110 { get; }
        public Point3 Vertex010 { get; }
        public Point3 Vertex001 { get; }
        public Point3 Vertex101 { get; }
        public Point3 Vertex111 { get; }
        public Point3 Vertex011 { get; }
    }
}

